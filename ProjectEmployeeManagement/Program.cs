using System;

namespace ProjectEmployeeManagement
{
    class Program
    {
         static void Main(string[] args)
        {
        // Employee tempEmployee = new Employee();
        // tempEmployee.empNo = 203;
        // tempEmployee.empName = "Ralph";
        // tempEmployee.empSalary = 10000;
        // tempEmployee.empIsPermanent = true; 

        // System.Console.WriteLine(tempEmployee.getBonus(5));

        Developer juniorDev = new Developer();
        juniorDev.empNo = 221;
        juniorDev.empName = "Sean";
        juniorDev.empSalary = 70000;
        juniorDev.empIsPermanent = true; 
        
        System.Console.WriteLine(juniorDev.getBonus(5));

        HR HRrep = new HR();
        HRrep.empNo = 534;
        HRrep.empName = "Sarah";
        HRrep.empSalary = 65000;
        HRrep.empIsPermanent = true; 

        System.Console.WriteLine(HRrep.getBonus(5));

        Manager teamManager = new Manager();
        teamManager.empNo = 101;
        teamManager.empName = "John";
        teamManager.empSalary = 111000;
        teamManager.empIsPermanent = true; 

        System.Console.WriteLine(teamManager.getBonus(5));
       

        }
    }
}
