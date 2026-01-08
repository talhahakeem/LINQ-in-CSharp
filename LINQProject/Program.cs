using System;

namespace LinqProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 21, 56, 45, 23, 78, 34, 89, 66, 77, 89, 34, 56, 99, 88, 78 };

            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 40)
                    count++;
            }

            int[] brr = new int[count];
            int index = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 40)
                {
                    brr[index] = arr[i];
                    index++;
                }
            }

            Array.Sort(brr);
            Array.Reverse(brr);

            foreach (int num in brr)
            {
                Console.Write(num + " ");
            }
            Console.ReadLine();
        }
    }
}
