Console.WriteLine("Random Sum - generate n random numbers in [1,100] and print their sum");
Console.Write("Enter n (number of random values to generate): ");

string? input = Console.ReadLine();
if (!int.TryParse(input, out int n) || n <= 0)
{
    Console.WriteLine("Invalid input. Please enter a positive integer.");
    return;
}

Random random = new Random();
long sum = 0;
Console.WriteLine($"Generating {n} random numbers in [1,100]:");
for (int i = 0; i < n; i++)
{
    int value = random.Next(1, 101); // upper bound is exclusive, so use 101 to include 100
    Console.WriteLine(value);
    sum += value;
}
