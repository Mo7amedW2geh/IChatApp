namespace IChatTest {
    partial class UsernameForm {
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
            textBoxUsername = new TextBox();
            buttonJoin = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBoxUsername
            // 
            textBoxUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxUsername.Location = new Point(12, 44);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.PlaceholderText = "Username";
            textBoxUsername.Size = new Size(261, 27);
            textBoxUsername.TabIndex = 0;
            textBoxUsername.KeyDown += textBoxUsername_KeyDown;
            // 
            // buttonJoin
            // 
            buttonJoin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonJoin.Location = new Point(12, 91);
            buttonJoin.Name = "buttonJoin";
            buttonJoin.Size = new Size(261, 29);
            buttonJoin.TabIndex = 1;
            buttonJoin.Text = "Join Chat";
            buttonJoin.UseVisualStyleBackColor = true;
            buttonJoin.Click += buttonJoin_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 2;
            label1.Text = "Enter Username";
            // 
            // UsernameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(285, 134);
            Controls.Add(label1);
            Controls.Add(buttonJoin);
            Controls.Add(textBoxUsername);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UsernameForm";
            Text = "IChat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxUsername;
        private Button buttonJoin;
        private Label label1;
    }
}