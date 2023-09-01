using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OOP
{
    [XmlInclude(typeof(burger))]
    [XmlInclude(typeof(pizza))]
    [XmlInclude(typeof(sushi))]
    [XmlInclude(typeof(hotdog))]
    public class fastfood : food
    {
        [XmlElement]
        public string name { get; set; }
        public fastfood(string str1 = "fastfood", string str2 = "unknown") : base(str1) {
            name = str2;
        }
        public fastfood() { 
            
        }

        public override void display_info() {
            base.display_info();           
            Console.WriteLine("Name: "+name);
        }
    }
}
