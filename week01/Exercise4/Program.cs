using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());

        while (number != 0)
        {
            numbers.Add(number);

            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
        }

        int sum = 0;
        int max = numbers[0];
        int smallestPositive = int.MaxValue;

        foreach (int n in numbers)
        {
            sum += n;

            if (n > max)
            {
                max = n;
            }

            if (n > 0 && n < smallestPositive)
            {
                smallestPositive = n;
            }
        }

        double average = (double)sum / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        numbers.Sort();

        Console.WriteLine("The sorted list is:");
        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}