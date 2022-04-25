using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.IO;

namespace P0withTesting
{
    class Program
    {
        public static int CartItemID { get; set; }
        public static int CartID { get; set; }
        public static int ProductID { get; set; }
        public static int PriceTotal { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
