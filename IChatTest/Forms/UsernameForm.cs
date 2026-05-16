using IChatTest.Mangers;

namespace IChatTest {
    public partial class UsernameForm : Form {

        // Fields
        public string Username = "";

        // Constructor
        public UsernameForm() {
            InitializeComponent();
        }

        // Event Handlers
        private void buttonJoin_Click(object sender, EventArgs e) {
            Username = textBoxUsername.Text;

            if (string.IsNullOrWhiteSpace(Username)) {
                MessageBox.Show("Please enter a valid username.");
                return;
            }

            bool exists = UsersFile.ReadUsersInfo().Any(u => u.Username == Username);

            if (exists) {
                MessageBox.Show("Username is already taken.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBoxUsername_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                buttonJoin.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}