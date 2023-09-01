using OOP;
using System;

namespace DynamicModule.garden
{
    public class MainGarden
    {
        private food newfood;
        private IGarden garden;
        private IGarden GetGarden(string ind)
        {
            switch (ind.ToLower())
            {
                case "apple" or "1": return new AppleGarden();
                default: throw new Exception("Type error");
            }
        }

        public food Produce(string index, int price, int mass, string arg1, int arg2)
        {
            garden = GetGarden(index);
            newfood = garden.CreateFood(price, mass, arg1, arg2);
            return newfood;
        }

    }
}
