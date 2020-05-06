using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Happy_Hunting
{
    class Flanders
    {
        public Point Position { get; set; }
        public int Donuts { get; set; }
        private ElementsOfMap lastElement { get; set; }
        public List<Point> Path;

        public Flanders(Point point, GameLevel level)
        {
            Position = point;
            lastElement = ElementsOfMap.Empty;
            Path = FindPath(level);
            level.Gomer.GomerMove += (p) => Move(level);
            level.Gomer.GomerGrabeDount += (p) => Path = FindPath(level);
        }

        public void Move(GameLevel level)
        {
            if (Path.Count == 0) Path = FindPath(level);
            var newPosition = Path[0];
            if (level.InMap(newPosition) && !level.СellBusy(newPosition))
            {
                level.SetElement(Position, lastElement);
                lastElement = ElementsOfMap.Empty;
                if (level[newPosition] == ElementsOfMap.Donut)
                    GrabeDonut(level);
                level.SetElement(newPosition, ElementsOfMap.Flanders); 
                Position = newPosition;
                Path.RemoveAt(0);
                if (level.Donuts.Count == 0) level.FinishGame();
            }
        }

        private void GrabeDonut(GameLevel level)
        {
            Donuts++;
            lastElement = ElementsOfMap.Bible;
        }

        public List<Point> FindPath(GameLevel level)
        {
            var start = Position;
            var donutsSet = level.Donuts.ToHashSet();
            var visited = new HashSet<Point>();
            var queue = new Queue<PathElement>();
            queue.Enqueue(new PathElement(start, null));
            while (queue.Count != 0)
            {
                var point = queue.Dequeue();
                if (visited.Contains(point.Point)) continue;
                visited.Add(point.Point);
                if (donutsSet.Contains(point.Point))
                    return point.Select(x => x).Reverse().Skip(1).ToList();
                for (var dx = -1; dx <= 1; dx++)
                    for (var dy = -1; dy <= 1; dy++)
                    {
                        if (!level.InMap(new Point(point.Point.X + dx, point.Point.Y + dy))) continue;
                        if (level[new Point(point.Point.X + dx, point.Point.Y + dy)] == ElementsOfMap.Wall) continue;
                        if ((dx == 0 && dy == 0) || (dx != 0 && dy != 0)) continue;
                        queue.Enqueue(new PathElement(new Point(point.Point.X + dx, point.Point.Y + dy), point));
                    }
            }
            return new List<Point>();
        }
    }

    class PathElement : IEnumerable<Point>
    {
        public Point Point { get; set; }
        private PathElement previousPoint;

        public PathElement(Point point, PathElement pathElement)
        {
            this.Point = point;
            previousPoint = pathElement;
        }

        public IEnumerator<Point> GetEnumerator()
        {
            yield return Point;
            var pathItem = previousPoint;
            while (pathItem != null)
            {
                yield return pathItem.Point;
                pathItem = pathItem.previousPoint;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
