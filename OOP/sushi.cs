using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OOP
{
    [Serializable]
    public class sushi : fastfood
    {
        [XmlElement]
        public int mass { get; set; }
        [XmlElement]
        public int price { get; set; }
        [XmlElement]
        public string fishtype { get; set; }
        [XmlElement]
        public int amount { get; set; }

        public sushi(string str1, string str2, int p = 0, int m = 0, string s = "salmon",int am=0) : base(str1, str2)
        {
            this.mass = m;
            this.price = p;
            this.fishtype = s;
            this.amount = amount;
        }
        public sushi() : base("fastfood", "unknown")
        {
            this.price = 0;
            this.mass = 0;
            this.fishtype = "-";
            this.amount = 0;
        }
        public override void display_info()
        {
            base.display_info();
            Console.WriteLine("Price: " + price.ToString() + "\n" + "Mass: " + mass.ToString() + "\n" + "Fish type: "+fishtype + "\n" +"Amount: "+amount.ToString());
        }
    }
}
