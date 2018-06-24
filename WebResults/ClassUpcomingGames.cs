using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebResults
{
    class ClassUpcomingGames
    {
        static Form formMain;
        public static void start(Form main)
        {
            formMain = main;
            var panelContent = formMain.Controls.Find("panelContent", true).FirstOrDefault();
            panelContent.Controls.Clear();
            read("dataPhase3/coefficientUpcomingATPSingle.txt");
        }

        private static void read(string path)
        {
            int counter = 0;
            StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                counter++;
                string[] parts = sr.ReadLine().Split(',');
                generateGUI(counter, parts);
            }

            sr.Close();
        }

        private static void generateGUI(int id, string[] parts) {
            Panel panelCUGContent = new Panel();
            panelCUGContent.BackgroundImage = Properties.Resources.bg01;
            panelCUGContent.Dock = DockStyle.Top;
            panelCUGContent.Name = "panelCUGContent" + id;
            panelCUGContent.Size = new Size(0, 50);

            Panel panelCUGLine = new Panel();
            panelCUGLine.BackColor = Color.FromArgb(0, 130, 130);
            panelCUGLine.Dock = DockStyle.Top;
            panelCUGLine.Name = "panelCUGLine" + id;
            panelCUGLine.Size = new Size(0, 1);
            panelCUGContent.Controls.Add(panelCUGLine);


            Label labelCUGCounter = new Label();
            labelCUGCounter.Name = "labelCUGCounter" + id;
            labelCUGCounter.Text = "[" + id + "]";
            labelCUGCounter.BackColor = Color.Transparent;
            labelCUGCounter.ForeColor = Color.Gold;
            labelCUGCounter.Font = new Font("Century Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCUGCounter.AutoSize = true;
            labelCUGCounter.Location = new Point(5, 12);
            panelCUGContent.Controls.Add(labelCUGCounter);


            Label labelCUGDate = new Label();
            labelCUGDate.Name = "labelCUGDate" + id;
            labelCUGDate.Text = parts[0] + " (" + parts[1] + ")";
            labelCUGDate.BackColor = Color.Transparent;
            labelCUGDate.ForeColor = Color.Red;
            labelCUGDate.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCUGDate.AutoSize = true;
            labelCUGDate.Location = new Point(60, 5);
            panelCUGContent.Controls.Add(labelCUGDate);

            Label labelCUGLocationCourt = new Label();
            labelCUGLocationCourt.Name = "labelCUGLocation" + id;
            labelCUGLocationCourt.Text = parts[8] + " (" + parts[7] + ")";
            labelCUGLocationCourt.BackColor = Color.Transparent;
            labelCUGLocationCourt.ForeColor = Color.Green;
            labelCUGLocationCourt.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCUGLocationCourt.AutoSize = true;
            labelCUGLocationCourt.Location = new Point(200, 5);
            panelCUGContent.Controls.Add(labelCUGLocationCourt);

            Label labelCUGPlayers = new Label();
            labelCUGPlayers.Name = "labelCUGPlayers" + id;
            labelCUGPlayers.Text = parts[9] + " ::: VS ::: " + parts[10];
            labelCUGPlayers.BackColor = Color.Transparent;
            labelCUGPlayers.ForeColor = Color.LightGreen;
            labelCUGPlayers.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCUGPlayers.AutoSize = true;
            panelCUGContent.Controls.Add(labelCUGPlayers);
            labelCUGPlayers.Location = new Point((formMain.Width - labelCUGPlayers.Width) / 2, 5);

            Panel panelCUGType = new Panel();
            panelCUGType.BackColor = Color.Transparent;
            panelCUGType.Name = "panelCUGType" + id;
            panelCUGType.Size = new Size(350, 20);
            panelCUGType.Location = new Point(formMain.Width - 370, 5);
            panelCUGContent.Controls.Add(panelCUGType);

            if (parts[6] == "Final")
            {
                PictureBox pbCUGFinal = new PictureBox();
                pbCUGFinal.BackColor = Color.Transparent;
                pbCUGFinal.Image = Properties.Resources.typeFinal;
                pbCUGFinal.SizeMode = PictureBoxSizeMode.CenterImage;
                pbCUGFinal.Name = "pbCUGFinal" + id;
                pbCUGFinal.Size = new Size(69, 20);
                pbCUGFinal.Dock = DockStyle.Left;
                panelCUGType.Controls.Add(pbCUGFinal);
            }

            if (parts[4] == "Qualification")
            {
                PictureBox pbCUGQualification = new PictureBox();
                pbCUGQualification.BackColor = Color.Transparent;
                pbCUGQualification.Image = Properties.Resources.typeQualification;
                pbCUGQualification.SizeMode = PictureBoxSizeMode.CenterImage;
                pbCUGQualification.Name = "pbCUGQualification" + id;
                pbCUGQualification.Size = new Size(106, 20);
                pbCUGQualification.Dock = DockStyle.Left;
                panelCUGType.Controls.Add(pbCUGQualification);
            }

            if (parts[3] == "Challenger")
            {
                PictureBox pbCUGChallenger = new PictureBox();
                pbCUGChallenger.BackColor = Color.Transparent;
                pbCUGChallenger.Image = Properties.Resources.typeChallenger;
                pbCUGChallenger.SizeMode = PictureBoxSizeMode.CenterImage;
                pbCUGChallenger.Name = "pbCUGChallenger" + id;
                pbCUGChallenger.Size = new Size(106, 20);
                pbCUGChallenger.Dock = DockStyle.Left;
                panelCUGType.Controls.Add(pbCUGChallenger);
            }

            if (parts[2] == "ATP")
            {
                PictureBox pbCUGATP = new PictureBox();
                pbCUGATP.BackColor = Color.Transparent;
                pbCUGATP.Image = Properties.Resources.typeATP;
                pbCUGATP.SizeMode = PictureBoxSizeMode.CenterImage;
                pbCUGATP.Name = "pbCUGATP" + id;
                pbCUGATP.Size = new Size(69, 20);
                pbCUGATP.Dock = DockStyle.Left;
                panelCUGType.Controls.Add(pbCUGATP);
            }

            Label labelCUGP1 = new Label();
            labelCUGP1.Name = "labelCUGP1" + id;
            labelCUGP1.Text = "P1 [" + parts[11].Substring(parts[11].IndexOf("=") + 1, parts[11].Length - parts[11].IndexOf("=") - 1) + "]";
            labelCUGP1.BackColor = Color.Transparent;
            labelCUGP1.ForeColor = Color.Blue;
            labelCUGP1.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCUGP1.AutoSize = true;
            panelCUGContent.Controls.Add(labelCUGP1);
            labelCUGP1.Location = new Point(60, 25);

            Label labelCUGP2 = new Label();
            labelCUGP2.Name = "labelCUGP2" + id;
            labelCUGP2.Text = "P2 [" + parts[12].Substring(parts[12].IndexOf("=") + 1, parts[12].Length- parts[12].IndexOf("=") - 1) + "]";
            labelCUGP2.BackColor = Color.Transparent;
            labelCUGP2.ForeColor = Color.Blue;
            labelCUGP2.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCUGP2.AutoSize = true;
            panelCUGContent.Controls.Add(labelCUGP2);
            labelCUGP2.Location = new Point(160, 25);

            Label labelCUGS2_0 = new Label();
            labelCUGS2_0.Name = "labelCUGS2_0" + id;
            labelCUGS2_0.Text = "2:0 [" + parts[13].Substring(parts[13].IndexOf("=") + 1, parts[13].Length - parts[13].IndexOf("=") - 1) + "]";
            labelCUGS2_0.BackColor = Color.Transparent;
            labelCUGS2_0.ForeColor = Color.Blue;
            labelCUGS2_0.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCUGS2_0.AutoSize = true;
            panelCUGContent.Controls.Add(labelCUGS2_0);
            labelCUGS2_0.Location = new Point(260, 25);

            Label labelCUGS2_1 = new Label();
            labelCUGS2_1.Name = "labelCUGS2_1" + id;
            labelCUGS2_1.Text = "2:1 [" + parts[14].Substring(parts[14].IndexOf("=") + 1, parts[14].Length - parts[14].IndexOf("=") - 1) + "]";
            labelCUGS2_1.BackColor = Color.Transparent;
            labelCUGS2_1.ForeColor = Color.Blue;
            labelCUGS2_1.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCUGS2_1.AutoSize = true;
            panelCUGContent.Controls.Add(labelCUGS2_1);
            labelCUGS2_1.Location = new Point(360, 25);

            Label labelCUGS1_2 = new Label();
            labelCUGS1_2.Name = "labelCUGS1_2" + id;
            labelCUGS1_2.Text = "1:2 [" + parts[15].Substring(parts[15].IndexOf("=") + 1, parts[15].Length - parts[15].IndexOf("=") - 1) + "]";
            labelCUGS1_2.BackColor = Color.Transparent;
            labelCUGS1_2.ForeColor = Color.Blue;
            labelCUGS1_2.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCUGS1_2.AutoSize = true;
            panelCUGContent.Controls.Add(labelCUGS1_2);
            labelCUGS1_2.Location = new Point(460, 25);

            Label labelCUGS0_2 = new Label();
            labelCUGS0_2.Name = "labelCUGS0_2" + id;
            labelCUGS0_2.Text = "0:2 [" + parts[16].Substring(parts[16].IndexOf("=") + 1, parts[16].Length - parts[16].IndexOf("=") - 1) + "]";
            labelCUGS0_2.BackColor = Color.Transparent;
            labelCUGS0_2.ForeColor = Color.Blue;
            labelCUGS0_2.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCUGS0_2.AutoSize = true;
            panelCUGContent.Controls.Add(labelCUGS0_2);
            labelCUGS0_2.Location = new Point(560, 25);

            Label labelCUGH1 = new Label();
            labelCUGH1.Name = "labelCUGH1" + id;
            labelCUGH1.Text = parts[17].Substring(0, parts[17].IndexOf("=")) + " [" + parts[17].Substring(parts[17].IndexOf("=") + 1, parts[17].Length - parts[17].IndexOf("=") - 1) + "]";
            labelCUGH1.BackColor = Color.Transparent;
            labelCUGH1.ForeColor = Color.Blue;
            labelCUGH1.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCUGH1.AutoSize = true;
            panelCUGContent.Controls.Add(labelCUGH1);
            labelCUGH1.Location = new Point(660, 25);

            Label labelCUGH2 = new Label();
            labelCUGH2.Name = "labelCUGH2" + id;
            labelCUGH2.Text = parts[18].Substring(0, parts[18].IndexOf("=")) + " [" + parts[18].Substring(parts[18].IndexOf("=") + 1, parts[18].Length - parts[18].IndexOf("=") - 1) + "]";
            labelCUGH2.BackColor = Color.Transparent;
            labelCUGH2.ForeColor = Color.Blue;
            labelCUGH2.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCUGH2.AutoSize = true;
            panelCUGContent.Controls.Add(labelCUGH2);
            labelCUGH2.Location = new Point(790, 25);

            Label labelCUGTU = new Label();
            labelCUGTU.Name = "labelCUGTU" + id;
            labelCUGTU.Text = parts[19].Substring(0, parts[19].IndexOf("=")) + " [" + parts[19].Substring(parts[19].IndexOf("=") + 1, parts[19].Length - parts[19].IndexOf("=") - 1) + "]";
            labelCUGTU.BackColor = Color.Transparent;
            labelCUGTU.ForeColor = Color.Blue;
            labelCUGTU.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCUGTU.AutoSize = true;
            panelCUGContent.Controls.Add(labelCUGTU);
            labelCUGTU.Location = new Point(920, 25);

            Label labelCUGTO = new Label();
            labelCUGTO.Name = "labelCUGTO" + id;
            labelCUGTO.Text = parts[20].Substring(0, parts[20].IndexOf("=")) + " [" + parts[20].Substring(parts[20].IndexOf("=") + 1, parts[20].Length - parts[20].IndexOf("=") - 1) + "]";
            labelCUGTO.BackColor = Color.Transparent;
            labelCUGTO.ForeColor = Color.Blue;
            labelCUGTO.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCUGTO.AutoSize = true;
            panelCUGContent.Controls.Add(labelCUGTO);
            labelCUGTO.Location = new Point(1050, 25);


            var panelContent = formMain.Controls.Find("panelContent", true).FirstOrDefault();
            Point pointPanel = panelCUGContent.PointToScreen(new Point(0, 0));
            panelCUGContent.Parent = panelContent;
            panelCUGContent.Location = panelContent.PointToClient(pointPanel);
            panelCUGContent.BringToFront();
        }
    }
}
