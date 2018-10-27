using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleXml {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("XML");
            CreateXmlFile();
        }

        public static void CreateXmlFile() {
            //create list of users
            var listUsers = new List<User>() {
                new User{ Name="John Rambo",Age=25,Company="Holywood"},
                new User{ Name="John Smith",Age=35,Company="LuterCorp"},
                new User{ Name="Jenifer Lopez",Age=22,Company="Muzic"},
            };
            XmlSerializer serialiser = new XmlSerializer(typeof(List<User>));
            TextWriter Filestream = new StreamWriter(@"D:\Users.xml");
            serialiser.Serialize(Filestream, listUsers);
            Filestream.Close();
            
        }
    }
}
