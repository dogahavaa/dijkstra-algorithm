using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgoritmasiv2
{
    internal class Dugum
    {

        //public string gecerliDugum { get; set; }

        public string gecerliDugum;
        public List<string> erisilebilirDugumleri;
        public List<int> mesafeleri;
        public bool ziyaretEdilmis;

        public Dugum(string gecerliDugum, List<string> erisilebilirDugumleri, List<int> mesafeleri)
        {
            this.gecerliDugum = gecerliDugum;
            this.erisilebilirDugumleri = erisilebilirDugumleri;
            this.mesafeleri = mesafeleri;
            ziyaretEdilmis = false;
        }

    }
}
