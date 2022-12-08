namespace LoansAnalyzerAPI.Users.UserInfo
{
    public class JobDetails
    {
        public Guid Id { get; init; }
        public int TypeId { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime? EndDate { get; init; }

        public JobDetails(int typeId, string name, string description, DateTime startDate, DateTime? endDate)
        {
            Id = Guid.NewGuid();
            TypeId = typeId;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }
        public JobDetails() { }
    }
}
