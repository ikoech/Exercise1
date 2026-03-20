var carsList = new List<Car>();
while (true)
{
    Console.Write("Enter car Brand: ");
    string brand = Console.ReadLine() ?? string.Empty;
    if (brand.ToLower().Trim() == "exit")
    {
        break;
    }
    Console.Write("Enter car Model: ");
    string model = Console.ReadLine() ?? string.Empty;
    Console.Write("Enter Year: ");
    int year = int.Parse(Console.ReadLine());
    Console.Write("Enter Speed: ");
    int speed = int.Parse(Console.ReadLine());

    //Car carObject = new Car(brand, model, year, speed);
    //carsList.Add(carObject);

    carsList.Add(new Car(brand, model, year, speed));


}

foreach (Car car in carsList)
{
    Console.WriteLine($"{car.Brand} {car.Model} {car.Year} {car.Speed}");
}



class Car
{
    public Car(string brand, string model, int year, int speed)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Speed = speed;
    }

    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int Speed { get; set; }
}

/*
 * 
var carsList = new List<Car>();
while (true)
{
    Console.Write("Enter car Brand: ");
    string brand = Console.ReadLine();
    if (brand.ToLower().Trim() == "exit") 
    {
        break;
    }
    Console.Write("Enter car Model: ");
    string model = Console.ReadLine() ?? string.Empty;
    Console.Write("Enter Year: ");
    int year = int.Parse(Console.ReadLine());
    Console.Write("Enter Speed: ");
    int speed = int.Parse(Console.ReadLine());

    //Car carObject = new Car(brand, model, year, speed);
    //carsList.Add(carObject);

    carsList.Add(new Car(brand, model, year, speed));


}

//Car car1 = new Car("Toyota", "Corolla");
//car1.Year = null;

Car car1 = new Car("Toyota", "Auris", 2020, 220 );
car1.Passenger = new List<string> { "John", "Alice", "Bob" };
carsList.Add(car1);

Car car2 = new Car("Honda", "Civic", 2019, 210, new List<string> { "David", "Emma" });
carsList.Add(car2);



foreach (Car car in carsList)
{
    Console.WriteLine($"{car.Brand} {car.Model} {car.Year} {car.Speed}");
}



class Car
{
    public Car(string brand, string model)
    {
        Brand = brand;
        Model = model;
    }

    public Car(string brand, string model, int year, int speed)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Speed = speed;
    }

    public Car(string brand, string model, int? year, int speed, List<string> passenger) : this(brand, model)
    {
        Year = year;
        Speed = speed;
        Passenger = passenger;
    }

    public string Brand { get; set; } 
    public string Model { get; set; } 
    public int? Year { get; set; }  // int? means that the Year property can hold either an integer value or null, allowing for cases where the year of the car is unknown or not applicable.
    public int Speed { get; set; } 
    //public bool isTrue { get; set; }
    public List<string> Passenger { get; set; }
    //public string[] Passenger { get; set; }

}

 */