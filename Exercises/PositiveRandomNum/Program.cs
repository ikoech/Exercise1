using System;

// Program 'random_numbers' - reads a positive integer N and generates N random numbers in [1,100]
Console.Write("Enter a positive integer N: ");
if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
{
    Console.WriteLine("Invalid input. Please run the program again and enter a positive integer.");
    return;
}

var rnd = new Random();
int sum = 0;
int min = 101;
int max = 0;

Console.WriteLine();
// Generate and print numbers on a single line
for (int i = 0; i < n; i++)
{
    int value = rnd.Next(1, 101); // [1,100]
    sum += value;
    if (value < min) min = value;
    if (value > max) max = value;
    Console.Write(value);
    if (i < n - 1) Console.Write(" ");
}

Console.WriteLine();
double average = (double)sum / n;
Console.WriteLine($"Average: {average:F2}");
Console.WriteLine($"Min: {min}");
Console.WriteLine($"Max: {max}");
