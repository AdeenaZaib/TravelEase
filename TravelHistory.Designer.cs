﻿namespace dbproject
{
    partial class TravelHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TravelHistory));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.history = new System.Windows.Forms.ListView();
            this.add = new System.Windows.Forms.Button();
            this.labelButton2 = new LabelButton();
            this.labelButton5 = new LabelButton();
            this.labelButton4 = new LabelButton();
            this.labelButton3 = new LabelButton();
            this.labelButton1 = new LabelButton();
            this.circularPictureBox1 = new Components.CircularPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Daminga PERSONAL USE ONLY Mediu", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "TRAVELEASE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(-3, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(811, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "_________________________________________________________________________________" +
    "_____________________________________________________";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Daminga PERSONAL USE ONLY Mediu", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(266, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Your Travel History";
            // 
            // history
            // 
            this.history.HideSelection = false;
            this.history.Location = new System.Drawing.Point(44, 188);
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(519, 227);
            this.history.TabIndex = 14;
            this.history.UseCompatibleStateImageBehavior = false;
            this.history.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.LightSteelBlue;
            this.add.Location = new System.Drawing.Point(599, 283);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(109, 42);
            this.add.TabIndex = 30;
            this.add.Text = "ADD REVIEW";
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // labelButton2
            // 
            this.labelButton2.BackColor = System.Drawing.Color.Transparent;
            this.labelButton2.BorderColor = System.Drawing.Color.Transparent;
            this.labelButton2.BorderThickness = 2;
            this.labelButton2.CornerRadius = 10;
            this.labelButton2.FillColor = System.Drawing.Color.Transparent;
            this.labelButton2.FlatAppearance.BorderSize = 0;
            this.labelButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelButton2.Font = new System.Drawing.Font("Creato Display", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelButton2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelButton2.Location = new System.Drawing.Point(487, 64);
            this.labelButton2.Name = "labelButton2";
            this.labelButton2.Size = new System.Drawing.Size(120, 23);
            this.labelButton2.TabIndex = 29;
            this.labelButton2.Text = "DIGITAL PASSES";
            this.labelButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelButton2.UseVisualStyleBackColor = false;
            this.labelButton2.Click += new System.EventHandler(this.labelButton2_Click);
            // 
            // labelButton5
            // 
            this.labelButton5.BackColor = System.Drawing.Color.Transparent;
            this.labelButton5.BorderColor = System.Drawing.Color.Transparent;
            this.labelButton5.BorderThickness = 2;
            this.labelButton5.CornerRadius = 10;
            this.labelButton5.FillColor = System.Drawing.Color.Transparent;
            this.labelButton5.FlatAppearance.BorderSize = 0;
            this.labelButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelButton5.Font = new System.Drawing.Font("Creato Display", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelButton5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelButton5.Location = new System.Drawing.Point(346, 64);
            this.labelButton5.Name = "labelButton5";
            this.labelButton5.Size = new System.Drawing.Size(120, 23);
            this.labelButton5.TabIndex = 13;
            this.labelButton5.Text = "TRAVEL HISTORY";
            this.labelButton5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelButton5.UseVisualStyleBackColor = false;
            this.labelButton5.Click += new System.EventHandler(this.labelButton5_Click_1);
            // 
            // labelButton4
            // 
            this.labelButton4.BackColor = System.Drawing.Color.Transparent;
            this.labelButton4.BorderColor = System.Drawing.Color.Transparent;
            this.labelButton4.BorderThickness = 2;
            this.labelButton4.CornerRadius = 10;
            this.labelButton4.FillColor = System.Drawing.Color.Transparent;
            this.labelButton4.FlatAppearance.BorderSize = 0;
            this.labelButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelButton4.Font = new System.Drawing.Font("Creato Display", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelButton4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelButton4.Location = new System.Drawing.Point(115, 64);
            this.labelButton4.Name = "labelButton4";
            this.labelButton4.Size = new System.Drawing.Size(104, 23);
            this.labelButton4.TabIndex = 12;
            this.labelButton4.Text = "TRIP SEARCH";
            this.labelButton4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelButton4.UseVisualStyleBackColor = false;
            this.labelButton4.Click += new System.EventHandler(this.labelButton4_Click);
            // 
            // labelButton3
            // 
            this.labelButton3.BackColor = System.Drawing.Color.Transparent;
            this.labelButton3.BorderColor = System.Drawing.Color.Transparent;
            this.labelButton3.BorderThickness = 2;
            this.labelButton3.CornerRadius = 10;
            this.labelButton3.FillColor = System.Drawing.Color.Transparent;
            this.labelButton3.FlatAppearance.BorderSize = 0;
            this.labelButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelButton3.Font = new System.Drawing.Font("Creato Display", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelButton3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelButton3.Location = new System.Drawing.Point(237, 64);
            this.labelButton3.Name = "labelButton3";
            this.labelButton3.Size = new System.Drawing.Size(85, 23);
            this.labelButton3.TabIndex = 11;
            this.labelButton3.Text = "BOOKINGS";
            this.labelButton3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelButton3.UseVisualStyleBackColor = false;
            this.labelButton3.Click += new System.EventHandler(this.labelButton3_Click_1);
            // 
            // labelButton1
            // 
            this.labelButton1.BackColor = System.Drawing.Color.Transparent;
            this.labelButton1.BorderColor = System.Drawing.Color.Transparent;
            this.labelButton1.BorderThickness = 2;
            this.labelButton1.CornerRadius = 10;
            this.labelButton1.FillColor = System.Drawing.Color.Transparent;
            this.labelButton1.FlatAppearance.BorderSize = 0;
            this.labelButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelButton1.Font = new System.Drawing.Font("Creato Display", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelButton1.Location = new System.Drawing.Point(44, 64);
            this.labelButton1.Name = "labelButton1";
            this.labelButton1.Size = new System.Drawing.Size(60, 23);
            this.labelButton1.TabIndex = 10;
            this.labelButton1.Text = "HOME";
            this.labelButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelButton1.UseVisualStyleBackColor = false;
            // 
            // circularPictureBox1
            // 
            this.circularPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.circularPictureBox1.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.circularPictureBox1.BorderColor = System.Drawing.Color.DarkKhaki;
            this.circularPictureBox1.BorderColor2 = System.Drawing.Color.DarkGreen;
            this.circularPictureBox1.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.circularPictureBox1.BorderSize = 2;
            this.circularPictureBox1.GradientAngle = 50F;
            this.circularPictureBox1.Location = new System.Drawing.Point(753, 15);
            this.circularPictureBox1.Name = "circularPictureBox1";
            this.circularPictureBox1.Size = new System.Drawing.Size(43, 43);
            this.circularPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.circularPictureBox1.TabIndex = 1;
            this.circularPictureBox1.TabStop = false;
            // 
            // TravelHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.add);
            this.Controls.Add(this.labelButton2);
            this.Controls.Add(this.history);
            this.Controls.Add(this.labelButton5);
            this.Controls.Add(this.labelButton4);
            this.Controls.Add(this.labelButton3);
            this.Controls.Add(this.labelButton1);
            this.Controls.Add(this.circularPictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TravelHistory";
            this.Text = "TravelHistory";
            this.Load += new System.EventHandler(this.TravelHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Components.CircularPictureBox circularPictureBox1;
        private LabelButton labelButton1;
        private LabelButton labelButton3;
        private LabelButton labelButton4;
        private LabelButton labelButton5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView history;
        private LabelButton labelButton2;
        private System.Windows.Forms.Button add;
    }
}