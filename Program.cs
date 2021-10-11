using System;
using System.Xml;
using Newtonsoft.Json;

namespace XMLEditing
{
    class Program
    {
        static void Main(string[] args)
        {
            TestingFile();
            //RemoveEvent();
            SettingsAndProperties();
            ConvertToJson();
            Console.ReadLine();
        }
        //Adding New Properties
        static void TestingFile()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\Aventra_task\conf - examples.xml");
            XmlNode root = doc.SelectSingleNode("ActiveCMSMonitor");
            XmlElement monitorEvent = doc.CreateElement("MonitorEvent");
            root.AppendChild(monitorEvent);

            XmlAttribute xsiType = doc.CreateAttribute("GreatThis");
            xsiType.Value = "DatabaseAction";
            monitorEvent.Attributes.Append(xsiType);

            XmlElement createFolder = doc.CreateElement("PassFail");
            monitorEvent.AppendChild(createFolder);
            doc.Save(@"D:\Aventra_task\conf - examples.xml");

            Console.WriteLine(doc.InnerXml);
        }
       
         //Deleting the Target Node
        static void RemoveEvent()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\Aventra_task\conf - examples.xml");
            XmlNode root = doc.SelectSingleNode("ActiveCMSMonitor");
            var tgtNode = doc.SelectSingleNode("ActiveCMSMonitor/MonitorEvent[@Name='Card Xml Export']");
            root.RemoveChild(tgtNode);
            doc.Save(@"D:\Aventra_task\conf - examples.xml");
        }

        //Setting New properties 
        static void SettingsAndProperties()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\Aventra_task\conf - examples.xml");
            XmlNode root = doc.SelectSingleNode("ActiveCMSMonitor/MonitorEvent");
            
            //var tgtNode = doc.SelectSingleNode("ActiveCMSMonitor/MonitorEvent[@Name='Card Xml Export']");
            XmlElement eventProperties = doc.CreateElement("Properties");
            root.AppendChild(eventProperties);

            /*XmlAttribute xsiType = doc.CreateAttribute($"xsi:type");
            xsiType.Value = "FileImportAction";
            monitorEvent.Attributes.Append(xsiType);

            XmlElement createFolder = doc.CreateElement("Pass");
            monitorEvent.AppendChild(createFolder);*/
            doc.Save(@"D:\Aventra_task\conf - examples.xml");

            Console.WriteLine(doc.InnerXml);
        }

        //Serializng to Json

        static void ConvertToJson()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\Aventra_task\conf - examples.xml");
            string jsonText = JsonConvert.SerializeXmlNode(doc);
            Console.WriteLine(jsonText);

        }
    }
}
