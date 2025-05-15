namespace dbproject
{
    partial class BookTrip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookTrip));
            this.translucentRoundedPanel1 = new Components.TranslucentRoundedPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new Components.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TripReview = new Components.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.translucentRoundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // translucentRoundedPanel1
            // 
            this.translucentRoundedPanel1.BackColor = System.Drawing.Color.Transparent;
            this.translucentRoundedPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.translucentRoundedPanel1.BorderWidth = 1;
            this.translucentRoundedPanel1.Controls.Add(this.label9);
            this.translucentRoundedPanel1.Controls.Add(this.button1);
            this.translucentRoundedPanel1.Controls.Add(this.label2);
            this.translucentRoundedPanel1.Controls.Add(this.textBox1);
            this.translucentRoundedPanel1.Controls.Add(this.label1);
            this.translucentRoundedPanel1.Controls.Add(this.TripReview);
            this.translucentRoundedPanel1.Controls.Add(this.label4);
            this.translucentRoundedPanel1.CornerRadius = 10;
            this.translucentRoundedPanel1.Location = new System.Drawing.Point(148, 32);
            this.translucentRoundedPanel1.Name = "translucentRoundedPanel1";
            this.translucentRoundedPanel1.Size = new System.Drawing.Size(505, 386);
            this.translucentRoundedPanel1.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Chocolate;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(193, 307);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 25);
            this.button1.TabIndex = 32;
            this.button1.Text = "BOOK TRIP";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(92, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "No of people";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderColor = System.Drawing.Color.Transparent;
            this.textBox1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textBox1.BorderRadius = 0;
            this.textBox1.BorderSize = 2;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.Location = new System.Drawing.Point(96, 208);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.textBox1.PasswordChar = false;
            this.textBox1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBox1.PlaceholderText = "";
            this.textBox1.Size = new System.Drawing.Size(287, 31);
            this.textBox1.TabIndex = 22;
            this.textBox1.Texts = "";
            this.textBox1.UnderlinedStyle = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(92, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Traveller ID";
            // 
            // TripReview
            // 
            this.TripReview.BackColor = System.Drawing.SystemColors.Window;
            this.TripReview.BorderColor = System.Drawing.Color.Transparent;
            this.TripReview.BorderFocusColor = System.Drawing.Color.HotPink;
            this.TripReview.BorderRadius = 0;
            this.TripReview.BorderSize = 2;
            this.TripReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TripReview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TripReview.Location = new System.Drawing.Point(96, 132);
            this.TripReview.Margin = new System.Windows.Forms.Padding(4);
            this.TripReview.Multiline = false;
            this.TripReview.Name = "TripReview";
            this.TripReview.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TripReview.PasswordChar = false;
            this.TripReview.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TripReview.PlaceholderText = "";
            this.TripReview.Size = new System.Drawing.Size(287, 31);
            this.TripReview.TabIndex = 18;
            this.TripReview.Texts = "";
            this.TripReview.UnderlinedStyle = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Daminga PERSONAL USE ONLY Mediu", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkOrange;
            this.label4.Location = new System.Drawing.Point(120, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 29);
            this.label4.TabIndex = 15;
            this.label4.Text = "BOOK THIS TRIP";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Unageo", 9.749998F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(18, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 18);
            this.label9.TabIndex = 19;
            this.label9.Text = "< back";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // BookTrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.translucentRoundedPanel1);
            this.Name = "BookTrip";
            this.Text = "BookTrip";
            this.translucentRoundedPanel1.ResumeLayout(false);
            this.translucentRoundedPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Components.TranslucentRoundedPanel translucentRoundedPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private Components.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private Components.TextBox TripReview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
    }
}