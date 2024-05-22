﻿namespace Version2
{
    partial class Singl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ambientTemperature = new System.Windows.Forms.TextBox();
            this.initialTemperature = new System.Windows.Forms.TextBox();
            this.highTempLocation = new System.Windows.Forms.TextBox();
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.dataGridViewResults);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ambientTemperature);
            this.panel1.Controls.Add(this.initialTemperature);
            this.panel1.Controls.Add(this.highTempLocation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 696);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(491, 540);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(307, 107);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(47, 193);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(619, 40);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "Введите местоположение с высокой температурой\r\n\r\n";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(47, 402);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(619, 40);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "Введите окружающую температуру\r\n";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(47, 299);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(619, 40);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Введите начальную температуру";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(664, 136);
            this.label2.TabIndex = 4;
            this.label2.Text = "Решение теплопроводност в одномерном плотности";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ambientTemperature
            // 
            this.ambientTemperature.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ambientTemperature.Location = new System.Drawing.Point(691, 402);
            this.ambientTemperature.Name = "ambientTemperature";
            this.ambientTemperature.Size = new System.Drawing.Size(79, 40);
            this.ambientTemperature.TabIndex = 2;
            // 
            // initialTemperature
            // 
            this.initialTemperature.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initialTemperature.Location = new System.Drawing.Point(691, 299);
            this.initialTemperature.Name = "initialTemperature";
            this.initialTemperature.Size = new System.Drawing.Size(79, 40);
            this.initialTemperature.TabIndex = 1;
            // 
            // highTempLocation
            // 
            this.highTempLocation.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highTempLocation.Location = new System.Drawing.Point(691, 193);
            this.highTempLocation.Name = "highTempLocation";
            this.highTempLocation.Size = new System.Drawing.Size(79, 40);
            this.highTempLocation.TabIndex = 0;
            this.highTempLocation.Text = "\r\n";
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResults.Location = new System.Drawing.Point(71, 497);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.RowHeadersWidth = 62;
            this.dataGridViewResults.RowTemplate.Height = 28;
            this.dataGridViewResults.Size = new System.Drawing.Size(339, 150);
            this.dataGridViewResults.TabIndex = 9;
            
            // 
            // Singl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 696);
            this.Controls.Add(this.panel1);
            this.Name = "Singl";
            this.Text = "Form3";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox highTempLocation;
        private System.Windows.Forms.TextBox initialTemperature;
        private System.Windows.Forms.TextBox ambientTemperature;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewResults;
    }
}