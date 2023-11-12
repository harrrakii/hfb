namespace MyApp;

    public class ConsoleController
    {
        private List<List<char>> text;

        public ConsoleController(string text)
        {
            this.text = text.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToCharArray().ToList())
                .ToList();
        }

        public void PrintInfo()
        {
            Console.Clear();
            foreach (var line in text)
            {
                Console.WriteLine(string.Join("", line));
            }
        }

        public Triangle GetTriangle()
        {
            return TriangleParser.ParseTriangleFromString(string.Join("\n", text.Select(x => string.Join("", x))));
        }

        public void UpdateInfo((int left, int top) cursorPosition, ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                text[cursorPosition.top].RemoveAt(cursorPosition.left);
            }
            else if (char.IsDigit(keyInfo.KeyChar))
            {
                if (cursorPosition.left >= text[cursorPosition.top].Count)
                {
                    text[cursorPosition.top].Add(keyInfo.KeyChar);
                }
                else
                {
                    text[cursorPosition.top].Insert(cursorPosition.left, keyInfo.KeyChar);
                }
            }

            Console.Clear();
            foreach (var line in text)
            {
                Console.WriteLine(string.Join("", line));
            }

            Console.SetCursorPosition(cursorPosition.left - (char.IsDigit(keyInfo.KeyChar) ? 0 : 1),
                cursorPosition.top);
        }
    }
