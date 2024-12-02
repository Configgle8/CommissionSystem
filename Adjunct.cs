using System;

public class Adjunct : Employee
{
    public double HourlyRate { get; set; }
    public int HoursWorked { get; set; }

    public Adjunct(string firstName, string lastName, bool married, string gender, DateTime birthDate, Address homeAddress, PhoneNumber homePhone, PhoneNumber cellPhone, double hourlyRate, int hoursWorked)
        : base(firstName, lastName, married, gender, birthDate, homeAddress, homePhone, cellPhone)
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }

    public override decimal Earnings
    {
        get
        {
            return (decimal)(HourlyRate * HoursWorked); 
        }
    }

    public override double TaxWithholdingPercentage
    {
        get
        {
            return 10; 
        }
    }

    public override string Category
    {
        get
        {
            return "Adjunct"; 
        }
    }
}
