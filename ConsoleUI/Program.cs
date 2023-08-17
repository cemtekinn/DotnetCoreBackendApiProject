using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();

            //CategoryTest();

            //SubCategoryTest();

            // UserTest();

            //CustomerTest();
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var item in customerManager.GetAll())
            {
                Console.WriteLine($"Kullanıcı Adı:{item.CustomerName+" "+item.CustomerLastname}\nKullanıcı Mail:{item.CustomerEmail}");
            }
        }

        private static void UserTest()
        {
            //UserManager user = new UserManager(new EfUserDal());
            //foreach (var item in user.GetAll())
            //{
            //    Console.WriteLine("Kullanıcı Adı: "+item.UserName+"\nKullanıcı Şifre: "+item.UserPassword);
            //}

          
            
        }

        

        

      

    }
}
