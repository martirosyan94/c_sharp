using System;
using System.Collections.Generic;
using System.Text;

namespace Seasons
{
    class Student
    {
        private string name;
        private string surname;
        private double[] ratings;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public double[] Ratings { get => ratings; set => ratings = value; }

        // This function is used to test ref usage
        public void AverageRatings(ref double result)
        {
            double sum = 0;
            for (int i = 0; i < ratings.Length; i++)
                sum += ratings[i];

            result = sum / ratings.Length;
        }

    }
}
