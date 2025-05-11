namespace dbproject
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.translucentRoundedPanel1 = new Components.TranslucentRoundedPanel();
            this.Loginn = new RoundedButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.emailtxt = new System.Windows.Forms.RichTextBox();
            this.pwd = new System.Windows.Forms.RichTextBox();
            this.translucentRoundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // translucentRoundedPanel1
            // 
            this.translucentRoundedPanel1.BackColor = System.Drawing.Color.Transparent;
            this.translucentRoundedPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.translucentRoundedPanel1.BorderWidth = 1;
            this.translucentRoundedPanel1.Controls.Add(this.pwd);
            this.translucentRoundedPanel1.Controls.Add(this.Loginn);
            this.translucentRoundedPanel1.Controls.Add(this.emailtxt);
            this.translucentRoundedPanel1.Controls.Add(this.linkLabel1);
            this.translucentRoundedPanel1.Controls.Add(this.label4);
            this.translucentRoundedPanel1.Controls.Add(this.label2);
            this.translucentRoundedPanel1.Controls.Add(this.label3);
            this.translucentRoundedPanel1.Controls.Add(this.label1);
            this.translucentRoundedPanel1.CornerRadius = 10;
            this.translucentRoundedPanel1.Location = new System.Drawing.Point(216, 12);
            this.translucentRoundedPanel1.Name = "translucentRoundedPanel1";
            this.translucentRoundedPanel1.Size = new System.Drawing.Size(369, 415);
            this.translucentRoundedPanel1.TabIndex = 0;
            // 
            // Loginn
            // 
            this.Loginn.BackColor = System.Drawing.Color.DarkKhaki;
            this.Loginn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Loginn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loginn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Loginn.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.Loginn.Location = new System.Drawing.Point(143, 317);
            this.Loginn.Name = "Loginn";
            this.Loginn.Size = new System.Drawing.Size(102, 36);
            this.Loginn.TabIndex = 6;
            this.Loginn.Text = "LOGIN";
            this.Loginn.UseVisualStyleBackColor = false;
            this.Loginn.Click += new System.EventHandler(this.Loginn_Click);
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
            this.label3.Location = new System.Drawing.Point(56, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Email";
            this.label3.Click += new System.EventHandler(this.label3_Click);
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
            // emailtxt
            // 
            this.emailtxt.Location = new System.Drawing.Point(60, 188);
            this.emailtxt.Name = "emailtxt";
            this.emailtxt.Size = new System.Drawing.Size(259, 31);
            this.emailtxt.TabIndex = 1;
            this.emailtxt.Text = "";
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(60, 258);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(259, 31);
            this.pwd.TabIndex = 7;
            this.pwd.Text = "";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.translucentRoundedPanel1);
            this.Name = "Login";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.translucentRoundedPanel1.ResumeLayout(false);
            this.translucentRoundedPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Components.TranslucentRoundedPanel translucentRoundedPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private RoundedButton Loginn;
        private System.Windows.Forms.RichTextBox emailtxt;
        private System.Windows.Forms.RichTextBox pwd;
    }
}