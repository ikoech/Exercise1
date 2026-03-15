using System.Collections;
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
Console.WriteLine("6) Sort the sting input without using built-in Sort method");
Console.WriteLine("7) Extract a sub-string from a given string without using the library function ");
Console.WriteLine("8) Check whether a given substring is present in the given string.");
Console.WriteLine("9) Replace lowercase characters by uppercase and vice-versa.");
Console.WriteLine("10) Search the position of a substring within a string");
Console.WriteLine("11) Find the number of times a specific string appears in a string");
Console.WriteLine("12) Insert a substring before the first occurrence of a string");
Console.WriteLine("13) Get the palindromic substrings from a given string");
Console.WriteLine("14) Remove duplicate characters from a given string");
Console.WriteLine("15) Finds the given two texts are anagram between them nor not");
Console.Write("Enter choice (1-15): ");

// Run only the selected exercise
string? choice = Console.ReadLine();
switch (choice)
{
    case "1": Exercise1_Length(); break;
    case "2": Exercise2_CompareLengths(); break;
    case "3": Exercise3_PrintCharacters(); break;
    case "4": Exercise4_CountWithRegex(); break;
    case "5": Exercise5_MostFrequentChar(); break;
    case "6": Exercise6_SortStringWithoutSortMethod(); break;
    case "7": Exercise7_ExtractSubStringFromGivenString(); break;
    case "8": Exercise8_CheckSubstringIsInGivenString(); break;
    case "9": Exercise9_ReplaceLowerAndUppercaseString(); break;
    case "10": Exercise10_SearchSubstringPositionInaString(); break;
    case "11": Exercise11_FindStringAppersInaString(); break;
    case "12": Exercise12_InsertSubstringB41stOccurrenceString(); break;
    case "13": Exercise13_GetPalindromicSubstringsFromGivenString(); break;
    case "14": Exercise14_RemoveDuplicateCharacters(); break;
    case "15": Exercise15_CheckAnagram(); break;

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
// Exercise 6: Sort user-provided strings without using built-in Sort
// - Prompts the user for the number of strings `n` and then reads `n` lines.
// - Uses a simple comparison-based nested loop (swap when out of order)
//   to sort the array in ascending ordinal order (case-sensitive).
// - This is an O(n^2) in-place algorithm (suitable for small `n`).
// - Notes:
//   * Sorting uses `StringComparison.Ordinal` (bytewise comparison). Use
//     `StringComparison.OrdinalIgnoreCase` if you want case-insensitive sort.
//   * Duplicate strings are preserved; the algorithm is stable enough
//     for this use (relative order of equal strings is unchanged).
//   * Input validation ensures a positive integer is provided for `n`.
void Exercise6_SortStringWithoutSortMethod()
{
    Console.Write("Enter number of strings: ");
    if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
    {
        Console.WriteLine("Invalid number.");
        return;
    }

    Console.WriteLine($"Input {n} strings below :");
    string[] arrayList = new string[n];
    for (int i = 0; i < n; i++)
    {
        Console.Write($"String {i + 1}: ");
        arrayList[i] = Console.ReadLine() ?? string.Empty;
    }

    string temp = string.Empty;
    for (int i = 0; i < arrayList.Length; i++)
    {
        for (int j = i + 1; j < arrayList.Length; j++)
        {
            if (string.Compare(arrayList[i], arrayList[j], StringComparison.Ordinal) > 0)
            {
                temp = arrayList[i];
                arrayList[i] = arrayList[j];
                arrayList[j] = temp;
            }
        }
    }

    Console.WriteLine("After sorting the array appears like : \r\n");
    foreach (var item in arrayList)
    {
        Console.WriteLine(item);
    }
}

// Exercise 7: extract a substring without using built-in Library functions
// - Reads a source string from the user
// - Asks for a 1-based start position and a desired length
// - Validates inputs and prints the substring by iterating characters
// Note: this implementation does not use string.Substring and performs
//       manual extraction so the behaviour is explicit and easy to follow.
void Exercise7_ExtractSubStringFromGivenString()
{
    Console.Write("\n\nExtract a substring from a given string:\n");

    Console.Write("Input the string: ");
    string source = Console.ReadLine() ?? string.Empty;
    if (source.Length == 0)
    {
        Console.WriteLine("No input provided.");
        return;
    }

    // Ask for 1-based start position
    Console.Write("Input the position to start extraction (1-based): ");
    if (!int.TryParse(Console.ReadLine(), out int start) || start < 1 || start > source.Length)
    {
        Console.WriteLine("Invalid start position.");
        return;
    }

    // Ask for length of substring
    Console.Write("Input the length of substring: ");
    if (!int.TryParse(Console.ReadLine(), out int length) || length < 0)
    {
        Console.WriteLine("Invalid length.");
        return;
    }

    // Adjust length if requested substring would exceed source length
    int maxAvailable = source.Length - (start - 1);
    if (length > maxAvailable)
    {
        length = maxAvailable; // truncate to available characters
    }

    // Extract and print characters manually (no Substring)
    Console.Write("The substring retrieved from the string is: ");
    for (int i = 0; i < length; i++)
    {
        Console.Write(source[start - 1 + i]);
    }
    Console.WriteLine();
}

// Exercise 8: check whether a given substring appears in a source string
// - Prompts the user for a source string and then a substring to search for.
// - Uses `string.Contains(..., StringComparison.OrdinalIgnoreCase)` so the
//   check is case-insensitive. To perform a case-sensitive search, change
//   to `StringComparison.Ordinal` or remove the comparison parameter.
// - Handles empty source input by aborting early with a message.
// - Note: the entered substring is used as-is (no trimming); you may want
//   to call `Trim()` if you expect accidental leading/trailing spaces.
void Exercise8_CheckSubstringIsInGivenString()
{
    string? source, substring;

    Console.Write("\n\nCheck a substring from a given string:\n");
    Console.Write("Input the string: ");

     source = Console.ReadLine() ?? string.Empty;
    if (source.Length == 0)
    {
        Console.WriteLine("No input provided.");
        return;
    }

    // Ask for 1-based start position
    Console.Write("Input the position to start extraction (1-based): ");
        substring = Console.ReadLine() ?? string.Empty;

    bool result = source.Contains(value: substring, StringComparison.OrdinalIgnoreCase);

    Console.WriteLine(result ? $"The substring '{substring}' is present in the string." : $"The substring '{substring}' is not present in the string.");
}

// Exercise 9: swap lowercase and uppercase letters in a string
// - Reads a source string from the user and produces a new string
//   where each lowercase letter becomes uppercase and each uppercase
//   letter becomes lowercase. Non-letter characters are preserved.
// - Uses ASCII-range checks ('a'-'z' and 'A'-'Z') and `char.ToUpper`/`ToLower`.
// - Validation: empty input prints a message and returns early.
void Exercise9_ReplaceLowerAndUppercaseString()
{
    string? source;
    string results = string.Empty;

    Console.Write("\n\nCheck a substring from a given string:\n");
    Console.Write("Input the string: ");

    source = Console.ReadLine() ?? string.Empty;
    if (source.Length == 0)
    {   
        Console.WriteLine("No input provided.");
        return;
    }

    char[] charArr = source.ToCharArray();

    for (int i = 0; i < charArr.Length; i++)
    {
        if (charArr[i] >= 'a' && charArr[i] <= 'z')
        {
            results += char.ToUpper(charArr[i]);
        }
        else if (charArr[i] >= 'A' && charArr[i] <= 'Z')
        {
            results += char.ToLower(charArr[i]);
        }
        else
        {
            results += charArr[i];
        }
    }

    Console.WriteLine(results);
}

// Exercise 10: find the position of a substring inside a source string
// - Prompts for a source string and a substring to search for.
// - Uses `IndexOf` which returns a 0-based index, or -1 if not found.
// - The search is case-sensitive; use an overload with StringComparison
//   for case-insensitive lookup if needed.
void Exercise10_SearchSubstringPositionInaString()
{
    string source, substring;
    Console.WriteLine("Search the position of an substring in a string:");
    Console.WriteLine("Enter the string");

    source = Console.ReadLine() ?? string.Empty;

    Console.WriteLine("Enter the SubString");

    substring = Console.ReadLine() ?? string.Empty;
    int index = source.IndexOf(substring);
    if (index < 0)
    {
        Console.WriteLine("there is no substring find in the string");

    }
    else
        Console.WriteLine("the string {0} found substring of {1} at  position {2}", source, substring, index);
}

// Exercise 11: Find the number of times a substring appears in a given string.
// Prompt the user to input the string to be searched for
// Loop to count occurrences of the findstring in the original string
// Find the index of the findstring in the original string after the last found index
// Increment the count of occurrences and update the last found index
// Display the count of occurrences of the findstring in the original string
void Exercise11_FindStringAppersInaString()
{
    string source, findstring;
    int initialString = 0; 
    int count = -1; 
    int index = -1;

    Console.Write("\n\nFind the number of times a specific string appears in a string:\n");
    Console.Write("Input the original string : ");

    source = Console.ReadLine() ?? string.Empty;

    Console.Write("Input the string to be searched for : ");
    findstring = Console.ReadLine()?? string.Empty;

    while (initialString != -1)
    {
        initialString = source.IndexOf(findstring, index + 1);

        count += 1;
        index = initialString;
    }

    Console.Write("The string '{0}' occurs " + count + " times.\n", findstring);

}

//Exercise 12: Insert a substring before the first occurrence of a string.
// Prompt the user to input the original string and the string to be inserted
// Locate the position of the first occurrence of the string to be found
// Modify the insert string for formatting purposes
// Insert the insert string before the first occurrence of the found string
// Display the modified string
void Exercise12_InsertSubstringB41stOccurrenceString()
{
    string input, indexString, newString;
    int count;

    Console.Write("\n\nInsert a substring before the first occurrence of a string :\n");
    Console.Write("Input the original string : ");
    input = Console.ReadLine() ?? string.Empty;

    Console.Write("Input the string to be searched for : ");
    indexString = Console.ReadLine() ?? string.Empty;

    Console.Write("Input the string to be inserted : ");
    newString = Console.ReadLine() ?? string.Empty;

    count = input.IndexOf(indexString);
    newString = " " + newString.Trim() + " ";
    input = input.Insert(count, newString);

    Console.Write("The modified string is : {0}\n\n", input);
}

// Exercise 13: find and display the longest palindromic substring
// - Uses the expand-around-center technique: for each character (and
//   between characters) it expands outward to find the longest palindrome
//   centered there. This is simple and runs in O(n^2) time in the worst case
//   and O(1) extra space (besides the output substring).
// - The helper `longest_Palindrome` returns the longest palindromic substring.
// - Example: input "babad" -> returns "bab" or "aba" (either is acceptable).
void Exercise13_GetPalindromicSubstringsFromGivenString()
{
    string str = "aaaaaabbbbccc";
    Console.WriteLine("Original String: " + str);

    Console.WriteLine("Longest palindromic substring:");
    Console.WriteLine(longest_Palindrome(str));
}

// Expand-around-center helper to compute longest palindromic substring
string longest_Palindrome(string stringLong)
{
    int start = 0, maxLength = 1;

    for (int index = 0; index < stringLong.Length; index++)
    {
        // Odd length palindromes (center at i)
        int left = index, right = index;
        while (left >= 0 && right < stringLong.Length && stringLong[left] == stringLong[right])
        {
            if (right - left + 1 > maxLength)
            {
                start = left;
                maxLength = right - left + 1;
            }
            left--;
            right++;
        }

        // Even length palindromes (center between i and i+1)
        left = index;
        right = index + 1;
        while (left >= 0 && right < stringLong.Length && stringLong[left] == stringLong[right])
        {
            if (right - left + 1 > maxLength)
            {
                start = left;
                maxLength = right - left + 1;
            }
            left--;
            right++;
        }
    }

    return stringLong.Substring(start, maxLength);
}


// Exercise 14: remove duplicate characters from a string, preserving smallest lexicographic order
// - Reads a sample string and prints the result after removing duplicate characters
//   such that the resulting string contains each character only once and is
//   the smallest in lexicographical order among all possible results.
// - Algorithm: greedy stack-based approach using last-index lookup and a stack
//   to build the result. Time O(n), extra space O(n).
void Exercise14_RemoveDuplicateCharacters()
{
    string originalString = "aaaaaabbbbccc";
    Console.WriteLine("Original String: " + originalString);

    Console.WriteLine("After removing duplicate characters from the said string:");
    Console.WriteLine(RemoveDuplicateChars(originalString));
}

string RemoveDuplicateChars(string input)
{
    var lastIndex = new Dictionary<char, int>();

    // Store the last index of each character
    for (int i = 0; i < input.Length; i++)
        lastIndex[input[i]] = i;

    var inResult = new HashSet<char>();
    var stack = new Stack<char>();

    for (int i = 0; i < input.Length; i++)
    {
        char ch = input[i];
        if (!inResult.Contains(ch))
        {
            // Remove elements from the stack that are greater than current and occur later in the string
            while (stack.Count > 0 && stack.Peek() > ch && i < lastIndex[stack.Peek()])
                inResult.Remove(stack.Pop());

            inResult.Add(ch);
            stack.Push(ch);
        }
    }

    var resultChars = new char[stack.Count];
    int idx = stack.Count - 1;

    // Reverse the stack content to restore original order
    foreach (var c in stack)
        resultChars[idx--] = c;

    return new string(resultChars);
}
// Exercise 15: check whether two strings are anagrams (simple brute-force)
// - Reads two input strings and determines whether they are anagrams by
//   comparing characters.
//   Count character frequencies (Dictionary) and compare the counts.
void Exercise15_CheckAnagram()
{
    Console.WriteLine("Program to find whether two strings are anagrams or not");
    Console.WriteLine();
    Console.Write("Enter the first string: ");
    string first = Console.ReadLine() ?? string.Empty;
    Console.Write("Enter the second string: ");
    string second = Console.ReadLine() ?? string.Empty;

    int len1 = first.Length;
    int len2 = second.Length;

    // Quick rejection: different lengths cannot be anagrams
    if (len1 != len2)
    {
        Console.WriteLine($"The strings '{first}' and '{second}' are not anagrams (different length). ");
        return;
    }

    char[] firstChars = first.ToCharArray();
    char[] secondChars = second.ToCharArray();

    int matchCount = 0;
    for (int i = 0; i < len1; i++)
    {
        for (int j = 0; j < len2; j++)
        {
            if (firstChars[i] == secondChars[j])
            {
                matchCount++;
            }
        }
    }

    if (matchCount == len1)
        Console.WriteLine($"The strings '{first}' and '{second}' are anagrams");
    else
        Console.WriteLine($"The strings '{first}' and '{second}' are not anagrams");
}
