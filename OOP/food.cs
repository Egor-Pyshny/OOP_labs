using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Serialization;

namespace OOP
{
    [XmlInclude(typeof(fastfood))]
    public class food
    {
        private int amount = 0;
        internal int Amount { get { return amount; } private set { amount = value; } }
        public string type { get ; set; }
        private List<food> foodlist = new List<food>();
        internal List<food> FoodList { get { return foodlist; }}
        public food this[int index]
        {
            get {
                if (index < foodlist.Count)
                {
                    return foodlist[index];
                }
                else {
                    return null;
                }
            }
            set {
                if (index < foodlist.Count)
                {
                    foodlist[index] = value;
                }
                else if (index < foodlist.Count+1)
                {
                    foodlist.Add(value);
                    amount++;
                } else throw new Exception("Index out of bounds");
            }
        }

        public void DeleteFromList(int index) {
            if (index < foodlist.Count)
            {
                foodlist.RemoveAt(index);
                amount--;
            }
            else
            {
                throw new Exception("Index out of bounds");
            }
        }

        public food() {
            this.type = "unknown type";
        }
        public food(string str1 = "unknown type") {
            this.type = str1;
        }
        public virtual void display_info() {
            Console.WriteLine("Type: "+type);
        }
    }
}
