
namespace ShipsAndPorts_LinearShell
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawHullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.methodJarviusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readFromFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.drawPointGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawShellGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.shipMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.drawToolStripMenuItem,
            this.createGroupToolStripMenuItem,
            this.shipMoveToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1193, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readFromFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // readFromFileToolStripMenuItem
            // 
            this.readFromFileToolStripMenuItem.Name = "readFromFileToolStripMenuItem";
            this.readFromFileToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.readFromFileToolStripMenuItem.Text = "Read From File";
            this.readFromFileToolStripMenuItem.Click += new System.EventHandler(this.readFromFileToolStripMenuItem_Click);
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawPointToolStripMenuItem,
            this.drawHullToolStripMenuItem,
            this.methodJarviusToolStripMenuItem});
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.drawToolStripMenuItem.Text = "Draw";
            // 
            // drawPointToolStripMenuItem
            // 
            this.drawPointToolStripMenuItem.Name = "drawPointToolStripMenuItem";
            this.drawPointToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.drawPointToolStripMenuItem.Text = "drawPoint";
            this.drawPointToolStripMenuItem.Click += new System.EventHandler(this.drawPointToolStripMenuItem_Click);
            // 
            // drawHullToolStripMenuItem
            // 
            this.drawHullToolStripMenuItem.Name = "drawHullToolStripMenuItem";
            this.drawHullToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.drawHullToolStripMenuItem.Text = "drawHull";
            this.drawHullToolStripMenuItem.Click += new System.EventHandler(this.drawHullToolStripMenuItem_Click);
            // 
            // methodJarviusToolStripMenuItem
            // 
            this.methodJarviusToolStripMenuItem.Name = "methodJarviusToolStripMenuItem";
            this.methodJarviusToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.methodJarviusToolStripMenuItem.Text = "MethodJarvius";
            this.methodJarviusToolStripMenuItem.Click += new System.EventHandler(this.methodJarviusToolStripMenuItem_Click);
            // 
            // createGroupToolStripMenuItem
            // 
            this.createGroupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readFromFileToolStripMenuItem1,
            this.drawPointGroupToolStripMenuItem,
            this.drawShellGroupToolStripMenuItem});
            this.createGroupToolStripMenuItem.Name = "createGroupToolStripMenuItem";
            this.createGroupToolStripMenuItem.Size = new System.Drawing.Size(107, 24);
            this.createGroupToolStripMenuItem.Text = "CreateGroup";
            // 
            // readFromFileToolStripMenuItem1
            // 
            this.readFromFileToolStripMenuItem1.Name = "readFromFileToolStripMenuItem1";
            this.readFromFileToolStripMenuItem1.Size = new System.Drawing.Size(199, 26);
            this.readFromFileToolStripMenuItem1.Text = "ReadFromFile";
            this.readFromFileToolStripMenuItem1.Click += new System.EventHandler(this.readFromFileToolStripMenuItem1_Click);
            // 
            // drawPointGroupToolStripMenuItem
            // 
            this.drawPointGroupToolStripMenuItem.Name = "drawPointGroupToolStripMenuItem";
            this.drawPointGroupToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.drawPointGroupToolStripMenuItem.Text = "drawPointGroup";
            this.drawPointGroupToolStripMenuItem.Click += new System.EventHandler(this.drawPointGroupToolStripMenuItem_Click);
            // 
            // drawShellGroupToolStripMenuItem
            // 
            this.drawShellGroupToolStripMenuItem.Name = "drawShellGroupToolStripMenuItem";
            this.drawShellGroupToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.drawShellGroupToolStripMenuItem.Text = "drawShellGroup";
            this.drawShellGroupToolStripMenuItem.Click += new System.EventHandler(this.drawShellGroupToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(13, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(900, 377);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(967, 150);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(201, 372);
            this.listBox1.TabIndex = 2;
            // 
            // shipMoveToolStripMenuItem
            // 
            this.shipMoveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawToolStripMenuItem1});
            this.shipMoveToolStripMenuItem.Name = "shipMoveToolStripMenuItem";
            this.shipMoveToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.shipMoveToolStripMenuItem.Text = "ShipMove";
            // 
            // drawToolStripMenuItem1
            // 
            this.drawToolStripMenuItem1.Name = "drawToolStripMenuItem1";
            this.drawToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.drawToolStripMenuItem1.Text = "Draw";
            this.drawToolStripMenuItem1.Click += new System.EventHandler(this.drawToolStripMenuItem1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 570);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readFromFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawHullToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem methodJarviusToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem createGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readFromFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem drawPointGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawShellGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shipMoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem1;
        private System.Windows.Forms.Timer timer1;
    }
}

