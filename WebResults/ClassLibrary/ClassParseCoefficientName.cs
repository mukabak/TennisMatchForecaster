using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebResults
{
    class ClassParseCoefficientName
    {
        public static string parseCoefficientName(string koefName)
        {
            string temp = "";
            if (koefName == "П1") {temp = "P1"; }
            else if (koefName == "П2") { temp = "P2"; }
            else if (koefName == "2:0") { temp = "2:0"; }
            else if (koefName == "2:1") { temp = "2:1"; }
            else if (koefName == "1:2") { temp = "1:2"; }
            else if (koefName == "0:2") { temp = "0:2"; }
            else if (koefName.Contains("Ф")) { temp = "H" + koefName.Substring(1, koefName.Length - 1); }
            else if (koefName.Contains("Тот")) { temp = "T" + koefName.Substring(3, koefName.Length - 3); }
            else { MessageBox.Show("Something wrong with a coefficient name!\nMessage: " + koefName); }
            return temp;
        }
    }
}
