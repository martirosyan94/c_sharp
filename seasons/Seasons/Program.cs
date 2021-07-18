using System;

namespace Seasons
{
    class Program
    {
        static void Main(string[] args)
        {
            //short monthNumber = short.Parse(Console.ReadLine());
            //Console.WriteLine(GetSeason(monthNumber));

            Student stud = new Student();
            stud.Name = "Ashot";
            stud.Surname = "Martirosyan";
            stud.Ratings = new double[] { 99, 65, 42, 55, 73};
            double result = 0;
            stud.AverageRatings(ref result);
            Console.WriteLine(result);

            int i = 5;
            UpdateValue(ref i);
            Console.WriteLine(i);
        }

        static String GetSeason(short month)
        {
            switch (month)
            {
                case short n when (3<=n && n<=5):
                    return "Spring";
                case short n when (6 <= n && n <= 8):
                    return "Summer";
                case short n when ( 9 <= n && n <= 11):
                    return "Atumn";
                case short n when(n == 12 || n == 1 || n == 2 ):
                    return "Winter";
                default:
                    return "There is no such a season";
            }
        

        }

        static void UpdateValue(ref int i) => i += 1;
    }
}
