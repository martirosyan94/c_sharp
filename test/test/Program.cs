using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student
            {
                Name = "Susan",
                Enrolled = false
            };

            Enroll(out student);
            Console.WriteLine(student.Name);
            // student.Name is still Susan
            // student.Enrolled is now true
            int i = 5;
            UpdateInt(i, out i);
            Console.WriteLine(i);

            double s;
            CountAverage(out s, 4, 5, 6);
            Console.WriteLine(s);

        }

        static void Enroll(out Student student)
        {
            //student.Name = "Anna"; // This changes the student variable that was passed in outside of the method.
            student = new Student(); // This does not change the student variable outside of the method but creates a new reference. Since student now points to a new reference, the student variable outside of the method is no longer affected after this line.
            student.Name = "Anna"; // This changes the local student inside the method.
        }

        static void UpdateInt(int a, out int i)
        {
            i = a+1;
        }

        static void CountAverage(out double s, params double[] args) 
        {
            s = 0;
            for (int i =0; i<args.Length; i++)
                s += args[i];
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public bool Enrolled { get; set; }
    }
}
