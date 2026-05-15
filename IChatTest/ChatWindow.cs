namespace IChatTest
{
    public partial class ChatWindow : Form
    {
        private string username;

        public ChatWindow(string user)
        {
            InitializeComponent();
            username = user;

            // Set the label display
            labelUsername.Text = username;

            // Add this user to the global active users list
            lock (ChatMemory.UserLock)
            {
                if (!ChatMemory.ActiveUsers.Contains(username))
                {
                    ChatMemory.ActiveUsers.Add(username);
                }
            }

            // Initial UI refresh
            RefreshChat();
            RefreshUserList();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMessage.Text)) return;

            lock (ChatMemory.MessageLock)
            {
                ChatMemory.Messages.Add($"{username}: {textBoxMessage.Text}");
                textBoxMessage.Clear();
                RefreshChat();
            }
        }

        private void RefreshChat()
        {
            lock (ChatMemory.MessageLock)
            {
                // To prevent flickering, only clear/refill if counts differ 
                // or use a simple clear for small projects:
                listBoxMessages.Items.Clear();
                foreach (var message in ChatMemory.Messages)
                {
                    listBoxMessages.Items.Add(message);
                }

                // Auto-scroll to the latest message
                listBoxMessages.SelectedIndex = listBoxMessages.Items.Count - 1;
                listBoxMessages.SelectedIndex = -1;
            }
        }

        private void RefreshUserList()
        {
            lock (ChatMemory.UserLock)
            {
                // Ensure your ListBox on the left is named 'listBoxUsers'
                listBoxUsers.Items.Clear();
                foreach (var user in ChatMemory.ActiveUsers)
                {
                    listBoxUsers.Items.Add(user);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshChat();
            RefreshUserList();
        }

        // This removes the user from the list when they close their chat window
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            lock (ChatMemory.UserLock)
            {
                ChatMemory.ActiveUsers.Remove(username);
            }
            base.OnFormClosing(e);
        }
    }
}