using System.Collections.Generic;
using System.Reflection;
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
        var vehiclePriceQuery = (from v in vehicles
                                where v.Price > 1000000
                                select v).ToList();
        Display(vehiclePrice);
        Console.WriteLine();
        Display(vehiclePriceQuery);
        Console.WriteLine();

        //  Retrieve vehicle models along with their fuel types.
        var modelFuelTypes = vehicles.Select(v => (v.Model, string.Join(", ", v.FuelTypes))).ToList();
        var modelFuelTypesQuery = (from v in vehicles
                                  select new
                                  {
                                      Model = v.Model,
                                      FuelTypes = string.Join(", ", v.FuelTypes)
                                  }).ToList();
        Display(modelFuelTypes);
        Console.WriteLine();
        Display(modelFuelTypesQuery);
        Console.WriteLine();

        //  Retrieve all unique fuel types.
        List<string> uniqueFuelTypes = vehicles.SelectMany(v => v.FuelTypes).Distinct().ToList();
        var uniqueFuelTypesQuery = (from v in vehicles
                                    from fuelType in v.FuelTypes
                                    select fuelType).Distinct().ToList();
        Display(uniqueFuelTypes);
        Console.WriteLine();
        Display(uniqueFuelTypesQuery);
        Console.WriteLine();

        //  Find the vehicle with the highest and lowest price.
        //var HighestPrice = (from v in vehicles select v).Max(e => e.Price);
        var vehiclesSorted = vehicles.OrderByDescending(v => v.Price);
        var vehiclesSortedQuery = (from v in vehicles
                                   orderby v.Price
                                   select v).ToList();

        var highestPriceVehicle = vehiclesSorted.First();
        Console.WriteLine(highestPriceVehicle);

        var lowestPriceVehicle = vehiclesSorted.Last();
        Console.WriteLine(lowestPriceVehicle);
        Console.WriteLine();

        var highestPriceVehicleQuery = vehiclesSortedQuery.First();
        Console.WriteLine(highestPriceVehicle);

        var lowestPriceVehicleQuery = vehiclesSortedQuery.Last();
        Console.WriteLine(lowestPriceVehicle);
        Console.WriteLine();

        //  Group vehicles by brand.
        var groupedVehicles = vehicles.GroupBy(v => v.Brand).ToList();
        var groupedVehiclesQuery = (from v in vehicles
                                    group v by v.Brand into car
                                    select new
                                    {
                                        Key = car.Key,
                                        Cars = car
                                    }).ToList();

        foreach (var group in groupedVehicles)
        {
            Console.WriteLine($"Brand: {group.Key}");
            foreach (var v in group)
            {
                Console.WriteLine($"{v}");
            }
        }
        Console.WriteLine();

        foreach(var group in groupedVehiclesQuery)
{
            Console.WriteLine($"Brand: {group.Key}");
            foreach (var v in group.Cars) // Iterate over Models instead of group
            {
                Console.WriteLine($"Model: {v}");
            }
        }
        Console.WriteLine();

        //  Count vehicles available in each brand.
        var brandCarCount = groupedVehicles.Select(group => new { Brand = group.Key, Count = group.Count() }).ToList();
        var brandCarCountQuery = (from v in groupedVehiclesQuery
                                 select new
                                 {
                                     Brand = v.Key,
                                     Count = v.Cars.Count()
                                 }).ToList();
        Display(brandCarCount);
        Console.WriteLine();
        Display(brandCarCountQuery);
        Console.WriteLine();

        //  Retrieve vehicles with missing price values.
        var nullPrice = vehicles.Where(v => v.Price == null).ToList();
        var nullPriceQuery = (from v in vehicles
                         where v.Price == null
                         select v).ToList();

        Display(nullPrice);
        Console.WriteLine();
        Display(nullPriceQuery);
        Console.WriteLine();

        //  Sort vehicles by price, then by brand.
        var vehiclesSortPriceBrand = vehicles.OrderBy(v => v.Price).ThenBy(v => v.Brand).ToList();
        var vehiclesSortPriceBrandQuery = (from v in vehicles
                                           orderby v.Price, v.Brand
                                           select v).ToList();

        Display(vehiclesSortPriceBrand);
        Console.WriteLine();
        Display(vehiclesSortPriceBrandQuery);
        Console.WriteLine();

        //  Find the average price of vehicles in each brand.
        var avgPrice = groupedVehicles
            .Select(group => new
            {
                Brand = group.Key,
                AveragePrice = group.Where(v => v.Price != null).Any() ? group.Where(v => v.Price != null).Average(v => v.Price) : 0
            }).ToList();
        var avgPricesQuery = (from v in groupedVehiclesQuery
                              select new
                              {
                                  brandName = v.Key,
                                  avgPrice = v.Cars.Average(c => c.Price)
                              }).ToList();

        Display(avgPrice);
        Console.WriteLine();
        Display(avgPricesQuery);
        Console.WriteLine();

        //  Find the brand with the highest number of vehicles.
        var brandCount = brandCarCount.Max(v => v.Count);
        var brandCountQuery = brandCarCountQuery.Max(v => v.Count);


        var brandWithMaxCount = brandCarCount.Where(v => v.Count == brandCount).ToList();
        var brandWithMaxCountQuery = (from v in brandCarCount
                                where v.Count == brandCountQuery
                                select v).ToList();


        Display(brandWithMaxCount);
        Console.WriteLine();
        Display(brandWithMaxCountQuery);
        Console.WriteLine();
    }
}