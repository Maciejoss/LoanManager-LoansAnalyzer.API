namespace LoansAnalyzerAPI.Models.Clients.AdditionalData
{
    public class GovernmentDocument
    {
        public Guid Id { get; set; }
        public int TypeId { get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public string Number { get; set; }

        public GovernmentDocument(int typeId, string name, string description, string number)
        {
            Id = Guid.NewGuid();
            TypeId = typeId;
            Name = name;
            Description = description;
            Number = number;
        }
        
        public GovernmentDocument() { }
    }
}
