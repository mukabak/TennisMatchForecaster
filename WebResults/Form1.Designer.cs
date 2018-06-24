using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WebResults
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Boolean updating = false;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lineChart1 = new MindFusion.Charting.WinForms.LineChart();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.pbPMUpcoming = new System.Windows.Forms.PictureBox();
            this.pbPMSpace = new System.Windows.Forms.PictureBox();
            this.panelLine = new System.Windows.Forms.Panel();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPLName = new System.Windows.Forms.Label();
            this.panelControlBox = new System.Windows.Forms.Panel();
            this.pbPCBUpdate = new System.Windows.Forms.PictureBox();
            this.picPCBMin = new System.Windows.Forms.PictureBox();
            this.picPCBClose = new System.Windows.Forms.PictureBox();
            this.panelCenter.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPMUpcoming)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPMSpace)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelControlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPCBUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPCBMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPCBClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.BackColor = System.Drawing.Color.Transparent;
            this.panelCenter.BackgroundImage = global::WebResults.Properties.Resources.bg01;
            this.panelCenter.Controls.Add(this.panelContent);
            this.panelCenter.Controls.Add(this.panelMenu);
            this.panelCenter.Controls.Add(this.panelLine);
            this.panelCenter.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 49);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(800, 521);
            this.panelCenter.TabIndex = 2;
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.Transparent;
            this.panelContent.Controls.Add(this.pictureBox2);
            this.panelContent.Controls.Add(this.lineChart1);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 71);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(800, 450);
            this.panelContent.TabIndex = 4;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::WebResults.Properties.Resources.logo25;
            this.pictureBox2.Location = new System.Drawing.Point(320, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(260, 25);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // lineChart1
            // 
            this.lineChart1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lineChart1.BackgroundImage = global::WebResults.Properties.Resources.bg01;
            this.lineChart1.BackgroundImageAlign = MindFusion.Drawing.ImageAlign.TopRight;
            this.lineChart1.ForeColor = System.Drawing.Color.DarkRed;
            this.lineChart1.LegendTitle = "IHIUGUG";
            this.lineChart1.Location = new System.Drawing.Point(169, 4);
            this.lineChart1.Name = "lineChart1";
            this.lineChart1.Padding = new System.Windows.Forms.Padding(5);
            this.lineChart1.ShowLegend = true;
            this.lineChart1.Size = new System.Drawing.Size(411, 256);
            this.lineChart1.SubtitleFontName = null;
            this.lineChart1.SubtitleFontSize = null;
            this.lineChart1.SubtitleFontStyle = null;
            this.lineChart1.TabIndex = 1;
            this.lineChart1.Text = "lineChart1";
            this.lineChart1.Theme.UniformSeriesFill = new MindFusion.Drawing.SolidBrush("#FF90EE90");
            this.lineChart1.Theme.UniformSeriesStroke = new MindFusion.Drawing.SolidBrush("#FF000000");
            this.lineChart1.Theme.UniformSeriesStrokeThickness = 2D;
            this.lineChart1.TitleFontName = null;
            this.lineChart1.TitleFontSize = null;
            this.lineChart1.TitleFontStyle = null;
            this.lineChart1.DataItemClicked += new System.EventHandler<MindFusion.Charting.HitResult>(this.lineChart1_DataItemClicked);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelMenu.Controls.Add(this.pbPMUpcoming);
            this.panelMenu.Controls.Add(this.pbPMSpace);
            this.panelMenu.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 1);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(800, 70);
            this.panelMenu.TabIndex = 3;
            // 
            // pbPMUpcoming
            // 
            this.pbPMUpcoming.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPMUpcoming.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbPMUpcoming.Image = global::WebResults.Properties.Resources.upcoming1;
            this.pbPMUpcoming.Location = new System.Drawing.Point(10, 0);
            this.pbPMUpcoming.Name = "pbPMUpcoming";
            this.pbPMUpcoming.Size = new System.Drawing.Size(80, 70);
            this.pbPMUpcoming.TabIndex = 1;
            this.pbPMUpcoming.TabStop = false;
            this.pbPMUpcoming.Click += new System.EventHandler(this.pbPMUpcoming_Click);
            this.pbPMUpcoming.MouseEnter += new System.EventHandler(this.pbPMUpcoming_MouseEnter);
            this.pbPMUpcoming.MouseLeave += new System.EventHandler(this.pbPMUpcoming_MouseLeave);
            // 
            // pbPMSpace
            // 
            this.pbPMSpace.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbPMSpace.Location = new System.Drawing.Point(0, 0);
            this.pbPMSpace.Name = "pbPMSpace";
            this.pbPMSpace.Size = new System.Drawing.Size(10, 70);
            this.pbPMSpace.TabIndex = 0;
            this.pbPMSpace.TabStop = false;
            // 
            // panelLine
            // 
            this.panelLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.panelLine.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLine.Location = new System.Drawing.Point(0, 0);
            this.panelLine.Name = "panelLine";
            this.panelLine.Size = new System.Drawing.Size(800, 1);
            this.panelLine.TabIndex = 2;
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.Transparent;
            this.panelFooter.BackgroundImage = global::WebResults.Properties.Resources.bg01;
            this.panelFooter.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 570);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(800, 30);
            this.panelFooter.TabIndex = 1;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelHeader.BackgroundImage")));
            this.panelHeader.Controls.Add(this.panelLogo);
            this.panelHeader.Controls.Add(this.panelControlBox);
            this.panelHeader.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(800, 49);
            this.panelHeader.TabIndex = 0;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.Transparent;
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Controls.Add(this.lblPLName);
            this.panelLogo.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 49);
            this.panelLogo.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::WebResults.Properties.Resources.logo25;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblPLName
            // 
            this.lblPLName.AutoSize = true;
            this.lblPLName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPLName.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPLName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.lblPLName.Location = new System.Drawing.Point(40, 14);
            this.lblPLName.Name = "lblPLName";
            this.lblPLName.Size = new System.Drawing.Size(165, 22);
            this.lblPLName.TabIndex = 0;
            this.lblPLName.Text = "Tennis Forecaster";
            // 
            // panelControlBox
            // 
            this.panelControlBox.BackColor = System.Drawing.Color.Transparent;
            this.panelControlBox.Controls.Add(this.pbPCBUpdate);
            this.panelControlBox.Controls.Add(this.picPCBMin);
            this.panelControlBox.Controls.Add(this.picPCBClose);
            this.panelControlBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelControlBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControlBox.Location = new System.Drawing.Point(685, 0);
            this.panelControlBox.Name = "panelControlBox";
            this.panelControlBox.Size = new System.Drawing.Size(115, 49);
            this.panelControlBox.TabIndex = 0;
            // 
            // pbPCBUpdate
            // 
            this.pbPCBUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPCBUpdate.ErrorImage = null;
            this.pbPCBUpdate.Image = global::WebResults.Properties.Resources.update1;
            this.pbPCBUpdate.Location = new System.Drawing.Point(10, 12);
            this.pbPCBUpdate.Name = "pbPCBUpdate";
            this.pbPCBUpdate.Size = new System.Drawing.Size(25, 25);
            this.pbPCBUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPCBUpdate.TabIndex = 3;
            this.pbPCBUpdate.TabStop = false;
            this.pbPCBUpdate.Click += new System.EventHandler(this.pbPCBUpdate_Click);
            this.pbPCBUpdate.MouseEnter += new System.EventHandler(this.pbPCBUpdate_MouseEnter);
            this.pbPCBUpdate.MouseLeave += new System.EventHandler(this.pbPCBUpdate_MouseLeave);
            // 
            // picPCBMin
            // 
            this.picPCBMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picPCBMin.BackgroundImage")));
            this.picPCBMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPCBMin.ErrorImage = null;
            this.picPCBMin.Image = global::WebResults.Properties.Resources.min1;
            this.picPCBMin.Location = new System.Drawing.Point(45, 12);
            this.picPCBMin.Name = "picPCBMin";
            this.picPCBMin.Size = new System.Drawing.Size(25, 25);
            this.picPCBMin.TabIndex = 2;
            this.picPCBMin.TabStop = false;
            this.picPCBMin.Click += new System.EventHandler(this.picPCBMin_Click);
            this.picPCBMin.MouseEnter += new System.EventHandler(this.picPCBMin_MouseEnter);
            this.picPCBMin.MouseLeave += new System.EventHandler(this.picPCBMin_MouseLeave);
            // 
            // picPCBClose
            // 
            this.picPCBClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picPCBClose.BackgroundImage")));
            this.picPCBClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPCBClose.Image = global::WebResults.Properties.Resources.close1;
            this.picPCBClose.Location = new System.Drawing.Point(80, 12);
            this.picPCBClose.Name = "picPCBClose";
            this.picPCBClose.Size = new System.Drawing.Size(25, 25);
            this.picPCBClose.TabIndex = 0;
            this.picPCBClose.TabStop = false;
            this.picPCBClose.Click += new System.EventHandler(this.picPCBClose_Click);
            this.picPCBClose.MouseEnter += new System.EventHandler(this.picPCBClose_MouseEnter);
            this.picPCBClose.MouseLeave += new System.EventHandler(this.picPCBClose_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelCenter.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPMUpcoming)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPMSpace)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelControlBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPCBUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPCBMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPCBClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelControlBox;
        private System.Windows.Forms.PictureBox picPCBClose;

        private void picPCBClose_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pb.Image = Properties.Resources.close2;
        }

        private void picPCBClose_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pb.Image = Properties.Resources.close1;
        }

        private void picPCBClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void picPCBMin_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pb.Image = Properties.Resources.min2;
        }

        private void picPCBMin_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pb.Image = Properties.Resources.min1;
        }

        private void picPCBMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pbPMUpcoming_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pb.Image = Properties.Resources.upcoming2;
        }

        private void pbPMUpcoming_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pb.Image = Properties.Resources.upcoming1;
        }

        private void pbPMUpcoming_Click(object sender, EventArgs e)
        {
            panelContent.Visible = false;
            ClassUpcomingGames.start(this);
            panelContent.Visible = true;
        }

        private void callClassUpcomingGames() {
            ClassUpcomingGames.start(this);
        }

        private void pbPCBUpdate_MouseEnter(object sender, EventArgs e)
        {
            if (updating == false)
            {
                PictureBox pb = sender as PictureBox;
                pb.Image = Properties.Resources.update2;
            }
        }

        private void pbPCBUpdate_MouseLeave(object sender, EventArgs e)
        {
            if (updating == false)
            {
                PictureBox pb = sender as PictureBox;
                pb.Image = Properties.Resources.update1;
            }
        }

        private void pbPCBUpdate_Click(object sender, EventArgs e)
        {
            updating = true;
            PictureBox pb = sender as PictureBox;
            pb.Image = Properties.Resources.updating;

            MethodInvoker myProcessStarter = new MethodInvoker(update);
            myProcessStarter.BeginInvoke(null, null);
        }

        public void update() {
            ClassPhase1.start();
            ClassPhase2.start();
            ClassPhase3.start();
            updating = false;
            pbPCBUpdate.Image = Properties.Resources.update1;
        }

        private PictureBox picPCBMin;
        private Panel panelLogo;
        private Label lblPLName;
        private Panel panelFooter;
        private PictureBox pictureBox1;
        private Panel panelLine;
        private Panel panelCenter;
        private Panel panelMenu;
        private Panel panelContent;
        private PictureBox pbPMSpace;
        private PictureBox pbPMUpcoming;
        private PictureBox pbPCBUpdate;
        private MindFusion.Charting.WinForms.LineChart lineChart1;
        private PictureBox pictureBox2;
    }
}

