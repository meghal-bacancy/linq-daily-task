using System.Collections.Generic;
using day1;

class Program
{
    public static void Display<T>(List<T> list)
    {
        foreach (T item in list)
        {
            Console.WriteLine(item);
        }
    }

    static void Main(string[] args)
    {
        List<Vehicle> vehicles = Vehicle.GetVehicles();

        // Get vehicles costing more than 1,000,000.
        var vehiclePrice = vehicles.Where(v => v.Price > 1000000).ToList();
        Display(vehiclePrice);
        Console.WriteLine();

        //  Retrieve vehicle models along with their fuel types.
        var modelFuelTypes = vehicles.Select(v => (v.Model, string.Join(", ", v.FuelTypes))).ToList();
        Display(modelFuelTypes);
        Console.WriteLine();

        //  Retrieve all unique fuel types.
        List<string> uniqueFuelTypes = vehicles.SelectMany(v => v.FuelTypes).Distinct().ToList();
        Display(uniqueFuelTypes);
        Console.WriteLine();

        //  Find the vehicle with the highest and lowest price.
        //var HighestPrice = (from v in vehicles select v).Max(e => e.Price);
        var vehiclesSorted = vehicles.OrderByDescending(v => v.Price);

        var highestPriceVehicle = vehiclesSorted.First();
        Console.WriteLine(highestPriceVehicle);

        var lowestPriceVehicle = vehiclesSorted.Last();
        Console.WriteLine(lowestPriceVehicle);
        Console.WriteLine();

        //  Group vehicles by brand.
        var groupedVehicles = vehicles.GroupBy(v => v.Brand).ToList();
        foreach (var group in groupedVehicles)
        {
            Console.WriteLine($"Brand: {group.Key}");
            foreach (var v in group)
            {
                Console.WriteLine($"{v}");
            }
        }
        Console.WriteLine();

        //  Count vehicles available in each brand.
        //var brandCar = vehiclesSorted.Count();
        var brandCarCount = groupedVehicles.Select(group => new { Brand = group.Key, Count = group.Count() });
        Display(brandCarCount.ToList());
        Console.WriteLine();

        //  Retrieve vehicles with missing price values.
        var nullPrice = vehicles.Where(v => v.Price == null).ToList();
        Display(nullPrice);
        Console.WriteLine();

        //  Sort vehicles by price, then by brand.
        var vehiclesSortPriceBrand = vehicles.OrderByDescending(v => v.Price).OrderBy(v => v.Brand).ToList();
        Display(vehiclesSortPriceBrand.ToList());
        Console.WriteLine();

        //  Find the average price of vehicles in each brand.
        var avgPrice = groupedVehicles
            .Select(group => new
            {
                Brand = group.Key,
                AveragePrice = group.Where(v => v.Price != null).Any() ? group.Where(v => v.Price != null).Average(v => v.Price) : 0
            }).ToList();
        Display(avgPrice);
        Console.WriteLine();

        //  Find the brand with the highest number of vehicles.
        var brandCount = groupedVehicles
            .Select(group => new
            {
                Brand = group.Key,
                count = group.Count()
            }).ToList();
        Display(brandCount);
        Console.WriteLine();
    }
}