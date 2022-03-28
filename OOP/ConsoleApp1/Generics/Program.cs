// See https://aka.ms/new-console-template for more information
using Generics;

int[] days = new int[] { 11, 12, 13, 14 };
Console.WriteLine(String.Join(",", days));
int largestDayPosition = ArrayUtilities.FindLargestIndex(days);

Console.WriteLine(days[largestDayPosition]);

double[] temperatures = new double[] { 24.12, 17.6, 7.46, 10.8, 11.3 };
Console.WriteLine(String.Join(",", temperatures));
int largestTemperaturePosition = ArrayUtilities.FindLargestIndex(temperatures);
Console.WriteLine(temperatures[largestTemperaturePosition]);
