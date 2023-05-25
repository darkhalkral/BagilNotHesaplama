using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace ders14_dll
{
    public class nothesapla
    {
        OleDbConnection con;
        OleDbDataAdapter da;
        DataTable dt = new DataTable();
        public void baglanti()
        {
            dt.Clear();
            con = new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0; Data Source=C:\\Users\\halid\\source\\repos\\ogrnothesap.mdb");
            da = new OleDbDataAdapter("Select * from ogrenci", con);
            da.Fill(dt);
        }
        public float sınıfort()
        {
            baglanti();
            int count = dt.Rows.Count;
            float sınıfort = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int ogrort = Convert.ToInt32(dt.Rows[i]["ort"]);
                if (ogrort <=15)
                {
                    count--;
                }
                else
                {
                    sınıfort = sınıfort + ogrort;
                }
            }
            sınıfort = sınıfort / count;
            return sınıfort;
        }
        public double standartsapma(float sınıfort)
        {
            baglanti();
            double sapma = 0;
            int count = dt.Rows.Count;
            float varyans = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int ogrort = Convert.ToInt32(dt.Rows[i]["ort"]);
                if (ogrort <= 15)
                {
                    count--;
                }
                else
                {
                    varyans = varyans + ((ogrort-sınıfort) * (ogrort - sınıfort));
                }
            }
            varyans = varyans / count-1;
            sapma = Math.Sqrt(varyans);
            return sapma;
        }
        public string harfnotu(int ogrort, float sınıfort, double sapma)
        {
            double tstandart = ((ogrort - sınıfort) / sapma) * 10 + 50;
            string harfnotu = "";
            if(sınıfort>=80 && sınıfort <= 100)
            {
                
            }
            else if(sınıfort>70 && sınıfort < 80)
            {
                if (tstandart >= 59)
                {
                    harfnotu = "AA";
                }
                else if (tstandart >= 54 && tstandart <= 58.99)
                {
                    harfnotu = "BA";
                }
                else if (tstandart >= 49 && tstandart <= 53.99)
                {
                    harfnotu = "BB";
                }
                else if (tstandart >= 44 && tstandart <= 48.99)
                {
                    harfnotu = "CB";
                }
                else if (tstandart >= 39 && tstandart <= 43.99)
                {
                    harfnotu = "CC";
                }
                else if (tstandart >= 34 && tstandart <= 38.99)
                {
                    harfnotu = "DC";
                }
                else if (tstandart >= 29 && tstandart <= 33.99)
                {
                    harfnotu = "DD";
                }
                else if (tstandart >= 24 && tstandart <= 28.99)
                {
                    harfnotu = "FD";
                }
                else if (tstandart < 24)
                {
                    harfnotu = "FF";
                }
            }
            else if (sınıfort > 62.5 && sınıfort <= 70)
            {
                if (tstandart >= 61)
                {
                    harfnotu = "AA";
                }
                else if (tstandart >= 56 && tstandart <= 60.99)
                {
                    harfnotu = "BA";
                }
                else if (tstandart >= 51 && tstandart <= 55.99)
                {
                    harfnotu = "BB";
                }
                else if (tstandart >= 46 && tstandart <= 50.99)
                {
                    harfnotu = "CB";
                }
                else if (tstandart >= 41 && tstandart <= 45.99)
                {
                    harfnotu = "CC";
                }
                else if (tstandart >= 36 && tstandart <= 35.99)
                {
                    harfnotu = "DC";
                }
                else if (tstandart >= 31 && tstandart <= 35.99)
                {
                    harfnotu = "DD";
                }
                else if (tstandart >= 26 && tstandart <= 30.99)
                {
                    harfnotu = "FD";
                }
                else if (tstandart < 26)
                {
                    harfnotu = "FF";
                }
            }
            else if (sınıfort > 57.5 && sınıfort <= 62.5)
            {
                if (tstandart >= 63)
                {
                    harfnotu = "AA";
                }
                else if (tstandart >= 58 && tstandart <= 62.99)
                {
                    harfnotu = "BA";
                }
                else if (tstandart >= 53 && tstandart <= 57.99)
                {
                    harfnotu = "BB";
                }
                else if (tstandart >= 48 && tstandart <= 52.99)
                {
                    harfnotu = "CB";
                }
                else if (tstandart >= 43 && tstandart <= 47.99)
                {
                    harfnotu = "CC";
                }
                else if (tstandart >= 38 && tstandart <= 42.99)
                {
                    harfnotu = "DC";
                }
                else if (tstandart >= 33 && tstandart <= 37.99)
                {
                    harfnotu = "DD";
                }
                else if (tstandart >= 28 && tstandart <= 32.99)
                {
                    harfnotu = "FD";
                }
                else if (tstandart < 28)
                {
                    harfnotu = "FF";
                }
            }
            else if (sınıfort > 52.5 && sınıfort <= 57.5)
            {
                if (tstandart >= 65)
                {
                    harfnotu = "AA";
                }
                else if (tstandart >= 60 && tstandart <= 64.99)
                {
                    harfnotu = "BA";
                }
                else if (tstandart >= 55 && tstandart <= 59.99)
                {
                    harfnotu = "BB";
                }
                else if (tstandart >= 50 && tstandart <= 54.99)
                {
                    harfnotu = "CB";
                }
                else if (tstandart >= 45 && tstandart <= 49.99)
                {
                    harfnotu = "CC";
                }
                else if (tstandart >= 40 && tstandart <= 44.99)
                {
                    harfnotu = "DC";
                }
                else if (tstandart >= 35 && tstandart <= 39.99)
                {
                    harfnotu = "DD";
                }
                else if (tstandart >= 30 && tstandart <= 34.99)
                {
                    harfnotu = "FD";
                }
                else if (tstandart < 30)
                {
                    harfnotu = "FF";
                }
            }
            else if (sınıfort > 47.5 && sınıfort <= 52.5)
            {
                if (tstandart >= 67)
                {
                    harfnotu = "AA";
                }
                else if (tstandart >= 62 && tstandart <= 66.99)
                {
                    harfnotu = "BA";
                }
                else if (tstandart >= 57 && tstandart <= 61.99)
                {
                    harfnotu = "BB";
                }
                else if (tstandart >= 52 && tstandart <= 56.99)
                {
                    harfnotu = "CB";
                }
                else if (tstandart >= 47 && tstandart <= 51.99)
                {
                    harfnotu = "CC";
                }
                else if (tstandart >= 42 && tstandart <= 46.99)
                {
                    harfnotu = "DC";
                }
                else if (tstandart >= 37 && tstandart <= 41.99)
                {
                    harfnotu = "DD";
                }
                else if (tstandart >= 32 && tstandart <= 36.99)
                {
                    harfnotu = "FD";
                }
                else if (tstandart < 32)
                {
                    harfnotu = "FF";
                }
            }
            else if (sınıfort > 42.5 && sınıfort <= 47.5)
            {
                if (tstandart >= 69)
                {
                    harfnotu = "AA";
                }
                else if (tstandart >= 64 && tstandart <= 68.99)
                {
                    harfnotu = "BA";
                }
                else if (tstandart >= 59 && tstandart <= 63.99)
                {
                    harfnotu = "BB";
                }
                else if (tstandart >= 54 && tstandart <= 58.99)
                {
                    harfnotu = "CB";
                }
                else if (tstandart >= 49 && tstandart <= 53.99)
                {
                    harfnotu = "CC";
                }
                else if (tstandart >= 44 && tstandart <= 48.99)
                {
                    harfnotu = "DC";
                }
                else if (tstandart >= 39 && tstandart <= 43.99)
                {
                    harfnotu = "DD";
                }
                else if (tstandart >= 34 && tstandart <= 38.99)
                {
                    harfnotu = "FD";
                }
                else if (tstandart < 34)
                {
                    harfnotu = "FF";
                }
            }
            else if (sınıfort <= 42.5)
            {
                if (tstandart >= 71)
                {
                    harfnotu = "AA";
                }
                else if (tstandart >= 66 && tstandart <= 70.99)
                {
                    harfnotu = "BA";
                }
                else if (tstandart >= 61 && tstandart <= 65.99)
                {
                    harfnotu = "BB";
                }
                else if (tstandart >= 56 && tstandart <= 60.99)
                {
                    harfnotu = "CB";
                }
                else if (tstandart >= 51 && tstandart <= 55.99)
                {
                    harfnotu = "CC";
                }
                else if (tstandart >= 46 && tstandart <= 50.99)
                {
                    harfnotu = "DC";
                }
                else if (tstandart >= 41 && tstandart <= 45.99)
                {
                    harfnotu = "DD";
                }
                else if (tstandart >= 36 && tstandart <= 40.99)
                {
                    harfnotu = "FD";
                }
                else if (tstandart < 36)
                {
                    harfnotu = "FF";
                }
            }
            return harfnotu;
        }
    }
}
