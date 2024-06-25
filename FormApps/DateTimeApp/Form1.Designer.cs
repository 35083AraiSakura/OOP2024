namespace DateTimeApp {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label1 = new Label();
            dtpBirthday = new DateTimePicker();
            bpDateCount = new Button();
            tbDisp = new TextBox();
            nudDay = new NumericUpDown();
            btDayBefore = new Button();
            btDayAfter = new Button();
            btOld = new Button();
            ((System.ComponentModel.ISupportInitialize)nudDay).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(91, 48);
            label1.Name = "label1";
            label1.Size = new Size(62, 32);
            label1.TabIndex = 0;
            label1.Text = "日付";
            // 
            // dtpBirthday
            // 
            dtpBirthday.CalendarFont = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpBirthday.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpBirthday.Location = new Point(191, 41);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(175, 39);
            dtpBirthday.TabIndex = 1;
            // 
            // bpDateCount
            // 
            bpDateCount.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            bpDateCount.Location = new Point(215, 96);
            bpDateCount.Name = "bpDateCount";
            bpDateCount.Size = new Size(135, 60);
            bpDateCount.TabIndex = 2;
            bpDateCount.Text = "今日までの日数";
            bpDateCount.UseVisualStyleBackColor = true;
            bpDateCount.Click += bpDateCount_Click;
            // 
            // tbDisp
            // 
            tbDisp.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbDisp.Location = new Point(69, 328);
            tbDisp.Name = "tbDisp";
            tbDisp.Size = new Size(297, 35);
            tbDisp.TabIndex = 3;
            // 
            // nudDay
            // 
            nudDay.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            nudDay.Location = new Point(69, 206);
            nudDay.Name = "nudDay";
            nudDay.Size = new Size(120, 35);
            nudDay.TabIndex = 4;
            // 
            // btDayBefore
            // 
            btDayBefore.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btDayBefore.Location = new Point(215, 174);
            btDayBefore.Name = "btDayBefore";
            btDayBefore.Size = new Size(95, 48);
            btDayBefore.TabIndex = 5;
            btDayBefore.Text = "日前";
            btDayBefore.UseVisualStyleBackColor = true;
            btDayBefore.Click += btDayBefore_Click;
            // 
            // btDayAfter
            // 
            btDayAfter.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btDayAfter.Location = new Point(215, 232);
            btDayAfter.Name = "btDayAfter";
            btDayAfter.Size = new Size(95, 48);
            btDayAfter.TabIndex = 5;
            btDayAfter.Text = "日後";
            btDayAfter.UseVisualStyleBackColor = true;
            btDayAfter.Click += btDayAfter_Click;
            // 
            // btOld
            // 
            btOld.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btOld.Location = new Point(348, 198);
            btOld.Name = "btOld";
            btOld.Size = new Size(91, 53);
            btOld.TabIndex = 6;
            btOld.Text = "年齢";
            btOld.UseVisualStyleBackColor = true;
            btOld.Click += btOld_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 414);
            Controls.Add(btOld);
            Controls.Add(btDayAfter);
            Controls.Add(btDayBefore);
            Controls.Add(nudDay);
            Controls.Add(tbDisp);
            Controls.Add(bpDateCount);
            Controls.Add(dtpBirthday);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nudDay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpBirthday;
        private Button bpDateCount;
        private TextBox tbDisp;
        private NumericUpDown nudDay;
        private Button btDayBefore;
        private Button btDayAfter;
        private Button btOld;
    }
}
