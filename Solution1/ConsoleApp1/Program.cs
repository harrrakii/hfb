using System;
using System.Text;

namespace MyApp 
{
    internal class Program
    {
       private static Dictionary<ConsoleKey, (int left, int top)> arrows =
        new Dictionary<ConsoleKey, (int left, int top)>()
        {
            { ConsoleKey.UpArrow, (-1, -1) },
            { ConsoleKey.DownArrow, (-1, 1) },
            { ConsoleKey.RightArrow , (0, 0) },
            { ConsoleKey.LeftArrow , (-2, 0) }
        };

        public static void Main()
        {
            var path = Console.ReadLine();
            var extension = path.Substring(path.LastIndexOf('.') + 1);
            var triangle = ReadTriangleFromFile(path, extension);
            var consoleText = triangle.ToString(extension);
            
            var consoleController = new ConsoleController(consoleText);
            consoleController.PrintInfo();

            while (true)
            {
                var pressedKey = Console.ReadKey();
                if (arrows.ContainsKey(pressedKey.Key))
                {
                    var position = Console.GetCursorPosition();
                    consoleController.PrintInfo();
                    Console.SetCursorPosition(position.Left + arrows[pressedKey.Key].left, position.Top + arrows[pressedKey.Key].top);
                    continue;
                }
                consoleController.UpdateInfo(Console.GetCursorPosition(), pressedKey);
                if (pressedKey.Key == ConsoleKey.F1)
                {
                    var newTriangle = consoleController.GetTriangle().ToString(extension);
                    using var writer = new StreamWriter(path);
                    writer.Write(newTriangle);
                }
                if (pressedKey.Key == ConsoleKey.Escape)
                {
                    return;
                }
            }
        }

        private static Triangle ReadTriangleFromFile(string path, string extension)
        {
            if (extension == FileExtensions.Txt)
            {
                return TriangleParser.ParseTriangleTxt(path);
            }

            if (extension == FileExtensions.Json)
            {
                return TriangleParser.ParseTriangleJson(path);
            }

            if (extension == FileExtensions.Xml)
            {
                return TriangleParser.ParseTriangleXml(path);
            }

            throw new Exception("Неизвестное расширение файла!");
        }
    }
}