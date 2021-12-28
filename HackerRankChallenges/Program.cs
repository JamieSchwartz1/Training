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

//https://www.hackerrank.com/challenges/grading/problem

class Result
{
    public static List<int> gradingStudents(List<int> grades)
    {
        List<int> finalScores = new List<int>();
        foreach (int grade in grades)
        {
            if (grade % 5 < 3 || grade < 38)                    //ex. grade = 46 -> mod is 1, do not round up. Any grade ending in 0,1,2,6,7 does not round up.
            {
                finalScores.Add(grade);
            }
            else                                                //ex. grade = 68 -> mod is 3, round up to 70. Any grade ending in 3,4,5,8,9 rounds up.
            {
                finalScores.Add(grade + (5 - (grade % 5)));     //ex. grade = 65 -> mod = 0 -> 65 + 5 - 0 = 70
                                                                //ex. grade = 78 -> mod = 3 -> 78 + 5 - 3 = 80
            }
        }
        return finalScores;                                     //return grades
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int gradesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> grades = new List<int>();

        for (int i = 0; i < gradesCount; i++)
        {
            int gradesItem = Convert.ToInt32(Console.ReadLine().Trim());
            grades.Add(gradesItem);
        }

        //List<int> result = Result.gradingStudents(grades);

        //textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
