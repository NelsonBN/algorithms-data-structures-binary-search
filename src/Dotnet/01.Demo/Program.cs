using static System.Console;


Write("How many items do you want? ");
var totalItems = Convert.ToInt32(ReadLine());


var binarySearch = new BinarySearchAlgorithm();
for(var i = 0; i < totalItems; i++)
{
    var number = Random.Shared.Next(1, int.MaxValue);
    binarySearch.Add(number);
}

binarySearch.Print();

do
{
    Write("What number are you looking for? ");
    var search = Convert.ToInt32(ReadLine());

    (var position, var steps) = binarySearch.Search(search);
    WriteLine($">>> The number '{search}' is in the position '{position}', and it took '{steps}' steps.");
} while(true);


public class BinarySearchAlgorithm
{
    private List<int> _numbers = new();

    public void Add(int number)
    {
        (_, _, var position) = _search(number);
        _numbers.Insert(position, number);
    }


    public (int Position, int Steps) Search(int number)
    {
        (var position, var steps, _) = _search(number);
        return (position, steps);
    }

    public (int Position, int Steps, int NearestPosition) _search(int number)
    {
        var steps = 0;

        var left = 0;
        var right = _numbers.Count - 1;

        while(left <= right)
        {
            steps++;

            var middle = left + ((right - left) / 2);

            if(_numbers[middle] == number)
            {
                return (middle, steps, middle);
            }

            if(_numbers[middle] < number)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return (-1, steps, left);
    }

    public void Print()
    {
        for(var i = 0; i < _numbers.Count; i++)
        {
            WriteLine($"-> {i + 1:n0} = {_numbers[i]}");
        }
    }
}
