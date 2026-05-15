using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
