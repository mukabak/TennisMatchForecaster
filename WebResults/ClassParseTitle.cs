using NickBuhro.Translit;
using System;

namespace WebResults
{
    class ClassParseTitle
    {
        public static string parseTitle(string title)
        {
            string[] parts = title.Split('.');
            string newTitle = "";
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Length > 1)
                {
                    if (parts[i].IndexOf(" ") == 0)
                    {
                        parts[i] = parts[i].Substring(1, parts[i].Length - 1);
                    }
                    if (parts[i].LastIndexOf(" ") == parts[i].Length - 1)
                    {
                        parts[i] = parts[i].Substring(0, parts[i].Length - 1);
                    }

                    if (parts[i].Contains(","))
                    {
                        string newParts = "";
                        string[] smallParts = parts[i].Split(',');
                        for (int a = 0; a < smallParts.Length; a++)
                        {
                            if (smallParts[a].IndexOf(" ") == 0)
                            {
                                smallParts[a] = smallParts[a].Substring(1, smallParts[a].Length - 1);
                            }
                            if (smallParts[a].LastIndexOf(" ") == smallParts[a].Length - 1)
                            {
                                smallParts[a] = smallParts[a].Substring(0, smallParts[a].Length - 1);
                            }
                            if (smallParts[a] != "Турнир")
                            {
                                newParts += smallParts[a] + ",";
                            }
                        }
                        newParts = newParts.Substring(1, newParts.Length - 1);
                        parts[i] = newParts;

                    }
                    if (parts[i] != "Турнир" || parts[i] != "Cт" || parts[i] != "Ветераны")
                    {
                        if (parts[i] == "- Брие")
                        {
                            parts[i] = "Cт Брие";
                        }

                        string[] listATP = { "Турнир ATP", "ATP Champions Tour", "ATP World Tour Finals", "Турнирнир ATP", "ATP", "Турнир АТР", "АТР" };
                        foreach (string ATPtype in listATP)
                        {
                            if (parts[i] == ATPtype)
                            {
                                parts[i] = "ATP";
                            }

                        }
                        string[] listATPChallenger = { "ATP Challenger Tour", "Челленджер тур ATP", "ATP Next Gen Finals", "ATP World Tennis Challenge" };
                        foreach (string ATPtype in listATPChallenger)
                        {
                            if (parts[i] == ATPtype)
                            {
                                parts[i] = "ATP,Challenger";
                            }

                        }
                        string[] listChallenger = { "Челленджер" };
                        foreach (string ATPtype in listChallenger)
                        {
                            if (parts[i] == ATPtype)
                            {
                                parts[i] = "Challenger";
                            }
                        }
                        string[] listQualification = { "Квалификация" };
                        foreach (string ATPtype in listQualification)
                        {
                            if (parts[i] == ATPtype)
                            {
                                parts[i] = "Qualification";
                            }

                        }
                        string[] listHard = { "Хард", "Hard", "Open", "Indoor Hard", "Outdoor Greenset" };
                        foreach (string court in listHard)
                        {
                            if (parts[i] == court)
                            {
                                parts[i] = "Hard";
                            }

                        }
                        string[] listClay = { "Clay", "Грунт", "Грунг" };
                        foreach (string court in listClay)
                        {
                            if (parts[i] == court)
                            {
                                parts[i] = "Clay";
                            }

                        }
                        string[] listGrass = { "Трава", "Grass" };
                        foreach (string court in listGrass)
                        {
                            if (parts[i] == court)
                            {
                                parts[i] = "Grass";
                            }

                        }
                        string[] listCarpet = { "Carpet", "Ковер" };
                        foreach (string court in listCarpet)
                        {
                            if (parts[i] == court)
                            {
                                parts[i] = "Carpet";
                            }

                        }
                        string[] listFinal = { "Финал" };
                        foreach (string final in listFinal)
                        {
                            if (parts[i] == final)
                            {
                                parts[i] = "Final";
                            }

                        }
                        string[] listDoubles = { "Пары" };
                        foreach (string doubles in listDoubles)
                        {
                            if (parts[i] == doubles)
                            {
                                parts[i] = "Double";
                            }

                        }
                        if (parts[i].Length > 0)
                        {
                            newTitle += parts[i] + ",";
                        }
                    }
                }
            }
            newTitle = newTitle.Substring(0, newTitle.Length - 1);
            string[] listCourt = { ",Hard", ",Clay", ",Grass", ",Carpet" };
            Boolean isContainsCourt = false;
            foreach (string court in listCourt)
            {
                if (newTitle.Contains(court))
                {
                    isContainsCourt = true;
                }
            }
            if (!isContainsCourt)
            {
                newTitle = newTitle + ",Unknown Court";
            }
            return newTitle;
        }

        public static String[] getATP(string parsedTtile)
        {
            Boolean isATP = false;
            string allWords = "ATP,Challenger,Qualification,Double,Final,Hard,Clay,Grass,Carpet";
            Boolean isLocation = false;
            String[] temp = { "Null", "Null", "Null", "Null", "Null", "Null", "Unknown Location" };
            String[] parts = parsedTtile.Split(',');
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] == "ATP")
                {
                    isATP = true;
                    temp[0] = "ATP";
                }
                if (parts[i] == "Challenger")
                {
                    temp[1] = "Challenger";
                }
                if (parts[i] == "Qualification")
                {
                    temp[2] = "Qualification";
                }
                if (parts[i] == "Double")
                {
                    temp[3] = "Double";
                }
                if (parts[i] == "Final")
                {
                    temp[4] = "Final";
                }
                if (parts[i] == "Hard")
                {
                    temp[5] = "Hard";
                }
                if (parts[i] == "Clay")
                {
                    temp[5] = "Clay";
                }
                if (parts[i] == "Grass")
                {
                    temp[5] = "Grass";
                }
                if (parts[i] == "Carpet")
                {
                    temp[5] = "Carpet";
                }
                if (parts[i] == "Unknown Court")
                {
                    temp[5] = "Unknown Court";
                }
                if (!allWords.Contains(parts[i]) && !isLocation && parts[i].Length > 0)
                {
                    isLocation = true;
                    if((parts[i].LastIndexOf(" ") == parts[i].Length - 2) || (parts[i].LastIndexOf("-") == parts[i].Length - 2))
                    {
                        parts[i] = parts[i].Substring(0, parts[i].Length - 2);
                    }
                    temp[6] = parts[i];
                    temp[6] = Transliteration.CyrillicToLatin(temp[6], Language.Russian);
                }
            }
            if (!isATP)
            {
                temp[0] = ""; temp[1] = ""; temp[2] = ""; temp[3] = ""; temp[4] = ""; temp[5] = ""; temp[6] = "";
            }
            return temp;
        }
    }
}