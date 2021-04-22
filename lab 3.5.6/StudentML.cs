using System;

namespace lab_3
{
    class StudentML : Student
    {
        private struct RecordBook
        {
            public GradesOfExam EnglishGram;
            public GradesOfExam Listening;
            public int EnglishPhonetics;
            public int Linguistics;
            public int POWAS;
        }

        public StudentML(string name, string surname, ushort age, string gender, string education, short yearOfStudy,
                           string formOfEducation, string departmentOfTheUniversity) : base(name, surname, age, gender, "mslu",
                           education, "ft", "modern languages translation", yearOfStudy, formOfEducation, departmentOfTheUniversity)
        {

        }

        public override void PassTheSession()
        {
            Random rand = new Random();
            RecordBook recordBook = new RecordBook();

            recordBook.EnglishPhonetics = rand.Next(1, 11);
            if (recordBook.EnglishPhonetics <= 4)
            {
                numberOfRetakes++;
            }

            recordBook.Linguistics = rand.Next(1, 11);
            if (recordBook.Linguistics <= 4)
            {
                numberOfRetakes++;
            }

            recordBook.POWAS = rand.Next(1, 11);
            if (recordBook.POWAS <= 4)
            {
                numberOfRetakes++;
            }

            int eg = rand.Next(1, 11);
            if (eg >= 4)
            {
                recordBook.EnglishGram = GradesOfExam.credited;
            }
            else
            {
                recordBook.EnglishGram = GradesOfExam.notСredited;
            }

            int listen = rand.Next(1, 11);
            if (listen >= 4)
            {
                recordBook.Listening = GradesOfExam.credited;
            }
            else
            {
                recordBook.Listening = GradesOfExam.notСredited;
            }

            _averageScore = (recordBook.EnglishPhonetics + recordBook.Linguistics + recordBook.POWAS) / 3;

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
                if (_averageScore < 6)
                {
                    _grants = 0;
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
