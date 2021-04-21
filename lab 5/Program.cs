using System;

namespace lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*StudentIAPT Lera = new StudentIAPT("valerya", "fedarchuk", 21, "woman", "secondary", 4, "daytime", "budget form");
            Lera.PassTheSession();
            Lera.GetGrants();
            Lera.PassTheLaboratory();
            Lera.Deduct();
            Lera.Information();
            Lera.TransferToAnotherSpecialty("vmsis");
            Lera.WriteDiploma();
            Lera.GraduateFromUniversity();
            Lera.Information();*/
            /*StudentML Alesya = new StudentML("alesya", "tsyrelchuk", 20, "woman", "secondary", 2, "daytime", "paid form");
            Alesya.PassTheSession();
            Alesya.GetGrants();
            Alesya.Deduct();
            Alesya.Information();*/
            Student Nastya = new StudentIAPT("nastya", "tsyrelchuk", 20, "woman", "secondary", 3, "daytime", "budgetPas form");
            Nastya.PassTheSession();
            Nastya.GetGrants();
            Nastya.Information();

        }
    }
}