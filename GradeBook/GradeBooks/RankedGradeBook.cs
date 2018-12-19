using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            double count = 0;

            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            foreach (var student in Students)
            {
                if (student.AverageGrade <= averageGrade)
                {
                    count += 1;
                }
            }

            double place = count / Students.Count * 100;
            
            if (place > 80)
            {
                return 'A';
            }
            else if (place > 60)
            {
                return 'B';
            }
            else if (place > 40)
            {
                return 'C';
            }
            else if  (place > 20)
            {
                return 'D';
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
