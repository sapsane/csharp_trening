﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.Xml;
using System.Xml.Serialization;

namespace addressbook_test_data_generators2
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args[0] == "groups")
            {

                int count = Convert.ToInt32(args[1]);
                StreamWriter writer = new StreamWriter(args[2]);
                string format = args[3];

                List<GroupData> groups = new List<GroupData>();


                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)

                    });


                }
                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized Format=" + format);
                }
                writer.Close();
            }



            if (args[0] == "contacts")
            {

                int count = Convert.ToInt32(args[1]);
                StreamWriter writer = new StreamWriter(args[2]);
                string format = args[3];

                List<ContactData> contacts = new List<ContactData>();


                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                    );


                }

                if (format == "xml")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized Format=" + format);
                }
                writer.Close();


            }
        }
        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
                foreach (GroupData group in groups)
                {
                    writer.WriteLine(String.Format("${0},${1},${2}",
                        group.Name, group.Header, group.Footer));
                }

        }
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
                new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
                new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

            
    }
}

