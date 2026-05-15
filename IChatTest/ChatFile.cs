using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Text;

namespace IChatTest {
    internal class ChatFile {
        private static readonly string path = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "SharedFiles", "chat.txt");
        private static Mutex mutex = new(false, "Global\\ChatMutex");


        static public void WriteMessage(string message) {
            mutex.WaitOne();

            Directory.CreateDirectory("SharedFiles");
            if (!File.Exists(path)) {
                File.Create(path).Close();
            }

            File.AppendAllText(path, message + "\n");

            mutex.ReleaseMutex();
        }

        static public string[] ReadMessage() {
            Directory.CreateDirectory("SharedFiles");
            if (!File.Exists(path))
                return [];

            return File.ReadAllLines(path);
        }
    }
}
