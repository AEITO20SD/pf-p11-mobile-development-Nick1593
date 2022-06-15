using System;
using System.Collections.Generic;

namespace Testing_Environment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = { "Hello", "Bye", "Done", "1", "2", "3", "4" };
            Console.WriteLine(Calculate(array));
        }
        private static int Calculate(string[] array)
        {
            int length = array.Length;

            List<int> ignore = new List<int>();

            ignore.Add(-1);

            int totalConnections = 0;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (array[i] != array[j] && !ignore.Contains(j))
                    {
                        /*SomeMethod(array[i], array[j]);*/
                        totalConnections++;
                    }
                }
                ignore.Add(i);
            }

            Console.WriteLine( length * ( length - 1) / 2);

            return totalConnections;
        }
    }
}
