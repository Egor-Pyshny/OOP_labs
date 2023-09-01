using System;
using System.Collections.Generic;
using System.IO;

namespace OOP._de_serialization
{

    public class serialize
    {
        private string path = "1.json";
        private food Food = Methods.f;
        public void json_serialize(string s) {
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(fileStream);
            List<food> list = Food.FoodList;
            foreach (food element in list)
            {
                Type type = element.GetType();
                string jsonString = System.Text.Json.JsonSerializer.Serialize(Convert.ChangeType(element, type));
                writer.WriteLine(jsonString);
            }
            writer.Flush();
            writer.Close();
            fileStream.Close();
        }
    }
}
