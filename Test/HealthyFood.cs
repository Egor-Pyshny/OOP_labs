using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using OOP;

namespace DynamicModule
{
    [XmlInclude(typeof(Apple))]
    public class HealthyFood : food
    {
        public string name { get; set; }
        public HealthyFood(string str1 = "healthyfood", string str2 = "unknown") : base(str1)
        {
            name = str2;
        }
        public HealthyFood() { }

        public override void display_info()
        {
            base.display_info();
            Console.WriteLine("Name: " + name);
        }
    }
}
