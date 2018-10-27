using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleXml {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("XML");
            CreateXmlFile();
            ReadXML();
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
        public static void ReadXML() {
            var xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string str = null;
            FileStream fs = new FileStream(@"D:\Users.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("User");
            for (i = 0; i <= xmlnode.Count - 1; i++) {
                xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                str = xmlnode[i].ChildNodes.Item(0).InnerText.Trim() + "  " + xmlnode[i].ChildNodes.Item(1).InnerText.Trim() + "  " + xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
                Console.WriteLine(str);
            }
            fs.Close();
            Console.WriteLine("\n End of file");
            Console.ReadKey();
        }

        public static void RegexSample() {
            Regex regex = new Regex(@"\d+");
            Match match = regex.Match("Dot 25 Step");
            if (match.Success) {
                Console.WriteLine(match.Value);
            }
        }
        public static void RegexSample1() {
            // First we see the input string.
            string input = "/content/alternate-1.aspx";

            // Here we call Regex.Match.
            Match match = Regex.Match(input, @"content/([A-Za-z0-9\-]+)\.aspx$",
                RegexOptions.IgnoreCase);

            // Here we check the Match instance.
            if (match.Success) {
                // Finally, we get the Group value and display it.
                string key = match.Groups[1].Value;
                Console.WriteLine(key);
            }
        }

        public static void RegexNextMatch() {
            string value = "4 AND 5 or 7";

            // Get first match.
            Match match = Regex.Match(value, @"\d");
            if (match.Success) {
                Console.WriteLine(match.Value);
            }

            // Get second match.
            match = match.NextMatch();
            if (match.Success) {
                Console.WriteLine(match.Value);
            }
        }

        public static void RegexSample2() {
            Match m = Regex.Match("123 Axxxxy", @"A.*y");
            if (m.Success) {
                Console.WriteLine("Value  = " + m.Value);
                Console.WriteLine("Length = " + m.Length);
                Console.WriteLine("Index  = " + m.Index);
            }
        }
    }
}
