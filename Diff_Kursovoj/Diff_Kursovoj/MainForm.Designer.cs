namespace Diff_Kursovoj
{
    partial class MainForm
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
            this.input = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.go = new MaterialSkin.Controls.MaterialRaisedButton();
            this.OTVET = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // input
            // 
            this.input.Depth = 0;
            this.input.Hint = "";
            this.input.Location = new System.Drawing.Point(107, 78);
            this.input.MouseState = MaterialSkin.MouseState.HOVER;
            this.input.Name = "input";
            this.input.PasswordChar = '\0';
            this.input.SelectedText = "";
            this.input.SelectionLength = 0;
            this.input.SelectionStart = 0;
            this.input.Size = new System.Drawing.Size(242, 23);
            this.input.TabIndex = 0;
            this.input.UseSystemPasswordChar = false;
            // 
            // go
            // 
            this.go.Depth = 0;
            this.go.Location = new System.Drawing.Point(15, 113);
            this.go.MouseState = MaterialSkin.MouseState.HOVER;
            this.go.Name = "go";
            this.go.Primary = true;
            this.go.Size = new System.Drawing.Size(334, 41);
            this.go.TabIndex = 2;
            this.go.Text = "Вычислить";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // OTVET
            // 
            this.OTVET.Depth = 0;
            this.OTVET.Hint = "";
            this.OTVET.Location = new System.Drawing.Point(107, 107);
            this.OTVET.MouseState = MaterialSkin.MouseState.HOVER;
            this.OTVET.Name = "OTVET";
            this.OTVET.PasswordChar = '\0';
            this.OTVET.SelectedText = "";
            this.OTVET.SelectionLength = 0;
            this.OTVET.SelectionStart = 0;
            this.OTVET.Size = new System.Drawing.Size(242, 23);
            this.OTVET.TabIndex = 5;
            this.OTVET.UseSystemPasswordChar = false;
            this.OTVET.Visible = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 113);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(76, 17);
            this.materialLabel1.TabIndex = 6;
            this.materialLabel1.Text = "Результат";
            this.materialLabel1.Visible = false;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(12, 84);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(66, 17);
            this.materialLabel3.TabIndex = 8;
            this.materialLabel3.Text = "Функция";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 168);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.OTVET);
            this.Controls.Add(this.go);
            this.Controls.Add(this.input);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Аналитическое дифференцирование";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField input;
        private MaterialSkin.Controls.MaterialRaisedButton go;
        private MaterialSkin.Controls.MaterialSingleLineTextField OTVET;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
    }
}

