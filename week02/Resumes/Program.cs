class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2023;
        job1._endYear = 2024;

        Job job2 = new Job();
        job2._company = "Apple";
        job2._jobTitle = "Manager";
        job2._startYear = 2024;
        job2._endYear = 2025;

        Resume myResume = new Resume();
        myResume._name = "Kelvin Melfah";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Verify dot notation access
        Console.WriteLine(myResume._jobs[0]._jobTitle);

        myResume.Display();
    }
}