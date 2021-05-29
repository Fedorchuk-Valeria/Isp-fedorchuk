using System;

namespace lab_3
{
    sealed class StudentIAPT : Student, StudentIT
    {
        private struct RecordBook
        {
            public int MMA;
            public int English;
            public int Programming;
            public int Logics;
            public GradesOfExam PE;
        };

        static private int maxPoint;
        private RecordBook recordBook = new RecordBook();

        public delegate int Mark(int subject, Random rand);
        
        static public event Mark ExamAnswer;
        static int FivePointSystem(int subject, Random rand)
        {
            maxPoint = 5;
            subject = rand.Next(1, 6);
            return subject;
        }

        public StudentIAPT(string name, string surname, ushort age, string gender, string education, short yearOfStudy,
                           string formOfEducation, string departmentOfTheUniversity) : base(name, surname, age, gender, "bsuir",
                           education, "fscan", "computer science and programming technologies", yearOfStudy, formOfEducation, departmentOfTheUniversity)
        {
            ExamAnswer += delegate (int subject, Random rand)
            {
                maxPoint = 10;
                subject = rand.Next(1, 11);
                return subject;
            };
        }

        static public void ToFivePointSystem()
        {
            maxPoint = 5;
            ExamAnswer += (subject, rand) => FivePointSystem(subject, rand);
        }

        public void AccessToIIS()
        {
            Console.WriteLine("Enter password:");
            string temp;
            int password = 0;

            while (password == 0)
            {
                temp = Console.ReadLine();
                if (temp.Length != 6)
                {
                    Console.WriteLine("Input Error. Try again");
                    continue;
                }
                try
                {
                    password = Convert.ToInt32(temp);
                }
                catch
                {
                    Console.WriteLine("Input Error. Try again");
                }
            }

            Console.WriteLine($"MMA: {recordBook.MMA}");
            Console.WriteLine($"English: {recordBook.English}");
            Console.WriteLine($"Programming: {recordBook.Programming}");
            Console.WriteLine($"PE: {recordBook.PE}");
        }

        static void LanguageLevel(string str)
        {
            int language = 0;
            Random rand = new Random();
            language = ExamAnswer(language, rand);
            if (language < 0.5 * maxPoint)
            {
                Console.WriteLine($"Your {str} language proficiency is poor\n");
            }
            else if (language >= 5 && language <= 0.8 * maxPoint)
            {
                Console.WriteLine($"Your {str} language proficiency is normal\n");
            }
            else
            {
                Console.WriteLine($"Your {str} language proficiency is exellent\n");
            }
        }
           

        public override void PassTheSession()
        {
            Random rand = new Random();
            recordBook.MMA = ExamAnswer(recordBook.MMA, rand);
            if (recordBook.MMA <= 0.4 * maxPoint)
            {
                numberOfRetakes++;
            }

            recordBook.English = ExamAnswer(recordBook.English, rand);
            if (recordBook.English < 0.4 * maxPoint)
            {
                numberOfRetakes++;
            }

            recordBook.Programming = ExamAnswer(recordBook.Programming, rand);
            if (recordBook.Programming < 0.4 * maxPoint)
            {
                numberOfRetakes++;
            }

            recordBook.Logics = ExamAnswer(recordBook.Logics, rand);
            if (recordBook.Logics < 0.4 * maxPoint)
            {
                numberOfRetakes++;
            }

            int pe = 0;
            pe = ExamAnswer(pe, rand);
            if (pe >= 0.25 * maxPoint)
            {
                recordBook.PE = GradesOfExam.credited;
            }
            else
            {
                recordBook.PE = GradesOfExam.notСredited;
            }

            _averageScore = (recordBook.MMA + recordBook.English + recordBook.Programming + recordBook.Logics) / 4;

            if (_averageScore < 0.5 * maxPoint)
            {
                _academicPerformance = "poor";
            }
            else if (_averageScore >= 0.5 * maxPoint && _averageScore <= 0.8 * maxPoint)
            {
                _academicPerformance = "normal";
            }
            else
            {
                _academicPerformance = "excellent";
            }
        }

        public void LanguageLearning()
        {
            LanguageLevel("C#");
            LanguageLevel("C");
            LanguageLevel("C++");
        }

        public void YourActivity()
        {
            Console.WriteLine("You are a leading specialist in the field of formation and use of computer information systems and technologies");
        }

        public void PassTheLaboratory()
        {

            int laba = 0;
            Random rand = new Random();
            laba = ExamAnswer(laba, rand);
            if (laba > 0.4 * maxPoint)
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
                if(_averageScore < 0.5 * maxPoint)
                {
                    _grants = 0;
                } 
                else if(_averageScore < 0.6 * maxPoint)
                {
                    _grants = _minimumGrants;
                }
                else if (_averageScore < 0.8 * maxPoint)
                {
                    _grants = (float)(_minimumGrants * 1.2);
                }
                else if (_averageScore < 0.9 * maxPoint)
                {
                    _grants = (float)(_minimumGrants * 1.4);
                }
                else if (_averageScore <= maxPoint)
                {
                    _grants = (float)(_minimumGrants * 1.6);
                }
            }
        }

        public override void GraduateFromUniversity()
        {
            base.GraduateFromUniversity();

            if(numberOfRetakes < 3)
            {
                FieldOfActivity(YourActivity);
            }
        }
    }
}
