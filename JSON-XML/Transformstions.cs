using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using OOP;
using DynamicModule;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using OOP;

namespace JSON_XML
{
    class Transformstions
    {
        public static void TransformJSONtoXML() {
            XmlSerializer serializer = new XmlSerializer(typeof(food));
            XmlSerializer serializer2 = new XmlSerializer(typeof(HealthyFood));
            Assembly assembly = Assembly.LoadFrom("C:\\Users\\user\\source\\repos\\OOP\\Test\\bin\\Debug\\net5.0\\DynamicModule.dll");
            Assembly assembly2 = Assembly.LoadFrom("C:\\Users\\user\\source\\repos\\OOP\\OOP\\bin\\Debug\\net5.0\\OOP.dll");
            string path = "1.json";
            List<food> list = new List<food>();
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fileStream);
            string jsonstring;
            int i = 0;
            while ((jsonstring = reader.ReadLine()) != null)
            {
                string findtype = "";
                string[] arr = jsonstring.Split(',');
                foreach (string str in arr)
                {
                    if (str.StartsWith("\"name\""))
                    {
                        findtype = str.Split(':')[1].Replace("\"", "");
                        break;
                    }
                }
                Type mytype = assembly2.GetType("OOP."+findtype);
                if (mytype == null)
                {
                    mytype = assembly.GetType("DynamicModule." + findtype);
                }
                object res = JsonConvert.DeserializeObject(jsonstring, mytype);

                list.Add((food)res);
                i++;
            }
            FileStream fileStream1 = new FileStream("1.xml", FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(fileStream1);
            foreach (food item in list) {
                if (item.type == "healthyfood")
                {
                    serializer2.Serialize(writer, item);
                }
                else {
                    serializer.Serialize(writer, item);
                }
            }

            writer.Flush();
            writer.Close();
            reader.Close();
            fileStream.Close();
        }
    }
}
