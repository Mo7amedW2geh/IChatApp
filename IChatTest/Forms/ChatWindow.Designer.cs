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
            labelUsers = new Label();
            buttonSend = new Button();
            textBoxMessage = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            listBoxUsers = new ListBox();
            chatPanel = new FlowLayoutPanel();
            labelChat = new Label();
            SuspendLayout();
            // 
            // labelUsers
            // 
            labelUsers.AutoSize = true;
            labelUsers.Location = new Point(11, 4);
            labelUsers.Name = "labelUsers";
            labelUsers.Size = new Size(44, 20);
            labelUsers.TabIndex = 7;
            labelUsers.Text = "Users";
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
            textBoxMessage.Location = new Point(11, 411);
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.PlaceholderText = "Message";
            textBoxMessage.Size = new Size(543, 27);
            textBoxMessage.TabIndex = 5;
            textBoxMessage.KeyDown += textBoxMessage_KeyDown;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // listBoxUsers
            // 
            listBoxUsers.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxUsers.FormattingEnabled = true;
            listBoxUsers.Location = new Point(10, 28);
            listBoxUsers.Margin = new Padding(3, 4, 3, 4);
            listBoxUsers.Name = "listBoxUsers";
            listBoxUsers.Size = new Size(137, 364);
            listBoxUsers.TabIndex = 8;
            listBoxUsers.DrawItem += listBoxUsers_DrawItem;
            // 
            // chatPanel
            // 
            chatPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chatPanel.AutoScroll = true;
            chatPanel.BackColor = SystemColors.Window;
            chatPanel.BorderStyle = BorderStyle.FixedSingle;
            chatPanel.FlowDirection = FlowDirection.TopDown;
            chatPanel.Location = new Point(154, 28);
            chatPanel.Name = "chatPanel";
            chatPanel.Size = new Size(512, 364);
            chatPanel.TabIndex = 9;
            chatPanel.WrapContents = false;
            // 
            // labelChat
            // 
            labelChat.AutoSize = true;
            labelChat.Location = new Point(154, 4);
            labelChat.Name = "labelChat";
            labelChat.Size = new Size(83, 20);
            labelChat.TabIndex = 10;
            labelChat.Text = "Public Chat";
            // 
            // ChatWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 451);
            Controls.Add(labelChat);
            Controls.Add(chatPanel);
            Controls.Add(listBoxUsers);
            Controls.Add(labelUsers);
            Controls.Add(buttonSend);
            Controls.Add(textBoxMessage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ChatWindow";
            Text = "IChat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelUsers;
        private Button buttonSend;
        private TextBox textBoxMessage;
        private System.Windows.Forms.Timer timer1;
        private ListBox listBoxUsers;
        private FlowLayoutPanel chatPanel;
        private Label labelChat;
    }
}