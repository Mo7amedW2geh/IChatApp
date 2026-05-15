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
            timer1 = new System.Windows.Forms.Timer(components);
            listBoxUsers = new ListBox();
            chatPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(11, 4);
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
            textBoxMessage.Location = new Point(11, 411);
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.Size = new Size(543, 27);
            textBoxMessage.TabIndex = 5;
            textBoxMessage.KeyDown += textBoxMessage_KeyDown;
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
            listBoxUsers.Location = new Point(10, 28);
            listBoxUsers.Margin = new Padding(3, 4, 3, 4);
            listBoxUsers.Name = "listBoxUsers";
            listBoxUsers.Size = new Size(137, 364);
            listBoxUsers.TabIndex = 8;
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
            // ChatWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 451);
            Controls.Add(chatPanel);
            Controls.Add(listBoxUsers);
            Controls.Add(labelUsername);
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

        private Label labelUsername;
        private Button buttonSend;
        private TextBox textBoxMessage;
        private System.Windows.Forms.Timer timer1;
        private ListBox listBoxUsers;
        private FlowLayoutPanel chatPanel;
    }
}