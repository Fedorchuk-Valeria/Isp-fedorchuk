using System;

namespace lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Person.Human girlfriend = new Person.Human("anua987654", "cidorchuk", 17, "woman", "average", "absent", "single");
            Person.Human boyfriend = new Person.Human("sasha", "fedorchuk", 18, "man", "average", "absent", "single");
            girlfriend.Information();
            boyfriend.Information();
            girlfriend.ChangeOfPassportData("valerya");
            girlfriend.Information();
            girlfriend.ChangeOfPassportData("lera", "fed");
            girlfriend.Information();
            girlfriend.Marriage(boyfriend);
            boyfriend.Marriage(girlfriend);
            girlfriend.GrowingUp();
            girlfriend.Marriage(boyfriend);
            boyfriend.Marriage(girlfriend);
            girlfriend.Information();
            boyfriend.Information();
            girlfriend.Divorce();
            girlfriend.Information();
            Console.WriteLine(girlfriend["marital status"]);
            Console.WriteLine(girlfriend.Name);
        }
    }
}

namespace Person
{
    class Human
    {
        protected string _name;
        protected string _surname;
        protected ushort _age;
        protected string _gender;
        protected string _education;
        protected string _profession;
        protected string _maritalStatus;
        private string _maidenName;
        protected uint _id;
        static uint _amount;

        static string CheckData(string str, int a, int b)
        {
            int count = -1;
            while (count != str.Length)
            {
                count = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] >= a && str[i] <= b)
                    {
                        count++;
                    }
                }
                if (count != str.Length)
                {
                    Console.WriteLine($"{str} - invalid data. Try again");
                    str = Console.ReadLine();
                }
            }
            return str;
        }
        public Human(string name, string surname, ushort age, string gender)
            : this(name, surname, age, gender, "absent", "absent", "single")
        {

        }
        public Human(string name, string surname, ushort age, string gender, string education, string profession, string maritalStatus)
        {
            _name = CheckData(name, 97, 122);
            _surname = CheckData(surname, 97, 122);
            _maidenName = _surname;
            _age = age;
            while (gender != "man" && gender != "woman")
            {
                Console.WriteLine($"{_gender} - invalid gender. Try again");
                gender = Console.ReadLine();
            }
            _gender = gender;
            _education = CheckData(education, 97, 122);
            _profession = CheckData(profession, 97, 122);
            while (maritalStatus != "married" && maritalStatus != "single")
            {
                Console.WriteLine("Invalid gender. Try again");
                maritalStatus = Console.ReadLine();
            }
            _maritalStatus = maritalStatus;
            _amount++;
            _id = _amount;
        }

        public string Name
        {
            get
            { 
                return _name;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
        }

        public ushort Age
        {
            get
            {
                return _age;
            }
        }

        public string Gender
        {
            get
            {
                return _gender;
            }
        }

        public string MaritalStatus
        {
            get
            {
                return _maritalStatus;
            }
        }

        public string Education
        {
            get
            {
                return _education;
            }
            set
            {
                _education = CheckData(value, 97, 122);
            }
        }

        public string Profession
        {
            get
            {
                return _profession;
            }
            set
            {
                _profession = CheckData(value, 97, 122);
            }
        }

        public string this[string fieldName]
        {
            get
            {
                switch(fieldName)
                {
                    case "name": return _name;
                    case "surname": return _surname;
                    case "age": return Convert.ToString(_age);
                    case "gender": return _gender;
                    case "marital status": return _maritalStatus;
                    case "education": return _education;
                    case "profession": return _profession;
                    default: return "There is no such field";
                }
            }
        }

        public void Marriage(Human partner)
        {
            if (_age >= 18 && partner._age >= 18)
            {
                _maritalStatus = "married";
                if (_gender == "woman")
                {
                    _surname = partner._surname;
                }
            }
            else if (partner._age < 18)
            {
                Console.WriteLine($"{_name}, you cannot get married. Your partner is underage.");
            }
            else
            {
                Console.WriteLine($"{_name}, you cannot get married.You are underage.");
            }
        }

        public void Divorce()
        {
            if (_gender == "man" && _maritalStatus == "married")
            {
                _maritalStatus = "single";
            }
            else if(_gender == "woman" && _maritalStatus == "married")
            {
                _surname = _maidenName;
                _maritalStatus = "single";
            }
            else
            {
                Console.WriteLine("You cannot divorce");
            }
        }
        public void ChangeOfPassportData(string newName)
        {
            _name = CheckData(newName, 97, 122);
        }
        public void ChangeOfPassportData(string newName, string newSurname)
        {
            _name = CheckData(newName, 97, 122);
            _surname = CheckData(newSurname, 97, 122);
        }
        public void GrowingUp()
        {
            _age++;
        }
        public void Information()
        {
            Console.WriteLine($"ID: {_id}\nName: {_name}\nSurname: {_surname}\nAge: {_age}\n" +
                $"Gender: {_gender}\nEducation: {_education}\nProfession: {_profession}\nMaritalStatus: {_maritalStatus}\n");
        }
    }
}
