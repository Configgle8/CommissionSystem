using System;
public abstract class Employee
{
    private double retirementContributionRateValue;
    public bool IsAdjunct { get; set; }


    public string EmployeeType { get; set; }

    public double RetirementContributionRate
    {
        get
        {
            return retirementContributionRateValue;
        }
        set
        {
            if (value < 0 || value > 100)
                throw new ApplicationException("Retirement contribution rate must be between 0 and 100.");
            retirementContributionRateValue = value;
        }
    }

    public decimal Retirement { get; set; }

    public decimal TaxableIncome
    {
        get
        {
            return Earnings - (decimal)(Earnings * (decimal)(RetirementContributionRate / 100));
        }
    }

    public decimal NetPay
    {
        get
        {
            return Earnings - TaxWithheld - Retirement;
        }
    }

    private string firstNameValue;
    private string lastNameValue;
    private DateTime birthDateValue;

    public Employee() { }

    public Employee(string first, string last, bool married, string gender, DateTime birthDate, Address homeAddress, PhoneNumber homePhone, PhoneNumber cellPhone)
    {
        this.FirstName = first;
        this.LastName = last;
        this.Married = married;
        this.Gender = gender;
        this.BirthDate = birthDate;
        this.HomeAddress = homeAddress;
        this.HomePhone = homePhone;
        this.CellPhone = cellPhone;
    }

    public string FirstName
    {
        get
        {
            return Util.Capitalize(firstNameValue);
        }
        set
        {
            value = value.Trim().ToUpper();
            if (value.Length < 1)
                throw new ApplicationException("First name is empty!");
            foreach (char c in value)
                if (c < 'A' || c > 'Z')
                    throw new ApplicationException("First name must consist of letters only!");
            firstNameValue = value;
        }
    }

    public string LastName
    {
        get
        {
            return Util.Capitalize(lastNameValue);
        }
        set
        {
            value = value.Trim().ToUpper();
            if (value.Length < 1)
                throw new ApplicationException("Last name is empty!");
            foreach (char c in value)
                if (c < 'A' || c > 'Z')
                    throw new ApplicationException("Last name must consist of letters only!");
            lastNameValue = value;
        }
    }

    public string Name
    {
        get
        {
            return LastName + ", " + FirstName;
        }
    }

    public bool Married { get; set; }

    public string MaritalStatus
    {
        get
        {
            if (Married)
                return "married";
            else
                return "single";
        }
    }

    public bool IsMale { get; set; }

    public bool IsFemale
    {
        get
        {
            return !IsMale;
        }
        set
        {
            IsMale = !value;
        }
    }

    public string Gender
    {
        get
        {
            if (IsMale)
                return "Male";
            else
                return "Female";
        }
        set
        {
            value = value.ToUpper();
            if (value == "MALE" || value == "M")
                IsMale = true;
            else if (value == "FEMALE" || value == "F")
                IsMale = false;
            else
                throw new ApplicationException("Gender should be Male or Female!");
        }
    }

    public string Title
    {
        get
        {
            if (IsMale)
                return "Mr.";
            else
                return "Ms.";
        }
    }

    public string TitleName
    {
        get
        {
            return Title + " " + Name;
        }
    }

    public DateTime BirthDate
    {
        get
        {
            return birthDateValue;
        }
        set
        {
            if (value > DateTime.Now)
            {
                throw new ApplicationException("Employee birth date must be prior to today!");
            }
            birthDateValue = value;
        }
    }

    public byte Age
    {
        get
        {
            DateTime thisYearBirthDate = new DateTime(DateTime.Now.Year, BirthDate.Month, BirthDate.Day);

            if (thisYearBirthDate <= DateTime.Now)
            {
                return (byte)(DateTime.Now.Year - BirthDate.Year);
            }
            else
            {
                return (byte)(DateTime.Now.Year - BirthDate.Year - 1);
            }
        }
    }

    public Address HomeAddress { get; set; }

    public PhoneNumber HomePhone { get; set; }

    public PhoneNumber CellPhone { get; set; }

    public override string ToString()
    {
        return TitleName + "\t"
        + MaritalStatus + "\t"
        + Category + "\t"
        + "Earnings: " + Earnings.ToString("C") + "\t"
        + "Tax: " + TaxWithheld.ToString("C") + "\t"
        + HomeAddress;
    }

    public virtual string Category
    {
        get
        {
            return "Employee";
        }
    }

    public abstract decimal Earnings { get; }
    public abstract double TaxWithholdingPercentage { get; }

    public decimal TaxWithheld
    {
        get
        {
            return Earnings * (decimal)TaxWithholdingPercentage / 100;
        }
    }
}

public class EmployeePayrollSystem
{
    public void Add(ref Employee employee)
    {
        string answer;
        bool ok;

        do
        {
            ok = true;
            Console.Write("Is this a salaried or hourly employee (S/H)? ");
            answer = Console.ReadLine().Trim();
            if (answer.Length < 1)
            {
                ok = false;
                continue;
            }
            switch (answer.ToUpper()[0])
            {
                case 'S':
                    employee = new SalariedEmployee();
                    break;
                case 'H':
                    employee = new HourlyEmployee();
                    break;
                default:
                    ok = false;
                    break;
            }
        }
        while (!ok);

        do
        {
            ok = true;
            try
            {
                Console.Write("First Name: ");
                employee.FirstName = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        do
        {
            ok = true;
            try
            {
                Console.Write("Last Name: ");
                employee.LastName = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        do
        {
            ok = true;
            try
            {
                Console.Write("Gender: ");
                employee.Gender = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        do
        {
            ok = true;
            Console.Write("Married (Y/N)? ");
            answer = Console.ReadLine().Trim();
            if (answer.Length < 1)
            {
                ok = false;
                continue;
            }
            switch (answer.ToUpper()[0])
            {
                case 'Y':
                    employee.Married = true;
                    break;
                case 'N':
                    employee.Married = false;
                    break;
                default:
                    ok = false;
                    break;
            }
        }
        while (!ok);

        do
        {
            ok = true;
            try
            {
                Console.Write("Birth Date: ");
                employee.BirthDate = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        do
        {
            ok = true;
            try
            {
                Console.Write("Home Phone: ");
                employee.HomePhone = new PhoneNumber(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        do
        {
            ok = true;
            try
            {
                Console.Write("Cell Phone: ");
                employee.CellPhone = new PhoneNumber(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        employee.HomeAddress = new Address();
        do
        {
            ok = true;
            try
            {
                Console.Write("Street Address: ");
                employee.HomeAddress.Street = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        do
        {
            ok = true;
            try
            {
                Console.Write("City: ");
                employee.HomeAddress.City = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        do
        {
            ok = true;
            try
            {
                Console.Write("State: ");
                employee.HomeAddress.State = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        do
        {
            ok = true;
            try
            {
                Console.Write("Zip: ");
                employee.HomeAddress.Zip = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        Console.WriteLine("Employee added successfully!");
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
