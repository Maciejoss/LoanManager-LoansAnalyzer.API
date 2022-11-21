namespace LoansAnalyzerAPI.Users
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        private string Password { get; set; }
    }
}
