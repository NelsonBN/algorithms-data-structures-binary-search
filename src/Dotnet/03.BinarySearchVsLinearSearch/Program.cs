using static System.Console;

var numbers = new int[] { 12, 34, 45, 55, 67, 78, 89, 99, 187, 245 };

var search_1 = 12;
(var position_1_1, var steps_1_1) = LinearSearch(numbers, search_1);
WriteLine($"LinearSearch >>> The value '{search_1}' is in the position '{position_1_1}', and it took '{steps_1_1}' steps.");

(var position_1_2, var steps_1_2) = BinarySearch(numbers, search_1);
WriteLine($"BinarySearch >>> The value '{search_1}' is in the position '{position_1_2}', and it took '{steps_1_2}' steps.");


WriteLine();


var search_2 = 89;
(var position_2_1, var steps_2_1) = LinearSearch(numbers, search_2);
WriteLine($"LinearSearch >>> The value '{search_2}' is in the position '{position_2_1}', and it took '{steps_2_1}' steps.");

(var position_2_2, var steps_2_2) = BinarySearch(numbers, search_2);
WriteLine($"BinarySearch >>> The value '{search_2}' is in the position '{position_2_2}', and it took '{steps_2_2}' steps.");


WriteLine();


var search_3 = 67;
(var position_3_1, var steps_3_1) = LinearSearch(numbers, search_3);
WriteLine($"LinearSearch >>> The value '{search_3}' is in the position '{position_3_1}', and it took '{steps_3_1}' steps.");

(var position_3_2, var steps_3_2) = BinarySearch(numbers, search_3);
WriteLine($"BinarySearch >>> The value '{search_3}' is in the position '{position_3_2}', and it took '{steps_3_2}' steps.");


WriteLine();


var search_4 = 975;
(var position_4_1, var steps_4_1) = LinearSearch(numbers, search_4);
WriteLine($"LinearSearch >>> The value '{search_4}' is in the position '{position_4_1}', and it took '{steps_4_1}' steps.");

(var position_4_2, var steps_4_2) = BinarySearch(numbers, search_4);
WriteLine($"BinarySearch >>> The value '{search_4}' is in the position '{position_4_2}', and it took '{steps_4_2}' steps.");





static (int Position, int Steps) LinearSearch(int[] array, int search)
{
    var steps = 0;
    for(var i = 0; i < array.Length; i++)
    {
        steps++;

        if(array[i] == search)
        {
            return (i, steps); // return the position and the steps when the value is found
        }
    }

    return (-1, steps); // return -1 when the value is not found
}

static (int Position, int Steps) BinarySearch(int[] array, int search)
{
    var steps = 0;

    var left = 0;
    var right = array.Length - 1;

    while(left <= right)
    {
        steps++;

        var middle = left + ((right - left) / 2);

        if(array[middle] == search)
        {
            return (middle, steps);
        }

        if(array[middle] < search)
        {
            left = middle + 1;
        }
        else
        {
            right = middle - 1;
        }
    }

    return (-1, steps);
}
