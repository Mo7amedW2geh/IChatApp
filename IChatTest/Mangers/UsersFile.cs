using System;
using System.Collections.Generic;
using System.Text;

namespace IChatTest.Mangers {
    internal class UsersFile {
        private static readonly string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        private static readonly string dectionaryPath = Path.Combine(projectPath, "SharedFiles");
        private static readonly string path = Path.Combine(dectionaryPath, "users.txt");
        private static readonly Mutex mutex = new(false, "Global\\UserMutex");

        public static void AddOrUpdateUser(string username) {
            mutex.WaitOne();

            try {
                Directory.CreateDirectory(dectionaryPath);
                if (!File.Exists(path)) {
                    File.Create(path).Close();
                }

                var users = ReadUsersInfo();

                bool exists = false;

                foreach (var user in users) {
                    if (user.Username == username) {
                        user.LastSeen = DateTime.Now;
                        exists = true;
                        break;
                    }
                }

                if (!exists) {
                    users.Add(new Entities.User {
                        Username = username,
                        LastSeen = DateTime.Now
                    });
                }

                SaveUsers(users);
            } finally {
                mutex.ReleaseMutex();
            }
        }

        public static void RemoveUser(string username) {
            mutex.WaitOne();

            try {
                Directory.CreateDirectory(dectionaryPath);
                if (File.Exists(path)) {
                    List<string> users = new List<String>(File.ReadAllLines(path));

                    users.Remove(username);

                    File.WriteAllLines(path, users);
                }
            } finally {
                mutex.ReleaseMutex();
            }
        }

        public static List<Entities.User> ReadUsersInfo() {
            List<Entities.User> users = new List<Entities.User>();

            Directory.CreateDirectory(dectionaryPath);
            if (!File.Exists(path))
                return users;

            var lines = File.ReadAllLines(path);

            foreach (var line in lines) {
                var parts = line.Split('|');

                if (parts.Length != 2)
                    continue;

                if (DateTime.TryParse(parts[1], out DateTime time)) {
                    users.Add(new Entities.User {
                        Username = parts[0],
                        LastSeen = time
                    });
                }
            }

            return users;
        }

        private static void SaveUsers(List<Entities.User> users) {
            List<string> lines = new List<string>();

            foreach (var user in users) {
                lines.Add($"{user.Username}|{user.LastSeen:o}");
            }

            File.WriteAllLines(path, lines);
        }

        public static void RemoveInactiveUsers() {
            mutex.WaitOne();

            try {
                var users = ReadUsersInfo();
                users = users.Where(u => (DateTime.Now - u.LastSeen).TotalSeconds < 5).ToList();
                SaveUsers(users);
            } finally { 
                mutex.ReleaseMutex(); 
            }
        }

        public static string[] ReadUsers() {
            Directory.CreateDirectory(dectionaryPath);
            if (!File.Exists(path)) {
                return [];
            }

            return File.ReadAllLines(path);
        }
    }
}
