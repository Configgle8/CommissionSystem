// HourlyEmployee.cs
//
// Huimin Zhao
// 
// HourlyEmployee class that extends Employee.
using System;

public class HourlyEmployee : Employee
{
    private decimal wageValue; // wage per hour
    private decimal hoursValue; // hours worked for the week

    // parameter-less constructor
    public HourlyEmployee()
        : base()
    {
    }

    // constructor
    public HourlyEmployee(string first, string last, bool married, string gender, DateTime birthDate, Address homeAddress, PhoneNumber homePhone, PhoneNumber cellPhone,
        decimal hourlyWage, decimal hoursWorked )
       : base( first, last, married, gender, birthDate, homeAddress, homePhone, cellPhone)
   {
      this.Wage = hourlyWage; // validate hourly wage via property
      this.Hours = hoursWorked; // validate hours worked via property
   } // end HourlyEmployee constructor

   // property that gets and sets hourly employee's wage
   public decimal Wage
   {
      get
      {
          return wageValue;
      } // end get
      set
      {
          if (value < 0)
              throw new ApplicationException("Wage must not be negative!");
          wageValue = value;
      } // end set
   } // end property Wage

   // property that gets and sets hourly employee's hours
   public decimal Hours
   {
      get
      {
          return hoursValue;
      } // end get
      set
      {
          if (value < 0 || value > 80)
              throw new ApplicationException("Hours must be between 0 and 80!");
          hoursValue = value; 
      } // end set
   } // end property Hours

   // calculate earnings; override Employee's abstract property Earnings 
   public override decimal Earnings
   {
       get
       {
           if (Hours <= 40) // no overtime
               return Wage * Hours;
           else
               return (40 * Wage) + ((Hours - 40) * Wage * 1.5M);
       }
   } // end property Earnings

   // override Employee's abstract property Category 
   public override string Category
   {
       get
       {
           return "Hourly";
       }
   } // end property Category

   // override Employee's abstract property TaxWithholdingPercentage 
   public override double TaxWithholdingPercentage
   {
       get
       {
           return 0;
       }
   } // end property TaxWithholdingPercentage

} // end class HourlyEmployee

