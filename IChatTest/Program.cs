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
            ChatWindow userA = new ChatWindow("User A");
            ChatWindow userB = new ChatWindow("User B");

            userA.Show();
            userB.Show();

            Application.Run();
            //Application.Run(new Form1());
        }
    }
}