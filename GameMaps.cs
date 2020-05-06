using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E = Happy_Hunting.ElementsOfMap;

namespace Happy_Hunting
{
    static class GameMaps
    {
        static public E[,] MapFirst = new E[,] {
            {E.Wall,   E.Wall,  E.Gomer, E.Wall,  E.Empty, E.Empty, E.Empty, E.Donut, E.Wall,  E.Donut },

            {E.Wall,   E.Wall,  E.Empty, E.Wall,  E.Empty, E.Wall,  E.Wall,  E.Wall,   E.Wall,  E.Empty },

            {E.Donut, E.Wall,  E.Empty, E.Empty, E.Empty, E.Wall,  E.Wall,  E.Wall,   E.Wall,  E.Empty },

            {E.Empty,  E.Wall,  E.Wall,  E.Wall,  E.Empty, E.Empty, E.Empty, E.Empty,  E.Empty, E.Empty },

            {E.Empty,  E.Wall,  E.Empty, E.Empty, E.Empty, E.Wall,  E.Wall,  E.Wall,   E.Wall,  E.Wall },

            {E.Empty,  E.Wall,  E.Wall,  E.Wall,  E.Empty, E.Empty, E.Empty, E.Empty,  E.Empty, E.Flanders },

            {E.Empty,  E.Empty, E.Empty, E.Empty, E.Empty, E.Wall,  E.Wall,  E.Wall,   E.Wall,  E.Wall }
        };

        static public E[,] MapSecond = new E[,] {
            /*1*/{E.Gomer, E.Empty, E.Empty, E.Empty, E.Empty, E.Empty, E.Donut, E.Empty, E.Empty, E.Empty },//+

            /*2*/{E.Empty, E.Wall,  E.Wall,  E.Wall,  E.Empty, E.Wall,  E.Wall,  E.Wall,  E.Wall,  E.Empty },//+

            /*3*/{E.Empty, E.Wall,  E.Empty, E.Empty, E.Empty, E.Empty, E.Wall,  E.Empty, E.Wall,  E.Empty },//+

            /*4*/{E.Empty, E.Wall,  E.Empty, E.Empty, E.Empty, E.Empty, E.Wall,  E.Empty, E.Empty, E.Empty },//+

            /*5*/{E.Empty, E.Donut, E.Wall,  E.Donut, E.Wall,  E.Wall,  E.Wall,  E.Empty, E.Wall,  E.Empty },//+

            /*6*/{E.Empty, E.Wall,  E.Empty, E.Empty, E.Empty, E.Empty, E.Wall,  E.Empty, E.Wall,  E.Empty },//+

            /*7*/{E.Empty, E.Wall,  E.Empty, E.Empty, E.Empty, E.Empty, E.Wall,  E.Empty, E.Wall,  E.Empty },//+

            /*8*/{E.Empty, E.Wall,  E.Empty, E.Donut, E.Empty, E.Empty, E.Empty, E.Empty, E.Wall,  E.Empty },//+

            /*9*/{E.Empty, E.Wall,  E.Wall,  E.Wall,  E.Wall,  E.Wall,  E.Wall,  E.Empty, E.Wall,  E.Empty },//+

           /*10*/{E.Donut, E.Empty, E.Empty, E.Empty, E.Empty, E.Empty, E.Empty, E.Donut, E.Wall,  E.Flanders }//+
        };
    }
}
