using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OOP
{
    [Serializable]
    public class hotdog : fastfood
    {
        [XmlElement]
        public int mass { get; set; }
        [XmlElement]
        public int price { get; set; }
        [XmlElement]
        public string size { get; set; }
        [XmlElement]
        public int sausagescount { get; set; }
        public hotdog(string str1, string str2, int p = 0, int m = 0, string s = "M", int sc = 0) : base(str1, str2)
        {
            this.mass = m;
            this.price = p;
            this.size = s;
            this.sausagescount = sc;
        }
        public hotdog() : base("fastfood", "unknown")
        {
            this.price = 0;
            this.mass = 0;
            this.size = "-";
            this.sausagescount = 0;
        }
        public override void display_info()
        {
            base.display_info();
            Console.WriteLine("Price: " + price.ToString() + "\n" + "Mass: " + mass.ToString() + "\n" + "Size: "+size + "\n"+"Sausages: "+sausagescount.ToString());
        }
    }
}
