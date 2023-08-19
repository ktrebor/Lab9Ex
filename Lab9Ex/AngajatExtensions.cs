using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9Ex
{
    static class AngajatExtensions
    {
        public static Guid GetId(this Angajat angajat) => angajat.Id;
    }
}
