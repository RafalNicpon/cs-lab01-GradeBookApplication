using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public bool IsWeighted;
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Podaj minimum 5 studentów");
            }

            var betterStudents = Students.Select(w => w.AverageGrade > averageGrade).Count();

            if (betterStudents/Students.Count <= 0.2f)
            {
                return 'A';
            }
            else if (betterStudents / Students.Count <= 0.4f)
            {
                return 'B';
            }
            else if (betterStudents / Students.Count <= 0.6f)
            {
                return 'C';
            }
            else if (betterStudents / Students.Count <= 0.8f)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Liczba studentów poniżej 5");
                return;
            }
            else
            {
                base.CalculateStatistics();
            }

        }
        public override void CalculateStudentStatistics(string proj)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStudentStatistics(proj);
        }

    }
}