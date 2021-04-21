using System;

namespace lab_3
{
    class StudentEconomist : Student
    {
        private struct RecordBook
        {
            public GradesOfExam History;
            public GradesOfExam PoliticalScience;
            public int English;
            public int Philosophy;
            public int Math;
        }

        public StudentEconomist(string name, string surname, ushort age, string gender, string education, short yearOfStudy,
                          string formOfEducation, string departmentOfTheUniversity) : base(name, surname, age, gender, "bseu",
                          education, "ffas", "econimist", yearOfStudy, formOfEducation, departmentOfTheUniversity)
        {

        }

        public override void PassTheSession()
        {
            Random rand = new Random();
            RecordBook recordBook = new RecordBook();

            recordBook.English = rand.Next(1, 11);
            if (recordBook.English <= 4)
            {
                numberOfRetakes++;
            }

            recordBook.Philosophy = rand.Next(1, 11);
            if (recordBook.Philosophy <= 4)
            {
                numberOfRetakes++;
            }

            recordBook.Math = rand.Next(1, 11);
            if (recordBook.Math <= 4)
            {
                numberOfRetakes++;
            }

            int hist = rand.Next(1, 11);
            if (hist >= 4)
            {
                recordBook.History = GradesOfExam.credited;
            }
            else
            {
                recordBook.History = GradesOfExam.notСredited;
            }

            int polit = rand.Next(1, 11);
            if (polit >= 4)
            {
                recordBook.PoliticalScience = GradesOfExam.credited;
            }
            else
            {
                recordBook.PoliticalScience = GradesOfExam.notСredited;
            }

            _averageScore = (recordBook.English + recordBook.Math + recordBook.Philosophy) / 3;

            if (_averageScore < 5)
            {
                _academicPerformance = "poor";
            }
            else if (_averageScore > 5 && _averageScore < 8)
            {
                _academicPerformance = "normal";
            }
            else
            {
                _academicPerformance = "excellent";
            }
        }

        public override void GetGrants()
        {
            base.GetGrants();

            if (_departmentOfTheUniversity != "paid form")
            {
                if (_averageScore < 5)
                {
                    _grants = 0;
                }
                else if (_averageScore < 6)
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
