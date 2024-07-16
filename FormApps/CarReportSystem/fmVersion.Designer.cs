namespace CarReportSystem {
    partial class fmVersion {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btVersionOK = new Button();
            label1 = new Label();
            lbVersion = new Label();
            SuspendLayout();
            // 
            // btVersionOK
            // 
            btVersionOK.Location = new Point(396, 278);
            btVersionOK.Name = "btVersionOK";
            btVersionOK.Size = new Size(75, 23);
            btVersionOK.TabIndex = 0;
            btVersionOK.Text = "OK";
            btVersionOK.UseVisualStyleBackColor = true;
            btVersionOK.Click += btVersionOK_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("游ゴシック", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 128);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(247, 35);
            label1.TabIndex = 1;
            label1.Text = "CarReportSystem";
            // 
            // lbVersion
            // 
            lbVersion.AutoSize = true;
            lbVersion.Font = new Font("游ゴシック", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbVersion.Location = new Point(52, 79);
            lbVersion.Name = "lbVersion";
            lbVersion.Size = new Size(112, 27);
            lbVersion.TabIndex = 2;
            lbVersion.Text = "Ver,1.0.0.0";
            // 
            // fmVersion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 313);
            Controls.Add(lbVersion);
            Controls.Add(label1);
            Controls.Add(btVersionOK);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "fmVersion";
            Text = "fmVersion";
            Load += fmVersion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btVersionOK;
        private Label label1;
        private Label lbVersion;
    }
}