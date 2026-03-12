using System;

int trials = 10000;
int[] counts = new int[13]; // indices 0..12, we'll use 2..12
Random rnd = new Random();

for (int i = 0; i < trials; i++)
{
    int d1 = rnd.Next(1, 7); // 1..6
    int d2 = rnd.Next(1, 7);
    counts[d1 + d2]++;
}

Console.WriteLine($"Frequency table (sum,count) for rolling two dices {trials} times:");
for (int sum = 2; sum <= 12; sum++)
{
    Console.WriteLine($"{sum} - {counts[sum]}");
}
