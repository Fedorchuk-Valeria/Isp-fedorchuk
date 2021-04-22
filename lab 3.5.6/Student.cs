using System;

namespace lab_3
{
    abstract class Student : Human, IComparable<Student>
    {
        protected string _universityName;
        protected string _facultyName;
        protected string _specialtyName;
        protected short _yearOfStudy;
        protected string _formOfEducation;
        protected string _departmentOfTheUniversity;
        protected float _averageScore;
        protected string _academicPerformance;
        protected float _grants;
        protected ushort numberOfRetakes;
        protected static float _minimumGrants = 85;
        protected enum GradesOfExam
        {
            credited,
            notСredited
        };

        public Student(string name, string surname, ushort age, string gender, string universityName, string education,
                       string facultyName, string specialtyName, short yearOfStudy, string formOfEducation, 
                       string departmentOfTheUniversity): base(name, surname, age, gender)
        {
            _universityName = CheckData(universityName, 97, 122);

            while (yearOfStudy < 1 || yearOfStudy > 4)
            {
                Console.WriteLine($"{yearOfStudy} - invalid gender. Try again");
                try
                {
                    yearOfStudy = Convert.ToInt16(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Input Error. Try again");
                }
            }

            _yearOfStudy = yearOfStudy;
            _formOfEducation = CheckData(formOfEducation, 97, 122);
            _facultyName = CheckData(facultyName, 97, 122);
            _specialtyName = CheckData(specialtyName, 97, 122);

            while (departmentOfTheUniversity != "paid form" && departmentOfTheUniversity != "budget form")
            {
                Console.WriteLine($"{departmentOfTheUniversity} - invalid gender. Try again");
                departmentOfTheUniversity = Console.ReadLine();
            }

            _departmentOfTheUniversity = departmentOfTheUniversity;
            numberOfRetakes = 0;
            _education = CheckData(education, 97, 122);
        }

        public int CompareTo(Student St)
        {
            if(_yearOfStudy == St._yearOfStudy)
            {
                return 0;
            } 
            else if(_yearOfStudy < St._yearOfStudy)
            {
                return -1;
            } 
            else
            {
                return 1;
            }
        }

        public abstract void PassTheSession();

        public virtual void GetGrants()
        {
            if (_departmentOfTheUniversity == "paid form")
            {
                _grants = 0;
            }
        }

        public void WriteDiploma()
        {
            if(_yearOfStudy == 4)
            {
                Console.WriteLine("Choose a diploma topic:");
                string topic = Console.ReadLine();
                topic = CheckData(topic, 97, 122);
            } else
            {
                Console.WriteLine("The diploma is written in the 4th year of study");
            }
        }

        public void WriteCourseWork()
        {
            Console.WriteLine("Choose a course work topic:");
            string topic = Console.ReadLine();
            topic = CheckData(topic, 97, 122);
        }

        public void GraduateFromUniversity()
        {
            _education = "higher";
            _grants = 0;
        }

        public void TransferToAnotherFaculty(string newFaculty, string newSpecialty)
        {
            _facultyName = CheckData(newFaculty, 97, 122);
            _specialtyName = CheckData(newSpecialty, 97, 122);
        }

        public void TransferToAnotherSpecialty(string newSpecialty)
        { 
            _specialtyName = CheckData(newSpecialty, 97, 122);
        }

        public void Deduct()
        {
            if(numberOfRetakes > 3)
            {
                Console.WriteLine($"{_name}, you are expelled\n");
            } 
            else
            {
                Console.WriteLine($"{_name}, you are good student");
            }
        }

        public override void Information()
        {
            base.Information();
            Console.WriteLine($"University name: {_universityName}\nFaculty name: {_facultyName}\nSpecialty name: {_specialtyName}\n" +
                $"Year of study: {_yearOfStudy}\nForm of education: {_formOfEducation}\nDepartment of the university: {_departmentOfTheUniversity}\n" +
                $"Academic performance: {_academicPerformance}\nGrants: {_grants}\n");
        }
    }
}
