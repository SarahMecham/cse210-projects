using System;

public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.Equals("USA", StringComparison.OrdinalIgnoreCase)
            || _country.Equals("United States", StringComparison.OrdinalIgnoreCase)
            || _country.Equals("United States of America", StringComparison.OrdinalIgnoreCase)
            || _country.Equals("US", StringComparison.OrdinalIgnoreCase);
            
    }

    public override string ToString()
    {
        return $"{_street}\n{_city}, {_state}, {_country}";
    }
}