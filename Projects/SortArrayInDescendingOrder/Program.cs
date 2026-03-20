/*
 * Method 1:
 * Using Array.Sort() and Array.Reverse() Method
 * First, sort the array using Array.Sort() method which sorts an array ascending order then, 
 * reverse it using Array.Reverse() method.
*/
Console.Write("\nSort Array Sort: "); // print a new line after printing all element of array
int[] arraySort = new int[] {1,2,3,4,5}; // declaring and initializing the array 
Array.Sort(arraySort);                   // Sort array in ascending order. 
Array.Reverse(arraySort);                // Reverse the array to get it in descending order.

foreach (int arrayValue in arraySort)    // Loop through the array and print each element.
{
    Console.Write(arrayValue + " ");     // print all element of array 
}

/*
 * Method 2: 
 * Using CompareTo() Method
 * You can also sort an array in decreasing order by using CompareTo() method.
 */
Console.Write("\nCompareTo Array Sort: ");              // print a new line after printing all element of array
int[] arrayCompareTo = new int[] {6,7,8};               // declaring and initializing the array
Array.Sort(arrayCompareTo, (a, b) => b.CompareTo(a));   // Sort the arr from last to first. compare every element to each other 
foreach (int arrayValue in arrayCompareTo)              // Loop through the array and print each element.
{
    Console.Write(arrayValue + " ");                    // print all element of array 
}
/*Method 3: 
 * Using delegate
 * Here, first Sort() the delegate using an anonymous method
*/
Console.Write("\nDelegate Array Sort: "); // print a new line after printing all element of array
int[] arrayDelegate = new int[] {9,10,11};            // declaring and initializing the array
Array.Sort(arrayDelegate, delegate (int a, int b)     // Sort the arr from last to first. compare every element to each other

{
    return b.CompareTo(a); 
}); 
foreach (int arrayValue in arrayDelegate)             // Loop through the array and print each element.
{
    Console.Write(arrayValue + " ");                 // print all element of array 
}

/*
 * Method 4:
 * Using LINQ OrderByDescending() Method
 * You can also sort an array in decreasing order by using LINQ OrderByDescending() method.
 */
Console.Write("\nLinq Array Sort: "); // print a new line after printing all element of array

int[] arrayLinq = new int[] {12,13,14,15};          // declaring and initializing the array
arrayLinq.OrderByDescending(x => x)                 // Sort the arr from last to first. compare every element to each other
         //.ToArray() 
         .ToList()                                  // Convert the sorted array to a array.
         .ForEach(x => Console.Write(x + " "));     // Loop through the list and print each element.

/*
 * Method 4: Using Iterative way
 * Sort an array without using any inbuilt function by iterative way.
 */
Console.Write("\nIterative Array Sort: ");                     // print a new line after printing all element of array

int[] arrayIterative = new int[] {16,17,18,19,20};              // declaring and initializing the array
int tempArray;

for (int i = 0; i < arrayIterative.Length - 1; i++)             // traverse 0 to array length 
{
    for (int j = 1 + i; j < arrayIterative.Length; j++)         // traverse i+1 to array length 
    {
        if (arrayIterative[i] < arrayIterative[j])              // compare array element with and all next element 
        {
            tempArray = arrayIterative[i];
            arrayIterative[i] = arrayIterative[j];
            arrayIterative[j] = tempArray;
        }
    }
}
foreach (int arrayValue in arrayIterative)                      // Loop through the array and print each element.
{
    Console.Write(arrayValue + " ");                            // print all element of array 
}