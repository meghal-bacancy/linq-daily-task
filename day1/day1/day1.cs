namespace day1
{
    public class Vehicle
    {
        public int Id;
        public string Model;
        public string Brand;
        public double? Price;
        public List<string> FuelTypes;

        public Vehicle(int id, string model, string brand, double? price, List<string> fuelTypes)
        {
            Id = id;
            Model = model;
            Brand = brand;
            Price = price;
            FuelTypes = fuelTypes;
        }

        public static List<Vehicle> GetVehicles()
        {
            return new List<Vehicle>
            {
                new Vehicle(1, "Model S", "Tesla", 7999999.99, new List<string>{"Electric"}),
                new Vehicle(2, "Civic", "Honda", 25000, new List<string>{"Petrol", "Hybrid"}),
                new Vehicle(3, "Corolla", "Toyota", 2200000, new List<string>{"Petrol"}),
                new Vehicle(4, "Mustang", "Ford", 55000, new List<string>{"Petrol"}),
                new Vehicle(5, "Model X", "Tesla", 8999999.99, new List<string>{"Electric"}),
                new Vehicle(6, "Camry", "Toyota", null, new List<string>{"Hybrid", "Petrol"}),
                new Vehicle(7, "F-150", "Ford", 4000000, new List<string>{"Petrol", "Diesel"}),
                new Vehicle(8, "Accord", "Honda", 2800000, new List<string>{"Hybrid", "Petrol"}),
                new Vehicle(9, "Q5", "Audi", 50000, new List<string>{"Petrol", "Diesel"}),
                new Vehicle(10, "X5", "BMW", 65000, new List<string>{"Diesel", "Hybrid"}),
                new Vehicle(11, "A4", "Audi", 42000, new List<string>{"Petrol"}),
                new Vehicle(12, "3 Series", "BMW", 45000, new List<string>{"Diesel", "Petrol"}),
                new Vehicle(13, "Model 3", "Tesla", 39999.99, new List<string>{"Electric"}),
                new Vehicle(14, "Ranger", "Ford", null, new List<string>{"Diesel"}),
                new Vehicle(15, "Altima", "Nissan", 24000, new List<string>{"Petrol"}),
                new Vehicle(16, "Sentra", "Nissan", null, new List<string>{"Petrol"}),
                new Vehicle(17, "CX-5", "Mazda", 2900000, new List<string>{"Petrol", "Diesel"}),
                new Vehicle(18, "Outback", "Subaru", 32000, new List<string>{"Petrol"}),
                new Vehicle(19, "Forester", "Subaru", 31000, new List<string>{"Hybrid", "Petrol"}),
                new Vehicle(20, "Cherokee", "Jeep", 36000, new List<string>{"Diesel", "Petrol"})
            };
        }

        public override string ToString()
        {
            return $"{Id}, {Model}, {Brand}, {Price?.ToString() ?? "N/A"}, {string.Join("/", FuelTypes)}";
        }
    }   
}