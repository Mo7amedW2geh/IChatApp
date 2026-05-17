using IChatApp.Mangers;

namespace IChatApp {
    internal static class Program {

        [STAThread]
        static void Main() {
            ApplicationConfiguration.Initialize();
            UsersFile.RemoveInactiveUsers();

            var usernameForm = new UsernameForm();

            if (usernameForm.ShowDialog() == DialogResult.OK)
                Application.Run(new ChatWindow(usernameForm.Username));
        }
    }
}