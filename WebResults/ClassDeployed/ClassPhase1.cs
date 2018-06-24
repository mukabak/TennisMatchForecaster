using System;

namespace WebResults
{
    public class ClassPhase1
    {
        public static string start() {
            DateTime lastDate = getLastUpdatedDate();
            DateTime interDate = lastDate.AddDays(-1);
            DateTime today = DateTime.Today;
            today = today.AddDays(1);
            while (interDate.AddDays(1) <= today)
            {
                string url = "https://olimp.kz/index.php?action=set_tmz&id=-360&use_DST=0&page=print_res&id=3&day=" + interDate.Day + "&month=" + interDate.Month + "&year=" + interDate.Year;
                string content = ClassHttpWebRequest.source(url);
                if (isResultsAvailable(content) == true) {
                    string fileName = interDate.ToString("yyyyMMdd") + ".html";
                    ClassFileManagement.createFile("dataPhase1/", fileName, content);
                    updateLastUpdatedDate(interDate, lastDate);
                }
                interDate = interDate.AddDays(1);
            }
            return "The Phase I is Successfully Updated! Date: " + interDate.Date.AddDays(-1).ToString("yyyyMMdd") + ".";
        }

        private static DateTime getLastUpdatedDate() {
            int y = 0, m = 0, d = 0;
            string tempLastDate = ClassFileManagement.getLastLine("dataPhase1/listOfDays.txt");
            y = int.Parse(tempLastDate.Substring(0, 4));
            m = int.Parse(tempLastDate.Substring(4, 2));
            d = int.Parse(tempLastDate.Substring(6, 2));
            DateTime temp = new DateTime(y, m, d);
            return temp;
        }

        private static Boolean isResultsAvailable(String sourceCode) {
            Boolean available = false;
            try
            {
                sourceCode = sourceCode.Substring(sourceCode.IndexOf("smwndcap") - 84, sourceCode.IndexOf("</table></TD></TR> </table>") - sourceCode.IndexOf("smwndcap") + 111);
                available = true;
            } catch {}
            return available;
        }

        private static void updateLastUpdatedDate(DateTime interDate, DateTime lastUpdatedDate) {
            int currentDate = int.Parse(interDate.ToString("yyyyMMdd"));
            int lastDate = int.Parse(lastUpdatedDate.ToString("yyyyMMdd"));
            if (currentDate > lastDate)
            {
                string line = "\n" + interDate.ToString("yyyyMMdd");
                ClassFileManagement.writeToFile("dataPhase1/listOfDays.txt", line, true);
            }
        }
    }
}
