using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            double x=34.1;
            double y=10.3;
            double result = x+y;
            System.Console.WriteLine(result);

            double[] numbers = new[] {12.7, 10.3, 6.11, 4.1};
            double result2 = 0.0;
            foreach(double number in numbers)
            {
                result2 += number;
            }
            Console.WriteLine(result2);

            if(args.Length > 0)
            {
                Console.WriteLine($"Hello, {args[0]}!");
            }
            else
            {
                Console.WriteLine("Hello!");
            }
            */

            // List<double> grades = new List<double>() {12.7, 10.3, 6.11, 4.1};
            // grades.Add(56.1);
            // double result3=0.0;
            // double highGrade = double.MinValue;
            // double lowGrade = double.MaxValue;
            // foreach(double number in grades)
            // {
            //     lowGrade = Math.Min(number, lowGrade);
            //     highGrade = Math.Max(number, highGrade);
            //     result3+=number;
            // }
            // Console.WriteLine(result3);
            // result3 /= grades.Count;
            // Console.WriteLine($"The lowest grade is {lowGrade:N2}");
            // Console.WriteLine($"The highest grade is {highGrade:N2}");
            // Console.WriteLine($"The average grade is {result3:N2}");

            IBook book = new DiskBook("The Book");
            //var book = new InMemoryBook("The Book");
            book.GradeAdded += OnGradeAdded;
            // book.AddGrade(89.1);
            // book.AddGrade(90.5);
            // book.AddGrade(77.5);
            EnterGrades(book);
            var stats = book.GetStatistics();
            Console.WriteLine($"The lowest grade is {stats.Low:N2}");
            Console.WriteLine($"The highest grade is {stats.High:N2}");
            Console.WriteLine($"The average grade is {stats.Average:N2}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit.");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
