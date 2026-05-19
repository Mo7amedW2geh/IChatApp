using System.Text.Json;
using Message = IChatApp.Entities.Message;

namespace IChatApp.Mangers {
    internal class MessagesFile {

        // Fields
        private static readonly string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        private static readonly string directoryPath = Path.Combine(projectPath, "SharedFiles");
        private static readonly string path = Path.Combine(directoryPath, "chat.json");
        private static readonly Mutex mutex = new(false, "Global\\ChatMutex");
        private static readonly SemaphoreSlim semaphore = new(1, 1);

        // Methods
        public static void WriteMessage(Message msg) {
            // mutex.WaitOne();
            semaphore.Wait();
            try {
                Directory.CreateDirectory(directoryPath);
                if (!File.Exists(path))
                    File.Create(path).Close();

                File.AppendAllText(path, JsonSerializer.Serialize(msg) + "\n");
            } finally {
                // mutex.ReleaseMutex();
                semaphore.Release();
            }
        }

        public static List<Message> ReadMessages() {
            Directory.CreateDirectory(directoryPath);
            if (!File.Exists(path)) return [];

            var result = new List<Message>();

            foreach (var line in File.ReadAllLines(path)) {
                try {
                    result.Add(JsonSerializer.Deserialize<Message>(line));
                } catch { }
            }

            return result;
        }
    }
}