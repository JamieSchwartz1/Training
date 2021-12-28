using System;
using System.Collections;

namespace StudentArray
{

    class Program
    {
        static void Main(string[] args)
        {
            string[] name = new string[5] {"Albert", "Brit", "Curtis", "Dan", "Erin"};
            int age = 10;
            Random rand = new Random();

            for (int i = 0; i<5; i++)
            {
                int science = rand.Next(30, 101);
                int math = rand.Next(30, 101);
                int literature = rand.Next(30, 101);
                int psych = rand.Next(30, 101);
                int french = rand.Next(30, 101);

                Console.WriteLine($"Name: {name[i]}, Age: {age+i}, Science: {science}, Math: {math}, Literature: {literature}, Psychology: {psych}, French: {french}");
            }
        }
    }
}
