using Exam;
using System.Text.Json;

Exam.Rectangle rectangle = new Exam.Rectangle(2, 2, 8, 4, "Red");
rectangle.Print();
rectangle = rectangle + 2;
rectangle.Print();

Exam.Rectangle rectangle1 = new Exam.Rectangle(2, 2, 8, 4, "Red");
Exam.Rectangle rectangle2 = new Exam.Rectangle(8, 2, 2, 1, "Blue");
Exam.Rectangle rectangle3 = new Exam.Rectangle(1, 2, 3, 4, "Green");
Exam.Rectangle rectangle4 = new Exam.Rectangle(7, 2, 3, 5, "Wrong color");
Exam.Rectangle rectangle5 = new Exam.Rectangle(2, 5, 1, 2, "Red");
List<Rectangle> rectangles = new List<Rectangle>() { rectangle, rectangle1, rectangle2,
                                                     rectangle3, rectangle4, rectangle5
                                                   };

foreach (var rect in rectangles)
{
    rect.Print();
}

var orderedRectangles = rectangles.OrderBy(rect => rect.X);
orderedRectangles = rectangles.OrderBy(rect => rect.Y);
orderedRectangles = rectangles.OrderBy(rect => rect.GetSurfaceArea());
orderedRectangles.First().Print();
orderedRectangles.Last().Print();

var serializedRectangles = JsonSerializer.Serialize<List<Rectangle>>(rectangles);
Console.WriteLine(serializedRectangles);