using online_school.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        ServiceEnrolment test = new ServiceEnrolment();
        test.ShowEnrolments();
    }
}