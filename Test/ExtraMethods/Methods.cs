using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP;
using DynamicModule.garden;

namespace DynamicModule.ExtraMethods
{
    public class Methods
    {
        List<food> list = new List<food>();
        public MainGarden garden = new MainGarden();
        public void addfood(string index) {
            food f;
            string[] temp = new string[4];
            Console.WriteLine("Enter mass:");
            temp[0] = Console.ReadLine();
            Console.WriteLine("Enter price:");
            temp[1] = Console.ReadLine();
            Console.WriteLine("Enter arg1:");
            temp[2] = Console.ReadLine();
            Console.WriteLine("Enter arg2:");
            temp[3] = Console.ReadLine();
            list.Add(garden.Produce(index, System.Convert.ToInt32(temp[1]), System.Convert.ToInt32(temp[0]), temp[2], System.Convert.ToInt32(temp[3])));
        }

        public void showinterface()
        {
            Console.WriteLine("1.Add apple");
            Console.WriteLine("2.Exit");
        }

        public List<food> startpoint() {
            Dictionary<string, MyDelegate> dict = new Dictionary<string, MyDelegate>()
            {
                {"1", addfood},
            };
            list.Clear();
            string s;
            do
            {
                showinterface();
                s = Console.ReadLine();
                if (dict.ContainsKey(s)) { dict[s](s); } else if (s != "2") { Console.WriteLine("Incorrect index"); }

            } while (s != "2");
            return list;
        }
    }
}
