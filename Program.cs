using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_1_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowMenu();
        }

        static void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ЛАБОРАТОРНАЯ РАБОТА №4 - МЕНЮ ===");
                Console.WriteLine("1. Задание 1 - List (элементы в L1 но не в L2)");
                Console.WriteLine("2. Задание 2 - LinkedList (проверка симметричности)");
                Console.WriteLine("3. Задание 3 - HashSet (анализ предпочтений)");
                Console.WriteLine("4. Задание 4 - Анализ текста (поиск отсутствующих букв)");
                Console.WriteLine("5. Задание 5 - Камера хранения");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите задание: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Task1();
                        break;
                    case "2":
                        Task2();
                        break;
                    case "3":
                        Task3();
                        break;
                    case "4":
                        Task4();
                        break;
                    case "5":
                        Task5();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        static void Task1()
        {
            Console.WriteLine("\n--- Задание 1: Элементы в L1 но не в L2 ---");

            Console.WriteLine("Список L1:");
            var L1 = Linq.GetIntListFromKeyboard();

            Console.WriteLine("Список L2:");
            var L2 = Linq.GetIntListFromKeyboard();

            var result = Linq.GetElementsInL1NotInL2(L1, L2);
            Console.WriteLine($"Элементы в L1 но не в L2: [{string.Join(", ", result)}]");
        }

        static void Task2()
        {
            Console.WriteLine("\n--- Задание 2: Проверка симметричности участка LinkedList ---");

            var list = Linq.GetIntLinkedListFromKeyboard();

            Console.Write("Введите начальный индекс i: ");
            int i = int.Parse(Console.ReadLine());

            Console.Write("Введите конечный индекс j: ");
            int j = int.Parse(Console.ReadLine());

            bool isSymmetric = Linq.IsSymmetricSegment(list, i, j);
            Console.WriteLine($"Участок [{i}-{j}] симметричен: {isSymmetric}");
        }

        static void Task3()
        {
            Console.WriteLine("\n--- Задание 3: Анализ предпочтений сладкоежек ---");

            Console.WriteLine("Введите все виды шоколада:");
            var allChocolate = Linq.GetStringHashSetFromKeyboard();

            Console.Write("Введите количество сладкоежек: ");
            int n = int.Parse(Console.ReadLine());

            var allLikers = new List<HashSet<string>>();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Сладкоежка {i + 1}:");
                var liker = Linq.GetStringHashSetFromKeyboard();
                allLikers.Add(liker);
            }

            Linq.AnalyzeSweetLikers(allLikers, allChocolate);
        }

        static void Task4()
        {
            Console.WriteLine("\n--- Задание 4: Анализ текста ---");
            string filePath;
            Console.Write("Введите путь к файлу: ");
            filePath = Console.ReadLine();
            try
            {
                int missingLetters = Linq.CountMissingLetters(filePath);
                Console.WriteLine($"Букв русского алфавита не встречается: {missingLetters}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void Task5()
        {
            Console.WriteLine("\n--- Задание 5: Камера хранения ---");
            string[] inputData;
            inputData = new string[7];
            Console.Write("Введите текущее время (HH:mm): ");
            inputData[0] = Console.ReadLine();
            Console.Write("Введите количество пассажиров: ");
            inputData[1] = Console.ReadLine();
            int n = int.Parse(inputData[1]);

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите данные пассажира {i + 1} (Фамилия HH:mm): ");
                inputData[i + 2] = Console.ReadLine();
            }

            try
            {
                var result = Linq.GetPassengersToFreeIn2Hours(inputData);
                Console.WriteLine("Пассажиры, которые освободят ячейки в ближайшие 2 часа:");
                if (result.Any())
                {
                    foreach (var passenger in result)
                    {
                        Console.WriteLine(passenger);
                    }
                }
                else
                {
                    Console.WriteLine("Нет таких пассажиров");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка обработки: {ex.Message}");
            }
        }
    }
}