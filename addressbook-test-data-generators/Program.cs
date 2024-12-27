// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using WebAddressbookTests;


namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args) 
        {
            int count= Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter( args[1] );

            for (int i = 0; i < count; i++) 
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                     TestBase.GenerateRandomString(10),
                     TestBase.GenerateRandomString(15),
                     TestBase.GenerateRandomString(15)
                       ));
                
            }
           
        }
    }

}










