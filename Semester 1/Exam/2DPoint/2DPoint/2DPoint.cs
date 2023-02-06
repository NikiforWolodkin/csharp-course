using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPoint
{
    public class DeleteException : Exception
    {
        public Point Point;

        public DeleteException(Point point, string message) : base(message)
        {
            Point = point;
        }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Point point)
            {
                if (point.X == X && point.Y == Y)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class Path
    {
        public List<Point> Points { get; set; }

        public Path()
        {
            Points = new List<Point>();
        }

        public Path(params Point[] points)
        {
            Points = new List<Point>(points);
        }

        public void Add(Point point) => Points.Add(point);
        public void Clear() => Points.Clear();

        public void Delete(Point point)
        {
            if (!Points.Contains(point))
            {
                throw new DeleteException(point, "Point is not a part of the path");
            }

            Points.Remove(point);
        }

        public void Subscribe(Publisher publisher)
        {
            publisher.Change += handleChange;
        }

        public void handleChange(object sender, EventArgs e)
        {
            foreach (var point in Points)
            {
                point.X = -point.X;
                point.Y = -point.Y;
            }
        }

        public (int, int, int, int) CountPoints()
        {
            int pointsPerQuater = Points.Count / 4;

            switch (Points.Count % 4)
            {
                case 0:
                    return (pointsPerQuater, pointsPerQuater, pointsPerQuater, pointsPerQuater);
                    break;
                case 1:
                    return (pointsPerQuater + 1, pointsPerQuater, pointsPerQuater, pointsPerQuater);
                    break;
                case 2:
                    return (pointsPerQuater + 1, pointsPerQuater + 1, pointsPerQuater, pointsPerQuater);
                    break;
                case 3:
                    return (pointsPerQuater + 1, pointsPerQuater + 1, pointsPerQuater + 1, pointsPerQuater);
                    break;
                case 4:
                    return (pointsPerQuater + 1, pointsPerQuater + 1, pointsPerQuater + 1, pointsPerQuater + 1);
                    break;
                default:
                    throw new Exception("Couldn't count points;");
                    break;
            }
        }

        public static bool operator ==(Path path1, Path path2)
        {
            return path1.Points.SequenceEqual(path2.Points);
        }

        public static bool operator !=(Path path1, Path path2)
        {
            return !path1.Points.SequenceEqual(path2.Points);
        }
    }
}
