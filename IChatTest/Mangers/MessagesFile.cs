using IChatTest.Entities;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Text;

namespace IChatTest.Mangers {
    internal class MessagesFile {
        private static readonly string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        private static readonly string dectionaryPath = Path.Combine(projectPath, "SharedFiles");
        private static readonly string path = Path.Combine(dectionaryPath, "chat.json");
        private static Mutex mutex = new(false, "Global\\ChatMutex");


        static public void WriteMessage(Entities.Message msg) {
            mutex.WaitOne();

            try {
                Directory.CreateDirectory(dectionaryPath);
                if (!File.Exists(path)) {
                    File.Create(path).Close();
                }

                var json = System.Text.Json.JsonSerializer.Serialize(msg);
                File.AppendAllText(path, json + "\n");
            } finally {
                mutex.ReleaseMutex();
            }
        }

        static public List<Entities.Message> ReadMessages() {
            Directory.CreateDirectory(dectionaryPath);
            if (!File.Exists(path))
                return [];

            var lines = File.ReadAllLines(path);

            List<Entities.Message> result = new List<Entities.Message>();

            foreach (var line in lines) {
                try {
                    result.Add(System.Text.Json.JsonSerializer.Deserialize<Entities.Message>(line));
                } catch { }
            }

            return result;
        }
    }
}
