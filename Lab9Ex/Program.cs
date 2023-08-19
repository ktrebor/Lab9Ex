using System;
using System.Collections.Generic;
using System.Linq;


namespace Lab9Ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const double minSalary = 7000;
            const double increaseSalaryBy10 = 1.10;
            const double increaseSalaryBy25 = 1.25;

            List<Angajat> listaAngajati = new List<Angajat>();

            var toma = new Angajat("Toma", 15520, Department.Development);
            listaAngajati.Add(toma);
            listaAngajati.Add(new Angajat("Cristi", 13520, Department.Development));
            listaAngajati.Add(new Angajat("Sorin", 16210, Department.Testing));
            listaAngajati.Add(new Angajat("Teo", 9520, Department.Logistics));
            listaAngajati.Add(new Angajat("Vio", 12520, Department.HumanResources));
            listaAngajati.Add(new Angajat("Costel", 6520, Department.Maintenance));
            listaAngajati.Add(new Angajat("Maria", 9500, Department.HumanResources));
            listaAngajati.Add(new Angajat("Mincu", 7500, Department.Maintenance));
            listaAngajati.Add(new Angajat("Alexandra", 7000, Department.Development));
            listaAngajati.Add(new Angajat("Dan", 10520, Department.Logistics));
            listaAngajati.Add(new Angajat("Mirica", 11210, Department.Testing));
            listaAngajati.Add(new Angajat("Ioana", 6960, Department.HumanResources));
            listaAngajati.Add(new Angajat("Zlatan", 3960, Department.HumanResources));
            listaAngajati.Add(new Angajat("Raluca", 6000, Department.Logistics));


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
                .Where(a => a.Salariu >= maxSalary)
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
            var costForDepartment = listaAngajati
                .Where(a => a.Departament is Department.Logistics)
                .Sum(a => a.Salariu);
            Console.WriteLine($"Suma salariilor din logistics: {costForDepartment}");

            //Va mari salariul unui angajat identificat prin Id cu 25%
            var targetId = toma.GetId();
            
            listaAngajati
                .Where(a => a.GetId() == targetId)
                .Select(a =>
                {
                    a.Salariu *= increaseSalaryBy25;
                    return a;
                }).ToList();
            
            toma.Afiseaza();

            //va mari salariile tuturor angajatilor din departamentul Testing cu 10%
            var increaseSalaryForTesting = listaAngajati
                .Where(a => a.Departament is Department.Testing)
                .Select(a =>
                {
                    a.Salariu *= increaseSalaryBy10;
                    return a;
                }).ToList();
            increaseSalaryForTesting.ForEach(a => a.Afiseaza());

            //Va afisa toti angajatii din departamentul HumanResources in ordine crescatoare alfabetica si descrescatoare a salariului.
            var orderedHumanResources = listaAngajati
                    .Where(a => a.Departament is Department.HumanResources)
                    .OrderBy(a => a.Nume)
                    .ThenByDescending(a => a.Salariu)
                    .ToList();
            orderedHumanResources.ForEach(a => a.Afiseaza());

            //Determinati primul angajat din departamentul Development cu salariul egal cu salariul minim din companie
            var poorestDevelopmentEmployee = listaAngajati
                .Where(a => a.Departament is Department.Development && a.Salariu == minSalary)
                .FirstOrDefault();

            if (poorestDevelopmentEmployee != null)
            {
                poorestDevelopmentEmployee.Afiseaza();
            } 
            else
            {
                Console.WriteLine($"Nu ai niciun angajat cu salariul mai mic de : {minSalary}");
            }

            //Afiseaza „exista” in cazul in care in lista angajatilor exista cel putin un angajat in departamentul Logistics cu salariul intre 5000 si 6000;
            bool logisticsWithRangeExists = listaAngajati
                .Any(a => a.Departament is Department.Logistics && a.Salariu >= 5000 && a.Salariu<=6000);
            if (logisticsWithRangeExists)
            {
                Console.WriteLine("Exista");
            }
            else
            {
                Console.WriteLine("Nu exista");
            }
        }
    }
}
