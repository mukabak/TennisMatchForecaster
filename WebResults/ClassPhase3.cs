using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace WebResults
{
    class ClassPhase3
    {
        public static string start() {
            ClassFileManagement.writeToFile("dataPhase3/coefficientUpcomingATPSingle.txt", "", false);
            string url = "https://olimp.kz/betting/tennis";
            getEachURLTitle(ClassHttpWebRequest.source(url));
            DateTime today = DateTime.Today;
            return "The Phase III is Successfully Updated! Date: " + today.ToString("yyyyMMdd") + ".";
        }

        private static void getEachURLTitle(string sourceCode) {
            for (int i=0; i != -1; i = sourceCode.IndexOf("selchamp"))
            {
                int startIndex = sourceCode.IndexOf("selchamp") + 50;
                sourceCode = sourceCode.Substring(startIndex, sourceCode.Length - startIndex);
                int urlStartIndex = sourceCode.IndexOf("index.php");
                sourceCode = sourceCode.Substring(urlStartIndex, sourceCode.Length - urlStartIndex);
                int nameEndIndex = sourceCode.IndexOf("</a>");
                string eachURLTitle = sourceCode.Substring(0, nameEndIndex);
                int nameStartIndex = eachURLTitle.IndexOf(">");
                string url = "https://olimp.kz/betting/" + eachURLTitle.Substring(0, nameStartIndex - 1);
                string tourTitle = eachURLTitle.Substring(nameStartIndex + 1, eachURLTitle.Length - nameStartIndex - 1);
                string[] title = new string[7];
                title = ClassParseTitle.getATP(ClassParseTitle.parseTitle(tourTitle));
                if (title[0] == "ATP" && title[3] == "Null")
                {
                    parseATPSinge(url, title);
                }
            }
        }

        public static void parseATPSinge(string url, string[] title) {
            string sourceCode = ClassHttpWebRequest.source(url);
            for (int i = 0; i != -1; i = sourceCode.IndexOf("(+"))
            {
                string coefficients = "";
                for (int a = 0; a < title.Length; a++)
                {
                    coefficients += title[a] + ",";
                }

                int dateStartIndex = sourceCode.IndexOf("(+") + 16;
                sourceCode = sourceCode.Substring(dateStartIndex, sourceCode.Length - dateStartIndex);

                int nameEndIndex = sourceCode.IndexOf("</a></span></b></font></td>");
                string eachDateName = sourceCode.Substring(0, nameEndIndex);

                int nameStartIndex = eachDateName.LastIndexOf(">");
                string playerNames = eachDateName.Substring(nameStartIndex + 1, eachDateName.Length - nameStartIndex - 1);

                Boolean isPalyerSingle = true;
                Boolean isWritable = true;
                string[] player = new string[3];
                player = ClassParsePlayersName.parseName(playerNames);
                if (player[0] == "false") { isPalyerSingle = false; isWritable = false; continue; }

                coefficients += player[1] + ",";
                coefficients += player[2] + ",";

                int d, m, y, h, n;
                try
                {
                    d = int.Parse(eachDateName.Substring(0, 2));
                    m = int.Parse(eachDateName.Substring(3, 2));
                    y = int.Parse(eachDateName.Substring(6, 4));
                    h = int.Parse(eachDateName.Substring(11, 2));
                    n = int.Parse(eachDateName.Substring(14, 2));
                }
                catch (Exception) { isWritable = false;  continue; }

                string date, time, day, month, year, hour, min;
                if (d < 10) { day = "0" + d; } else { day = d.ToString(); }
                if (m < 10) { month = "0" + m; } else { month = m.ToString(); }
                year = y.ToString();
                if (h < 10) { hour = "0" + h; } else { hour = h.ToString(); }
                if (n < 10) { min = "0" + n; } else { min = n.ToString(); }
                date = year + month + day;
                time = hour + ":" + min;
                coefficients = time + "," + coefficients;
                coefficients = date + "," + coefficients;

                int koefsStartIndex = sourceCode.IndexOf("П1") - 64;
                string eachGameKoefs = sourceCode.Substring(koefsStartIndex, sourceCode.Length - koefsStartIndex);
                eachGameKoefs = eachGameKoefs.Substring(0, eachGameKoefs.IndexOf("Тот(") + 800);

                string koefName = "";
                int koefTotalOverStartIndex = eachGameKoefs.LastIndexOf("googleStatKef") + 15;
                string koefTotalOver = eachGameKoefs.Substring(koefTotalOverStartIndex, eachGameKoefs.Length - koefTotalOverStartIndex);
                int koefTotalOverEndIndex = koefTotalOver.IndexOf("</span>");
                koefTotalOver = koefTotalOver.Substring(0, koefTotalOverEndIndex);

                int coefCounter = 0;
                for (int a = 0; a != -1; a = eachGameKoefs.IndexOf("googleStatIssueName"))
                {
                    try
                    {
                        int koefNameStartIndex = eachGameKoefs.IndexOf("googleStatIssueName") + 21;
                        eachGameKoefs = eachGameKoefs.Substring(koefNameStartIndex, eachGameKoefs.Length - koefNameStartIndex);

                        int koefNameEndIndex = eachGameKoefs.IndexOf("googleStatKef") + 40;
                        string eachNameKoef = eachGameKoefs.Substring(0, eachGameKoefs.Length - koefNameEndIndex);

                        int kNameEndIndex = eachNameKoef.IndexOf("</span>");
                        koefName = eachNameKoef.Substring(0, kNameEndIndex);

                        int koefStartIndex = eachNameKoef.IndexOf("googleStatKef") + 15;
                        string koef = eachNameKoef.Substring(koefStartIndex, eachNameKoef.Length - koefStartIndex);

                        int koefEndIndex = koef.IndexOf("</span>");
                        koef = koef.Substring(0, koefEndIndex);

                        if (koefName.Contains("Тот(")) { koefName += ":U"; }

                        koefName = ClassParseCoefficientName.parseCoefficientName(koefName);
                        coefficients += koefName + "=" + koef + ",";
                    }
                    catch (Exception) { coefficients = "";  continue; }
                    coefCounter++;
                }

                if (coefCounter != 9) { coefficients = ""; continue; }

                koefName = koefName.Substring(0, koefName.Length - 1);
                koefName += "O";
                coefficients += koefName + "=" + koefTotalOver + "\n";
                if (coefficients.Contains(")=") && coefficients.Contains("):U=")) {
                    ClassFileManagement.writeToFile("dataPhase3/coefficientUpcomingATPSingle.txt", coefficients, true);
                    isWritable = isCoefficientUnique(date, player[1], player[2]);
                    if (isWritable)
                    {
                        ClassFileManagement.writeToFile("dataPhase3/coefficientATPSingle.txt", coefficients, true);
                    }
                } else
                {
                    continue;
                }
            }
        }

        private static Boolean isCoefficientUnique(string date, string p1, string p2) {
            string keyword = date + p1 + p2;
            Boolean temp = true;
            StreamReader sr = new StreamReader("dataPhase3/coefficientATPSingle.txt");
            string lastLine = "";
            while (!sr.EndOfStream)
            {
                lastLine = sr.ReadLine();
                string[] parts = lastLine.Split(',');
                if(parts[0] + parts[9] +parts[10] == keyword)
                {
                    temp = false;
                }
            }
            sr.Close();
            return temp;
        }
    }
}
