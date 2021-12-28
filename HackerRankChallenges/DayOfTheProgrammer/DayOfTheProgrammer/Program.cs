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

    /*
     * Complete the 'dayOfProgrammer' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER year as parameter.
     */
    public static string dayOfProgrammer(int year)
    {
        string dotp = "";
        int dayOfYear = 256;

        if (year < 1918)
        {
            return year % 4 == 0 ? "12.09." + year : "13.09." + year;
            // DateTime theDate = new DateTime(year, 1, 1);
            // JulianCalendar julianCal = new JulianCalendar();
            // theDate = julianCal.AddDays(theDate, dayOfYear-1);
            //dotp = julianCal.GetDayOfMonth(theDate) + "." + julianCal.GetMonth(theDate) + "." + julianCal.GetYear(theDate);
            //dotp = theDate.ToString("dd.MM.yyyy");
        }
        else if (year == 1918) return "26.09." + year;
        else
        {
            // return (year % 4 == 0 && year % 100 != 0)|| year%400 == 0 ? "12.09."+year : "13.09."+year;
            DateTime theDate = new DateTime(year, 1, 1).AddDays(dayOfYear - 1);
            dotp = theDate.ToString("dd.MM.yyyy");
        }
        return dotp;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int year = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.dayOfProgrammer(year);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
