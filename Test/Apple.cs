using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DynamicModule
{
    public class Apple : HealthyFood  
    {
        [XmlElement]
        public int mass { get; set; }
        [XmlElement]
        public int price { get; set; }
        [XmlElement]
        public string sort { get; set; }
        [XmlElement]
        public int amount { get; set; }
        public Apple(string str1, string str2, int p = 0, int m = 0, string s = "M", int ca = 1) : base(str1, str2)
        {
            this.mass = m;
            this.price = p;
            this.sort = s;
            this.amount = ca;
        }
        public Apple() : base("healthyfood", "Apple")
        {
            this.price = 0;
            this.mass = 0;
            this.sort = "-";
            this.amount = 0;
        }
        public override void display_info()
        {
            base.display_info();
            Console.WriteLine("Price: " + price.ToString() + "\n" + "Mass: " + mass.ToString() + "\n" + "sort: " + sort + "\n" + "Amount: " + amount.ToString());
        }
    }
}
