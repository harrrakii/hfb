using System.Diagnostics;
using Timer = System.Timers.Timer;

namespace Explorer;

public class TextingSymbols
{
    private string text;
    private int printedSymbols;
    private Stopwatch stopwatch;
    private Timer timer;
    private bool isAlive;
    
    public TextingSymbols(string text)
    {
        this.text = text;
        stopwatch = new Stopwatch();
        printedSymbols = 0;
        timer = new Timer {Interval = 1000};
        isAlive = false;
    }

    public void StartTexting()
    {
        Console.Write("Введите свое имя: ");
        string name = Console.ReadLine();
        
        isAlive = true;
        timer.Elapsed += (_, _) => { UpdateConsole(); };
        timer.Start();
        stopwatch.Start();
        
        while (isAlive)
        {
            var key = Console.ReadKey();
            UpdateConsole();

            if (!isAlive)
            {
                break;
            }

            if (key.KeyChar == text[printedSymbols])
            {
                printedSymbols++;
                UpdateConsole();
            }
        }

        timer.Dispose();
        var charactersPerMinute = printedSymbols;
        var charactersPerSecond = printedSymbols/60;

        User user = new User { Name = name, CharactersPerMinute = charactersPerMinute, CharactersPerSecond = charactersPerSecond };
        RecordsTable.AddRecord(user);
    }

    private void UpdateConsole()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(text.Substring(0, printedSymbols));
        Console.ResetColor();
        Console.Write(text.Substring(printedSymbols));

        Console.WriteLine();
        

        if (stopwatch.Elapsed > TimeSpan.FromSeconds(20))
        {
            isAlive = false;
            stopwatch.Stop();
            timer.Close();
            Console.WriteLine("STOP!");
            Console.WriteLine("Press any key to go to leaderboard...");
        }
        else
        {
            Console.WriteLine("{0:mm':'ss}", stopwatch.Elapsed);
        }
    }
}