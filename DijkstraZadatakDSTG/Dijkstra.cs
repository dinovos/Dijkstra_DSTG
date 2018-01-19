using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DijkstraZadatakDSTG
{
    class Dijkstra
    {

        private static double MinimalnaUdaljenost(double[] udaljenost, bool[] minimalnaUdaljenost, int brojVrhova)
        {
            double najmanji = double.MaxValue;
            double najmanjiIndex = 0;

            for (int v = 0; v < brojVrhova; ++v)
            {
                if (minimalnaUdaljenost[v] == false && udaljenost[v] <= najmanji)
                {
                    najmanji = udaljenost[v];
                    najmanjiIndex = v;
                }
            }

            return najmanjiIndex;
        }

        public List<string> DijkstraAlgoritam(double[,] graf, int pocetniVrh, int brojVrhova)
        {
            double[] udaljenost = new double[brojVrhova];
            bool[] najkracaUdaljenost = new bool[brojVrhova];

            for (int i = 0; i < brojVrhova; ++i)
            {
                udaljenost[i] = double.MaxValue;
                najkracaUdaljenost[i] = false;
            }

            udaljenost[pocetniVrh] = 0.00;

            for (int count = 1; count < brojVrhova; ++count)
            {
                int u = (int)MinimalnaUdaljenost(udaljenost, najkracaUdaljenost, brojVrhova);
                najkracaUdaljenost[u] = true;

                for (int v = 0; v < brojVrhova; ++v)
                    if (!najkracaUdaljenost[v] && Convert.ToBoolean(graf[u, v]) && udaljenost[u] != double.MaxValue && udaljenost[u] + graf[u, v] < udaljenost[v])
                        udaljenost[v] = udaljenost[u] + graf[u, v];
            }


            List<string> lista = new List<string>();
            lista.Add("Vrh  ----->  Udaljenost od početne točke");
            lista.Add("---------------------------------------------------------------");


            for (int i = 0; i < brojVrhova; ++i)
            {
                lista.Add("  "+ i.ToString() +"    ------>    "+ udaljenost[i]);        
            }

            return lista;

        }

    }
}
