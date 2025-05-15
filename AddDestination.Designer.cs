namespace dbproject
{
    partial class AddDestination
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDestination));
            this.translucentRoundedPanel1 = new Components.TranslucentRoundedPanel();
            this.country = new System.Windows.Forms.RichTextBox();
            this.name = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.translucentRoundedPanel1.Controls.Add(this.country);
            this.translucentRoundedPanel1.Controls.Add(this.name);
            this.translucentRoundedPanel1.Controls.Add(this.button1);
            this.translucentRoundedPanel1.Controls.Add(this.label2);
            this.translucentRoundedPanel1.Controls.Add(this.label1);
            this.translucentRoundedPanel1.Controls.Add(this.label4);
            this.translucentRoundedPanel1.CornerRadius = 10;
            this.translucentRoundedPanel1.Location = new System.Drawing.Point(144, 61);
            this.translucentRoundedPanel1.Name = "translucentRoundedPanel1";
            this.translucentRoundedPanel1.Size = new System.Drawing.Size(505, 332);
            this.translucentRoundedPanel1.TabIndex = 19;
            // 
            // country
            // 
            this.country.Location = new System.Drawing.Point(107, 218);
            this.country.Name = "country";
            this.country.Size = new System.Drawing.Size(286, 33);
            this.country.TabIndex = 34;
            this.country.Text = "";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(107, 146);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(286, 33);
            this.name.TabIndex = 33;
            this.name.Text = "";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Chocolate;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(180, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 25);
            this.button1.TabIndex = 32;
            this.button1.Text = "ADD DESTINATION";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(102, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Country";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(103, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Daminga PERSONAL USE ONLY Mediu", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(119, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(274, 29);
            this.label4.TabIndex = 15;
            this.label4.Text = "ADD DESTINATION";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Unageo", 9.749998F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(12, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "< back";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // AddDestination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.translucentRoundedPanel1);
            this.Name = "AddDestination";
            this.Text = "AddDestination";
            this.translucentRoundedPanel1.ResumeLayout(false);
            this.translucentRoundedPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Components.TranslucentRoundedPanel translucentRoundedPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox country;
        private System.Windows.Forms.RichTextBox name;
        private System.Windows.Forms.Label label9;
    }
}