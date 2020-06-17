namespace VK_Mailing_Tool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tokenBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.attachmentsBox = new System.Windows.Forms.RichTextBox();
            this.variblesSupportBox = new System.Windows.Forms.CheckBox();
            this.messagesCountBox = new System.Windows.Forms.DomainUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.startButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.stopButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tokenBox
            // 
            this.tokenBox.Location = new System.Drawing.Point(101, 12);
            this.tokenBox.Name = "tokenBox";
            this.tokenBox.Size = new System.Drawing.Size(428, 20);
            this.tokenBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Токен группы: ";
            // 
            // textBox
            // 
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox.Location = new System.Drawing.Point(6, 19);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(299, 238);
            this.textBox.TabIndex = 3;
            this.textBox.Text = "Test message";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.textBox);
            this.groupBox1.Location = new System.Drawing.Point(218, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 263);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Текст для рассылки";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.attachmentsBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 208);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Вложения";
            // 
            // attachmentsBox
            // 
            this.attachmentsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.attachmentsBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.attachmentsBox.Location = new System.Drawing.Point(6, 19);
            this.attachmentsBox.Name = "attachmentsBox";
            this.attachmentsBox.Size = new System.Drawing.Size(188, 183);
            this.attachmentsBox.TabIndex = 4;
            this.attachmentsBox.Text = "wall-194957860_212\nmarket-194957860_4745070";
            // 
            // variblesSupportBox
            // 
            this.variblesSupportBox.AutoSize = true;
            this.variblesSupportBox.Location = new System.Drawing.Point(12, 278);
            this.variblesSupportBox.Name = "variblesSupportBox";
            this.variblesSupportBox.Size = new System.Drawing.Size(150, 17);
            this.variblesSupportBox.TabIndex = 6;
            this.variblesSupportBox.Text = "Поддержка переменных";
            this.variblesSupportBox.UseVisualStyleBackColor = true;
            // 
            // messagesCountBox
            // 
            this.messagesCountBox.Items.Add("100");
            this.messagesCountBox.Items.Add("200");
            this.messagesCountBox.Items.Add("300");
            this.messagesCountBox.Items.Add("400");
            this.messagesCountBox.Items.Add("500");
            this.messagesCountBox.Items.Add("600");
            this.messagesCountBox.Items.Add("700");
            this.messagesCountBox.Items.Add("800");
            this.messagesCountBox.Items.Add("900");
            this.messagesCountBox.Items.Add("1000");
            this.messagesCountBox.Items.Add("1500");
            this.messagesCountBox.Items.Add("2000");
            this.messagesCountBox.Items.Add("2500");
            this.messagesCountBox.Items.Add("3000");
            this.messagesCountBox.Items.Add("4000");
            this.messagesCountBox.Items.Add("5000");
            this.messagesCountBox.Location = new System.Drawing.Point(103, 252);
            this.messagesCountBox.Name = "messagesCountBox";
            this.messagesCountBox.Size = new System.Drawing.Size(109, 20);
            this.messagesCountBox.TabIndex = 7;
            this.messagesCountBox.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Кол-во человек:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 307);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(404, 23);
            this.progressBar.TabIndex = 10;
            // 
            // startButton
            // 
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.startButton.Location = new System.Drawing.Point(422, 307);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(107, 23);
            this.startButton.TabIndex = 11;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 338);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(541, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // stopButton
            // 
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.stopButton.Location = new System.Drawing.Point(422, 307);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(107, 23);
            this.stopButton.TabIndex = 13;
            this.stopButton.Text = "Стоп";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Visible = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(541, 360);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.messagesCountBox);
            this.Controls.Add(this.variblesSupportBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tokenBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(557, 399);
            this.MinimumSize = new System.Drawing.Size(557, 399);
            this.Name = "Form1";
            this.Text = "VK Mailing Tool";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tokenBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox variblesSupportBox;
        private System.Windows.Forms.DomainUpDown messagesCountBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.RichTextBox attachmentsBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button stopButton;
    }
}

