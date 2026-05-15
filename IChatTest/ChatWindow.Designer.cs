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
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            labelUsername = new Label();
            buttonSend = new Button();
            textBoxMessage = new TextBox();
            listBoxMessages = new ListBox();
            timer1 = new System.Windows.Forms.Timer(components);
            listBoxUsers = new ListBox();
            SuspendLayout();
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(10, 3);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(30, 15);
            labelUsername.TabIndex = 7;
            labelUsername.Text = "User";
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(491, 307);
            buttonSend.Margin = new Padding(3, 2, 3, 2);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(92, 22);
            buttonSend.TabIndex = 6;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new Point(10, 308);
            textBoxMessage.Margin = new Padding(3, 2, 3, 2);
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.Size = new Size(476, 23);
            textBoxMessage.TabIndex = 5;
            // 
            // listBoxMessages
            // 
            listBoxMessages.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listBoxMessages.FormattingEnabled = true;
            listBoxMessages.Location = new Point(135, 20);
            listBoxMessages.Margin = new Padding(3, 2, 3, 2);
            listBoxMessages.Name = "listBoxMessages";
            listBoxMessages.Size = new Size(448, 274);
            listBoxMessages.TabIndex = 4;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;
            // 
            // listBoxUsers
            // 
            listBoxUsers.FormattingEnabled = true;
            listBoxUsers.Location = new Point(9, 21);
            listBoxUsers.Name = "listBoxUsers";
            listBoxUsers.Size = new Size(120, 274);
            listBoxUsers.TabIndex = 8;
            // 
            // ChatWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(593, 338);
            Controls.Add(listBoxUsers);
            Controls.Add(labelUsername);
            Controls.Add(buttonSend);
            Controls.Add(textBoxMessage);
            Controls.Add(listBoxMessages);
            Margin = new Padding(3, 2, 3, 2);
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
        private ListBox listBoxUsers;
    }
}