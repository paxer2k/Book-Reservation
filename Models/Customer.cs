namespace Models
{
    public class Customer
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }
        public string FirstName { get; }
        public string LastName { get; }
        public string EmailAddress { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public Customer(int id, string firstName, string lastName, string emailAddress)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }

        public Customer(string firstName, string lastName, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }

        public override string ToString()
        {
            return $"{FullName} ({EmailAddress})";
        }

    }
}
