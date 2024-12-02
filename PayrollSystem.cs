// PayrollSystem.cs
//
// Huimin Zhao
// 
// Payroll System 

using System;

public class PayrollSystem
{
    // The add function
    public void AddEmployee(ref Employee employee)
    {
        string answer;
        bool ok;

        // salaried or hourly?
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

        // Adjunct or Faculty?
        do
        {
            ok = true;
            Console.Write("Is this employee an Adjunct or Faculty member (A/F)? ");
            answer = Console.ReadLine().Trim();
            if (answer.Length < 1)
            {
                ok = false;
                continue;
            }
            switch (answer.ToUpper()[0])
            {
                case 'A':
                    employee.IsAdjunct = true;
                    break;
                case 'F':
                    employee.IsAdjunct = false;
                    break;
                default:
                    ok = false;
                    break;
            }
        }
        while (!ok);

        // first name
        do
        {
            ok = true;
            try
            {
                Console.Write("Enter First Name: ");
                employee.FirstName = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // last name
        do
        {
            ok = true;
            try
            {
                Console.Write("Enter Last Name: ");
                employee.LastName = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // gender
        do
        {
            ok = true;
            try
            {
                Console.Write("Enter Gender (Male/Female): ");
                employee.Gender = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // Married status
        do
        {
            ok = true;
            Console.Write("Are you married (Y/N)? ");
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

        // birth date
        do
        {
            ok = true;
            try
            {
                Console.Write("Enter Birth Date (MM/DD/YYYY): ");
                employee.BirthDate = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // home phone
        do
        {
            ok = true;
            try
            {
                Console.Write("Enter Home Phone Number: ");
                employee.HomePhone = new PhoneNumber(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // cell phone
        do
        {
            ok = true;
            try
            {
                Console.Write("Enter Cell Phone Number: ");
                employee.CellPhone = new PhoneNumber(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // address
        employee.HomeAddress = new Address();

        // street address
        do
        {
            ok = true;
            try
            {
                Console.Write("Enter Street Address: ");
                employee.HomeAddress.Street = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // city
        do
        {
            ok = true;
            try
            {
                Console.Write("Enter City: ");
                employee.HomeAddress.City = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // state
        do
        {
            ok = true;
            try
            {
                Console.Write("Enter State: ");
                employee.HomeAddress.State = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // zip code
        do
        {
            ok = true;
            try
            {
                Console.Write("Enter Zip Code: ");
                employee.HomeAddress.Zip = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // if salaried employee, gather salary details
        if (employee is SalariedEmployee)
        {
            // weekly salary
            do
            {
                ok = true;
                try
                {
                    Console.Write("Enter Weekly Salary: ");
                    ((SalariedEmployee)employee).WeeklySalary = decimal.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    ok = false;
                }
            }
            while (!ok);
        }
        else // if hourly employee, gather hourly details
        {
            // hours worked
            do
            {
                ok = true;
                try
                {
                    Console.Write("Enter Hours Worked: ");
                    ((HourlyEmployee)employee).Hours = decimal.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    ok = false;
                }
            }
            while (!ok);

            // wage rate
            do
            {
                ok = true;
                try
                {
                    Console.Write("Enter Wage Rate: ");
                    ((HourlyEmployee)employee).Wage = decimal.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    ok = false;
                }
            }
            while (!ok);
        }
    }

    // The main menu
    private void Menu()
    {
        bool quit = false;
        bool valid;
        string choice;
        Employee employee = null;

        Console.WriteLine("Welcome to the Payroll System!");

        do
        {
            Console.WriteLine();
            Console.WriteLine("Add a new employee:");
            AddEmployee(ref employee);
            Console.WriteLine();
            Console.WriteLine("Employee Details:");
            Console.WriteLine(employee.ToString());

            Console.WriteLine();
            do
            {
                valid = true;
                Console.Write("Do you want to quit (Y/N)?: ");
                choice = Console.ReadLine().Trim();
                if (choice.Length < 1)
                {
                    valid = false;
                    continue;
                }
                Console.WriteLine();
                switch (choice.ToUpper()[0])
                {
                    case 'N':
                        quit = false;
                        break;
                    case 'Y':
                        quit = true;
                        break;
                    default:
                        valid = false;
                        break;
                }
            } while (!valid);
        }
        while (!quit);

        Console.WriteLine();
        Console.WriteLine("Thank you for using the Payroll System!");
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        PayrollSystem sys = new PayrollSystem();
        sys.Menu();
    }
}
