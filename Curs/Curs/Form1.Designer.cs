namespace Curs
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.NameService = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServiceType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StartType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.button_Type = new System.Windows.Forms.Button();
            this.button_Continue = new System.Windows.Forms.Button();
            this.button_Pause = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button_Start = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameService,
            this.DisplayName,
            this.ServiceType,
            this.StartType,
            this.Status});
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(544, 476);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // NameService
            // 
            this.NameService.Text = "NameService";
            this.NameService.Width = 92;
            // 
            // DisplayName
            // 
            this.DisplayName.Text = "DisplayName";
            this.DisplayName.Width = 115;
            // 
            // ServiceType
            // 
            this.ServiceType.Text = "ServiceType";
            this.ServiceType.Width = 108;
            // 
            // Status
            // 
            this.Status.DisplayIndex = 3;
            this.Status.Text = "Status";
            this.Status.Width = 102;
            // 
            // StartType
            // 
            this.StartType.Text = "StartType";
            this.StartType.Width = 429;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button_Exit);
            this.groupBox1.Controls.Add(this.button_Refresh);
            this.groupBox1.Controls.Add(this.button_Type);
            this.groupBox1.Controls.Add(this.button_Continue);
            this.groupBox1.Controls.Add(this.button_Pause);
            this.groupBox1.Controls.Add(this.button_Stop);
            this.groupBox1.Controls.Add(this.button_Start);
            this.groupBox1.Location = new System.Drawing.Point(576, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 476);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Действия";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Automatic",
            "Manual",
            "Disabled"});
            this.comboBox1.Location = new System.Drawing.Point(17, 229);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(89, 408);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(100, 37);
            this.button_Exit.TabIndex = 7;
            this.button_Exit.Text = "ВЫЙТИ";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button8_Click);
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(89, 318);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(100, 37);
            this.button_Refresh.TabIndex = 6;
            this.button_Refresh.Text = "ОБНОВИТЬ";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button7_Click);
            // 
            // button_Type
            // 
            this.button_Type.Location = new System.Drawing.Point(154, 220);
            this.button_Type.Name = "button_Type";
            this.button_Type.Size = new System.Drawing.Size(100, 37);
            this.button_Type.TabIndex = 4;
            this.button_Type.Text = "УСТОНОВИТЬ ТИП ЗАПУСКА";
            this.button_Type.UseVisualStyleBackColor = true;
            this.button_Type.Click += new System.EventHandler(this.button5_Click);
            // 
            // button_Continue
            // 
            this.button_Continue.Location = new System.Drawing.Point(154, 128);
            this.button_Continue.Name = "button_Continue";
            this.button_Continue.Size = new System.Drawing.Size(100, 37);
            this.button_Continue.TabIndex = 3;
            this.button_Continue.Text = "ПРОДОЛЖИТЬ";
            this.button_Continue.UseVisualStyleBackColor = true;
            this.button_Continue.Click += new System.EventHandler(this.button4_Click);
            // 
            // button_Pause
            // 
            this.button_Pause.Location = new System.Drawing.Point(17, 128);
            this.button_Pause.Name = "button_Pause";
            this.button_Pause.Size = new System.Drawing.Size(100, 37);
            this.button_Pause.TabIndex = 2;
            this.button_Pause.Text = "ПАУЗА";
            this.button_Pause.UseVisualStyleBackColor = true;
            this.button_Pause.Click += new System.EventHandler(this.button3_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(154, 44);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(100, 37);
            this.button_Stop.TabIndex = 1;
            this.button_Stop.Text = "СТОП";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(17, 44);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(100, 37);
            this.button_Start.TabIndex = 0;
            this.button_Start.Text = "СТАРТ";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 500);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader NameService;
        private System.Windows.Forms.ColumnHeader DisplayName;
        private System.Windows.Forms.ColumnHeader ServiceType;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader StartType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.Button button_Type;
        private System.Windows.Forms.Button button_Continue;
        private System.Windows.Forms.Button button_Pause;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Button button_Start;
        public System.Windows.Forms.ComboBox comboBox1;
    }
}

