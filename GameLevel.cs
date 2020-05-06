using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Happy_Hunting
{
    class GameLevel
    {
        public int Width { get => Map.GetLength(0);}
        public int Height { get => Map.GetLength(1); }

        public ElementsOfMap[,] Map { get; set; }
        public HashSet<Point> Donuts { get; private set; }

        public Gomer Gomer { get; private set; }
        public Flanders Flanders { get; private set; }

        public GameLevel(ElementsOfMap[,] map)
        {
            Map = new ElementsOfMap[map.GetLength(0), map.GetLength(1)];
            for (var i = 0; i < map.GetLength(0); i++)
                for (var j = 0; j < map.GetLength(1); j++)
                    Map[i, j] = map[i, j];
            Donuts = new HashSet<Point>();
            FindGomerAndDonuts();
            FindFlanders();
        }

        public bool InMap(Point point) => point.X < Width && point.X >= 0 && point.Y < Height && point.Y >= 0;
        public bool СellBusy(Point point) => this[point] == ElementsOfMap.Wall || this[point] == ElementsOfMap.Flanders || this[point] == ElementsOfMap.Gomer;

        public void FinishGame()
        {
            var score = new int[] { Gomer.Donuts, Flanders.Donuts};
            var maxScore = score.Max();
            for (var i = 0; i < score.Length; i++)
                if (score[i] == maxScore) GameFinish((Character)i);
        }

        public void SetElement(Point point, ElementsOfMap element)
        {
            if (this[point] == ElementsOfMap.Donut)
            {
                Donuts.Remove(point);
                this[point] = element;
            }
            else this[point] = element;
        }

        public ElementsOfMap this[Point point]
        {
            get => Map[point.X, point.Y];
            set => Map[point.X, point.Y] = value;
        }

        public void FindGomerAndDonuts()
        {
            for (var x = 0; x < Width; x++)
                for (var y = 0; y < Height; y++)
                    switch (Map[x, y])
                    {
                        case ElementsOfMap.Gomer:
                            Gomer = new Gomer(new Point(x, y));
                            break;
                        case ElementsOfMap.Donut:
                            Donuts.Add(new Point(x, y));
                            break;
                    }
        }

        public void FindFlanders()
        {
            for (var x = 0; x < Width; x++)
                for (var y = 0; y < Height; y++)
                    if (Map[x, y] == ElementsOfMap.Flanders)
                            Flanders = new Flanders(new Point(x, y), this);
        }

        public event Action<Character> GameFinish;
    }
}