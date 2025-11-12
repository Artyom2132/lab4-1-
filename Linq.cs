using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab4_1_
{
    internal class Linq
    {
        public static List<T> GetElementsInL1NotInL2<T>(List<T> L1, List<T> L2)
        {
            return L1.Except(L2).ToList();
        }

        public static bool IsSymmetricSegment<T>(LinkedList<T> list, int i, int j)
        {
            var segment = list.Skip(i).Take(j - i + 1).ToList();
            return segment.SequenceEqual(segment.AsEnumerable().Reverse());
        }

        public static void AnalyzeSweetLikers(List<HashSet<string>> alllikers, HashSet<string> allchocolate)
        {
            HashSet<string> allLike = new HashSet<string>(allchocolate);
            HashSet<string> someLike = new HashSet<string>();
            HashSet<string> noneLike = new HashSet<string>(allchocolate);

            foreach (var liked in alllikers)
            {
                allLike.IntersectWith(liked);
                someLike.UnionWith(liked);
            }

            noneLike.ExceptWith(someLike);

            Console.WriteLine("Нравится всем: " + string.Join(", ", allLike));
            Console.WriteLine("Нравится некоторым: " + string.Join(", ", someLike));
            Console.WriteLine("Нравится никому: " + string.Join(", ", noneLike));
        }

        public static int CountMissingLetters(string filepath)
        {
            string text = File.ReadAllText(filepath).ToLower();
            var russianLetters = Enumerable.Range('а', 32).Select(c => (char)c);
            var presentLetters = new HashSet<char>(text.Where(char.IsLetter));

            return russianLetters.Count(letter => !presentLetters.Contains(letter));
        }

        public static List<string> GetPassengersToFreeIn2Hours(string[] inputData)
        {
            DateTime currentTime = ParseTime(inputData[0]);
            int passengerCount = int.Parse(inputData[1]);
            var passengers = new List<(string Name, DateTime FreeTime)>();

            for (int i = 2; i < 2 + passengerCount; i++)
            {
                string[] parts = inputData[i].Split(' ');
                string name = parts[0];
                DateTime freeTime = ParseTime(parts[1]);

                passengers.Add((name, freeTime));
            }

            var result = passengers
                .Where(p => p.FreeTime >= currentTime &&
                           GetTimeDifferenceInMinutes(p.FreeTime, currentTime) <= 120)
                .OrderBy(p => p.FreeTime)
                .Select(p => p.Name)
                .ToList();
            return result;
        }

        // Вспомогательные функции для ввода данных
        public static List<int> GetIntListFromKeyboard()
        {
            Console.WriteLine("Введите целые числа через пробел:");
            string input = Console.ReadLine();
            return input.Split(' ').Select(int.Parse).ToList();
        }

        public static List<string> GetStringListFromKeyboard()
        {
            Console.WriteLine("Введите строки через запятую:");
            string input = Console.ReadLine();
            return input.Split(',').Select(s => s.Trim()).ToList();
        }

        public static LinkedList<int> GetIntLinkedListFromKeyboard()
        {
            Console.WriteLine("Введите целые числа через пробел для связного списка:");
            string input = Console.ReadLine();
            var list = new LinkedList<int>();
            foreach (var num in input.Split(' ').Select(int.Parse))
            {
                list.AddLast(num);
            }
            return list;
        }

        public static HashSet<string> GetStringHashSetFromKeyboard()
        {
            Console.WriteLine("Введите строки через запятую для HashSet:");
            string input = Console.ReadLine();
            return new HashSet<string>(input.Split(',').Select(s => s.Trim()));
        }

        public static DateTime ParseTime(string timeString)
        {
            return DateTime.ParseExact(timeString, "HH:mm", null);
        }

        public static int GetTimeDifferenceInMinutes(DateTime time1, DateTime time2)
        {
            return (int)(time1 - time2).TotalMinutes;
        }
    }
}