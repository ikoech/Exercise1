using System.Text.RegularExpressions;

// Program: Multiple small string exercises collected in one file.
// Select one exercise from the menu below to run. Each exercise
// is implemented in its own local function to avoid running them
// all together.
Console.WriteLine("Choose an exercise to run:");
Console.WriteLine("1) String length");
Console.WriteLine("2) Compare two strings (length)");
Console.WriteLine("3) Print characters of a string");
Console.WriteLine("4) Count alphabets/digits/special (Regex)");
Console.WriteLine("5) Most frequent character");
Console.Write("Enter choice (1-5): ");
string? choice = Console.ReadLine();

// Run only the selected exercise
switch (choice)
{
    case "1": Exercise1_Length(); break;
    case "2": Exercise2_CompareLengths(); break;
    case "3": Exercise3_PrintCharacters(); break;
    case "4": Exercise4_CountWithRegex(); break;
    case "5": Exercise5_MostFrequentChar(); break;
    default: Console.WriteLine("No valid choice selected."); break;
}

// Exercise 1: string length
// - Prompts the user for a string and prints its length.
// - Handles null/empty input with a message.
void Exercise1_Length()
{
    Console.Write("Enter a string: ");
    string? input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
    {
        // no input provided (null or empty)
        Console.WriteLine("No input provided.");
    }
    else
    {
        // show the entered text and its Length property
        Console.WriteLine($"You entered: {input}");
        Console.WriteLine($"Length of the string is: {input.Length}.");
    }
}

// Exercise 2: compare two strings by length
// - Reads two strings and compares their content and lengths.
// - Uses a manual GetLength helper (counts chars) to avoid relying on
//   any external helper — this matches earlier exercises.
void Exercise2_CompareLengths()
{
    Console.Write("First string: ");
    string first = Console.ReadLine() ?? string.Empty;

    Console.Write("Second string: ");
    string second = Console.ReadLine() ?? string.Empty;

    // Manual length counter: iterates characters and increments a counter.
    int GetLength(string s)
    {
        int count = 0;
        foreach (char c in s) count++;
        return count;
    }

    if (first == second)
    {
        // strings are exactly equal (same characters in same order)
        Console.WriteLine("The length of both strings are equal and also both strings are equal.");
    }
    else if (GetLength(first) == GetLength(second))
    {
        // different content but same number of characters (code units)
        Console.WriteLine("The two strings are different but have the same length.");
    }
    else
    {
        Console.WriteLine("The two strings are different and have different lengths.");
    }
}

// Exercise 3: print characters
// - Prints each character of a string separated by spaces.
// - Preserves the input order. Skips when input is empty.
void Exercise3_PrintCharacters()
{
    Console.Write("Input the string: ");
    string? input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("No input provided.");
        return;
    }
    Console.WriteLine("The characters of the string are:");
    bool first = true;
    foreach (char c in input)
    {
        if (!first) Console.Write(' ');
        Console.Write(c);
        first = false;
    }
    Console.WriteLine();
}

// Exercise 4: count alphabets, digits, special using Regex
// - Uses regular expressions to count character categories.
// - Note: the special-character pattern counts whitespace as special;
//   change to "[^A-Za-z0-9\\s]" to exclude spaces if desired.
void Exercise4_CountWithRegex()
{
    Console.Write("Input the string: ");
    string strInput = Console.ReadLine() ?? string.Empty;

    // Count alphabetic characters (A-Z and a-z)
    int alphabets = Regex.Matches(strInput, "[A-Za-z]").Count;
    // Count digit characters (0-9)
    int digit = Regex.Matches(strInput, "\\d").Count;
    // Count everything that is not alphanumeric (includes spaces/punctuation)
    int specialChar = Regex.Matches(strInput, "[^A-Za-z0-9]").Count;

    Console.WriteLine("Number of Alphabets in the string is: {0}", alphabets);
    Console.WriteLine("Number of Digits in the string is: {0}", digit);
    Console.WriteLine("Number of Special characters in the string is: {0}", specialChar);
}

// Exercise 5: most frequent character (original algorithm, no Dictionary)
// - Finds the character that occurs most often using repeated Replace.
// - Note: this algorithm mutates the working string `text` as it counts
//   and therefore removes counted characters to avoid double counting.
// - Tie behavior: the first-seen character wins because we use '>' when
//   updating the max; change to '>=' to prefer the last-seen on ties.
void Exercise5_MostFrequentChar()
{
    Console.Write("Enter an input string: ");
    string text = Console.ReadLine() ?? string.Empty;

    string mostFrequentChar = string.Empty;
    int maxCount = 0;

    // Iterate through the string, count occurrences of each character and track the most frequent one
    for (int index = 0; index < text.Length; index++)
    {
        char currentChar = text[index];
        string remaining = text.Replace(currentChar.ToString(), "");

        int currentCount = text.Length - remaining.Length;
        // If the current character's occurrence count (currentCount) is greater than the highest seen so far (maxCount), update the most frequent character and the max count.
        if (currentCount > maxCount)
        {
            mostFrequentChar = currentChar.ToString();
            maxCount = currentCount;
        }

        // Remove counted characters and continue with remaining
        text = remaining;
    }

    Console.WriteLine("The Highest frequency of character {0} appears number of\r\n times : {1}", mostFrequentChar, maxCount.ToString());
}
