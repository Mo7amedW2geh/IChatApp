using IChatTest.Entities;
using IChatTest.Mangers;

namespace IChatTest {
    public partial class ChatWindow : Form {
        private string username;
        private int rowWidth;
        private int lastMessageCount = 0;
        private string[] lastUsers = Array.Empty<string>();

        public ChatWindow(string user) {
            InitializeComponent();
            username = user;
            rowWidth = chatPanel.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 10;

            UsersFile.AddOrUpdateUser(username);
            MessagesFile.WriteMessage(new Entities.Message {
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
            var msg = new Entities.Message() {
                Sender = username,
                Text = textBoxMessage.Text,
                Type = "user",
                Time = DateTime.Now.ToString("hh:mm:ss")
            };
            MessagesFile.WriteMessage(msg);
            textBoxMessage.Clear();
        }

        private void RefreshChat() {
            var messages = MessagesFile.ReadMessages();
            if (messages.Count == lastMessageCount)
                return;

            var newMessages = messages.Skip(lastMessageCount).ToList();

            foreach (var msg in newMessages) {
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
            var users = UsersFile.ReadUsersInfo().Select(u => u.Username).ToArray();
            if (users.SequenceEqual(lastUsers))
                return;

            listBoxUsers.BeginUpdate();
            listBoxUsers.Items.Clear();

            listBoxUsers.Items.Add(username);
            foreach (var user in users)
                if (user != username)
                    listBoxUsers.Items.Add(user);

            lastUsers = users;
            listBoxUsers.EndUpdate();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            UsersFile.AddOrUpdateUser(username);
            UsersFile.RemoveInactiveUsers();

            RefreshChat();
            RefreshUserList();
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            UsersFile.RemoveUser(username);
            MessagesFile.WriteMessage(new Entities.Message {
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
        private void AddLeft(Entities.Message msg) {
            Panel row = CreateRow();

            Label lbl = new Label();
            lbl.Text = $"{msg.Sender}:\n{msg.Text}\n[{msg.Time}] ";
            lbl.AutoSize = true;
            lbl.BackColor = Color.LightGray;
            lbl.Padding = new Padding(8);
            lbl.AutoSize = true;
            lbl.MaximumSize = new Size(rowWidth - 10, 0);

            row.Controls.Add(lbl);
            chatPanel.Controls.Add(row);

            lbl.Location = new Point(0, 5); // LEFT FIXED
            row.Height = lbl.Height + 10;
        }

        private void AddRight(Entities.Message msg) {
            Panel row = CreateRow();

            Label lbl = new Label();
            lbl.Text = $"you:\n{msg.Text}\n[{msg.Time}] ";
            lbl.BackColor = Color.LightBlue;
            lbl.Padding = new Padding(8);
            lbl.AutoSize = true;
            lbl.MaximumSize = new Size(rowWidth - 10, 0);
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top;

            row.Controls.Add(lbl);
            chatPanel.Controls.Add(row);

            lbl.Location = new Point(rowWidth - lbl.Width, 5);
            row.Height = lbl.Height + 10;
        }

        private void AddCenter(Entities.Message msg) {
            Panel row = CreateRow();

            Label lbl = new Label();
            lbl.Text = msg.Text;
            lbl.AutoSize = true;
            lbl.BackColor = Color.Gold;
            lbl.Padding = new Padding(8);
            lbl.AutoSize = true;
            lbl.MaximumSize = new Size(rowWidth - 10, 0);

            row.Controls.Add(lbl);
            chatPanel.Controls.Add(row);

            lbl.Location = new Point((rowWidth - lbl.PreferredWidth) / 2, 5);
            row.Height = lbl.Height + 10;
        }

        private Panel CreateRow() {
            int scrollBarWidth = SystemInformation.VerticalScrollBarWidth;
            return new Panel {
                Width = rowWidth,
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

        private void listBoxUsers_DrawItem(object sender, DrawItemEventArgs e) {
            if (e.Index < 0)
                return;

            string item = listBoxUsers.Items[e.Index].ToString();
            Color textColor = Color.Black;

            if (item == username)
                textColor = Color.Blue;

            e.DrawBackground();

            using (Brush brush = new SolidBrush(textColor)) {
                e.Graphics.DrawString(item, e.Font, brush, e.Bounds);
            }

            e.DrawFocusRectangle();
        }
    }
}