namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

// EXERCISE 2: Encapsulation - Validation in Property Setter
// The Ingredient class has basic properties, but the setter for 'Quantity'
// has no validation. Your task:
// - Ensure 'Quantity' cannot be set to a negative number (throw ArgumentOutOfRangeException)
// - Ensure 'Name' cannot be set to null or empty (throw ArgumentException)

public class Ingredient
{
    private string _name;
    private double _quantity;

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException();
            _name = value;
        }
    }
    public string Measure { get; set; }
    public double Quantity
    {
        get { return _quantity; }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException();
            _quantity = value;
        }
    }

    public Ingredient()
    {
        _name = "Unknown"; // Set backing field directly to avoid empty string exception on default init
        Measure = "";
        _quantity = 0;
    }

    public Ingredient(string name, string measure, double quantity)
    {
        Name = name;
        Measure = measure;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"{Quantity} {Measure} of {Name}";
    }
}