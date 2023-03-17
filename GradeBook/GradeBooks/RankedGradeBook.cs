using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    internal class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            base.Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("You need more than 5 students to calculate letter grading.");
            }

            int twentyPercentOfStudents = (int)Students.Count * (2 / 10); //calculating how much is 20% of students

            List<double> averageGrades = Students.Select(n => n.AverageGrade).ToList(); //list of avg grades of students
            averageGrades.OrderBy(n => n); //sorted ascending


            if (averageGrades[twentyPercentOfStudents] < averageGrade)
                return 'A';
            else if (averageGrades[twentyPercentOfStudents*2] < averageGrade)
                return 'B';
            else if (averageGrades[twentyPercentOfStudents*3] < averageGrade)
                return 'C';
            else if (averageGrades[twentyPercentOfStudents*4] < averageGrade)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("You need more than 5 students to calculate ranked grading.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }
    }
}
