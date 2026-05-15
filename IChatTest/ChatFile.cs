using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Text;

namespace IChatTest {
    internal class ChatFile {
        private static readonly string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        private static readonly string dectionaryPath = Path.Combine(projectPath, "SharedFiles");
        private static readonly string path = Path.Combine(dectionaryPath, "chat.txt");
        private static Mutex mutex = new(false, "Global\\ChatMutex");


        static public void WriteMessage(string message) {
            mutex.WaitOne();

            Directory.CreateDirectory(dectionaryPath);
            if (!File.Exists(path)) {
                File.Create(path).Close();
            }

            File.AppendAllText(path, message + "\n");

            mutex.ReleaseMutex();
        }

        static public string[] ReadMessage() {
            Directory.CreateDirectory(dectionaryPath);
            if (!File.Exists(path))
                return [];

            return File.ReadAllLines(path);
        }
    }
}
