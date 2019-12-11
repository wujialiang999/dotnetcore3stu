namespace dotnetcore3stu
{
    public class WelcomService : IWelcomeService
    {
        public string getMessage()
        {
            return "Hello from IWelcomeService";
        }
    }
}