using System;

// Short Name - read given name and family name, then print a short name
// Format: first initial + ". " + first four letters of last name (or whole last name if shorter)

Console.Write("First name: ");
string firstName = Console.ReadLine() ?? string.Empty;
Console.Write("Last name: ");
string lastName = Console.ReadLine() ?? string.Empty;

firstName = firstName.Trim();
lastName = lastName.Trim();

string initial = firstName.Length > 0 ? firstName[0].ToString() : string.Empty;
string lastPart = lastName.Length <= 4 ? lastName : lastName.Substring(0, 4);

Console.WriteLine($"Short name: {initial}. {lastPart}");
