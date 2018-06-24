using NickBuhro.Translit;
using System.Windows.Forms;

namespace WebResults
{
    public class ClassParsePlayersName
    {
        public static string[] parseName(string playerNames) {
            string[] temp = new string[3];
            int indexName = 0;

            if (playerNames.Contains("/"))
            {
                temp[0] = "false";
                //MessageBox.Show("Players are not correct!\nIt is a double game!\nMessage: " + players);
            }

            if (playerNames.Contains(","))
            {
                string newPlayers = "";
                string[] chars = playerNames.Split(',');
                for (int i = 0; i < chars.Length; i++)
                {
                    newPlayers += chars[i] + ".";
                }
                playerNames = newPlayers.Substring(0, newPlayers.Length - 1);
            }

            if (playerNames.Contains(". - "))
            {
                indexName = playerNames.IndexOf(". - ");
                temp[1] = playerNames.Substring(0, indexName + 1);
                temp[2] = playerNames.Substring(indexName + 4, playerNames.Length - indexName - 4);
            }
            else if (playerNames.Contains(" - "))
            {
                indexName = playerNames.IndexOf(" - ");
                temp[1] = playerNames.Substring(0, indexName);
                temp[2] = playerNames.Substring(indexName + 3, playerNames.Length - indexName - 3);
            }
            else
            {
                temp[0] = "false";
                MessageBox.Show("There is an error with players name!\nMessage: " + playerNames);
            }
            temp[1] = Transliteration.CyrillicToLatin(temp[1], Language.Russian);
            temp[2] = Transliteration.CyrillicToLatin(temp[2], Language.Russian);
            return temp;
        }
    }
}
