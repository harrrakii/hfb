namespace HotKeys2
{
    public enum MenuAction
    {
        None = 0,
        AddHotKey = -1,
        SaveHotKeys = -2,
        ToggleExecutionMode = -3,
        Back = -4,
        ModifyHotKey = -5,
        DeleteHotKey = -6
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            HotKeyManager hotKeyManager;
            var executionMode = false;
            var consoleDrawer = new ConsoleDrawer();

            Console.WriteLine("Введите путь до файла с горячими клавишами");
            var hotKeysPath = Console.ReadLine();
            if (File.Exists(hotKeysPath))
            {
                Console.WriteLine("Файл найден");
                hotKeyManager = new HotKeyManager(hotKeysPath);
            }
            else
            {
                Console.WriteLine("Файл не найден");
                hotKeyManager = new HotKeyManager();
            }

            while (true)
            {
                if (!executionMode)
                {
                    Console.Clear();
                    ConsoleDrawer.DrawTips();
                    var menuAction = consoleDrawer.DrawArrowMenu(hotKeyManager.HotKeys);

                    switch (menuAction)
                    {
                        case MenuAction.AddHotKey:
                            Console.Clear();
                            Console.WriteLine("Добавление новой горячей клавиши");
                            Console.WriteLine();

                            Console.WriteLine("Введите новую клавишу");
                            var key = ConsoleExtensions.ReadKey();

                            while (!hotKeyManager.CanAddKey(key))
                            {
                                Console.WriteLine("Такая клавиша уже добавлена");
                                Console.WriteLine("Введите новую клавишу");
                                key = ConsoleExtensions.ReadKey();
                            }

                            Console.WriteLine("Введите путь исполнения");
                            var processPath = Console.ReadLine();

                            hotKeyManager.AddNewHotKey(key, processPath);
                            break;
                        case MenuAction.SaveHotKeys:
                            Console.Clear();
                            Console.WriteLine("Сохранение горячих клавиш");
                            Console.WriteLine();

                            Console.WriteLine("Введите путь сохранения");
                            var savePath = Console.ReadLine();
                            hotKeyManager.SaveHotKeysToFile(savePath);
                            break;
                        case MenuAction.ToggleExecutionMode:
                            executionMode = true;
                            break;
                        case MenuAction.ModifyHotKey:
                            Console.Clear();
                            Console.WriteLine("Изменение горячей клавиши");
                            Console.WriteLine();

                            Console.WriteLine("Введите существующую клавишу");
                            var existingKey = ConsoleExtensions.ReadKey();

                            while (!hotKeyManager.HotKeys.ContainsKey(existingKey))
                            {
                                Console.WriteLine("Такой клавиши не существует");
                                Console.WriteLine("Введите существующую клавишу");
                                existingKey = ConsoleExtensions.ReadKey();
                            }

                            Console.WriteLine("Введите новую клавишу");
                            var newKey = ConsoleExtensions.ReadKey();

                            while (!hotKeyManager.CanAddKey(newKey))
                            {
                                Console.WriteLine("Такая клавиша уже добавлена");
                                Console.WriteLine("Введите новую клавишу");
                                newKey = ConsoleExtensions.ReadKey();
                            }

                            Console.WriteLine("Введите новый путь исполнения");
                            var newProcessPath = Console.ReadLine();

                            hotKeyManager.ModifyHotKey(existingKey, newKey, newProcessPath);
                            break;
                        case MenuAction.DeleteHotKey:
                            Console.Clear();
                            Console.WriteLine("Удаление горячей клавиши");
                            Console.WriteLine();

                            Console.WriteLine("Введите существующую клавишу");
                            var keyToDelete = ConsoleExtensions.ReadKey();

                            while (!hotKeyManager.HotKeys.ContainsKey(keyToDelete))
                            {
                                Console.WriteLine("Такой клавиши не существует");
                                Console.WriteLine("Введите существующую клавишу");
                                keyToDelete = ConsoleExtensions.ReadKey();
                            }

                            hotKeyManager.DeleteHotKey(keyToDelete);
                            break;
                        case MenuAction.Back:
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    ConsoleDrawer.DrawTips();
                    ConsoleDrawer.DrawHotKeys(hotKeyManager.HotKeys);

                    var keyPressed = ConsoleExtensions.ReadKey();

                    if (hotKeyManager.HotKeys.ContainsKey(keyPressed))
                    {
                        hotKeyManager.Execute(keyPressed);
                    }
                    else if (keyPressed == ConsoleKey.Escape)
                    {
                        executionMode = false;
                    }
                }
            }
        }
    }
}
    