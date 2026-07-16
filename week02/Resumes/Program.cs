using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Customer Representative";
        job1._company = "Telus";
        job1._startYear = 2022;
        job1._endYear = 2023;

        Job job2 = new Job();
        job2._jobTitle = "Customer Representative";
        job2._company = "Everise";
        job2._startYear = 2024;
        job2._endYear = 2026;

        job1.DisplayJobInfo();
        job2.DisplayJobInfo();

        Resume myResume = new Resume();
        myResume._name = "Diego Tzep";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.DisplayResume();


    }
}