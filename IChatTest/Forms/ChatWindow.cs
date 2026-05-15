namespace IChatTest {
    public partial class ChatWindow : Form {
        private string username;

        public ChatWindow(string user) {
            InitializeComponent();
            username = user;
            labelUsername.Text = username;

            UserFile.AddUser(username);
            ChatFile.WriteMessage($"*** {username} joined the chat ***");

            RefreshChat();
            RefreshUserList();
        }

        private void buttonSend_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(textBoxMessage.Text)) return;
            string msg = $"[{DateTime.Now:hh:mm:ss}]{username}: {textBoxMessage.Text}";
            ChatFile.WriteMessage(msg);
            textBoxMessage.Clear();
            RefreshChat();
        }

        private void RefreshChat() {
            listBoxMessages.Items.Clear();
            string[] messages = ChatFile.ReadMessage();
            listBoxMessages.Items.AddRange(messages);
            if (listBoxMessages.Items.Count > 0) 
                listBoxMessages.TopIndex = listBoxMessages.Items.Count - 1;
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
            ChatFile.WriteMessage($"*** {username} left the chat ***");
            base.OnFormClosing(e);
        }
    }
}