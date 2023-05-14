namespace Project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_nokta = new Button();
            btn_dikdortgen = new Button();
            panel1 = new Panel();
            btn_cember = new Button();
            btn_silindir = new Button();
            btn_kure = new Button();
            btn_yuzey = new Button();
            btn_prizma = new Button();
            btn_dortgen = new Button();
            button9 = new Button();
            btn_carpisma = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btn_nokta
            // 
            btn_nokta.Location = new Point(12, 12);
            btn_nokta.Name = "btn_nokta";
            btn_nokta.Size = new Size(137, 78);
            btn_nokta.TabIndex = 0;
            btn_nokta.Text = "Nokta için\r\nRastgele";
            btn_nokta.UseCompatibleTextRendering = true;
            btn_nokta.UseVisualStyleBackColor = true;
            btn_nokta.Click += btn_nokta_Click;
            // 
            // btn_dikdortgen
            // 
            btn_dikdortgen.Location = new Point(155, 12);
            btn_dikdortgen.Name = "btn_dikdortgen";
            btn_dikdortgen.Size = new Size(137, 78);
            btn_dikdortgen.TabIndex = 1;
            btn_dikdortgen.Text = "Dikdörtgen\r\niçin Rastgele";
            btn_dikdortgen.UseVisualStyleBackColor = true;
            btn_dikdortgen.Click += btn_dikdortgen_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(12, 96);
            panel1.Name = "panel1";
            panel1.Size = new Size(1061, 569);
            panel1.TabIndex = 2;
            panel1.MouseClick += panel1_MouseClick;
            // 
            // btn_cember
            // 
            btn_cember.Location = new Point(298, 12);
            btn_cember.Name = "btn_cember";
            btn_cember.Size = new Size(143, 78);
            btn_cember.TabIndex = 3;
            btn_cember.TabStop = false;
            btn_cember.Text = "Çember için\r\nRastgele\r\n";
            btn_cember.UseVisualStyleBackColor = true;
            btn_cember.Click += btn_cember_Click;
            // 
            // btn_silindir
            // 
            btn_silindir.Location = new Point(447, 12);
            btn_silindir.Name = "btn_silindir";
            btn_silindir.Size = new Size(145, 78);
            btn_silindir.TabIndex = 4;
            btn_silindir.Text = "Silindir için\r\nRastgele\r\n";
            btn_silindir.UseVisualStyleBackColor = true;
            btn_silindir.Click += btn_silindir_Click;
            // 
            // btn_kure
            // 
            btn_kure.Location = new Point(598, 12);
            btn_kure.Name = "btn_kure";
            btn_kure.Size = new Size(140, 78);
            btn_kure.TabIndex = 5;
            btn_kure.Text = "Küre için\r\nRastgele\r\n";
            btn_kure.UseVisualStyleBackColor = true;
            btn_kure.Click += btn_kure_Click;
            // 
            // btn_yuzey
            // 
            btn_yuzey.Location = new Point(741, 13);
            btn_yuzey.Name = "btn_yuzey";
            btn_yuzey.Size = new Size(146, 77);
            btn_yuzey.TabIndex = 6;
            btn_yuzey.Text = "Yüzey için\r\nRastgele\r\n";
            btn_yuzey.UseVisualStyleBackColor = true;
            btn_yuzey.Click += btn_yuzey_Click;
            // 
            // btn_prizma
            // 
            btn_prizma.Location = new Point(895, 12);
            btn_prizma.Name = "btn_prizma";
            btn_prizma.Size = new Size(168, 78);
            btn_prizma.TabIndex = 7;
            btn_prizma.Text = "Dikdörtgen Prizma\r\niçin Rastgele\r\n";
            btn_prizma.UseVisualStyleBackColor = true;
            btn_prizma.Click += btn_prizma_Click;
            // 
            // btn_dortgen
            // 
            btn_dortgen.Location = new Point(1070, 12);
            btn_dortgen.Name = "btn_dortgen";
            btn_dortgen.Size = new Size(139, 78);
            btn_dortgen.TabIndex = 8;
            btn_dortgen.Text = "Dörtgen için\r\nRastgele\r\n";
            btn_dortgen.UseVisualStyleBackColor = true;
            btn_dortgen.Click += btn_dortgen_Click;
            // 
            // button9
            // 
            button9.Location = new Point(1079, 105);
            button9.Name = "button9";
            button9.Size = new Size(130, 78);
            button9.TabIndex = 9;
            button9.Text = "Temizle";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // btn_carpisma
            // 
            btn_carpisma.Enabled = false;
            btn_carpisma.Location = new Point(1079, 200);
            btn_carpisma.Name = "btn_carpisma";
            btn_carpisma.Size = new Size(136, 100);
            btn_carpisma.TabIndex = 10;
            btn_carpisma.Text = "Çarpışma";
            btn_carpisma.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 7.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1079, 303);
            label1.Name = "label1";
            label1.Size = new Size(110, 36);
            label1.TabIndex = 11;
            label1.Text = "yeşil: çarpışma \r\ngerçekleşti";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1079, 479);
            label2.Name = "label2";
            label2.Size = new Size(162, 75);
            label2.TabIndex = 12;
            label2.Text = "başlangıç noktasını\r\nötemek için\r\npanele tıkla\r\n";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1230, 677);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_carpisma);
            Controls.Add(button9);
            Controls.Add(btn_dortgen);
            Controls.Add(btn_prizma);
            Controls.Add(btn_yuzey);
            Controls.Add(btn_kure);
            Controls.Add(btn_silindir);
            Controls.Add(btn_cember);
            Controls.Add(panel1);
            Controls.Add(btn_dikdortgen);
            Controls.Add(btn_nokta);
            Name = "Form1";
            Text = "Carpisma Denetimi";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_nokta;
        private Button btn_dikdortgen;
        private Panel panel1;
        private Button btn_cember;
        private Button btn_silindir;
        private Button btn_kure;
        private Button btn_yuzey;
        private Button btn_prizma;
        private Button btn_dortgen;
        private Button button9;
        private Button btn_carpisma;
        private Label label1;
        private Label label2;
    }
}