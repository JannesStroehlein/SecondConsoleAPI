# SecondConsoleAPI
Allows you to open a second console window from a C# Application.

## Examples
Opening a window and writing to it:
```C#
Console.WriteLine("Hello, Console 1!");
SecondConsole second = new SecondConsole("Console 2", 1000, 550, 12); //Title: Console 2, Width: 1000, Height: 550, FontSize: 12
second.Open();
second.WriteLine("Hello, Console 2!");
Console.ReadKey(); //Just to make the main thread busy
second.Close();
Application.Exit();
```
Colored Output:
```C#
SecondConsole second = new SecondConsole("Console 2", 1000, 550, 12); //Title: Console 2, Width: 1000, Height: 550, FontSize: 12
//Method 1:
second.WriteColor(SecondConsoleColors.Yellow ,"This shouldn't be green. ");
second.WriteLineColor(SecondConsoleColors.Green ,"Or is it?");

//Method 2:
second.WriteLineFormatted("%2This is supposed to be %4green%2!"); //Using the identifier '%' for color codes
```

## Color Codes
Color Code | Color
------------ | -------------
0 | Black
1 | DarkBlue
2 | DarkGreen
3 | DarkCyan
4 | DarkRed
5 | DarkMagenta
6 | Yellow
7 | Gray
8 | DarkGray
9 | Blue
A | Green
B | Cyan
C | Red
D | Magenta
E | LightGoldenrodYellow
F | White
