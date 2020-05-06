using System;
using System.Drawing;

namespace Happy_Hunting
{
    class Gomer
    {
        public Point Position { get; set; }
        public int Donuts { get; set; }

        public Gomer(Point point) => Position = point;

        public void Move(GameLevel level, Direction direction)
        {
            var newPosition = direction.CreateNewPosition(Position);
            if (level.InMap(newPosition) && !level.СellBusy(newPosition))
            {
                level.SetElement(Position, ElementsOfMap.Empty);
                if (level[newPosition] == ElementsOfMap.Donut) GrabeDonut(level, newPosition);
                else if (level[newPosition] == ElementsOfMap.Bible)
                {
                    Donuts--;
                    level.SetElement(newPosition, ElementsOfMap.Gomer);
                }
                else level.SetElement(newPosition, ElementsOfMap.Gomer);
                Position = newPosition;
                GomerMove(Position);
            }
            else return;
            if (Donuts < 0) level.FinishGame();
        }

        public void GrabeDonut(GameLevel level, Point point)
        {
            Donuts++;
            level.SetElement(point, ElementsOfMap.Gomer);
            if (level.Donuts.Count == 0)
            {
                level.FinishGame();
                return;
            }
            GomerGrabeDount(Position);
        }

        public event Action<Point> GomerMove;
        public event Action<Point> GomerGrabeDount;
    }
}
