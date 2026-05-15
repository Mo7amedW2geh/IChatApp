using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IChatTest {
    public partial class ChatWindow : Form {
        private string username;

        public ChatWindow(string user) {
            username = user;
            InitializeComponent();
            labelUsername.Text = username;
        }
        private void buttonSend_Click(object sender, EventArgs e) {
            lock (ChatMemory.MessageLock) {
                ChatMemory.Messages.Add($"{username}: {textBoxMessage.Text}");
                textBoxMessage.Clear();
                RefreshChat();
            }
        }

        private void RefreshChat() {
            lock (ChatMemory.MessageLock) {
                listBoxMessages.Items.Clear();
                foreach (var message in ChatMemory.Messages) {
                    listBoxMessages.Items.Add(message);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            RefreshChat();
        }
    }
}
