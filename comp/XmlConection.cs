using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;


namespace comp
{
    public class XmlConection
    {   
        string route_xml = $"{Environment.CurrentDirectory}/ext/db.xml";

        string[] list_elements_xml = {"id", "name", "pass", "money", "active"}; 

        XmlDocument xml_doc = new XmlDocument();


        public void readInfo(string condition = "", params dynamic[] obj)
        {   
            xml_doc.Load(route_xml);
            
            XmlNodeList list_xml = xml_doc.SelectNodes("Users/Person");

            foreach (XmlNode item in list_xml)
            {
                foreach (string str_element in obj)
                {
                    XmlNode general_single_node = item.SelectSingleNode(str_element);

                    if (condition != "")
                    {
                        if (item.FirstChild.InnerText == condition)
                        {
                            Console.WriteLine(general_single_node.InnerText); 
                        }
                    }
                    else
                    {
                        Console.WriteLine(general_single_node.InnerText); 
                    }
                }
            }
            
        }

        public List<string> verifyInfo(string condition_id = "", string filter = "", params dynamic[] obj)
        {
            xml_doc.Load(route_xml);
            
            List<string> element_string = new List<string>();

            XmlNodeList list_xml = xml_doc.SelectNodes("Users/Person");

            foreach (XmlNode item in list_xml)
            {
                foreach (string str_element in obj)
                {
                    XmlNode general_single_node = item.SelectSingleNode(str_element);

                    if (condition_id != "")
                    {
                        if (item.FirstChild.InnerText == condition_id)
                        {
                            element_string.Add(general_single_node.InnerText); 
                        }
                    }
                    else
                    {
                        
                        if (str_element == filter)
                        {
                            element_string.Add(general_single_node.InnerText);
                        }
                        
                    }
                
                }
            }

            return element_string;
        }

        public void deleteInfo(params dynamic[] obj)
        {
            xml_doc.Load(route_xml);

            XmlNode docElement = xml_doc.DocumentElement;

            XmlNodeList list_xml = xml_doc.SelectNodes("Users/Person");

            foreach (XmlNode item in list_xml)
            {
                if (item.SelectSingleNode("id").InnerText == obj[0])
                {
                    docElement.RemoveChild(item);
                }
            }

            xml_doc.Save(route_xml);
        }

        public void updateInfo(string condition = "", params dynamic[] obj)
        {
            xml_doc.Load(route_xml);

            XmlNode docElement = xml_doc.DocumentElement;
            XmlNode docNewElement = createElement(obj);

            XmlNodeList list_xml = xml_doc.SelectNodes("Users/Person");

            foreach (XmlNode item in list_xml)
            {
                if (item.SelectSingleNode("id").InnerText == condition)
                {
                    docElement.ReplaceChild(docNewElement, item);
                }
            }

            xml_doc.Save(route_xml);
        }

        public void createInfo(params dynamic[] obj)
        {
            xml_doc.Load(route_xml);

            XmlNode docNewElement = createElement(obj);

            XmlNode docElement = xml_doc.DocumentElement;

            docElement.InsertAfter(docNewElement, docElement.LastChild);

            xml_doc.Save(route_xml);
        }

        private XmlNode createElement(params dynamic[] obj)
        {
            int counter = 0;

            XmlNode docNewElement = xml_doc.CreateElement("Person");

            XmlNodeList list_xml = xml_doc.SelectNodes("Users/Person");

            
            foreach (string item in list_elements_xml)
            {
                try
                {
                    XmlElement element = xml_doc.CreateElement(item);
                    element.InnerText = obj[counter];
                    docNewElement.AppendChild(element);
                }
                catch
                {
                    Console.WriteLine("Faltan parametros");
                }
                
                counter++;
            }

            return docNewElement;
        }

        private int countXmlNodes()
        {
            int counter = 0;

            xml_doc.Load(route_xml);

            XmlNodeList list_xml = xml_doc.SelectNodes("Users/Person");

            foreach (var item in list_xml)
            {
                counter++;
            }

            return counter;
        }

        public int generateId()
        {   
            return countXmlNodes() + 1; 
        }
    }
}