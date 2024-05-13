using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgoritmasiv2
{
    internal class Dijkstra
    {
        public List<SaklananAyrit> saklananAyritlar;
        public List<Dugum> dugumler;
        public List<Dugum> gecerliDugumlerListesi;
        public List<Dugum> erisilebilirDugumlerListesi;
        public List<int> mesafeler;
        //public List<string> genelErisilebilirDugumlerKumesi;

        #region Constructor
        public Dijkstra()
        {
            saklananAyritlar = new List<SaklananAyrit>();
            dugumler = new List<Dugum>();
            gecerliDugumlerListesi = new List<Dugum>();
            erisilebilirDugumlerListesi = new List<Dugum>();
            //genelErisilebilirDugumlerKumesi = new List<string>();
            mesafeler = new List<int>();
        }

        #endregion


        public void Algoritma(string baslangicDugumu)
        {

            #region Başlangıç düğümü ve ilk erişilebilir düğümleri

            // Başlangıç düğümü
            Dugum baslangicDugum = BaslangicDugumuBul(baslangicDugumu);
            gecerliDugumlerListesi.Add(baslangicDugum);

            // İlk erişilebilir düğümler kümesini oluştur
            for (int i = 0; i < gecerliDugumlerListesi.Count; i++)
            {
                for (int j = 0; j < gecerliDugumlerListesi[i].erisilebilirDugumleri.Count; j++)
                {

                    for (int k = 0; k < dugumler.Count; k++)
                    {
                        if (gecerliDugumlerListesi[i].erisilebilirDugumleri[j] == dugumler[k].gecerliDugum)
                        {
                            erisilebilirDugumlerListesi.Add(dugumler[k]);
                            break;
                        }
                    }
                }
            }

            #endregion


            for (int i = 0; i < dugumler.Count; i++)
            {
                Console.WriteLine("------- {0}. İTERASYON BAŞLADI -----", (i+1));

                #region Geçerli Düğümler Kümesi Yazdır

                Console.Write("Geçerli Düğümler Kümesi       = ");
                for (int j = 0; j < gecerliDugumlerListesi.Count; j++)
                {
                    Console.Write(gecerliDugumlerListesi[j].gecerliDugum + " ");
                }
                Console.WriteLine();

                #endregion

                #region Erişilebilir Düğümler Kümesi Yazdır

                Console.Write("Erişilebilir Düğümler Kümesi  = ");
                for (int j = 0; j < erisilebilirDugumlerListesi.Count; j++)
                {
                    Console.Write(erisilebilirDugumlerListesi[j].gecerliDugum + " ");
                }
                Console.WriteLine();

                #endregion

                BaglantilarMesafelerSaklananAyrit();

                Console.WriteLine("En kısa mesafe");
                Console.WriteLine(saklananAyritlar[i].nereden + " -> " + saklananAyritlar[i].nereye + " = " + saklananAyritlar[i].mesafe);

                Console.WriteLine("------- İTERASYON BİTTİ ----------");
                Console.WriteLine();
            }

        }



        private Dugum BaslangicDugumuBul(string baslangicDugumu)
        {
            Dugum baslangicDugum = null;
            for (int i = 0; i < dugumler.Count; i++)
            {
                if (dugumler[i].gecerliDugum == baslangicDugumu)
                {
                    baslangicDugum = dugumler[i];
                    break;
                }
            }
            return baslangicDugum;
        }

       

        private void BaglantilarMesafelerSaklananAyrit()
        {
            // Geçerli düğümler kümesinden erişilebilir düğümler kümesindeki elemanlar arasındaki uzaklıklar ve yazdırma kısmı
            for (int i = 0; i < gecerliDugumlerListesi.Count; i++)
            {
                Dugum suankiDugum = gecerliDugumlerListesi[i];            
                // Seçili Düğümün erişebildikleri
                for (int j = 0; j < suankiDugum.erisilebilirDugumleri.Count; j++) // j = Erişilen düğümün index numarası
                {
                string erisilenDugum = suankiDugum.erisilebilirDugumleri[j]; // Örneğin A düğümünün eriştiği B veya C
                     if (ErisilebilirdeYoksa(erisilenDugum))
                     {
                        Console.WriteLine(suankiDugum.gecerliDugum + " -> " + erisilenDugum + " = " + suankiDugum.mesafeleri[j]);
                        mesafeler.Add(suankiDugum.mesafeleri[j]);
                     }
                }
            }


            int minMesafe = mesafeler.Min();

            int[] indexler = EnKisaMesafeyeSahipDugum(minMesafe);
            SaklananAyritOlustur(indexler); // En kısa mesafe saklanan ayrıta eklendi, Erişilen düğüm geçerli düğümler kümesine eklendi 
            //mesafeler.Clear();

        }

        private bool ErisilebilirdeYoksa(string erisilenDugum)
        {
            for(int i = 0; i < erisilebilirDugumlerListesi.Count;i++) 
            {
                if (erisilenDugum == erisilebilirDugumlerListesi[i].gecerliDugum)
                    return true;
                
            }
            return false;
        }

        private bool GecerlideYoksa(string gecerliDugum)
        {
            for (int i = 0; i < gecerliDugumlerListesi.Count; i++)
            {
                if (gecerliDugum == gecerliDugumlerListesi[i].gecerliDugum)
                {
                    return true;
                }
            }
            return false;
        }

        private int[] EnKisaMesafeyeSahipDugum(int mesafe) // Minimum mesafeye dair indexleri geri döndüren metot
        {
            int[] indexler = new int[2];

            for (int i = 0; i < gecerliDugumlerListesi.Count; i++)
            {
                for (int j = 0; j < gecerliDugumlerListesi[i].erisilebilirDugumleri.Count; j++)
                {

                    if (mesafe == gecerliDugumlerListesi[i].mesafeleri[j])
                    {
                        indexler[0] = i; // Geçerli düğümler listesindeki düğümün indexi
                        indexler[1] = j; // Eriştiğinin indexi
                    }
                }
            }
            return indexler;
        }

        private void SaklananAyritOlustur(int[] indexler)
        {
            string saklananAyritNereden = gecerliDugumlerListesi[indexler[0]].gecerliDugum;
            string saklananAyritNereye = gecerliDugumlerListesi[indexler[0]].erisilebilirDugumleri[indexler[1]];
            int mesafe = gecerliDugumlerListesi[indexler[0]].mesafeleri[indexler[1]];
            SaklananAyrit s = new SaklananAyrit(saklananAyritNereden, saklananAyritNereye, mesafe);
            saklananAyritlar.Add(s);

            // Erişilen düğümü geçerli düğümler kümesine at
            // Erişilebilir düğümler kümesinden çıkart.
            for (int i = 0; i < dugumler.Count; i++)
            {
                if (saklananAyritNereye == dugumler[i].gecerliDugum)
                {

                    if (!(GecerlideYoksa(dugumler[i].gecerliDugum)))
                    {
                        gecerliDugumlerListesi.Add(dugumler[i]);
                    }

                    ErisilebilirDugumEkle(dugumler[i]);
                }
                erisilebilirDugumlerListesi.RemoveAll(x => x.gecerliDugum == saklananAyritNereye);
            }
            
        }


        private void ErisilebilirDugumEkle(Dugum dugum)
        {
            // Erişilebilir düğüm ekle
            for (int i = 0; i < dugumler.Count; i++)
            {
                for (int j = 0; j < dugum.erisilebilirDugumleri.Count; j++)
                {
                    if (dugum.erisilebilirDugumleri[j] == dugumler[i].gecerliDugum && !ErisilebilirdeYoksa(dugum.erisilebilirDugumleri[j]))
                    {
                        erisilebilirDugumlerListesi.Add(dugumler[i]);                 
                    }
                }
            }
        }

        public void DugumEkle(string dugum, List<string> edugum, List<int> mesafe)
        {
            // Gelen parametreleri Dugum nesnesine çevirip dugumler listesine attık
            Dugum veri = new Dugum(dugum, edugum, mesafe);
            dugumler.Add(veri);
        }
    }
}



// Gecerli Düğümler A, B
// Erisilebilir Düğümler C, E, G
// A -> B, C
// B -> C, E, G