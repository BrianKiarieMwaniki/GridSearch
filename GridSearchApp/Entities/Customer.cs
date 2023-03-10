namespace GridSearchApp.Entities
{
    public class Customer
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? City  { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }   
        
        public string? FullName { get => $"{FirstName} {LastName}"; }
    }
}
