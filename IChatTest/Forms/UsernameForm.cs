using IChatTest.Mangers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace IChatTest {
    public partial class UsernameForm : Form {
        public string Username = "";
        public UsernameForm() {
            InitializeComponent();
        }

        private void buttonJoin_Click(object sender, EventArgs e) {
            Username = textBoxUsername.Text;
            if (string.IsNullOrWhiteSpace(Username)) {
                MessageBox.Show("Please enter a valid username.");
                return;
            }

            var users = UsersFile.ReadUsersInfo().Select(u => u.Username).ToArray();

            bool exists = false;

            foreach (var user in users) {
                if (user == Username) {
                    exists = true;
                    break;
                }
            }

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
