using User = IChatApp.Entities.User;

namespace IChatApp.Mangers {
    internal class UsersFile {

        // Fields
        private static readonly string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        private static readonly string directoryPath = Path.Combine(projectPath, "SharedFiles");
        private static readonly string path = Path.Combine(directoryPath, "users.txt");
        private static readonly Mutex mutex = new(false, "Global\\UserMutex");

        // Methods
        public static void AddOrUpdateUser(string username) {
            mutex.WaitOne();
            try {
                Directory.CreateDirectory(directoryPath);
                if (!File.Exists(path))
                    File.Create(path).Close();

                var users = ReadUsersInfo();
                var existing = users.FirstOrDefault(u => u.Username == username);

                if (existing != null)
                    existing.LastSeen = DateTime.Now;
                else
                    users.Add(new User { Username = username, LastSeen = DateTime.Now });

                SaveUsers(users);
            } finally {
                mutex.ReleaseMutex();
            }
        }

        public static void RemoveUser(string username) {
            mutex.WaitOne();
            try {
                Directory.CreateDirectory(directoryPath);
                if (!File.Exists(path)) return;

                var users = ReadUsersInfo().Where(u => u.Username != username).ToList();
                SaveUsers(users);
            } finally {
                mutex.ReleaseMutex();
            }
        }

        public static void RemoveInactiveUsers() {
            mutex.WaitOne();
            try {
                var users = ReadUsersInfo().Where(u => (DateTime.Now - u.LastSeen).TotalSeconds < 5).ToList();
                SaveUsers(users);
            } finally {
                mutex.ReleaseMutex();
            }
        }

        public static List<User> ReadUsersInfo() {
            var users = new List<User>();

            Directory.CreateDirectory(directoryPath);
            if (!File.Exists(path)) return users;

            foreach (var line in File.ReadAllLines(path)) {
                var parts = line.Split('|');
                if (parts.Length != 2) continue;

                if (DateTime.TryParse(parts[1], out DateTime time))
                    users.Add(new User { Username = parts[0], LastSeen = time });
            }

            return users;
        }

        public static string[] ReadUsers() {
            Directory.CreateDirectory(directoryPath);
            if (!File.Exists(path)) return [];
            return File.ReadAllLines(path);
        }

        private static void SaveUsers(List<User> users) {
            File.WriteAllLines(path, users.Select(u => $"{u.Username}|{u.LastSeen:o}"));
        }
    }
}
