// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Sets!");


var toyotaCorolla = new Car() { Brand = "Toyota", Model = "Corolla", UserRanking = 74 };
var mazda3 = new Car() { Brand = "Mazda", Model = "3", UserRanking = 87 };
var skodaOctavia = new Car() { Brand = "Skoda", Model = "Octavia", UserRanking = 63 };
var skodaSuperb = new Car() { Brand = "Skoda", Model = "Superb", UserRanking = 95 };
var audiQ5 = new Car() { Brand = "Audi", Model = "Q5", UserRanking = 90 };


var testSet = new SortedSet<Car>();
testSet.Add(toyotaCorolla);
testSet.Add(mazda3);


var allCars = new SortedSet<Car>() { toyotaCorolla, mazda3, skodaOctavia, skodaSuperb, audiQ5 };

var efficientCars = new SortedSet<Car>(){toyotaCorolla, skodaOctavia};

var familyCars = new SortedSet<Car>() { toyotaCorolla, skodaOctavia, skodaSuperb, audiQ5 };

Console.WriteLine(efficientCars.IsSubsetOf(allCars));
Console.WriteLine(efficientCars.Overlaps(familyCars));

Console.WriteLine(allCars.Max.ToString());
Console.WriteLine(allCars.Min.ToString());

public class Car : IComparable<Car>
{
    public string Brand { get; init; }
    public string Model { get; init; }
    public int UserRanking { get; init; }
    public int CompareTo(Car? obj)
    {
        return UserRanking.CompareTo(obj.UserRanking);
    }

    public override string ToString()
    {
        return $"{Brand} {Model}  Rank: {UserRanking}";
    }
}

