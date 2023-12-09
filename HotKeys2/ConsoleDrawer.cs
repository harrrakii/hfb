namespace HotKeys2;

public class ConsoleDrawer
    {
        private int arrowPosition = 0;

        public static void DrawTips()
        {
            Console.WriteLine("Менеджер горячих клавиш");
            Console.WriteLine("F1 - добавить");
            Console.WriteLine("F9 - сохранить");
            Console.WriteLine("F10 - режим выполнения");
            Console.WriteLine("F2 - удалить");
            Console.WriteLine("F3 - изменить");
            Console.WriteLine("Backspace - выйти из режима выполнения");
            Console.WriteLine("----------------------------");
            Console.WriteLine();
        }

        public MenuAction DrawArrowMenu(Dictionary<ConsoleKey, HotKey> hotKeys)
        {
            var keys = hotKeys.Keys.ToArray();
            for (var i = 0; i < keys.Length; i++)
            {
                Console.Write(i == arrowPosition ? "=>" : "  ");
                Console.WriteLine($"{hotKeys[keys[i]].Key} - {hotKeys[keys[i]].ProcessPath}");
            }

            var keyPressed = ConsoleExtensions.ReadKey();

            ChangeArrowPosition(keyPressed, hotKeys);

            switch (keyPressed)
            {
                case ConsoleKey.F1:
                    return MenuAction.AddHotKey;
                case ConsoleKey.F9:
                    return MenuAction.SaveHotKeys;
                case ConsoleKey.F10:
                    return MenuAction.ToggleExecutionMode;
                case ConsoleKey.F2:
                    return MenuAction.DeleteHotKey;
                case ConsoleKey.F3:
                    return MenuAction.ModifyHotKey;
                case ConsoleKey.Backspace:
                    return MenuAction.Back;
                default:
                    return MenuAction.None;
            }
        }

        public static void DrawHotKeys(Dictionary<ConsoleKey, HotKey> hotKeys)
        {
            foreach (var hotKey in hotKeys)
            {
                Console.WriteLine($"  {hotKey.Key} - {hotKey.Value.ProcessPath}");
            }
        }

        public void ChangeArrowPosition(ConsoleKey key, Dictionary<ConsoleKey, HotKey> hotKeys)
        {
            if (key == ConsoleKey.UpArrow)
            {
                arrowPosition--;
                if (arrowPosition < 0)
                {
                    arrowPosition = 0;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                arrowPosition++;
                if (arrowPosition >= hotKeys.Count)
                {
                    arrowPosition = hotKeys.Count - 1;
                }
            }
        }
    }