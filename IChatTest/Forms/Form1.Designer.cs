namespace IChatTest {
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
            listBoxUserA = new ListBox();
            textBoxUserA = new TextBox();
            buttonSendA = new Button();
            labelA = new Label();
            labelB = new Label();
            buttonSendB = new Button();
            textBoxUserB = new TextBox();
            listBoxUserB = new ListBox();
            SuspendLayout();
            // 
            // listBoxUserA
            // 
            listBoxUserA.FormattingEnabled = true;
            listBoxUserA.Location = new Point(12, 79);
            listBoxUserA.Name = "listBoxUserA";
            listBoxUserA.Size = new Size(394, 364);
            listBoxUserA.TabIndex = 0;
            // 
            // textBoxUserA
            // 
            textBoxUserA.Location = new Point(12, 32);
            textBoxUserA.Name = "textBoxUserA";
            textBoxUserA.Size = new Size(283, 27);
            textBoxUserA.TabIndex = 1;
            // 
            // buttonSendA
            // 
            buttonSendA.Location = new Point(301, 30);
            buttonSendA.Name = "buttonSendA";
            buttonSendA.Size = new Size(105, 29);
            buttonSendA.TabIndex = 2;
            buttonSendA.Text = "Send";
            buttonSendA.UseVisualStyleBackColor = true;
            buttonSendA.Click += buttonSendA_Click;
            // 
            // labelA
            // 
            labelA.AutoSize = true;
            labelA.Location = new Point(12, 9);
            labelA.Name = "labelA";
            labelA.Size = new Size(52, 20);
            labelA.TabIndex = 3;
            labelA.Text = "User A";
            // 
            // labelB
            // 
            labelB.AutoSize = true;
            labelB.Location = new Point(479, 9);
            labelB.Name = "labelB";
            labelB.Size = new Size(51, 20);
            labelB.TabIndex = 7;
            labelB.Text = "User B";
            // 
            // buttonSendB
            // 
            buttonSendB.Location = new Point(768, 30);
            buttonSendB.Name = "buttonSendB";
            buttonSendB.Size = new Size(105, 29);
            buttonSendB.TabIndex = 6;
            buttonSendB.Text = "Send";
            buttonSendB.UseVisualStyleBackColor = true;
            buttonSendB.Click += buttonSendB_Click;
            // 
            // textBoxUserB
            // 
            textBoxUserB.Location = new Point(479, 32);
            textBoxUserB.Name = "textBoxUserB";
            textBoxUserB.Size = new Size(283, 27);
            textBoxUserB.TabIndex = 5;
            // 
            // listBoxUserB
            // 
            listBoxUserB.FormattingEnabled = true;
            listBoxUserB.Location = new Point(479, 79);
            listBoxUserB.Name = "listBoxUserB";
            listBoxUserB.Size = new Size(394, 364);
            listBoxUserB.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(885, 450);
            Controls.Add(labelB);
            Controls.Add(buttonSendB);
            Controls.Add(textBoxUserB);
            Controls.Add(listBoxUserB);
            Controls.Add(labelA);
            Controls.Add(buttonSendA);
            Controls.Add(textBoxUserA);
            Controls.Add(listBoxUserA);
            Name = "Form1";
            Text = "IChat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxUserA;
        private TextBox textBoxUserA;
        private Button buttonSendA;
        private Label labelA;
        private Label labelB;
        private Button buttonSendB;
        private TextBox textBoxUserB;
        private ListBox listBoxUserB;
    }
}
