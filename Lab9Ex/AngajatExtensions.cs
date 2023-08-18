using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9Ex
{
    static class AngajatExtensions
    {
        public static void VerificaSalariuPlafon(this Angajat angajat, double salariu)
        {
            if (angajat == null)
            {
                return;
            }
            else if (angajat.Salariu > salariu)
            {
                angajat.Afiseaza();
            }
        }
    }
}
