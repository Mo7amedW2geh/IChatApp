using IChatTest.Mangers;
using Message = IChatTest.Entities.Message;

namespace IChatTest {
    public partial class ChatWindow : Form {

        // Fields
        private string username;
        private int rowWidth;
        private int lastMessageCount = 0;
        private string[] lastUsers = Array.Empty<string>();

        // Constructor
        public ChatWindow(string user) {
            InitializeComponent();
            username = user;
            rowWidth = chatPanel.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 10;

            UsersFile.AddOrUpdateUser(username);
            MessagesFile.WriteMessage(new Message {
                Sender = username,
                Text = $"{username} joined the chat",
                Type = "system",
                Time = DateTime.Now.ToString("hh:mm:ss")
            });

            RefreshChat();
            RefreshUserList();
        }

        // Event Handlers
        private void buttonSend_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(textBoxMessage.Text)) return;

            MessagesFile.WriteMessage(new Message {
                Sender = username,
                Text = textBoxMessage.Text,
                Type = "user",
                Time = DateTime.Now.ToString("hh:mm:ss")
            });

            textBoxMessage.Clear();
        }

        private void textBoxMessage_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && e.Shift) return;

            if (e.KeyCode == Keys.Enter) {
                buttonSend.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            UsersFile.AddOrUpdateUser(username);
            UsersFile.RemoveInactiveUsers();
            RefreshChat();
            RefreshUserList();
        }

        private void listBoxUsers_DrawItem(object sender, DrawItemEventArgs e) {
            if (e.Index < 0) return;

            string item = listBoxUsers.Items[e.Index].ToString();
            Color textColor = item == username ? Color.Blue : Color.Black;

            e.DrawBackground();

            using (Brush brush = new SolidBrush(textColor))
                e.Graphics.DrawString(item, e.Font, brush, e.Bounds);

            e.DrawFocusRectangle();
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            UsersFile.RemoveUser(username);
            MessagesFile.WriteMessage(new Message {
                Sender = username,
                Text = $"{username} left the chat",
                Type = "system",
                Time = DateTime.Now.ToString("hh:mm:ss")
            });
            base.OnFormClosing(e);
        }

        // Refresh Methods
        private void RefreshChat() {
            var messages = MessagesFile.ReadMessages();
            if (messages.Count == lastMessageCount) return;

            foreach (var msg in messages.Skip(lastMessageCount)) {
                if (msg.Type == "system") AddCenter(msg);
                else if (msg.Sender == username) AddRight(msg);
                else AddLeft(msg);
            }

            lastMessageCount = messages.Count;
            ScrollToBottom();
        }

        private void RefreshUserList() {
            var users = UsersFile.ReadUsersInfo().Select(u => u.Username).ToArray();
            if (users.SequenceEqual(lastUsers)) return;

            listBoxUsers.BeginUpdate();
            listBoxUsers.Items.Clear();
            listBoxUsers.Items.Add(username);

            foreach (var user in users)
                if (user != username)
                    listBoxUsers.Items.Add(user);

            lastUsers = users;
            listBoxUsers.EndUpdate();
        }

        // Message Rendering
        private void AddLeft(Message msg) {
            var lbl = CreateBubble($"{msg.Sender}:\n{msg.Text}\n[{msg.Time}] ", Color.LightGray);
            var row = CreateRow();

            row.Controls.Add(lbl);
            lbl.Location = new Point(0, 5);
            row.Height = lbl.Height + 10;
            chatPanel.Controls.Add(row);
        }

        private void AddRight(Message msg) {
            var lbl = CreateBubble($"you:\n{msg.Text}\n[{msg.Time}] ", Color.LightBlue);
            var row = CreateRow();

            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            row.Controls.Add(lbl);
            lbl.Location = new Point(rowWidth - lbl.Width, 5);
            row.Height = lbl.Height + 10;
            chatPanel.Controls.Add(row);
        }

        private void AddCenter(Message msg) {
            var lbl = CreateBubble(msg.Text, Color.Gold);
            var row = CreateRow();

            row.Controls.Add(lbl);
            lbl.Location = new Point((rowWidth - lbl.PreferredWidth) / 2, 5);
            row.Height = lbl.Height + 10;
            chatPanel.Controls.Add(row);
        }

        // UI Helpers
        private Label CreateBubble(string text, Color color) {
            return new Label {
                Text = text,
                BackColor = color,
                Padding = new Padding(8),
                AutoSize = true,
                MaximumSize = new Size(rowWidth - 10, 0)
            };
        }

        private Panel CreateRow() {
            return new Panel {
                Width = rowWidth,
                Height = 40,
                Margin = new Padding(5)
            };
        }

        private void ScrollToBottom() {
            if (chatPanel.Controls.Count == 0) return;
            chatPanel.ScrollControlIntoView(chatPanel.Controls[chatPanel.Controls.Count - 1]);
        }
    }
}