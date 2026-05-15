namespace IChatTest {
    partial class ChatWindow {
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
            components = new System.ComponentModel.Container();
            labelUsername = new Label();
            buttonSend = new Button();
            textBoxMessage = new TextBox();
            listBoxMessages = new ListBox();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(12, 4);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(38, 20);
            labelUsername.TabIndex = 7;
            labelUsername.Text = "User";
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(561, 409);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(105, 29);
            buttonSend.TabIndex = 6;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new Point(12, 411);
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.Size = new Size(543, 27);
            textBoxMessage.TabIndex = 5;
            // 
            // listBoxMessages
            // 
            listBoxMessages.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listBoxMessages.FormattingEnabled = true;
            listBoxMessages.Location = new Point(12, 27);
            listBoxMessages.Name = "listBoxMessages";
            listBoxMessages.Size = new Size(654, 364);
            listBoxMessages.TabIndex = 4;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;
            // 
            // ChatWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 450);
            Controls.Add(labelUsername);
            Controls.Add(buttonSend);
            Controls.Add(textBoxMessage);
            Controls.Add(listBoxMessages);
            MaximizeBox = false;
            Name = "ChatWindow";
            Text = "IChat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelUsername;
        private Button buttonSend;
        private TextBox textBoxMessage;
        private ListBox listBoxMessages;
        private System.Windows.Forms.Timer timer1;
    }
}