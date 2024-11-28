public class CommissionEmployee
{
    protected string firstName;
    protected string lastName;
    protected string socialSecurityNumber;
    protected decimal grossSales;
    protected decimal commissionRate;

    public CommissionEmployee(string first, string last, string ssn,
                               decimal sales, decimal rate)
    {
        firstName = first;
        lastName = last;
        socialSecurityNumber = ssn;
        GrossSales = sales;
        CommissionRate = rate;
    }

    public string FirstName
    {
        get
        {
            return firstName;
        }
    }

    public string LastName
    {
        get
        {
            return lastName;
        }
    }

    public decimal GrossSales
    {
        get
        {
            return grossSales;
        }
        set
        {
            grossSales = (value < 0) ? 0 : value;
        }
    }

    public decimal CommissionRate
    {
        get
        {
            return commissionRate;
        }
        set
        {
            commissionRate = (value > 0 && value < 1) ? value : 0;
        }
    }
    public string SocialSecurityNumber
    {
        get { return socialSecurityNumber; }
    }
    public virtual decimal Earnings()
    {
        return commissionRate * grossSales;
    }
    public override string ToString()
    {
        return string.Format(
            "{0}: {1} {2}\n{3}: {4}\n{5}: {6:C}\n{7}: {8:F2}",
            "commission employee", firstName, lastName,
            "social security number", socialSecurityNumber,
            "gross sales", grossSales, "commission rate", commissionRate);
    }
}

public class BasePlusCommissionEmployee : CommissionEmployee
{
    private decimal baseSalary;

    public BasePlusCommissionEmployee(string first, string last, string ssn, decimal sales, decimal rate, decimal salary)
    : base( first, last, ssn, sales, rate)
    {
        BaseSalary = salary;
    }

    public decimal BaseSalary
    {
        get { return baseSalary; }
        set { baseSalary = (value < 0) ? 0 : value; }
    }
    public override decimal Earnings()
    {
        return base.Earnings() + BaseSalary;
    }
public override string ToString()
{
    return string.Format(
        "{0}: {1} {2}\n{3}: {4}\n{5}: {6}:C\n{7}: {8:F2}\n{9}: {10:C}",
        "base-salaried commission employee", firstName, lastName,
        "social security number", socialSecurityNumber,
        "gross sales", grossSales, "commission rate", commissionRate,
        "base salary", baseSalary);
        
}
}



public class BasePlusCommissionEmployeeTest
{
    public static void Main(string[] args)
    {
        BasePlusCommissionEmployee basePlusCommissionEmployee = new BasePlusCommissionEmployee("Bob", "Lewis", "333-33-3333", 5000.00M, .04M, 300.00M);

        Console.WriteLine("Employee information obtained by properties and methods: \n");

        Console.WriteLine("{0} {1}", "First name is", basePlusCommissionEmployee.FirstName);

        Console.WriteLine("{0} {1}", "Last name is", basePlusCommissionEmployee.LastName);

        Console.WriteLine("{0} {1}", "Social security number is", basePlusCommissionEmployee.SocialSecurityNumber);

        Console.WriteLine("{0} {1:C}", "Gross sales are", basePlusCommissionEmployee.GrossSales);
        Console.WriteLine("{0} {1:F2}", "Commission rate is", basePlusCommissionEmployee.CommissionRate);
        Console.WriteLine("{0} {1:C}", "Earnings are", basePlusCommissionEmployee.Earnings());
        Console.WriteLine("{0} {1:C}", "Base salary is", basePlusCommissionEmployee.BaseSalary);

        basePlusCommissionEmployee.BaseSalary = 1000.00M;

        Console.WriteLine("earnings: {0:C}",
            basePlusCommissionEmployee.Earnings());
    }
}
         