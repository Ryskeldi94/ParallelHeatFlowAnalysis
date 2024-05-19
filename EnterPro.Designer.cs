namespace Version2
{
    partial class EnterPro
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
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
            this.panel1.Size = new System.Drawing.Size(868, 750);
            this.panel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 620);
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
            this.textBox3.Text = "Плотность г/см³\r\n\r\n";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(47, 402);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(619, 40);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "Коэффициент теплопроводности Вт/м·°C\r\n";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(47, 299);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(619, 40);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Удельная теплоемкость Дж/г·°C";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(664, 136);
            this.label2.TabIndex = 4;
            this.label2.Text = "Вводить своиство металла\r\n";
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
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.Location = new System.Drawing.Point(445, 479);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(206, 114);
            this.button2.TabIndex = 10;
            this.button2.Text = "Решение на двухмерным плоскости\r\n";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.Location = new System.Drawing.Point(142, 479);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(211, 114);
            this.button3.TabIndex = 9;
            this.button3.Text = "Решение на одномерным плоскости";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // EnterPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 750);
            this.Controls.Add(this.panel1);
            this.Name = "EnterPro";
            this.Text = "EnterPro";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ambientTemperature;
        private System.Windows.Forms.TextBox initialTemperature;
        private System.Windows.Forms.TextBox highTempLocation;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}