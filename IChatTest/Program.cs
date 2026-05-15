namespace IChatTest {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            UsernameForm usernameForm = new UsernameForm();

            if (usernameForm.ShowDialog() == DialogResult.OK)
                Application.Run(new ChatWindow(usernameForm.Username));


            //Application.Run(new Form1());
        }
    }
}