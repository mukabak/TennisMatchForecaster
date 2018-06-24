using MindFusion.Charting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebResults
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            int[] DORA = new int[3];
            DORA[0] = 0;
            DORA[1] = 1;
            DORA[2] = 4;
            lineChart1.XDataFields.Clear();
            DataBoundSeries series1 = new DataBoundSeries(DORA);
            series1.Title = "12";
            series1.XDataField = "AGE";

            series1.YDataField = "";
            //let the control know changes have been made
            lineChart1.Series.Add(series1);

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            panelContent.Visible = false;
            ClassUpcomingGames.start(this);
            panelContent.Visible = true;
        }

        private void lineChart1_DataItemClicked(object sender, MindFusion.Charting.HitResult e)
        {

        }

        private void displayPlayedGames(string name)
        {
            string path = "dataPhase2/dataATPSingle.txt";
            StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                string[] parts = sr.ReadLine().Split(',');
                if (parts[9] == name && parts[10] == "1") { // p1 win

                }
            }
            sr.Close();
        }
    }
}