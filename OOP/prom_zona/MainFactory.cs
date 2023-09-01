using System;

namespace OOP.prom_zona
{
    public class MainFactory
    {
        private food newfood;
        private IFactory factory;

        private IFactory GetFactory(string ind)
        {
            switch (ind.ToLower())
            {
                case "burger" or "1": return new McDonalds();
                case "sushi" or "2": return new SushiVesla();
                case "pizza" or "3": return new Dominos();
                case "hotdog" or "4": return new ButerBro();
                default: throw new Exception("Type error");
            }
        }

        public food Produce(string index, int price, int mass, string arg1, int arg2) { 
            factory = GetFactory(index);
            newfood = factory.CreateFood(price, mass, arg1, arg2);
            return newfood;
        }                     
    }
}
