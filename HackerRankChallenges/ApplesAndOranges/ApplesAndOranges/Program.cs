using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    //read 2 inputs separated by " ". This represents houseSam
    //read 2 inputs separated by " ". This represents appleTree and orangeTree locations
    //Sam's house must be within the tree locations
    //read 2 inputs separated by " ". This represents how many apples and oranges fell
    //location of fallen apples. if number of inputs == number of fallen apples, 
    //this represents the location of each fallen apple
    //location of fallen oranges. if number of inputs == number of fallen oranges,
    //this represents the location of each fallen orange
    //apple tree + fallen apple = finalApple
    //orange tree + fallen orange = finalOrange
    //if finalApple is within houseSam inputs, add 1 to apple output
    //if finalOrange is within houseSam inpurts, add 1 to orange output

    /*
     * Complete the 'countApplesAndOranges' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER s
     *  2. INTEGER t
     *  3. INTEGER a
     *  4. INTEGER b
     *  5. INTEGER_ARRAY apples
     *  6. INTEGER_ARRAY oranges
     */

    public static void countApplesAndOranges(int s, int t, int a, int b, List<int> apples, List<int> oranges)
    {
        int appleCount = 0;
        int orangeCount = 0;
        for (int i = 0; i < apples.Count; i++)
        {
            if (a + apples[i] >= s && a + apples[i] <= t) { appleCount++; }
        }
        for (int i = 0; i < oranges.Count; i++)
        {
            if (b + oranges[i] >= s && b + oranges[i] <= t) { orangeCount++; }
        }
        Console.WriteLine(appleCount);
        Console.WriteLine(orangeCount);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int s = Convert.ToInt32(firstMultipleInput[0]);

        int t = Convert.ToInt32(firstMultipleInput[1]);

        string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int a = Convert.ToInt32(secondMultipleInput[0]);

        int b = Convert.ToInt32(secondMultipleInput[1]);

        string[] thirdMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int m = Convert.ToInt32(thirdMultipleInput[0]);

        int n = Convert.ToInt32(thirdMultipleInput[1]);

        List<int> apples = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(applesTemp => Convert.ToInt32(applesTemp)).ToList();

        List<int> oranges = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(orangesTemp => Convert.ToInt32(orangesTemp)).ToList();

        Result.countApplesAndOranges(s, t, a, b, apples, oranges);
    }
}