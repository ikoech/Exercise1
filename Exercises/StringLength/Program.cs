//Exercise: Write a program that takes a string as input and outputs the length of the string. The program should also handle the case where the input is null or empty.
/*Console.Write("Enter a string: ");

string? input = Console.ReadLine();
if (input is null)
{
    Console.WriteLine("No input provided.");
}
else
{
    Console.WriteLine($"You entered: {input}");
    Console.WriteLine($" Length of the string is: {input.Length}.");
}*/
//END


//START
//Exercise: Write a program that takes two strings as input and compares their lengths. The program should output whether the strings are of equal length, and if not, which one is longer.

/*Console.Write("First string: ");
string first = Console.ReadLine() ?? string.Empty;

Console.Write("Second string: ");
string second = Console.ReadLine() ?? string.Empty;

int GetLength(string s)
{
    int count = 0;
    foreach (char c in s) count++;
    return count;
}

//string GetLongerString(string a, string b)
//{
//   return GetLength(a) >= GetLength(b) ? a : b;
//}
//Console.WriteLine($"First: {first} ({GetLength(first)} chars)");
//Console.WriteLine($"Second: {second} ({GetLength(second)} chars)");

// Check for equality and same length
if (first == second)
{
    Console.WriteLine("The length of both strings are equal and also, both \r\n strings are equal.\r\n");
}
else if (GetLength(first) == GetLength(second))
{
    Console.WriteLine("The two strings are different but have the same length.");
}
else
{
    Console.WriteLine("The two strings are different and have different lengths.");
}
//END
*/

//START
//Exercise: Write a program that takes a string as input and outputs each character of the string on a new line. The program should also handle the case where the input is null or empty.

/*Console.Write("Input the string: ");
string? input = Console.ReadLine();

if (string.IsNullOrEmpty(input))
{
    Console.WriteLine("No input provided.");
}
else
{
    Console.WriteLine("The characters of the string are:");
    foreach (char c in input)
    {
        Console.Write(c + " ");
    }
    Console.WriteLine();
}
END
*/


