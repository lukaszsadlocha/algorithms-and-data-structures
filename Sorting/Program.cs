// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

Console.WriteLine("Hello, Sorting World!");

int[] arrayToSort = { 8, 15, 3, 64, 32, 9, 66 };

PrintArray(arrayToSort, "Array to sort: ");

Console.WriteLine("BubbleSort");
PrintArray(BubbleSort(arrayToSort));

Console.WriteLine("InsertionSort");
PrintArray(InsertionSort(arrayToSort));


//Merge sort -> split and merge
//QuickSort -> find pivot point and put all elements on the left and right side

int[] InsertionSort(int[] originalArray)
{
    var array = GetArrayCopy(originalArray);

    var i = 0;
    while (i < array.Length - 1)
    {
        if (array[i] > array[i + 1])
        {

            var valueToInsert = array[i + 1];

            var moveValues = true;
            var j = i;
            while (j >= 0 && moveValues)
            {
                if (valueToInsert < array[j])
                {
                    array[j + 1] = array[j];
                    array[j] = valueToInsert;
                    j--;

                }
                else
                {
                    moveValues = false;
                }
            }
        }

        i++;
        PrintArray(array, $"[Iteration {i}]  ");
    }

    return array;
}

int[] BubbleSort(int[] originalArray)
{
    var array = GetArrayCopy(originalArray);

    var isSorted = false;

    while (!isSorted)
    {
        isSorted = true;// assume that table is sorted

        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] < array[i + 1]) continue;
            isSorted = false;
            (array[i], array[i + 1]) = (array[i + 1], array[i]);
        }
        //After iteration;
        PrintArray(array, $"[Next iteration]  ");
    }

    return array;
}

int[] GetArrayCopy(int[] originalArray)
{
    var array = new int[originalArray.Length];
    Array.Copy(originalArray, array, originalArray.Length);
    return array;
}
void PrintArray(int[] array, string s = "")
{

    Console.WriteLine(s + string.Join(',', array));
}