using System;

namespace lab_3
{
    sealed class StudentIAPT : Student
    {
        private struct RecordBook
        {
            public int MMA;
            public int English;
            public int Programming;
            public int Logics;
            public GradesOfExam PE;
        }

        public StudentIAPT(string name, string surname, ushort age, string gender, string education, short yearOfStudy,
                           string formOfEducation, string departmentOfTheUniversity) : base(name, surname, age, gender, "bsuir",
                           education, "fscan", "computer science and programming technologies", yearOfStudy, formOfEducation, departmentOfTheUniversity)
        {

        }

        public override void PassTheSession()
        {
            Random rand = new Random();
            RecordBook recordBook = new RecordBook();

            recordBook.MMA = rand.Next(1, 11);
            if(recordBook.MMA <= 4)
            {
                numberOfRetakes++;
            }

            recordBook.English = rand.Next(1, 11);
            if (recordBook.English <= 4)
            {
                numberOfRetakes++;
            }

            recordBook.Programming = rand.Next(1, 11);
            if (recordBook.Programming <= 4)
            {
                numberOfRetakes++;
            }

            recordBook.Logics = rand.Next(1, 11);
            if (recordBook.Logics <= 4)
            {
                numberOfRetakes++;
            }

            int pe = rand.Next(1, 11);
            if (pe >= 4)
            {
                recordBook.PE = GradesOfExam.credited;
            }
            else
            {
                recordBook.PE = GradesOfExam.notСredited;
            }

            _averageScore = (recordBook.MMA + recordBook.English + recordBook.Programming + recordBook.Logics) / 4;

            if (_averageScore < 5)
            {
                _academicPerformance = "poor";
            }
            else if (_averageScore >= 5 && _averageScore <= 8)
            {
                _academicPerformance = "normal";
            }
            else
            {
                _academicPerformance = "excellent";
            }
        }

        public void PassTheLaboratory()
        {
            Random rand = new Random();

            int laba = rand.Next(1, 11);
            if(laba > 4)
            {
                Console.WriteLine($"{_name}, you passed the laboratory. your mark: {laba}");
            }
            else
            {
                Console.WriteLine($"{_name}, you didn’t surrender the laboratory");
            }
        }

        public override void GetGrants()
        {
            base.GetGrants();

            if (_departmentOfTheUniversity != "paid form")
            {
                if(_averageScore < 5)
                {
                    _grants = 0;
                } 
                else if(_averageScore < 6)
                {
                    _grants = _minimumGrants;
                }
                else if (_averageScore < 8)
                {
                    _grants = (float)(_minimumGrants * 1.2);
                }
                else if (_averageScore < 9)
                {
                    _grants = (float)(_minimumGrants * 1.4);
                }
                else if (_averageScore <= 10)
                {
                    _grants = (float)(_minimumGrants * 1.6);
                }
            }
        }
    }
}
