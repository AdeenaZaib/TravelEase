namespace dbproject
{
    partial class payments
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
            this.translucentRoundedPanel1 = new Components.TranslucentRoundedPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.amount = new System.Windows.Forms.RichTextBox();
            this.method = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cvv = new System.Windows.Forms.RichTextBox();
            this.exp = new System.Windows.Forms.RichTextBox();
            this.num = new System.Windows.Forms.RichTextBox();
            this.pay = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.translucentRoundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // translucentRoundedPanel1
            // 
            this.translucentRoundedPanel1.BackColor = System.Drawing.Color.Transparent;
            this.translucentRoundedPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.translucentRoundedPanel1.BorderWidth = 1;
            this.translucentRoundedPanel1.Controls.Add(this.label2);
            this.translucentRoundedPanel1.Controls.Add(this.amount);
            this.translucentRoundedPanel1.Controls.Add(this.method);
            this.translucentRoundedPanel1.Controls.Add(this.label1);
            this.translucentRoundedPanel1.Controls.Add(this.cvv);
            this.translucentRoundedPanel1.Controls.Add(this.exp);
            this.translucentRoundedPanel1.Controls.Add(this.num);
            this.translucentRoundedPanel1.Controls.Add(this.pay);
            this.translucentRoundedPanel1.Controls.Add(this.label9);
            this.translucentRoundedPanel1.Controls.Add(this.label5);
            this.translucentRoundedPanel1.Controls.Add(this.label3);
            this.translucentRoundedPanel1.Controls.Add(this.label4);
            this.translucentRoundedPanel1.CornerRadius = 10;
            this.translucentRoundedPanel1.Location = new System.Drawing.Point(148, 32);
            this.translucentRoundedPanel1.Name = "translucentRoundedPanel1";
            this.translucentRoundedPanel1.Size = new System.Drawing.Size(505, 386);
            this.translucentRoundedPanel1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(144, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 40);
            this.label2.TabIndex = 39;
            this.label2.Text = "Enter\r\nAmount";
            // 
            // amount
            // 
            this.amount.Location = new System.Drawing.Point(215, 252);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(162, 42);
            this.amount.TabIndex = 38;
            this.amount.Text = "";
            // 
            // method
            // 
            this.method.FormattingEnabled = true;
            this.method.Location = new System.Drawing.Point(178, 77);
            this.method.Name = "method";
            this.method.Size = new System.Drawing.Size(243, 21);
            this.method.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(96, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Method";
            // 
            // cvv
            // 
            this.cvv.Location = new System.Drawing.Point(339, 205);
            this.cvv.Name = "cvv";
            this.cvv.Size = new System.Drawing.Size(121, 25);
            this.cvv.TabIndex = 35;
            this.cvv.Text = "";
            // 
            // exp
            // 
            this.exp.Location = new System.Drawing.Point(47, 205);
            this.exp.Name = "exp";
            this.exp.Size = new System.Drawing.Size(162, 25);
            this.exp.TabIndex = 34;
            this.exp.Text = "";
            // 
            // num
            // 
            this.num.Location = new System.Drawing.Point(47, 143);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(416, 36);
            this.num.TabIndex = 19;
            this.num.Text = "";
            // 
            // pay
            // 
            this.pay.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pay.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pay.Location = new System.Drawing.Point(215, 319);
            this.pay.Name = "pay";
            this.pay.Size = new System.Drawing.Size(111, 40);
            this.pay.TabIndex = 32;
            this.pay.Text = "CONFIRM";
            this.pay.UseVisualStyleBackColor = false;
            this.pay.Click += new System.EventHandler(this.pay_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(336, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 18);
            this.label9.TabIndex = 29;
            this.label9.Text = "CVV";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(44, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 18);
            this.label5.TabIndex = 21;
            this.label5.Text = "Expiry Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(43, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Card Number/Account Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Daminga PERSONAL USE ONLY Mediu", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(188, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 29);
            this.label4.TabIndex = 15;
            this.label4.Text = "PAYMENT";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // payments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.translucentRoundedPanel1);
            this.Name = "payments";
            this.Text = "payments";
            this.Load += new System.EventHandler(this.payments_Load);
            this.translucentRoundedPanel1.ResumeLayout(false);
            this.translucentRoundedPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Components.TranslucentRoundedPanel translucentRoundedPanel1;
        private System.Windows.Forms.Button pay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox cvv;
        private System.Windows.Forms.RichTextBox exp;
        private System.Windows.Forms.RichTextBox num;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox amount;
        private System.Windows.Forms.ComboBox method;
        private System.Windows.Forms.Label label1;
    }
}