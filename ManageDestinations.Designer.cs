namespace dbproject
{
    partial class ManageDestinations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageDestinations));
            this.add = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.destinationView = new System.Windows.Forms.ListView();
            this.labelButton2 = new LabelButton();
            this.label3 = new System.Windows.Forms.Label();
            this.labelButton5 = new LabelButton();
            this.labelButton1 = new LabelButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelButton3 = new LabelButton();
            this.SuspendLayout();
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.Chocolate;
            this.add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.add.Location = new System.Drawing.Point(644, 302);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(95, 44);
            this.add.TabIndex = 63;
            this.add.Text = "ADD DESTINATION";
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.Chocolate;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.delete.Location = new System.Drawing.Point(644, 235);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(95, 40);
            this.delete.TabIndex = 62;
            this.delete.Text = "DELETE DESTINATION";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // destinationView
            // 
            this.destinationView.HideSelection = false;
            this.destinationView.Location = new System.Drawing.Point(29, 155);
            this.destinationView.Name = "destinationView";
            this.destinationView.Size = new System.Drawing.Size(565, 272);
            this.destinationView.TabIndex = 61;
            this.destinationView.UseCompatibleStateImageBehavior = false;
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
            this.labelButton2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelButton2.Location = new System.Drawing.Point(141, 65);
            this.labelButton2.Name = "labelButton2";
            this.labelButton2.Size = new System.Drawing.Size(120, 23);
            this.labelButton2.TabIndex = 60;
            this.labelButton2.Text = "MANAGE USERS";
            this.labelButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelButton2.UseVisualStyleBackColor = false;
            this.labelButton2.Click += new System.EventHandler(this.labelButton2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Daminga PERSONAL USE ONLY Mediu", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 24);
            this.label3.TabIndex = 59;
            this.label3.Text = "TRAVELEASE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            this.labelButton5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelButton5.Location = new System.Drawing.Point(298, 65);
            this.labelButton5.Name = "labelButton5";
            this.labelButton5.Size = new System.Drawing.Size(188, 23);
            this.labelButton5.TabIndex = 58;
            this.labelButton5.Text = "MANAGE DESTINATIONS";
            this.labelButton5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelButton5.UseVisualStyleBackColor = false;
            this.labelButton5.Click += new System.EventHandler(this.labelButton5_Click);
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
            this.labelButton1.Location = new System.Drawing.Point(44, 65);
            this.labelButton1.Name = "labelButton1";
            this.labelButton1.Size = new System.Drawing.Size(60, 23);
            this.labelButton1.TabIndex = 57;
            this.labelButton1.Text = "HOME";
            this.labelButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelButton1.UseVisualStyleBackColor = false;
            this.labelButton1.Click += new System.EventHandler(this.labelButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(-3, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(811, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "_________________________________________________________________________________" +
    "_____________________________________________________";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Daminga PERSONAL USE ONLY Mediu", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Chocolate;
            this.label2.Location = new System.Drawing.Point(237, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(357, 29);
            this.label2.TabIndex = 55;
            this.label2.Text = "MANAGE DESTINATIONS";
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
            this.labelButton3.Location = new System.Drawing.Point(492, 65);
            this.labelButton3.Name = "labelButton3";
            this.labelButton3.Size = new System.Drawing.Size(199, 23);
            this.labelButton3.TabIndex = 64;
            this.labelButton3.Text = "MANAGE REVIEWS";
            this.labelButton3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelButton3.UseVisualStyleBackColor = false;
            this.labelButton3.Click += new System.EventHandler(this.labelButton3_Click);
            // 
            // ManageDestinations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelButton3);
            this.Controls.Add(this.add);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.destinationView);
            this.Controls.Add(this.labelButton2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelButton5);
            this.Controls.Add(this.labelButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "ManageDestinations";
            this.Text = "ManageDestinations";
            this.Load += new System.EventHandler(this.ManageDestinations_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.ListView destinationView;
        private LabelButton labelButton2;
        private System.Windows.Forms.Label label3;
        private LabelButton labelButton5;
        private LabelButton labelButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private LabelButton labelButton3;
    }
}