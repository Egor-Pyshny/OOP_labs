using OOP;

namespace DynamicModule.garden
{
    public class AppleGarden : IGarden
    {
        public food CreateFood(int price, int mass, string arg1, int arg2)
        {
            return new Apple("healthyfood", "Apple", mass, price, arg1, arg2);
        }
    }
}
