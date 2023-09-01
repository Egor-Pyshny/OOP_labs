using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OOP
{
    
    public class burger : fastfood
    {
        [XmlElement]
        public int mass { get; set; }
        [XmlElement]
        public int price { get; set; }
        [XmlElement]
        public string size { get; set; }
        [XmlElement]
        public int cutletamount { get; set; }
        public burger(string str1, string str2, int p = 0, int m = 0, string s = "M", int ca = 1) : base(str1, str2)
        {
            this.mass = m;
            this.price = p;
            this.size = s;
            this.cutletamount = ca;
        }
        public burger() : base("fastfood", "unknown")
        {
            this.price = 0;
            this.mass = 0;
            this.size = "-";
            this.cutletamount = 0;
        }
        public override void display_info()
        {
            base.display_info();
            Console.WriteLine("Price: " + price.ToString() + "\n" + "Mass: "+ mass.ToString() + "\n" + "Size: "+size + "\n" + "Coutlet amount: "+ cutletamount.ToString());
        }
    }
}
