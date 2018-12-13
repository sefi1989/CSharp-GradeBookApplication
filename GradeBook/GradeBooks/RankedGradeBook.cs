using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
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
    }
}
