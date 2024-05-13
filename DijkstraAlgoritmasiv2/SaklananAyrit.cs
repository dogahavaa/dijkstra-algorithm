using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgoritmasiv2
{
    internal class SaklananAyrit
    {

        public string nereden;
        public string nereye;
        public int mesafe;

        public SaklananAyrit(string nereden, string nereye, int mesafe)
        {
            this.nereden = nereden;
            this.nereye = nereye;
            this.mesafe = mesafe;
        }
    }
}
