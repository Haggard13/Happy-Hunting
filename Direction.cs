using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy_Hunting
{
    enum Direction
    {
        Right,
        Up,
        Left,
        Down
    }

    static class DirectionMethods
    {
        static public Point CreateNewPosition(this Direction direction, Point Position)
        {
            switch (direction)
            {
                case Direction.Right:
                    return new Point(Position.X + 1, Position.Y);
                case Direction.Up:
                    return new Point(Position.X, Position.Y - 1);
                case Direction.Left:
                    return new Point(Position.X - 1, Position.Y);
                case Direction.Down:
                    return new Point(Position.X, Position.Y + 1);
            }
            throw new ArgumentException();
        }
    }
}
