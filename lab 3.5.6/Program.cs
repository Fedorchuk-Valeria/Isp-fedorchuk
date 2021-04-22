using System;
using System.Collections.Generic;

namespace lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentIAPT Lera = new StudentIAPT("valerya", "fedarchuk", 21, "woman", "secondary", 4, "daytime", "budget form");
            Lera.PassTheLaboratory();
            Lera.PassTheSession();
            Lera.GetGrants();
            Lera.Deduct();
            //Lera.Information();
            //Lera.WriteDiploma();
            Lera.GraduateFromUniversity();
            //Lera.Information();
            StudentML Alesya = new StudentML("alesya", "tsyrelchuk", 20, "woman", "secondary", 2, "daytime", "paid form");
            Alesya.PassTheSession();
            Alesya.GetGrants();
            Alesya.Deduct();
            //Alesya.Information();
            StudentEconomist Nastya = new StudentEconomist("nastya", "tsyrelchuk", 20, "woman", "secondary", 3, "daytime", "budget form");
            Nastya.PassTheSession();
            Nastya.GetGrants();
            //Nastya.Information();

            List<Student> students = new List<Student>() { Lera, Alesya, Nastya };
           
            students.Sort();
        }
    }
}