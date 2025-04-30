namespace dbproject
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.translucentRoundedPanel1 = new Components.TranslucentRoundedPanel();
<<<<<<< HEAD
            
=======
            this.Login = new RoundedButton();
>>>>>>> bcc68764717aaa19e4ae4b15574b2c1d66e1f3bf
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new Components.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new Components.TextBox();
            this.translucentRoundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // translucentRoundedPanel1
            // 
            this.translucentRoundedPanel1.BackColor = System.Drawing.Color.Transparent;
            this.translucentRoundedPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.translucentRoundedPanel1.BorderWidth = 1;
            this.translucentRoundedPanel1.Controls.Add(this.Login);
            this.translucentRoundedPanel1.Controls.Add(this.linkLabel1);
            this.translucentRoundedPanel1.Controls.Add(this.label4);
            this.translucentRoundedPanel1.Controls.Add(this.textBox2);
            this.translucentRoundedPanel1.Controls.Add(this.label2);
            this.translucentRoundedPanel1.Controls.Add(this.label3);
            this.translucentRoundedPanel1.Controls.Add(this.label1);
            this.translucentRoundedPanel1.Controls.Add(this.textBox1);
            this.translucentRoundedPanel1.CornerRadius = 10;
            this.translucentRoundedPanel1.Location = new System.Drawing.Point(216, 0);
            this.translucentRoundedPanel1.Name = "translucentRoundedPanel1";
            this.translucentRoundedPanel1.Size = new System.Drawing.Size(369, 453);
            this.translucentRoundedPanel1.TabIndex = 0;
            // 
            // Login
            // 
<<<<<<< HEAD
            this.Login.BackColor = System.Drawing.Color.IndianRed;
            this.Login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Login.Font = new System.Drawing.Font("Unageo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
=======
            this.Login.BackColor = System.Drawing.Color.DarkKhaki;
            this.Login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.ForeColor = System.Drawing.SystemColors.ControlLightLight;
>>>>>>> bcc68764717aaa19e4ae4b15574b2c1d66e1f3bf
            this.Login.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.Login.Location = new System.Drawing.Point(143, 317);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(102, 36);
            this.Login.TabIndex = 6;
            this.Login.Text = "LOGIN";
            this.Login.UseVisualStyleBackColor = false;
<<<<<<< HEAD
            this.Login.Click += new System.EventHandler(this.Login_Click_1);
=======
>>>>>>> bcc68764717aaa19e4ae4b15574b2c1d66e1f3bf
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.BurlyWood;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.SandyBrown;
            this.linkLabel1.Location = new System.Drawing.Point(230, 377);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(58, 15);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Sign Up";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(96, 377);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Don\'t have an account?";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.BorderColor = System.Drawing.Color.Transparent;
            this.textBox2.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textBox2.BorderRadius = 0;
            this.textBox2.BorderSize = 2;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox2.Location = new System.Drawing.Point(60, 261);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Multiline = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.textBox2.PasswordChar = false;
            this.textBox2.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBox2.PlaceholderText = "";
            this.textBox2.Size = new System.Drawing.Size(259, 31);
            this.textBox2.TabIndex = 5;
            this.textBox2.Texts = "";
            this.textBox2.UnderlinedStyle = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(56, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(56, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Creato Display Medium", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(112, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "LOGIN";
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
            this.textBox1.Location = new System.Drawing.Point(60, 180);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.textBox1.PasswordChar = false;
            this.textBox1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBox1.PlaceholderText = "";
            this.textBox1.Size = new System.Drawing.Size(259, 31);
            this.textBox1.TabIndex = 1;
            this.textBox1.Texts = "";
            this.textBox1.UnderlinedStyle = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.translucentRoundedPanel1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.translucentRoundedPanel1.ResumeLayout(false);
            this.translucentRoundedPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Components.TranslucentRoundedPanel translucentRoundedPanel1;
        private System.Windows.Forms.Label label1;
        private Components.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private Components.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private RoundedButton Login;
    }
}