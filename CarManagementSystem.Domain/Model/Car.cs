namespace CarManagementSystem.Domain.Model
{
    public class Car : BaseModel
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public DateTime ProductionDate { get; set; }

        public static Car CreateCar(string brand, string model, string registrationNumber, DateTime productionDate)
        {
            return new Car
            {
                Brand = brand,
                Model = model,
                RegistrationNumber = registrationNumber,
                ProductionDate = productionDate
            };
        }

        public void UpdateCar(string brand, string model, string registrationNumber, DateTime productionDate)
        {
            Brand = brand;
            Model = model;
            RegistrationNumber = registrationNumber;
            ProductionDate = productionDate;
        }
    }
}