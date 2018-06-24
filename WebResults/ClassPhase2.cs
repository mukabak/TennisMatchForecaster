using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebResults
{
    public class ClassPhase2
    {
        public static string start()
        {
            string lastUpdatedDate = ClassFileManagement.getLastLine("dataPhase2/dataATPSingle.txt");
            lastUpdatedDate = lastUpdatedDate.Substring(0, 8);
            deleteLastUpdatedDate(lastUpdatedDate, "dataPhase2/dataATPSingle.txt");

            Boolean startUpdate = false;
            string interDate="";
            StreamReader sr = new StreamReader("dataPhase1/listOfDays.txt");
            while (!sr.EndOfStream)
            {
                interDate = sr.ReadLine();
                if (interDate == lastUpdatedDate)
                {
                    startUpdate = true;
                }
                if (startUpdate)
                {
                    string path = "dataPhase1/" + interDate + ".html";
                    getEachTour(interDate, ClassFileManagement.readFile(path));
                }
            }
            sr.Close();
            return "The Phase II is Successfully Updated! Date: " + interDate + ".";
        }

        public static void deleteLastUpdatedDate(string lastDate, string path)
        {
            string line;
            using (StreamReader sr = new StreamReader(path))
            {
                using (StreamWriter sw = new StreamWriter("dataPhase2/temp.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        string interDate = line.Substring(0, 8);
                        if (int.Parse(interDate) >= int.Parse(lastDate))
                        {
                            continue;
                        }
                        else
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
            }
            ClassFileManagement.replaceFile(path, "dataPhase2/temp.txt");
        }

        public static void getEachTour(string date, string sourceCode)
        {
            int index = 0;
            while (index != -1)
            {
                string eachTour;
                int startIndex = sourceCode.IndexOf("smwndcap") + 44;
                sourceCode = sourceCode.Substring(startIndex, sourceCode.Length - startIndex);
                int endIndex = sourceCode.IndexOf("</td></tr></table>");
                eachTour = sourceCode.Substring(0, endIndex);
                string tourTitle = eachTour.Substring(0, eachTour.IndexOf("koeftable") - 60);

                string[] title = new string[7];
                title = ClassParseTitle.getATP(ClassParseTitle.parseTitle(tourTitle));

                if (title[0] == "ATP" && title[3] == "Null")
                {
                    parseATPSingle(date, title, eachTour);
                }
                index = sourceCode.IndexOf("smwndcap");
            }

        }

        public static void parseATPSingle(string date, string[] tourTitle, string tourContent)
        {
            string fullContent = tourContent;


            int index = 0;
            while (index != -1)
            {
                int startIndex = tourContent.IndexOf("nowrap") + 45;
                tourContent = tourContent.Substring(startIndex, tourContent.Length - startIndex);
                int endIndex = tourContent.IndexOf("display: none;");
                tourContent = tourContent.Substring(0, endIndex);


                Boolean isWritable = true;
                Boolean isPalyerCorrect = true;
                Boolean isDateCorrect = false;
                Boolean isScoreCorrect = true;
                int index2 = 0;
                int h = 0, m = 0;
                int scoreP1 = 0, scoreP2 = 0;
                int set1P1 = 0, set1P2 = 0, set2P1 = 0, set2P2 = 0, set3P1 = 0, set3P2 = 0;
                string playerNames = "", winner = "";
                string isCancelled = "Cancelled";


                int end1 = tourContent.IndexOf("</b><br>");
                playerNames = tourContent.Substring(0, end1);

                string[] player = new string[3];
                player = ClassParsePlayersName.parseName(playerNames);
                if (player[0] == "false") {
                    isPalyerCorrect = false;
                }


                end1 += 9;
                tourContent = tourContent.Substring(end1, tourContent.Length - end1);
                string year = tourContent.Substring(6, 4);
                try
                {
                    if (int.Parse(year) > 2000)
                    {
                        h = int.Parse(tourContent.Substring(11, 2));
                        m = int.Parse(tourContent.Substring(14, 2));
                        isDateCorrect = true;
                    }
                }
                catch (Exception) { isDateCorrect = false; }
                if (!isDateCorrect)
                {
                    if (year.IndexOf(".") == 0)
                    {
                        year = tourContent.Substring(7, 4);
                        h = int.Parse(tourContent.Substring(12, 2));
                        m = int.Parse(tourContent.Substring(15, 2));
                    }
                    else
                    {
                        MessageBox.Show("The date is not found!\nMessage:" + year);
                    }
                }


                index2 = tourContent.IndexOf("valign=middle") + 17;
                string results = tourContent.Substring(index2, 30);
                if (results.Contains("Счет") || results.Contains("Score") || results.Contains("Есеп"))
                {
                    isCancelled = "Null";
                }
                else if (tourContent.Contains("отмен") || tourContent.Contains("завершен") || tourContent.Contains("0:0") || tourContent.Contains("0:1") || tourContent.Contains("1:0") || tourContent.Contains("1:1"))
                {
                    isCancelled = "Cancelled";
                }
                else
                {
                    isCancelled = "Cancelled";
                    //MessageBox.Show("Results not found!\nMessage: " + tourContent + "\nMessage: " + fullContent);
                }


                if (isPalyerCorrect && isCancelled == "Null")
                {
                    try
                    {
                        if (results.Contains("Score"))
                        {
                            results = results.Substring(1, results.Length - 1);
                        }
                        scoreP1 = int.Parse(results.Substring(6, 1));
                        scoreP2 = int.Parse(results.Substring(8, 1));


                        if (scoreP1 > scoreP2)
                        {
                            winner = "1";
                        }
                        else if (scoreP2 > scoreP1)
                        {
                            winner = "2";
                        }
                        else
                        {
                            isWritable = false;
                            MessageBox.Show("Winners not found!\nMessage: " + tourContent);
                        }


                        if (scoreP1 + scoreP2 == 2)
                        {
                            set1P1 = int.Parse(results.Substring(11, 1));
                            set1P2 = int.Parse(results.Substring(13, 1));
                            set2P1 = int.Parse(results.Substring(15, 1));
                            set2P2 = int.Parse(results.Substring(17, 1));
                        }
                        else if (scoreP1 + scoreP2 == 3)
                        {
                            set1P1 = int.Parse(results.Substring(11, 1));
                            set1P2 = int.Parse(results.Substring(13, 1));
                            set2P1 = int.Parse(results.Substring(15, 1));
                            set2P2 = int.Parse(results.Substring(17, 1));
                            try
                            {
                                set3P1 = int.Parse(results.Substring(19, 1));
                                set3P2 = int.Parse(results.Substring(21, 1));
                            }
                            catch (Exception)
                            {
                                isScoreCorrect = false;
                            }
                        }
                        else
                        {
                            isWritable = false;
                            MessageBox.Show("Score not found!\nMessage: " + tourContent);
                        }
                        if (!isScoreCorrect)
                        {
                            if (scoreP1 > scoreP2)
                            {
                                set3P1 = int.Parse(results.Substring(19, 2));
                                set3P2 = int.Parse(results.Substring(22, 1));
                            }
                            if (scoreP1 < scoreP2)
                            {
                                set3P1 = int.Parse(results.Substring(19, 1));
                                set3P2 = int.Parse(results.Substring(21, 2));
                            }
                        }


                        string hh = h.ToString();
                        if (h < 10) { hh = "0" + h.ToString(); }
                        string mm = m.ToString();
                        if (m < 10) { mm = "0" + m.ToString(); }


                        if (isWritable)
                        {
                            StreamWriter sw = new StreamWriter("dataPhase2/dataATPSingle.txt", true);
                            sw.WriteLine(date + "," + hh + "," + mm + "," + tourTitle[1] + "," + tourTitle[2] + "," + tourTitle[3] + "," + tourTitle[4] + "," + tourTitle[5] + "," + tourTitle[6] + "," + player[1] + "," + winner + "," + player[2] + "," + scoreP1 + "," + scoreP2 + "," + set1P1 + "," + set1P2 + "," + set2P1 + "," + set2P2 + "," + set3P1 + "," + set3P2);
                            sw.Close();
                        }


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Something wrong with scores! Message: " + results);
                    }
                }
                index = tourContent.IndexOf("nowrap");
            }
        }
    }
}
