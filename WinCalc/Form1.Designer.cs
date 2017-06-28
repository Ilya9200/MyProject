namespace WinCalc
{
    partial class frmMain
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
            this.res = new System.Windows.Forms.Label();
            this.lboperations = new System.Windows.Forms.ListBox();
            this.btn1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.discplabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lby = new System.Windows.Forms.Label();
            this.lbx = new System.Windows.Forms.Label();
            this.calc = new System.Windows.Forms.Button();
            this.tby = new System.Windows.Forms.TextBox();
            this.tbx = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // res
            // 
            this.res.AutoSize = true;
            this.res.Location = new System.Drawing.Point(6, 26);
            this.res.Name = "res";
            this.res.Size = new System.Drawing.Size(59, 13);
            this.res.TabIndex = 0;
            this.res.Text = "Результат";
            this.res.Click += new System.EventHandler(this.res_Click);
            // 
            // lboperations
            // 
            this.lboperations.Dock = System.Windows.Forms.DockStyle.Left;
            this.lboperations.FormattingEnabled = true;
            this.lboperations.Location = new System.Drawing.Point(3, 16);
            this.lboperations.MultiColumn = true;
            this.lboperations.Name = "lboperations";
            this.lboperations.Size = new System.Drawing.Size(212, 106);
            this.lboperations.TabIndex = 1;
            this.lboperations.SelectedIndexChanged += new System.EventHandler(this.lboperations_SelectedIndexChanged);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(188, 480);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(60, 21);
            this.btn1.TabIndex = 3;
            this.btn1.Text = "Выйти";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.discplabel);
            this.groupBox1.Controls.Add(this.lboperations);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 125);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Шаг 1 Выбор операции";
            // 
            // discplabel
            // 
            this.discplabel.AutoSize = true;
            this.discplabel.Location = new System.Drawing.Point(230, 16);
            this.discplabel.Name = "discplabel";
            this.discplabel.Size = new System.Drawing.Size(57, 13);
            this.discplabel.TabIndex = 1;
            this.discplabel.Text = "Описание";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lby);
            this.groupBox2.Controls.Add(this.lbx);
            this.groupBox2.Controls.Add(this.calc);
            this.groupBox2.Controls.Add(this.tby);
            this.groupBox2.Controls.Add(this.tbx);
            this.groupBox2.Location = new System.Drawing.Point(12, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 80);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Шаг 2 Ввод данных";
            // 
            // lby
            // 
            this.lby.AutoSize = true;
            this.lby.Location = new System.Drawing.Point(6, 53);
            this.lby.Name = "lby";
            this.lby.Size = new System.Drawing.Size(88, 13);
            this.lby.TabIndex = 4;
            this.lby.Text = "Второй операнд";
            // 
            // lbx
            // 
            this.lbx.AutoSize = true;
            this.lbx.Location = new System.Drawing.Point(6, 27);
            this.lbx.Name = "lbx";
            this.lbx.Size = new System.Drawing.Size(92, 13);
            this.lbx.TabIndex = 3;
            this.lbx.Text = "Первый операнд";
            // 
            // calc
            // 
            this.calc.Location = new System.Drawing.Point(233, 27);
            this.calc.Name = "calc";
            this.calc.Size = new System.Drawing.Size(120, 47);
            this.calc.TabIndex = 2;
            this.calc.Text = "Вычислить";
            this.calc.UseVisualStyleBackColor = true;
            this.calc.Click += new System.EventHandler(this.button1_Click);
            this.calc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.calc_KeyPress);
            // 
            // tby
            // 
            this.tby.Location = new System.Drawing.Point(104, 53);
            this.tby.Name = "tby";
            this.tby.Size = new System.Drawing.Size(100, 20);
            this.tby.TabIndex = 1;
            this.tby.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // tbx
            // 
            this.tbx.Location = new System.Drawing.Point(104, 27);
            this.tbx.Name = "tbx";
            this.tbx.Size = new System.Drawing.Size(100, 20);
            this.tbx.TabIndex = 0;
            this.tbx.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.res);
            this.groupBox4.Location = new System.Drawing.Point(12, 272);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(409, 90);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Шаг 4 Результат";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 512);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn1);
            this.MinimumSize = new System.Drawing.Size(515, 435);
            this.Name = "frmMain";
            this.Text = "Калькулятор";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label res;
        private System.Windows.Forms.ListBox lboperations;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label discplabel;
        private System.Windows.Forms.TextBox tby;
        private System.Windows.Forms.TextBox tbx;
        private System.Windows.Forms.Label lby;
        private System.Windows.Forms.Label lbx;
        private System.Windows.Forms.Button calc;
    }
}

