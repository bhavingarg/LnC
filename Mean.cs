using System;

class MyClass
{
    static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int n = input[0];
        int q = input[1];

        long[] array = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

        long[] prefixSum = new long[n + 1];
        prefixSum[0] = 0;

        for (int i = 1; i <= n; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + array[i - 1];
        }

        for (int i = 0; i < q; i++)
        {
            int[] range = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int left = range[0];
            int right = range[1];

            long sum = prefixSum[right] - prefixSum[left - 1];
            long length = right - left + 1;

            Console.WriteLine(sum / length);
        }
    }
}
