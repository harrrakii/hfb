using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace days
{
    internal class Program
    {

        public static void writeEveryDay(string date, everyDay day)
        {
            Console.WriteLine(day.date);
            foreach(var note in day.dayNotes)
            {
                Console.WriteLine(note.name);
            }
        }

        public static void descriptionNote(int cursorPosition, everyDay day)
        {
            note[] dayNotes = day.dayNotes.ToArray();
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine(dayNotes[cursorPosition].name);
                Console.WriteLine(dayNotes[cursorPosition].desc);
                Console.WriteLine(dayNotes[cursorPosition].date);
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Enter);

        }

        static void Main(string[] args)
        {

            Dictionary<string, everyDay> days = new Dictionary<string, everyDay>();
            ConsoleKeyInfo key;
            int cursorPosition = 1;
            DateTime date = DateTime.Now;
            days[date.ToString()] = new everyDay(date.ToString(), new List<note>()
            {
                new note("  pervi", "description", date.ToString())
            });
            do
            {
                Console.Clear();
                List<string> dates = new List<string>();
                foreach(var day in days.Keys)
                {
                    dates.Add(day);
                }
                writeEveryDay(date.ToString(), days[date.ToString()]);
                Console.SetCursorPosition(0, cursorPosition);
                Console.WriteLine("->");
                key = Console.ReadKey();
                switch(key.Key) 
                {
                    case ConsoleKey.LeftArrow:
                        date = date.AddDays(-1);
                        if (!dates.Contains(date.ToString()))
                        {
                            days[date.ToString()] = new everyDay(date.ToString(), new List<note>()
                            {
                                new note("  fdsfsdfs", "aaaaaaaaa", date.ToString()),
                                new note("  psdfpfpspfps", "bbbbbbb", date.ToString()),
                                new note("  rihuwehiurwhuie", "cccccccccc", date.ToString())
                            });
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        date = date.AddDays(1);
                        if (!dates.Contains(date.ToString()))
                        {
                            days[date.ToString()] = new everyDay(date.ToString(), new List<note>()
                            {
                                new note("  orpweipriwpeor", "aaaaaaaaa", date.ToString()),
                                new note("  al;skd;laks;ld", "bbbbbbb", date.ToString()),
                                new note("  .z,xmc.,zxmc.,zm.", "cccccccccc", date.ToString())
                            });
                        }
                        break;
                    case ConsoleKey.Enter:
                        descriptionNote(cursorPosition - 1, days[date.ToString()]);
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursorPosition != days[date.ToString()].dayNotes.Count) cursorPosition++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (cursorPosition != 1) cursorPosition--;
                        break;
                }
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}
