using System;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace OOP._de_serialization
{
    public class deserialize
    {
        Assembly assembly = Assembly.LoadFrom("C:\\Users\\user\\source\\repos\\OOP\\Test\\bin\\Debug\\net5.0\\DynamicModule.dll");
        private string path = "1.json";
        private food Food = Methods.f;
        public void json_deserialize(string s) {
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fileStream);
            string jsonstring;
            int i = Food.Amount;
            while ((jsonstring = reader.ReadLine())!=null) {
                string findtype="";
                string[] arr = jsonstring.Split(',');
                foreach (string str in arr) {
                    if (str.StartsWith("\"name\"")) { 
                        findtype = str.Split(':')[1].Replace("\"", "");
                        break;
                    }
                }
                Type mytype = Type.GetType("OOP." + findtype);
                if (mytype==null) {
                    mytype = assembly.GetType("DynamicModule." + findtype);
                }
                object res = JsonConvert.DeserializeObject(jsonstring, mytype);
                Food[i] = (food)res;
                i++;
            }
            reader.Close();
            fileStream.Close();
        }
    }
}
