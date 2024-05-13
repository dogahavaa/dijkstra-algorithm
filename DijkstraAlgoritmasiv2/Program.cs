using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgoritmasiv2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dijkstra dijkstra = new Dijkstra();

            #region Düğüm Ekle

            dijkstra.DugumEkle("A", new List<string> { "B", "C" }, new List<int> { 30, 42 });
            dijkstra.DugumEkle("B", new List<string> { "C", "E", "G" }, new List<int> { 10, 80, 110 });
            dijkstra.DugumEkle("C", new List<string> { "D", "F" }, new List<int> { 50, 55 });
            dijkstra.DugumEkle("D", new List<string> { "E", "F" }, new List<int> { 20, 12 });
            dijkstra.DugumEkle("E", new List<string> { "G" }, new List<int> { 15 });
            dijkstra.DugumEkle("F", new List<string> { "G" }, new List<int> { 60 });
            dijkstra.DugumEkle("G", new List<string> { "" }, new List<int> { });

            #endregion

            // Başlangıç ve son düğümü vererek algoritmayı başlat
            dijkstra.Algoritma("A"); 



            Console.ReadKey();
        }
    }
}
