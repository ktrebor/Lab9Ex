using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9Ex
{
    public class Angajat
    {
        public string Nume { get; private set; }
        public Guid Id { get; set; }
        public double Salariu { get; set; }
        public Department Departament { get; private set; }

        public Angajat(string nume, double salariu, Department departament)
        {
            Nume = nume;
            Id = Guid.NewGuid();
            this.Salariu = salariu;
            this.Departament = departament;
        }

        public override string ToString() => $"Nume: {Nume}, ID: {Id}, Salariu: {Salariu}, Department: {Departament}";
        public void Afiseaza() => Console.WriteLine(ToString());
    }
}
