using System;
using System.Collections.Generic;
using System.Linq;
using IdentityManagerAPIWrapper.Model;
using IdentityManagerAPIWrapper.Model.Roles;
using IdentityManagerAPIWrapper.Model.Users;
using IdentityManagerAPIWrapper.Services.Roles;
using IdentityManagerAPIWrapper.Services.Users;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            UserTest();
            RoleTest();

        }

        public static void RoleTest()
        {
            // Get Roless
            var service = RoleService.GetService("http://localhost:13414/admin");
            var obj = service.GetAll().Result;



            //Create Role
            int random = new Random().Next(100, 200);
            List<PropertyValue> properties = new List<PropertyValue>();
            properties.Add(new PropertyValue { Type = "name", Value = "role-" + random });
            CreateRoleResponse obj4 = null;
            try
            {
                obj4 = service.Create(properties.ToArray()).Result;
            }
            catch (AggregateException e)
            {
                foreach (var ex in e.InnerExceptions)
                {
                    Console.WriteLine(ex.Message);
                }

            }


            //Get Role
            if (obj4 != null)
            {
                var obj2 = service.Get(obj4.Data.Subject).Result;

                // Try getting user with wrong value throws error
                try
                {
                    var obj3 = service.Get("8442c53c-428a-4608-a0e7-d0ba040b2a85");
                }
                catch (AggregateException e)
                {
                    Console.WriteLine(e.Message);
                    foreach (var ex in e.InnerExceptions)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                
            }

            // Delete User
            try
            {
                if (obj4 != null)
                    service.Delete(obj4.Data.Subject);
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.Message);
                foreach (var ex in e.InnerExceptions)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void UserTest()
        {
            // Get Users
            var service = UserService.GetService("http://localhost:13414/admin");
            var obj = service.GetAll("admin").Result;



            //Create User
            int random = new Random().Next(100, 200);
            List<PropertyValue> properties = new List<PropertyValue>();
            properties.Add(new PropertyValue { Type = "username", Value = "hamza" + random });
            properties.Add(new PropertyValue { Type = "password", Value = "hamza10" });
            CreateUserResponse obj4 = null;
            try
            {
                obj4 = service.Create(properties.ToArray()).Result;
            }
            catch (AggregateException e)
            {
                foreach (var ex in e.InnerExceptions)
                {
                    Console.WriteLine(ex.Message);
                }

            }


            //Get User
            if (obj4 != null)
            {
                var obj2 = service.Get(obj4.Data.Subject).Result;

                // Try getting user with wrong value throws error
                try
                {
                    var obj3 = service.Get("8442c53c-428a-4608-a0e7-d0ba040b2a85");
                }
                catch (AggregateException e)
                {
                    Console.WriteLine(e.Message);
                    foreach (var ex in e.InnerExceptions)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }


                // User Set Property
                try
                {
                    const string propertyTypeName = "email";
                    var objProperties = obj2.Data.Properties;
                    var metaObj = objProperties.SingleOrDefault(w => w.Meta.Type == propertyTypeName);

                    if (metaObj != null)
                    {
                        var arrayPath = metaObj.Links.Update.Split('/');
                        string propertyTypId = arrayPath[arrayPath.Length - 1];
                        service.SetProperty(obj2.Data.Subject, propertyTypId, "hamzamayet@email.com");
                    }
                }
                catch (AggregateException e)
                {
                    Console.WriteLine(e.Message);
                    foreach (var ex in e.InnerExceptions)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }


            // Delete User
            try
            {
                if (obj4 != null)
                    service.Delete(obj4.Data.Subject);
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.Message);
                foreach (var ex in e.InnerExceptions)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
