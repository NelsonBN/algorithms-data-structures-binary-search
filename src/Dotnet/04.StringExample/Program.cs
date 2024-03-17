using Bogus;
using static System.Console;


Write("How many items do you want? ");
var totalItems = Convert.ToInt32(ReadLine());


var binarySearch = new BinarySearch();

var faker = new Faker();
for(var i = 1; i <= totalItems; i++)
{
    binarySearch.Add(faker.Name.FirstName());
}


binarySearch.Print();


do
{
    Write("What the name are you looking for? ");
    var search = ReadLine();

    (var position, var steps) = binarySearch.Search(search);

    WriteLine($">>> The name '{search}' is in the position '{position}', and it took '{steps}' steps.");

} while(true);


public class BinarySearch
{
    private readonly List<string> _items = new();

    public void Add(string item)
    {
        (var position, _) = Search(item);
        if(position < 0)
        {
            position = ~position;
        }
        _items.Insert(position, item);
    }

    public (int Position, int Steps) Search(string? item)
    {
        var steps = 0;

        var left = 0;
        var right = _items.Count - 1;

        while(left <= right)
        {
            steps++;

            var middle = left + ((right - left) / 2);

            if(_items[middle] == item)
            {
                return (middle, steps);
            }

            if(_items[middle].CompareTo(item) < 0)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return (~left, steps);
    }

    public void Print()
    {
        for(var i = 0; i < _items.Count; i++)
        {
            WriteLine($"-> {i + 1:n0} = {_items[i]}");
        }
    }
}
