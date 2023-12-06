using System;

class RadixSortt
{
    static int GetDigit(int number, int position)
    {
        return (number / (int)Math.Pow(10, position)) % 10;
    }

    static int FindMax(int[] array)
    {
        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
        return max;
    }

    static void RadixSort(int[] array)
    {
        int max = FindMax(array);
        for (int position = 0; max / (int)Math.Pow(10, position) > 0; position++)
        {
            CountingSort(array, position);
            Console.WriteLine($"Vuelta {position + 1}: ");
            PrintArray(array);
        }
    }

    static void CountingSort(int[] array, int position)
    {
        int[] output = new int[array.Length];
        int[] count = new int[10];

        for (int i = 0; i < 10; i++)
        {
            count[i] = 0;
        }

        for (int i = 0; i < array.Length; i++)
        {
            count[GetDigit(array[i], position)]++;
        }

        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        for (int i = array.Length - 1; i >= 0; i--)
        {
            output[count[GetDigit(array[i], position)] - 1] = array[i];
            count[GetDigit(array[i], position)]--;
        }

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = output[i];
        }
    }

    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int[] array = { 170, 45, 75, 90, 802, 24, 2, 66 };
        Console.WriteLine("Array original:");
        PrintArray(array);

        RadixSort(array);

        Console.WriteLine("\nArray ordenado:");
        PrintArray(array);
    }
}
