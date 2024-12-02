public class Faculty : Employee
{
    public string Department { get; set; }

    public Faculty(string firstName, string lastName, string department)
        : base(firstName, lastName)
    {
        Department = department;
    }

    
    public override decimal Earnings
    {
        get
        {
            return 60000m; 
        }
    }

    
    public override double TaxWithholdingPercentage
    {
        get
        {
            return 15; 
        }
    }
}
