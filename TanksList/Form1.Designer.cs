namespace TanksList
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tName = new System.Windows.Forms.TextBox();
            this.tCal = new System.Windows.Forms.TextBox();
            this.Calibre = new System.Windows.Forms.Label();
            this.tPower = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tCrew = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tProdStart = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tCountry = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tProdEnd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Hämta alla";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(149, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "Uppdatera";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(285, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 39);
            this.button3.TabIndex = 2;
            this.button3.Text = "Radera";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(421, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 39);
            this.button4.TabIndex = 3;
            this.button4.Text = "Insert";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(61, 58);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(490, 564);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(557, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // tName
            // 
            this.tName.Location = new System.Drawing.Point(561, 82);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(310, 26);
            this.tName.TabIndex = 6;
            // 
            // tCal
            // 
            this.tCal.Location = new System.Drawing.Point(561, 135);
            this.tCal.Name = "tCal";
            this.tCal.Size = new System.Drawing.Size(310, 26);
            this.tCal.TabIndex = 8;
            // 
            // Calibre
            // 
            this.Calibre.AutoSize = true;
            this.Calibre.Location = new System.Drawing.Point(557, 111);
            this.Calibre.Name = "Calibre";
            this.Calibre.Size = new System.Drawing.Size(58, 20);
            this.Calibre.TabIndex = 7;
            this.Calibre.Text = "Calibre";
            // 
            // tPower
            // 
            this.tPower.Location = new System.Drawing.Point(561, 252);
            this.tPower.Name = "tPower";
            this.tPower.Size = new System.Drawing.Size(310, 26);
            this.tPower.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(557, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Hrsp";
            // 
            // tCrew
            // 
            this.tCrew.Location = new System.Drawing.Point(561, 188);
            this.tCrew.Name = "tCrew";
            this.tCrew.Size = new System.Drawing.Size(310, 26);
            this.tCrew.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(557, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Crew";
            // 
            // tProdStart
            // 
            this.tProdStart.Location = new System.Drawing.Point(561, 526);
            this.tProdStart.Name = "tProdStart";
            this.tProdStart.Size = new System.Drawing.Size(310, 26);
            this.tProdStart.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(557, 494);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Production start";
            // 
            // tPrice
            // 
            this.tPrice.Location = new System.Drawing.Point(561, 454);
            this.tPrice.Name = "tPrice";
            this.tPrice.Size = new System.Drawing.Size(310, 26);
            this.tPrice.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(557, 422);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Price (USD)";
            // 
            // tAmount
            // 
            this.tAmount.Location = new System.Drawing.Point(561, 383);
            this.tAmount.Name = "tAmount";
            this.tAmount.Size = new System.Drawing.Size(310, 26);
            this.tAmount.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(557, 360);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Amount prod.";
            // 
            // tCountry
            // 
            this.tCountry.Location = new System.Drawing.Point(561, 315);
            this.tCountry.Name = "tCountry";
            this.tCountry.Size = new System.Drawing.Size(310, 26);
            this.tCountry.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(557, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Country";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // tProdEnd
            // 
            this.tProdEnd.Location = new System.Drawing.Point(561, 596);
            this.tProdEnd.Name = "tProdEnd";
            this.tProdEnd.Size = new System.Drawing.Size(310, 26);
            this.tProdEnd.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(557, 564);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Production end";
            // 
            // tID
            // 
            this.tID.Location = new System.Drawing.Point(13, 58);
            this.tID.Name = "tID";
            this.tID.Size = new System.Drawing.Size(42, 26);
            this.tID.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 694);
            this.Controls.Add(this.tID);
            this.Controls.Add(this.tProdEnd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tProdStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tCountry);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tPower);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tCrew);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tCal);
            this.Controls.Add(this.Calibre);
            this.Controls.Add(this.tName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.TextBox tCal;
        private System.Windows.Forms.Label Calibre;
        private System.Windows.Forms.TextBox tPower;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tCrew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tProdStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tCountry;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tProdEnd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tID;
    }
}

