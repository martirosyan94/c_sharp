using System;
using System.Collections.Generic;
using System.Text;

namespace Seasons
{
    class Student
    {

        public string Name { get; set; }
        public string Surname { get; set; }

        public double[] Ratings { get; set; }

        // This function is used to test ref usage
        public void AverageRatings(ref double result)
        {
            double sum = 0;
            for (int i = 0; i < Ratings.Length; i++)
                sum += Ratings[i];

            result = sum / Ratings.Length;
        }

    }
}
