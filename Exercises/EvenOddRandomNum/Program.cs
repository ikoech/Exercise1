Console.WriteLine("Hello, World!");

Console.WriteLine("oddpositive - generate a random number in [-10,10] and classify it as odd/even and positive/negative");

Random random = new Random();
int value = random.Next(-10, 11); // upper bound is exclusive, so use 11 to include 10

Console.WriteLine($"The generated number is {value}");

string parity = Math.Abs(value) % 2 == 1 ? "odd" : "even";
string sign;
if (value > 0)
    sign = "positive";
else if (value < 0)
    sign = "negative";
else
    sign = "neither positive nor negative";

Console.WriteLine($"{value} is {parity} and {sign}.");