using System;
using System.Collections.Generic;
using System.Linq;


namespace Lab9Ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Angajat> listaAngajati = new List<Angajat>();

            listaAngajati.Add(new Angajat("Toma", 15520, Department.Development));
            listaAngajati.Add(new Angajat("Cristi", 13520, Department.Development));
            listaAngajati.Add(new Angajat("Sorin", 16210, Department.Testing));
            listaAngajati.Add(new Angajat("Teo", 9520, Department.Logistics));
            listaAngajati.Add(new Angajat("Vio", 12520, Department.HumanResources));
            listaAngajati.Add(new Angajat("Costel", 6520, Department.Maintenance));
            listaAngajati.Add(new Angajat("Maria", 9500, Department.HumanResources));
            listaAngajati.Add(new Angajat("Mincu", 7500, Department.Maintenance));
            listaAngajati.Add(new Angajat("Dan", 10520, Department.Logistics));


            //lista cu toti angajatii cu salariul mai mare decat valoarea numerica oferita ca parametru
            var noOfWellPayedEmployees = listaAngajati
                .Where(a => a.Salariu > 10000)
                .ToList();
            noOfWellPayedEmployees.ForEach(a => a.Afiseaza());

            //lista cu toti angajatii din departamentul Maintenance
            var employeesFromMaintenance = listaAngajati
                .Where(a => a.Departament is Department.Maintenance)
                .ToList();
            employeesFromMaintenance.ForEach(a => a.Afiseaza());

            //angajatii ordonat cu salariul descrescator
            double maxSalary = listaAngajati.Max(a => a.Salariu);
            
            var listMaxSalary = listaAngajati
                .Where(a => a.Salariu == maxSalary)
                .ToList();
            listMaxSalary.ForEach(a => a.Afiseaza());

            //angajatii cu cel mai mare salariu din departamentul Development => ordonat salariul descrescator
            double maxSalaryInDepartment = listaAngajati
                .Where(a => a.Departament is Department.Development)
                .Max(a => a.Salariu);
         
            var maxSalaryForDevelopment = listaAngajati
                .Where(a => a.Departament is Department.Development && a.Salariu == maxSalaryInDepartment)
                .ToList();
            maxSalaryForDevelopment.ForEach(a => a.Afiseaza());

            //suma tuturor salariilor din companie
            var totalCosts = listaAngajati.Sum(a => a.Salariu);
            Console.WriteLine($"Suma salariilor: {totalCosts}");

            //suma tuturor salariilor din departamentul Logistics
            var costForDepartment = listaAngajati.Where(a => a.Departament is Department.Logistics).Sum(a => a.Salariu);
            Console.WriteLine($"Suma salariilor din logistics: {costForDepartment}");
        }
    }
}
