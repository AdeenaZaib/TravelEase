namespace dbproject
{
    partial class Destination
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
            this.panelGradientRounded1 = new Components.PanelGradientRounded();
            this.label1 = new System.Windows.Forms.Label();
            this.circularPictureBox1 = new Components.CircularPictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panelGradientRounded1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGradientRounded1
            // 
            this.panelGradientRounded1.BackColor = System.Drawing.Color.White;
            this.panelGradientRounded1.BorderRadius = 30;
            this.panelGradientRounded1.Controls.Add(this.button1);
            this.panelGradientRounded1.Controls.Add(this.circularPictureBox1);
            this.panelGradientRounded1.Controls.Add(this.label1);
            this.panelGradientRounded1.ForeColor = System.Drawing.Color.Black;
            this.panelGradientRounded1.GradientAngle = 90F;
            this.panelGradientRounded1.GradientBottomColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelGradientRounded1.GradientTopColor = System.Drawing.SystemColors.ButtonFace;
            this.panelGradientRounded1.Location = new System.Drawing.Point(-8, -6);
            this.panelGradientRounded1.Name = "panelGradientRounded1";
            this.panelGradientRounded1.Size = new System.Drawing.Size(823, 467);
            this.panelGradientRounded1.TabIndex = 0;
            this.panelGradientRounded1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGradientRounded1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Daminga PERSONAL USE ONLY Mediu", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "TravelEase";
            // 
            // circularPictureBox1
            // 
            this.circularPictureBox1.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.circularPictureBox1.BorderColor = System.Drawing.Color.SteelBlue;
            this.circularPictureBox1.BorderColor2 = System.Drawing.Color.LightSkyBlue;
            this.circularPictureBox1.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.circularPictureBox1.BorderSize = 2;
            this.circularPictureBox1.GradientAngle = 50F;
            this.circularPictureBox1.Location = new System.Drawing.Point(739, 6);
            this.circularPictureBox1.Name = "circularPictureBox1";
            this.circularPictureBox1.Size = new System.Drawing.Size(43, 43);
            this.circularPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.circularPictureBox1.TabIndex = 1;
            this.circularPictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(171, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Destination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelGradientRounded1);
            this.Name = "Destination";
            this.Text = "Destination";
            this.Load += new System.EventHandler(this.Destination_Load);
            this.panelGradientRounded1.ResumeLayout(false);
            this.panelGradientRounded1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Components.PanelGradientRounded panelGradientRounded1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private Components.CircularPictureBox circularPictureBox1;
    }
}