using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Text;

namespace IChatTest {
    internal class ChatFile {
        private static readonly string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        private static readonly string dectionaryPath = Path.Combine(projectPath, "SharedFiles");
        private static readonly string path = Path.Combine(dectionaryPath, "chat.json");
        private static Mutex mutex = new(false, "Global\\ChatMutex");


        static public void WriteMessage(Message msg) {
            mutex.WaitOne();

            Directory.CreateDirectory(dectionaryPath);
            if (!File.Exists(path)) {
                File.Create(path).Close();
            }

            var json = System.Text.Json.JsonSerializer.Serialize(msg);
            File.AppendAllText(path, json + "\n");

            mutex.ReleaseMutex();
        }

        static public List<Message> ReadMessages() {
            Directory.CreateDirectory(dectionaryPath);
            if (!File.Exists(path))
                return [];

            var lines = File.ReadAllLines(path);

            List<Message> result = new List<Message>();

            foreach (var line in lines) {
                try {
                    result.Add(System.Text.Json.JsonSerializer.Deserialize<Message>(line));
                } catch { }
            }

            return result;
        }
    }
}
