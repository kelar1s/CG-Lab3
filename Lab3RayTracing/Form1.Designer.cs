namespace Lab3RayTracing
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.glControl1 = new OpenTK.GLControl();
            this.label1 = new System.Windows.Forms.Label();
            this.trackbarR = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.trackbarG = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackbarB = new System.Windows.Forms.TrackBar();
            this.cbMirror = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.trackbarDepth = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.trackbarX = new System.Windows.Forms.TrackBar();
            this.trackbarY = new System.Windows.Forms.TrackBar();
            this.trackbarZ = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarZ)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl1.Location = new System.Drawing.Point(0, 0);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(1305, 780);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(49, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Изменение цвета";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // trackbarR
            // 
            this.trackbarR.Location = new System.Drawing.Point(76, 42);
            this.trackbarR.Margin = new System.Windows.Forms.Padding(2);
            this.trackbarR.Maximum = 255;
            this.trackbarR.Name = "trackbarR";
            this.trackbarR.Size = new System.Drawing.Size(122, 45);
            this.trackbarR.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(49, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "R";
            // 
            // trackbarG
            // 
            this.trackbarG.Location = new System.Drawing.Point(76, 91);
            this.trackbarG.Margin = new System.Windows.Forms.Padding(2);
            this.trackbarG.Maximum = 255;
            this.trackbarG.Name = "trackbarG";
            this.trackbarG.Size = new System.Drawing.Size(122, 45);
            this.trackbarG.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(48, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "G";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(48, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "B";
            // 
            // trackbarB
            // 
            this.trackbarB.Location = new System.Drawing.Point(76, 140);
            this.trackbarB.Margin = new System.Windows.Forms.Padding(2);
            this.trackbarB.Maximum = 255;
            this.trackbarB.Name = "trackbarB";
            this.trackbarB.Size = new System.Drawing.Size(122, 45);
            this.trackbarB.TabIndex = 11;
            // 
            // cbMirror
            // 
            this.cbMirror.AutoSize = true;
            this.cbMirror.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbMirror.Location = new System.Drawing.Point(62, 189);
            this.cbMirror.Margin = new System.Windows.Forms.Padding(2);
            this.cbMirror.Name = "cbMirror";
            this.cbMirror.Size = new System.Drawing.Size(155, 24);
            this.cbMirror.TabIndex = 12;
            this.cbMirror.Text = "Зеркальный вид";
            this.cbMirror.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(48, 232);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Глубина ретрейссинга";
            // 
            // trackbarDepth
            // 
            this.trackbarDepth.Location = new System.Drawing.Point(76, 276);
            this.trackbarDepth.Margin = new System.Windows.Forms.Padding(2);
            this.trackbarDepth.Maximum = 100;
            this.trackbarDepth.Minimum = 1;
            this.trackbarDepth.Name = "trackbarDepth";
            this.trackbarDepth.Size = new System.Drawing.Size(122, 45);
            this.trackbarDepth.TabIndex = 14;
            this.trackbarDepth.Value = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(58, 353);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Движение камеры";
            // 
            // trackbarX
            // 
            this.trackbarX.Location = new System.Drawing.Point(82, 403);
            this.trackbarX.Margin = new System.Windows.Forms.Padding(2);
            this.trackbarX.Maximum = 100;
            this.trackbarX.Name = "trackbarX";
            this.trackbarX.Size = new System.Drawing.Size(116, 45);
            this.trackbarX.TabIndex = 19;
            // 
            // trackbarY
            // 
            this.trackbarY.Location = new System.Drawing.Point(82, 452);
            this.trackbarY.Margin = new System.Windows.Forms.Padding(2);
            this.trackbarY.Maximum = 100;
            this.trackbarY.Name = "trackbarY";
            this.trackbarY.Size = new System.Drawing.Size(116, 45);
            this.trackbarY.TabIndex = 20;
            // 
            // trackbarZ
            // 
            this.trackbarZ.Location = new System.Drawing.Point(82, 501);
            this.trackbarZ.Margin = new System.Windows.Forms.Padding(2);
            this.trackbarZ.Maximum = 100;
            this.trackbarZ.Name = "trackbarZ";
            this.trackbarZ.Size = new System.Drawing.Size(116, 45);
            this.trackbarZ.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(48, 403);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "X";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(49, 452);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(49, 501);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "Z";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.trackbarR);
            this.panel1.Controls.Add(this.trackbarZ);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.trackbarY);
            this.panel1.Controls.Add(this.trackbarG);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.trackbarB);
            this.panel1.Controls.Add(this.trackbarX);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cbMirror);
            this.panel1.Controls.Add(this.trackbarDepth);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1032, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 780);
            this.panel1.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 780);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.glControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackbarR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarZ)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackbarR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackbarG;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackbarB;
        private System.Windows.Forms.CheckBox cbMirror;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackbarDepth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar trackbarX;
        private System.Windows.Forms.TrackBar trackbarY;
        private System.Windows.Forms.TrackBar trackbarZ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
    }
}

