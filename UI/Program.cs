class Program
{
    public static void Main(string[] args)
    {

        int[] numbers = { 19, 5, 42, 2, 77 };

        int result = sumTwoSmallestNumbers(numbers);

        Console.WriteLine(result);
    }





    public static int sumTwoSmallestNumbers(int[] numbers)
    {
        numbers = numbers.Where(x => x >= 0).ToArray();

        if (numbers.Length < 2)
            return 0;

        int smallest = int.MaxValue;
        int secondSmallest = int.MaxValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < smallest)
            {
                secondSmallest = smallest;
                smallest = numbers[i];
            }
            else if (numbers[i] < secondSmallest)
            {
                secondSmallest = numbers[i];
            }
        }

        int sum = smallest + secondSmallest;

        return sum;
    }
}
