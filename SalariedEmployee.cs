using System;

public class SalariedEmployee : Employee
{
    private decimal weeklySalaryValue;

    public SalariedEmployee() : base() { }

    public SalariedEmployee(string first, string last, bool married, string gender, DateTime birthDate, Address homeAddress, PhoneNumber homePhone, PhoneNumber cellPhone, decimal weeklySalary)
        : base(first, last, married, gender, birthDate, homeAddress, homePhone, cellPhone)
    {
        this.WeeklySalary = weeklySalary;
    }

    public decimal WeeklySalary
    {
        get { return weeklySalaryValue; }
        set
        {
            if (value < 0)
                throw new ApplicationException("Salary must not be negative!");
            weeklySalaryValue = value;
        }
    }

    public override decimal Earnings
    {
        get { return WeeklySalary; }
    }

    public override string Category
    {
        get { return "Salaried"; }
    }

    public override double TaxWithholdingPercentage
    {
        get { return 15; }
    }
}
