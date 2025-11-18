namespace MinuEpood
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            kogus_txt = new TextBox();
            toode_txt = new TextBox();
            hind_txt = new TextBox();
            lisa_kat_btn = new Button();
            kus_kat_btn = new Button();
            lisa_btn = new Button();
            uuenda_btn = new Button();
            kus_btn = new Button();
            puh_btn = new Button();
            button7 = new Button();
            otsifail_btn = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            toodePB = new PictureBox();
            textBox4 = new TextBox();
            kat_box = new ComboBox();
            dataGridView1 = new DataGridView();
            cartList = new ListBox();
            ((System.ComponentModel.ISupportInitialize)toodePB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            //
            //
            // Panels for admin and client

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.Location = new Point(26, 38);
            label1.Name = "label1";
            label1.Size = new Size(70, 25);
            label1.TabIndex = 0;
            label1.Text = "Toode: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(26, 82);
            label2.Name = "label2";
            label2.Size = new Size(71, 25);
            label2.TabIndex = 1;
            label2.Text = "Kogus: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F);
            label3.Location = new Point(26, 125);
            label3.Name = "label3";
            label3.Size = new Size(59, 25);
            label3.TabIndex = 2;
            label3.Text = "Hind: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F);
            label4.Location = new Point(26, 180);
            label4.Name = "label4";
            label4.Size = new Size(107, 25);
            label4.TabIndex = 3;
            label4.Text = "Kategooria: ";
            // 
            // kogus_txt
            // 
            kogus_txt.Location = new Point(134, 85);
            kogus_txt.Name = "kogus_txt";
            kogus_txt.Size = new Size(164, 23);
            kogus_txt.TabIndex = 4;
            // 
            // toode_txt
            // 
            toode_txt.Location = new Point(134, 41);
            toode_txt.Name = "toode_txt";
            toode_txt.Size = new Size(164, 23);
            toode_txt.TabIndex = 5;
            // 
            // hind_txt
            // 
            hind_txt.Location = new Point(134, 128);
            hind_txt.Name = "hind_txt";
            hind_txt.Size = new Size(164, 23);
            hind_txt.TabIndex = 6;
            // 
            // lisa_kat_btn
            // 
            lisa_kat_btn.Location = new Point(100, 230);
            lisa_kat_btn.Name = "lisa_kat_btn";
            lisa_kat_btn.Size = new Size(118, 23);
            lisa_kat_btn.TabIndex = 7;
            lisa_kat_btn.Text = "Lisa kategooria";
            lisa_kat_btn.UseVisualStyleBackColor = true;
            lisa_kat_btn.Click += lisa_kat_btn_Click;
            // 
            // kus_kat_btn
            // 
            kus_kat_btn.Location = new Point(220, 230);
            kus_kat_btn.Name = "kus_kat_btn";
            kus_kat_btn.Size = new Size(117, 23);
            kus_kat_btn.TabIndex = 8;
            kus_kat_btn.Text = "Kasuta kategooria";
            kus_kat_btn.UseVisualStyleBackColor = true;
            kus_kat_btn.Click += kus_kat_btn_Click;
            // 
            // lisa_btn
            // 
            lisa_btn.Location = new Point(70, 260);
            lisa_btn.Name = "lisa_btn";
            lisa_btn.Size = new Size(75, 23);
            lisa_btn.TabIndex = 9;
            lisa_btn.Text = "Lisa";
            lisa_btn.UseVisualStyleBackColor = true;
            lisa_btn.Click += lisa_btn_Click;
            // 
            // uuenda_btn
            // 
            uuenda_btn.Location = new Point(150, 260);
            uuenda_btn.Name = "uuenda_btn";
            uuenda_btn.Size = new Size(75, 23);
            uuenda_btn.TabIndex = 10;
            uuenda_btn.Text = "Uuenda";
            uuenda_btn.UseVisualStyleBackColor = true;
            uuenda_btn.Click += uuenda_btn_Click;
            // 
            // kus_btn
            // 
            kus_btn.Location = new Point(230, 260);
            kus_btn.Name = "kus_btn";   
            kus_btn.Size = new Size(75, 23);
            kus_btn.TabIndex = 11;
            kus_btn.Text = "Kastuta";
            kus_btn.UseVisualStyleBackColor = true;
            // 
            // puh_btn
            // 
            puh_btn.Location = new Point(310, 260);
            puh_btn.Name = "puh_btn";
            puh_btn.Size = new Size(75, 23);
            puh_btn.TabIndex = 12;
            puh_btn.Text = "Puhasta";
            puh_btn.UseVisualStyleBackColor = true;
            puh_btn.Click += puh_btn_Click;
            // 
            // maluta button
            // 
            button7.Location = new Point(463, 306);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 13;
            button7.Text = "Maluta";
            button7.UseVisualStyleBackColor = true;
            button7.Click += maluta_btn_Click;
            // 
            // otsifail_btn
            // 
            otsifail_btn.Location = new Point(463, 277);
            otsifail_btn.Name = "otsifail_btn";
            otsifail_btn.Size = new Size(75, 23);
            otsifail_btn.TabIndex = 14;
            otsifail_btn.Text = "Otsi fail";
            otsifail_btn.UseVisualStyleBackColor = true;
            otsifail_btn.Click += otsifail_btn_Click;
            // 
            // Pood
            // 
            button9.Location = new Point(589, 305);
            button9.Name = "button9";
            button9.Size = new Size(75, 23);
            button9.TabIndex = 15;
            button9.Text = "Pood";
            button9.UseVisualStyleBackColor = true;
            button9.Click += pood_btn_Click;
            // 
            // valin
            // 
            button10.Location = new Point(850, 565);
            button10.Name = "button10";
            button10.Size = new Size(75, 23);
            button10.TabIndex = 16;
            button10.Text = "Valin";
            button10.UseVisualStyleBackColor = true;
            button10.Click += valin_btn_Click;
            // 
            // ostan
            // 
            button11.Location = new Point(955, 565);
            button11.Name = "button11";
            button11.Size = new Size(75, 23);
            button11.TabIndex = 17;
            button11.Text = "Ostan";
            button11.UseVisualStyleBackColor = true;
            button11.Click += ostan_btn_Click;
            // 
            // saada arve
            // 
            button12.Location = new Point(751, 277);
            button12.Name = "button12";
            button12.Size = new Size(75, 23);
            button12.TabIndex = 18;
            button12.Text = "Saada arve";
            button12.UseVisualStyleBackColor = true;
            // 
            // toodePB
            // 
            toodePB.Location = new Point(463, 13);
            toodePB.Name = "toodePB";
            toodePB.Size = new Size(363, 246);
            toodePB.TabIndex = 19;
            toodePB.TabStop = false;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(670, 306);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(156, 23);
            textBox4.TabIndex = 20;
            
            // 
            // kat_box
            // 
            kat_box.FormattingEnabled = true;
            kat_box.Location = new Point(134, 183);
            kat_box.Name = "kat_box";
            kat_box.Size = new Size(164, 23);
            kat_box.TabIndex = 21;
            //
            // cartList
            //
            cartList = new ListBox();
            cartList.Location = new Point(850, 335);
            cartList.Size = new Size(280, 240);
            cartList.Name = "cartList";

            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(114, 335);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(712, 240);
            dataGridView1.TabIndex = 22;
            dataGridView1.CellMouseEnter += dataGridView1_CellMouseEnter1;
            dataGridView1.CellMouseLeave += dataGridView1_CellMouseLeave;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(1140, 610);

            Controls.Add(dataGridView1);
            Controls.Add(kat_box);
            Controls.Add(textBox4);
            Controls.Add(toodePB);
            Controls.Add(button12);
            Controls.Add(button10);
            Controls.Add(button11);
            Controls.Add(button9);
            Controls.Add(otsifail_btn);
            Controls.Add(button7);
            Controls.Add(puh_btn);
            Controls.Add(uuenda_btn);
            Controls.Add(kus_btn);
            Controls.Add(lisa_btn);
            Controls.Add(lisa_kat_btn);
            Controls.Add(kus_kat_btn);
            Controls.Add(hind_txt);
            Controls.Add(toode_txt);
            Controls.Add(kogus_txt);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(cartList);

            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)toodePB).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox kogus_txt;
        private TextBox toode_txt;
        private TextBox hind_txt;
        private Button lisa_kat_btn;
        private Button kus_kat_btn;
        private Button lisa_btn;
        private Button uuenda_btn;
        private Button kus_btn;
        private Button puh_btn;
        private Button button7;
        private Button otsifail_btn;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private PictureBox toodePB;
        private TextBox textBox4;
        private ComboBox kat_box;
        private ListBox cartList;
        private DataGridView dataGridView1;
    }
}