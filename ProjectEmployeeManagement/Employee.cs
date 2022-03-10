using System;

namespace ProjectEmployeeManagement
{
   abstract class Employee
    {
    public int empNo { get; set; }

    public string empName { get; set; }

    public double empSalary { get; set; }

    public bool empIsPermanent { get; set; }
    


    public double getBonus(double percentage){
        double bonus = empSalary * (percentage / 100);

        return bonus;
    }

    }
}