namespace practice.Web.Codes
{
    public class Membership : IMembership
    {
        public void CreateUserAccount(string username, string password)
        {
            // Here you would typically add code to create a user account in your database..

            Console.WriteLine($"Creating user account for: {username}");
            Console.WriteLine($"Password: {password}");
        }
    }
}
