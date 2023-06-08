using static System.Console;

var numbers = new int[] { 12, 34, 45, 55, 67, 78, 89, 99, 187, 245 };

do
{
    Write("What number are you looking for? ");
    var search = Convert.ToInt32(ReadLine());

    var position = BinarySearch(numbers, search, 0, numbers.Length - 1);
    WriteLine($">>> The number '{search}' is in the position '{position}'");
} while(true);



static int BinarySearch(int[] array, int search, int left, int right)
{
    while(left <= right)
    {
        var middle = left + ((right - left) / 2);

        if(search == array[middle])
        {
            return middle;
        }

        if(search > array[middle])
        {
            return BinarySearch(array, search, middle + 1, right);
        }

        return BinarySearch(array, search, left, middle - 1);
    }

    return -1;
}
