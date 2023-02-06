using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Exam
{
    public interface Figure
    {
        void Print();
    }

    public class Rectangle : Figure
    {
        [JsonIgnore] public ushort X { get; set; }
        [JsonIgnore] public ushort Y { get; set; }
        public ushort Width { get; set; }
        public ushort Height { get; set; }
        public string Color { get; set; }

        public Rectangle(ushort x, ushort y, ushort width, ushort height, string color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Color = color;
        }

        public Rectangle(ushort x, ushort y, string color) : this(x, y, 1, 1, color) { }

        public Rectangle() : this(1, 1, 1, 1, "") { }

        private void ResetColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void SetColor()
        {
            switch (Color)
            {
                case "Red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "Blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        public void Print()
        {
            SetColor();

            for (int i = 0; i < Height + Y; i++)
            {
                if (i < Y)
                {
                    Console.WriteLine();
                    continue;
                }

                for (int j = 0; j < Width + X; j++)
                {
                    if (j < X)
                    {
                        Console.Write("  ");
                        continue;
                    }

                    Console.Write("X");
                }

                Console.WriteLine();
            }

            ResetColor();
        }

        public int GetSurfaceArea()
        {
            return Width * Height;
        }

        public static Rectangle operator + (Rectangle rectangle, int amount)
        {
            rectangle.Width += Convert.ToUInt16(amount);
            rectangle.Height += Convert.ToUInt16(amount);
            return rectangle;
        }

        public override string ToString()
        {
            return $"{X}, {Y}, {Width}, {Height}, {Color}";
        }
    }
}
