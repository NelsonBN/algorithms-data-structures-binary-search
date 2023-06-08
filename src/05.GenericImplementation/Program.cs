using Bogus;
using static System.Console;

Write("How many items do you want? ");
var totalItems = Convert.ToInt32(ReadLine());


var binarySearch = new BinarySearch<Person>();

var faker = new Faker<Person>();
for(var i = 0; i < totalItems; i++)
{
    binarySearch.Add(faker
        .RuleFor(p => p.FirstName, (s, p) => s.Name.FirstName())
        .RuleFor(p => p.LastName, (s, p) => s.Name.LastName())
        .RuleFor(p => p.Age, (s, p) => s.Random.Int(18, 65))
        .Generate());
}

binarySearch.Print();

do
{
    Write("First name? ");
    var firstName = ReadLine();

    Write("Last name? ");
    var lastName = ReadLine();

    Write("Age? ");
    var age = Convert.ToInt32(ReadLine());


    var person = new Person
    {
        FirstName = firstName,
        LastName = lastName,
        Age = age
    };
    var position = binarySearch.Search(person);

    WriteLine($">>> The person '{person}' is in the position '{position}'");
} while(true);




public class BinarySearch<T> where T : IComparable<T>
{
    private readonly List<T> _items = new();

    public void Add(T item)
    {
        var position = Search(item);
        if(position < 0)
        {
            position = ~position;
        }
        _items.Insert(position, item);
    }

    public int Search(T item)
    {
        var left = 0; // First position
        var right = _items.Count - 1; // Last position

        while(left <= right)
        { // It has a time complexity of O(log n) because it divides the array in half in each iteration


            // The forward instruction makes this algorithm has a time complexity of O(log n), because it divides the array in half in each iteration,
            //   so that case the algorithm never has to iterate over all the elements of the array
            var middle = left + ((right - left) >> 1);

            if(_items[middle].CompareTo(item) == 0)
            {
                return middle; // return the position when the value is found
            }

            if(_items[middle].CompareTo(item) < 0)
            { // If the value is greater than the middle value, then the left position is the middle + 1
                left = middle + 1;
            }
            else
            { // If the value is less than the middle value, then the right position is the middle - 1
                right = middle - 1;
            }
        }

        // Return the complement of the left position when the value is not found
        //  When the value is not found, the left has the index of the position where the value should be
        //  The idea is to return a negative number to indicate that the value was not found
        return ~left;
    }

    public void Print()
    {
        for(var i = 0; i < _items.Count; i++)
        {
            WriteLine($"-> {i + 1:n0} = {_items[i]}");
        }
    }
}


public class Person : IComparable<Person>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }

    public int CompareTo(Person? other)
    {
        if(other is null)
        {
            return -1;
        }

        var result = Age.CompareTo(other.Age);
        if(result != 0)
        {
            return result;
        }

        result = compareTo(FirstName, other?.FirstName);
        if(result != 0)
        {
            return result;
        }

        return compareTo(LastName, other?.LastName);



        static int compareTo(string? left, string? right)
        {
            if(left is null && right is null)
            {
                return 0;
            }

            if(left is null)
            {
                return -1;
            }

            if(right is null)
            {
                return 1;
            }

            return left.CompareTo(right);
        }
    }

    public override string ToString()
        => $"{FirstName} {LastName} (Age: {Age})";
}
