using Buttons;

Button button = new Button("Button 1", 5, 5, 200, 400);
Console.WriteLine(button);

Console.WriteLine($"{button.Width}, {button.Height}");
button.Zoom(20);
Console.WriteLine($"{button.Width}, {button.Height}");

Button button2 = new Button("Button 2", 5, 5, 200, 300);
Console.WriteLine(button2.Equals(button));
Console.WriteLine(button2.Equals(button2));

User user = new User();
CheckButton checkButton = new CheckButton("Button 3", 5, 5, 200, 400);
CheckButton checkButton2 = new CheckButton("Button 4", 5, 5, 200, 300);

button.Subscribe(user);
button2.Subscribe(user);
checkButton.Subscribe(user);
checkButton2.Subscribe(user);

user.RaiseClick();
user.RaiseZoom(23);

LinkedList<Button> buttons = new LinkedList<Button>();
buttons.AddFirst(button);
buttons.AddFirst(button2);
buttons.AddFirst(checkButton);
buttons.AddFirst(checkButton2);

var buttonsWithSpecificArea = buttons.Where(btn => (btn.Width * btn.Height) < 49000);
foreach (var btn in buttonsWithSpecificArea)
{
    Console.WriteLine(btn.Width * btn.Height);
}

var checkButtons = buttons.Where(btn => btn is CheckButton);
foreach (var btn in checkButtons)
{
    Console.WriteLine(btn);
}