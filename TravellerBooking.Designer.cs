﻿namespace dbproject
{
    partial class TravellerBooking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TravellerBooking));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bookingsView = new System.Windows.Forms.ListView();
            this.actionComboBox = new System.Windows.Forms.ComboBox();
            this.ppl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.apply = new System.Windows.Forms.Button();
            this.noppl = new System.Windows.Forms.RichTextBox();
            this.combo = new System.Windows.Forms.ComboBox();
            this.labelButton2 = new LabelButton();
            this.labelButton5 = new LabelButton();
            this.labelButton4 = new LabelButton();
            this.labelButton3 = new LabelButton();
            this.labelButton1 = new LabelButton();
            this.circularPictureBox1 = new Components.CircularPictureBox();
            this.change = new System.Windows.Forms.Button();
            this.chg = new System.Windows.Forms.Label();
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
            this.label1.Size = new System.Drawing.Size(129, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "TravelEase";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Daminga PERSONAL USE ONLY Mediu", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(341, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bookings";
            this.label2.Click += new System.EventHandler(this.label2_Click);
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
            // bookingsView
            // 
            this.bookingsView.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bookingsView.HideSelection = false;
            this.bookingsView.Location = new System.Drawing.Point(24, 171);
            this.bookingsView.Name = "bookingsView";
            this.bookingsView.Size = new System.Drawing.Size(422, 239);
            this.bookingsView.TabIndex = 14;
            this.bookingsView.UseCompatibleStateImageBehavior = false;
            this.bookingsView.SelectedIndexChanged += new System.EventHandler(this.bookingsView_SelectedIndexChanged);
            // 
            // actionComboBox
            // 
            this.actionComboBox.FormattingEnabled = true;
            this.actionComboBox.Location = new System.Drawing.Point(613, 277);
            this.actionComboBox.Name = "actionComboBox";
            this.actionComboBox.Size = new System.Drawing.Size(121, 21);
            this.actionComboBox.TabIndex = 15;
            // 
            // ppl
            // 
            this.ppl.AutoSize = true;
            this.ppl.BackColor = System.Drawing.Color.Transparent;
            this.ppl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ppl.Location = new System.Drawing.Point(547, 226);
            this.ppl.Name = "ppl";
            this.ppl.Size = new System.Drawing.Size(171, 16);
            this.ppl.TabIndex = 27;
            this.ppl.Text = "Enter the Number of People";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(506, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Select Action:";
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(583, 330);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(86, 31);
            this.apply.TabIndex = 30;
            this.apply.Text = " APPLY";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // noppl
            // 
            this.noppl.Location = new System.Drawing.Point(570, 255);
            this.noppl.Name = "noppl";
            this.noppl.Size = new System.Drawing.Size(121, 24);
            this.noppl.TabIndex = 16;
            this.noppl.Text = "";
            // 
            // combo
            // 
            this.combo.FormattingEnabled = true;
            this.combo.Location = new System.Drawing.Point(570, 281);
            this.combo.Name = "combo";
            this.combo.Size = new System.Drawing.Size(121, 21);
            this.combo.TabIndex = 31;
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
            this.labelButton5.Click += new System.EventHandler(this.labelButton5_Click);
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
            this.labelButton3.Click += new System.EventHandler(this.labelButton3_Click);
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
            this.labelButton1.Click += new System.EventHandler(this.labelButton1_Click);
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
            this.circularPictureBox1.Location = new System.Drawing.Point(745, 12);
            this.circularPictureBox1.Name = "circularPictureBox1";
            this.circularPictureBox1.Size = new System.Drawing.Size(43, 43);
            this.circularPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.circularPictureBox1.TabIndex = 1;
            this.circularPictureBox1.TabStop = false;
            // 
            // change
            // 
            this.change.Location = new System.Drawing.Point(583, 301);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(86, 23);
            this.change.TabIndex = 32;
            this.change.Text = "CHANGE";
            this.change.UseVisualStyleBackColor = true;
            this.change.Click += new System.EventHandler(this.change_Click);
            // 
            // chg
            // 
            this.chg.AutoSize = true;
            this.chg.BackColor = System.Drawing.Color.Transparent;
            this.chg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chg.Location = new System.Drawing.Point(538, 242);
            this.chg.Name = "chg";
            this.chg.Size = new System.Drawing.Size(196, 16);
            this.chg.TabIndex = 33;
            this.chg.Text = "Make Changes to Your Booking";
            // 
            // TravellerBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chg);
            this.Controls.Add(this.change);
            this.Controls.Add(this.combo);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.labelButton2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ppl);
            this.Controls.Add(this.noppl);
            this.Controls.Add(this.actionComboBox);
            this.Controls.Add(this.bookingsView);
            this.Controls.Add(this.labelButton5);
            this.Controls.Add(this.labelButton4);
            this.Controls.Add(this.labelButton3);
            this.Controls.Add(this.labelButton1);
            this.Controls.Add(this.circularPictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TravellerBooking";
            this.Text = "TravellerBooking";
            this.Load += new System.EventHandler(this.TravellerBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Components.CircularPictureBox circularPictureBox1;
        private LabelButton labelButton1;
        private LabelButton labelButton3;
        private LabelButton labelButton4;
        private LabelButton labelButton5;
        private System.Windows.Forms.ListView bookingsView;
        private System.Windows.Forms.ComboBox actionComboBox;
        private System.Windows.Forms.Label ppl;
        private System.Windows.Forms.Label label4;
        private LabelButton labelButton2;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.RichTextBox noppl;
        private System.Windows.Forms.ComboBox combo;
        private System.Windows.Forms.Button change;
        private System.Windows.Forms.Label chg;
    }
}