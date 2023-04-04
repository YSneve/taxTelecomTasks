﻿
using System.Text.RegularExpressions;

namespace taxtelecomTasks;

internal class Program
{
    static void Main(String[] args)
    {

        Console.WriteLine("Введите строку");
        var inputStr = Console.ReadLine();


        if (IsAllLower(inputStr))
        {
            var processedString = FirstTaskReverse(inputStr);
            var longestString = GetLongestSubString(processedString);
            var sortedString = StringSort(processedString);

            Console.WriteLine("Результат: {0}\n", processedString);

            WriteLettersMatches(processedString);

            Console.WriteLine("Самая длинная подстрока: {0}\n" +
                "Отсортированная обработанная строка: {1}",  longestString, sortedString);   
        }
        else
        {
            WriteErrors(inputStr);
        }
    }
    // Задание 1
    private static string FirstTaskReverse(string userString)
    {

        return userString.Length % 2 != 0 ? ReverseString(userString) + userString : oddCase(userString);

        // Функция для нечетного кол-ва символов в строке
        string oddCase(string toReverseStr)
        {
            string firstHalf = ReverseString(toReverseStr[..(toReverseStr.Length / 2)]); // Развернутая первая половина входной строки
            string secondHalf = ReverseString(toReverseStr[(toReverseStr.Length / 2)..]); // Развернутая вторая половина входной строки

            return firstHalf + secondHalf;
        }

        //Функция разворота строки
        string ReverseString(string toReverseStr)
        {
            var toReverseList = toReverseStr.ToCharArray();

            Array.Reverse(toReverseList);

            return new string(toReverseList);
        }
    }

    //Задание 2
    private static bool IsAllLower(string checkString)
    {
        //Регулярное выражение, проверяющее на то, что строка от начала и до конца
        //является набором символов от a до z 
        var lowLetExpr = new Regex(@"(^[a-z]*$)");

        return lowLetExpr.IsMatch(checkString);
    }

    
    private static void WriteErrors(string inString)
    {
        //Регулярное выражение, проверяющее на то, что ряд символов
        //Является символом из диапазона от a до z 
        var lowerLetterExpr = new Regex(@"([a-z]*)");

        //Удаление подходящих для ввода символов
        //Удаление повторяющихся неподходящих для вывода символов и оставление неповторяющихся символов путем добавления в hashset
        var wrongLettersSet = new HashSet<char>(lowerLetterExpr.
                Replace(inString, "").
                ToCharArray());

        Console.WriteLine("Ошибка! Введены не подходящие символы." +
                          "\nСледующие, из введенных символов, не являются подходящими:" +
                          "\n{0}", new string(wrongLettersSet.ToArray()));
    }

    //Задание 3
    private static void WriteLettersMatches(string inString)
    {
        // Множество всех символов
        var allLettersSet = new HashSet<char>(inString.ToCharArray());

        // Цикл вывода символв и кол-ва их вхождений в строку
        Console.WriteLine("Символ : Кол-во вхождений");
        foreach (var letter in allLettersSet)
        {
            // Создаём регулярное выражение по символу
            // и получем кол-во вхождений этого символа в строку
            var letterMatches = new Regex(letter.ToString()).Matches(inString).Count();
            Console.WriteLine("{0} : {1}", letter, letterMatches);
        }
    }

    // Задание 4
    private static string GetLongestSubString(string inString) 
    {
        var vowelStartEnd = new Regex(@"[aeiouy].*[aeiouy]");

        return vowelStartEnd.Match(inString).Value;
    }

    // Задание 5
    private static string StringSort(string inString)
    {
        Console.WriteLine("1 - QuickSort\n" +
            "2 - TreeSort\n" +
            "Выберите сортировку: ");

        switch (Console.ReadLine())
        {
            case "1":
                return QuickSort.SortString(inString);

            case "2":
                return TreeSort.SortString(inString);

            default:
                return "Ошибка выбора сортировки!";

        }
    }
}