using System;

namespace _4_MethodsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /**
                YOUR CODE HERE.
            **/
        }

        public static string GetName()
        {
            string name = Console.ReadLine();
            return name;
        }

        public static string GreetFriend(string name)
        {
            string greet = $"Hello, {name}. You are my friend.";
            return greet;
        }

        public static double GetNumber()
        {
            string number = Console.ReadLine();
            double.TryParse(number, out double result);
            return result;
        }

        public static int GetAction()
        {
            string action = Console.ReadLine();
            int.TryParse(action, out int input);
            return input;
        }

        public static double DoAction(double x, double y, int action)
        {
            //i don't understand this one
            return action;
        }
    }
}
