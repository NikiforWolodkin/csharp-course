using _2DPoint;

_2DPoint.Path path = new _2DPoint.Path(new Point(4, 3), new Point(8, 3), new Point(6, 3));

Point point = new Point(7, -5);

path.Add(point);
Console.WriteLine(path.Points.Count);

path.Delete(point);
Console.WriteLine(path.Points.Count);

path.Clear();
Console.WriteLine(path.Points.Count);

_2DPoint.Path path2 = new _2DPoint.Path(new Point(4, 3), new Point(8, 3), new Point(6, 3), point);

Console.WriteLine(path == path);
Console.WriteLine(path == path2);

(int, int, int, int) points = path2.CountPoints();
Console.WriteLine($"{points.Item1}, {points.Item2}, {points.Item3}, {points.Item4}");

try
{
    path.Delete(point);
}
catch (DeleteException ex)
{
    Console.WriteLine(ex.Message);
}

Publisher publisher = new Publisher();
path2.Subscribe(publisher);

foreach (var pt in path2.Points)
{
    Console.WriteLine($"{pt.X}, {pt.Y}");
}
publisher.RaiseChange();
foreach (var pt in path2.Points)
{
    Console.WriteLine($"{pt.X}, {pt.Y}");
}

Type type = path.GetType();

foreach (var constructor in type.GetConstructors())
{
    Console.WriteLine(constructor);
}
foreach (var field in type.GetFields())
{
    Console.WriteLine(field);
}
foreach (var property in type.GetProperties())
{
    Console.WriteLine(property);
}