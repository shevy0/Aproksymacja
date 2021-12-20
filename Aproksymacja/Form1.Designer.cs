namespace Aproksymacja
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_addpoint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numeric_lp = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_X = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Y = new System.Windows.Forms.TextBox();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.button_lp_accept = new System.Windows.Forms.Button();
            this.button_lp_reset = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.numeric_sw = new System.Windows.Forms.NumericUpDown();
            this.button_oblicz = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_lp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_sw)).BeginInit();
            this.SuspendLayout();
            // 
            // button_addpoint
            // 
            this.button_addpoint.Location = new System.Drawing.Point(451, 72);
            this.button_addpoint.Margin = new System.Windows.Forms.Padding(4);
            this.button_addpoint.Name = "button_addpoint";
            this.button_addpoint.Size = new System.Drawing.Size(95, 26);
            this.button_addpoint.TabIndex = 0;
            this.button_addpoint.Text = "Dodaj punkt";
            this.button_addpoint.UseVisualStyleBackColor = true;
            this.button_addpoint.Click += new System.EventHandler(this.button_addpoint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Liczba punktów:";
            // 
            // numeric_lp
            // 
            this.numeric_lp.Location = new System.Drawing.Point(161, 25);
            this.numeric_lp.Margin = new System.Windows.Forms.Padding(4);
            this.numeric_lp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_lp.Name = "numeric_lp";
            this.numeric_lp.Size = new System.Drawing.Size(62, 26);
            this.numeric_lp.TabIndex = 2;
            this.numeric_lp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wprowadź X:";
            // 
            // textBox_X
            // 
            this.textBox_X.Location = new System.Drawing.Point(123, 72);
            this.textBox_X.Name = "textBox_X";
            this.textBox_X.Size = new System.Drawing.Size(100, 26);
            this.textBox_X.TabIndex = 4;
            this.textBox_X.Leave += new System.EventHandler(this.textBox_X_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Wprowadź Y:";
            // 
            // textBox_Y
            // 
            this.textBox_Y.Location = new System.Drawing.Point(335, 72);
            this.textBox_Y.Name = "textBox_Y";
            this.textBox_Y.Size = new System.Drawing.Size(100, 26);
            this.textBox_Y.TabIndex = 6;
            this.textBox_Y.Leave += new System.EventHandler(this.textBox_Y_Leave);
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(28, 113);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(182, 128);
            this.richTextBox.TabIndex = 7;
            this.richTextBox.Text = "";
            // 
            // button_lp_accept
            // 
            this.button_lp_accept.Location = new System.Drawing.Point(241, 25);
            this.button_lp_accept.Name = "button_lp_accept";
            this.button_lp_accept.Size = new System.Drawing.Size(87, 24);
            this.button_lp_accept.TabIndex = 8;
            this.button_lp_accept.Text = "Zatwierdź";
            this.button_lp_accept.UseVisualStyleBackColor = true;
            this.button_lp_accept.Click += new System.EventHandler(this.button_lp_accept_Click);
            // 
            // button_lp_reset
            // 
            this.button_lp_reset.Location = new System.Drawing.Point(335, 25);
            this.button_lp_reset.Name = "button_lp_reset";
            this.button_lp_reset.Size = new System.Drawing.Size(100, 26);
            this.button_lp_reset.TabIndex = 9;
            this.button_lp_reset.Text = "Resetuj";
            this.button_lp_reset.UseVisualStyleBackColor = true;
            this.button_lp_reset.Click += new System.EventHandler(this.button_lp_reset_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Stopień wielomianu:";
            // 
            // numeric_sw
            // 
            this.numeric_sw.BackColor = System.Drawing.Color.Fuchsia;
            this.numeric_sw.Location = new System.Drawing.Point(163, 257);
            this.numeric_sw.Name = "numeric_sw";
            this.numeric_sw.Size = new System.Drawing.Size(60, 26);
            this.numeric_sw.TabIndex = 11;
            // 
            // button_oblicz
            // 
            this.button_oblicz.Location = new System.Drawing.Point(28, 304);
            this.button_oblicz.Name = "button_oblicz";
            this.button_oblicz.Size = new System.Drawing.Size(251, 38);
            this.button_oblicz.TabIndex = 12;
            this.button_oblicz.Text = "Oblicz";
            this.button_oblicz.UseVisualStyleBackColor = true;
            this.button_oblicz.Click += new System.EventHandler(this.button_oblicz_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(297, 113);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(220, 229);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 468);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button_oblicz);
            this.Controls.Add(this.numeric_sw);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_lp_reset);
            this.Controls.Add(this.button_lp_accept);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.textBox_Y);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_X);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numeric_lp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_addpoint);
            this.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Aproksymacja zbioru punktów wielomianem";
            ((System.ComponentModel.ISupportInitialize)(this.numeric_lp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_sw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_addpoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numeric_lp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_X;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Y;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button button_lp_accept;
        private System.Windows.Forms.Button button_lp_reset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numeric_sw;
        private System.Windows.Forms.Button button_oblicz;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

