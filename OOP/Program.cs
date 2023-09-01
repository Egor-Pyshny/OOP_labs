using System;
using System.Collections.Generic;
using OOP._de_serialization;

namespace OOP
{
    public delegate void MyDelegate(string ind);
    
    class Program
    {
        static void Main(string[] args)
        {
            Methods methods = new Methods();
            serialize serialize = new serialize();
            deserialize deserialize = new deserialize();
            Dictionary<string, MyDelegate> dict = new Dictionary<string, MyDelegate>()
            {
                {"1", methods.addfood},
                {"2", methods.addfood},
                {"3", methods.addfood},
                {"4", methods.addfood},
                {"5", methods.showlist},
                {"6", methods.RemoveFromList},
                {"7", methods.edit },
                {"8", serialize.json_serialize },
                {"9", deserialize.json_deserialize },
                {"10", methods.showExtra },
                {"11",  methods.JSONtoXML },
                {"12" , methods.encrypt },
                {"13",methods.decpypt },
            };
            string s;          
            do
            {
                methods.showinterface();
                s = Console.ReadLine();
                if (dict.ContainsKey(s)) { dict[s](s); } else if(s!="14") { Console.WriteLine("Incorrect index"); }

            } while (s != "Exit" && s!="14");
            
        }
    }
}
