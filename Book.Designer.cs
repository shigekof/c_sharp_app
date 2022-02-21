
namespace Assignment3Task2
{
    partial class Book
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BookCancelButton = new System.Windows.Forms.Button();
            this.BookSubmitButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.BookExitButton = new System.Windows.Forms.Button();
            this.BookHelpButton = new System.Windows.Forms.Button();
            this.BookMainMenuButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Class and Slot";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Spin Wednesday 7am",
            "Spin Friday 6pm",
            "Cardio Thursday 6pm",
            "Cardio Friday 7am",
            "Pilates Wednesday 6pm"});
            this.comboBox2.Location = new System.Drawing.Point(359, 221);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(200, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Member ID";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(359, 184);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 7;
            // 
            // BookCancelButton
            // 
            this.BookCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BookCancelButton.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BookCancelButton.Location = new System.Drawing.Point(273, 324);
            this.BookCancelButton.Name = "BookCancelButton";
            this.BookCancelButton.Size = new System.Drawing.Size(92, 42);
            this.BookCancelButton.TabIndex = 9;
            this.BookCancelButton.Text = "Cancel";
            this.BookCancelButton.UseVisualStyleBackColor = true;
            // 
            // BookSubmitButton
            // 
            this.BookSubmitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(110)))), ((int)(((byte)(233)))));
            this.BookSubmitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BookSubmitButton.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BookSubmitButton.ForeColor = System.Drawing.Color.White;
            this.BookSubmitButton.Location = new System.Drawing.Point(395, 324);
            this.BookSubmitButton.Name = "BookSubmitButton";
            this.BookSubmitButton.Size = new System.Drawing.Size(152, 42);
            this.BookSubmitButton.TabIndex = 10;
            this.BookSubmitButton.Text = "Submit";
            this.BookSubmitButton.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(110)))), ((int)(((byte)(233)))));
            this.label5.Location = new System.Drawing.Point(297, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(223, 45);
            this.label5.TabIndex = 22;
            this.label5.Text = "Book Classes";
            // 
            // BookExitButton
            // 
            this.BookExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(110)))), ((int)(((byte)(233)))));
            this.BookExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BookExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BookExitButton.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BookExitButton.ForeColor = System.Drawing.Color.White;
            this.BookExitButton.Location = new System.Drawing.Point(536, 23);
            this.BookExitButton.Name = "BookExitButton";
            this.BookExitButton.Size = new System.Drawing.Size(149, 31);
            this.BookExitButton.TabIndex = 21;
            this.BookExitButton.Text = "Exit";
            this.BookExitButton.UseVisualStyleBackColor = false;
            this.BookExitButton.Click += new System.EventHandler(this.BookExitButton_Click_1);
            // 
            // BookHelpButton
            // 
            this.BookHelpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(110)))), ((int)(((byte)(233)))));
            this.BookHelpButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BookHelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BookHelpButton.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BookHelpButton.ForeColor = System.Drawing.Color.White;
            this.BookHelpButton.Location = new System.Drawing.Point(344, 24);
            this.BookHelpButton.Name = "BookHelpButton";
            this.BookHelpButton.Size = new System.Drawing.Size(147, 29);
            this.BookHelpButton.TabIndex = 20;
            this.BookHelpButton.Text = "Help";
            this.BookHelpButton.UseVisualStyleBackColor = false;
            this.BookHelpButton.Click += new System.EventHandler(this.BookHelpButton_Click_1);
            // 
            // BookMainMenuButton
            // 
            this.BookMainMenuButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(110)))), ((int)(((byte)(233)))));
            this.BookMainMenuButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BookMainMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BookMainMenuButton.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BookMainMenuButton.ForeColor = System.Drawing.Color.White;
            this.BookMainMenuButton.Location = new System.Drawing.Point(148, 24);
            this.BookMainMenuButton.Name = "BookMainMenuButton";
            this.BookMainMenuButton.Size = new System.Drawing.Size(149, 29);
            this.BookMainMenuButton.TabIndex = 18;
            this.BookMainMenuButton.Text = "Main Menu";
            this.BookMainMenuButton.UseVisualStyleBackColor = false;
            this.BookMainMenuButton.Click += new System.EventHandler(this.BookMainMenuButton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(359, 259);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 23;
            // 
            // Book
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BookExitButton);
            this.Controls.Add(this.BookHelpButton);
            this.Controls.Add(this.BookMainMenuButton);
            this.Controls.Add(this.BookSubmitButton);
            this.Controls.Add(this.BookCancelButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Book";
            this.Text = "Book";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BookCancelButton;
        private System.Windows.Forms.Button BookSubmitButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BookExitButton;
        private System.Windows.Forms.Button BookHelpButton;
        private System.Windows.Forms.Button BookMainMenuButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}