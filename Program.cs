using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccountKata
{
    public static class Program
    {
        private static readonly Random Random = new();
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public static void Main()
        {
            StringsHashcode(5);
        }

        private static void StringsHashcode(int charlen)
        {
            var data = new Dictionary<int, List<string>>();
            var hData = new Dictionary<int, string>();
            do
            {
                var stringA = charlen.GetString();
                var hCode = stringA.GetHashCode();
                if (hData.TryGetValue(hCode, out var stringB) && stringB != stringA)
                {
                    Console.WriteLine("stringA = {0}, stringB = {1}, hashCode = {2}", stringA, stringB, hCode);

                    if (!data.ContainsKey(hCode))
                        data.Add(hCode, new List<string>());

                    data[hCode].Add(stringA);
                    data[hCode].Add(stringB);

                    if (data[hCode].Count > 2 && !string.Equals(data[hCode][0], data[hCode][1]) &&
                        !string.Equals(data[hCode][1], data[hCode][2]) &&
                        !string.Equals(data[hCode][0], data[hCode][2]))
                    {
                        Console.WriteLine("\n** stringA = {0}, stringB = {1}, stringC = {2}, hashCode = {3} **", data[hCode][2],
                            data[hCode][0],
                            data[hCode][1], hCode);
                        break;
                    }
                }
                hData[hCode] = stringA;
            } while (true);
        }

        private static string GetString(this int len) =>
            new(Enumerable.Repeat(Chars, len).Select(s => s[Random.Next(s.Length)]).ToArray());

    }
}