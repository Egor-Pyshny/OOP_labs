﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.prom_zona
{
    class Dominos : IFactory
    {
        public food CreateFood(int price, int mass, string arg1, int arg2)
        {
            return new pizza("fastfood", "pizza", mass, price, arg1, arg2);
        }
    }
}
