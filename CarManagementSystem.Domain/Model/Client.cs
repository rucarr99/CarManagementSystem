namespace CarManagementSystem.Domain.Model
{
    public class Client : BaseModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public List<Car> Cars { get; set; } = new();

        public static Client CreateClient(string firstName, string lastName, string email, string phoneNumber,
            List<Car> cars)
        {
            return new Client
            {
                FirstName = firstName,
                Cars = cars,
                Email = email,
                LastName = lastName,
                PhoneNumber = phoneNumber
            };
        }

        public void UpdateClient(string firstName, string lastName, string email, string phoneNumber,
            List<Car> cars)
        {
            FirstName = firstName;
            Cars = cars;
            Email = email;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
    }
}