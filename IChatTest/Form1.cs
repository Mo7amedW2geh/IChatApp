namespace IChatTest {
    public partial class Form1 : Form {

        private List<String> sharedMessages = [];
        private readonly object messageLock = new();

        public Form1() {
            InitializeComponent();
        }

        private void buttonSendA_Click(object sender, EventArgs e) {
            lock (messageLock) {
                sharedMessages.Add($"User A: {textBoxUserA.Text}");
                textBoxUserA.Clear();
                RefreshChats();
            }
        }

        private void buttonSendB_Click(object sender, EventArgs e) {
            lock (messageLock) {
                sharedMessages.Add($"User B: {textBoxUserB.Text}");
                textBoxUserB.Clear();
                RefreshChats();
            }
        }

        private void RefreshChats() {
            lock (messageLock) {
                listBoxUserA.Items.Clear();
                listBoxUserB.Items.Clear();
                foreach (var message in sharedMessages) {
                    listBoxUserA.Items.Add(message);
                    listBoxUserB.Items.Add(message);
                }
            }
        }
    }
}
