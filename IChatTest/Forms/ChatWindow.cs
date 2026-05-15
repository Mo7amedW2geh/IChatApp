namespace IChatTest {
    public partial class ChatWindow : Form {
        private string username;
        private int lastMessageCount = 0;

        public ChatWindow(string user) {
            InitializeComponent();
            username = user;
            labelUsername.Text = username;

            UserFile.AddUser(username);
            ChatFile.WriteMessage(new Message {
                Sender = username,
                Text = $"{username} joined the chat",
                Type = "system",
                Time = DateTime.Now.ToString("hh:mm:ss")
            });

            RefreshChat();
            RefreshUserList();
        }

        private void buttonSend_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(textBoxMessage.Text)) return;
            var msg = new Message() {
                Sender = username,
                Text = textBoxMessage.Text,
                Type = "user",
                Time = DateTime.Now.ToString("hh:mm:ss")
            };
            ChatFile.WriteMessage(msg);
            textBoxMessage.Clear();
        }

        private void RefreshChat() {
            var messages = ChatFile.ReadMessages();
            if (messages.Count == lastMessageCount)
                return;

            chatPanel.Controls.Clear();

            foreach (var msg in messages) {
                if (msg.Type == "system")
                    AddCenter(msg);
                else if (msg.Sender == username)
                    AddRight(msg);
                else
                    AddLeft(msg);
            }

            lastMessageCount = messages.Count;
            ScrollToBottom();
        }

        private void RefreshUserList() {
            listBoxUsers.Items.Clear();
            string[] users = UserFile.ReadUsers();
            listBoxUsers.Items.AddRange(users);
        }

        private void timer1_Tick(object sender, EventArgs e) {
            RefreshChat();
            RefreshUserList();
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            UserFile.RemoveUser(username);
            ChatFile.WriteMessage(new Message {
                Sender = username,
                Text = $"{username} left the chat",
                Type = "system",
                Time = DateTime.Now.ToString("hh:mm:ss")
            });
            base.OnFormClosing(e);
        }

        private void textBoxMessage_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                buttonSend.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
        private void AddLeft(Message msg) {
            Panel row = CreateRow();

            Label lbl = new Label();
            lbl.Text = $"[{msg.Time}] {msg.Sender}: {msg.Text}";
            lbl.AutoSize = true;
            lbl.BackColor = Color.LightGray;
            lbl.Padding = new Padding(8);
            lbl.AutoSize = true;
            lbl.MaximumSize = new Size(chatPanel.ClientSize.Width - 40, 0);

            lbl.Location = new Point(0, 5); // LEFT FIXED

            row.Controls.Add(lbl);
            chatPanel.Controls.Add(row);
            row.Height = lbl.Height + 10;
        }

        private void AddRight(Message msg) {
            Panel row = CreateRow();

            Label lbl = new Label();
            lbl.Text = $"[{msg.Time}] {msg.Text}";
            lbl.AutoSize = true;
            lbl.BackColor = Color.LightBlue;
            lbl.Padding = new Padding(8);
            lbl.AutoSize = true;
            lbl.MaximumSize = new Size(chatPanel.ClientSize.Width - 40, 0);

            lbl.Location = new Point(
                row.Width - lbl.PreferredWidth - 10,
                5
            );

            lbl.Anchor = AnchorStyles.Right;

            row.Controls.Add(lbl);
            chatPanel.Controls.Add(row);
            row.Height = lbl.Height + 10;
        }

        private void AddCenter(Message msg) {
            Panel row = CreateRow();

            Label lbl = new Label();
            lbl.Text = msg.Text;
            lbl.AutoSize = true;
            lbl.BackColor = Color.Gold;
            lbl.Padding = new Padding(8);
            lbl.AutoSize = true;
            lbl.MaximumSize = new Size(chatPanel.ClientSize.Width - 40, 0);

            lbl.Location = new Point(
                (row.Width - lbl.PreferredWidth) / 2,
                5
            );

            row.Controls.Add(lbl);
            chatPanel.Controls.Add(row);
            row.Height = lbl.Height + 10;
        }

        private Panel CreateRow() {
            return new Panel {
                Width = chatPanel.ClientSize.Width - 20,
                Height = 40,
                Margin = new Padding(5)
            };
        }

        private void ScrollToBottom() {
            if (chatPanel.Controls.Count == 0)
                return;

            var last = chatPanel.Controls[chatPanel.Controls.Count - 1];
            chatPanel.ScrollControlIntoView(last);
        }
    }
}