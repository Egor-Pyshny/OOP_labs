using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OOP
{
    [Serializable]
    public class pizza : fastfood
    {
        public string type { get; private set; }
        public string name { get; private set; }
        [XmlElement]
        public int mass { get; set; }
        [XmlElement]
        public int price { get; set; }
        [XmlElement]
        public string doughtype { get; set; }
        [XmlElement]
        public int diameter { get; set; }
        public pizza(string str1, string str2, int p = 0, int m = 0, string s = "classic", int ca = 1) : base(str1, str2)
        {
            this.type = str1;
            this.name = str2;
            this.mass = m;
            this.price = p;
            this.doughtype = s;
            this.diameter = ca;
        }
        public pizza() : base("fastfood", "unknown")
        {
            this.type = "fastfood";
            this.name = "unknown";
            this.price = 0;
            this.mass = 0;
            this.doughtype = "-";
            this.diameter = 0;
        }
        public override void display_info()
        {
            base.display_info();
            Console.WriteLine("Price: " + price.ToString() + "\n" + "Mass: " + mass.ToString() + "\n" +"Dough type: "+ doughtype + "\n" + "Diameter: "+diameter.ToString());
        }
    }
}
