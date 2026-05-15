using System;
using System.Collections.Generic;
using System.Text;

namespace IChatTest {
    internal class UserFile {
        private static readonly string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        private static readonly string dectionaryPath = Path.Combine(projectPath, "SharedFiles");
        private static readonly string path = Path.Combine(dectionaryPath, "users.txt");
        private static readonly Mutex mutex = new(false, "Global\\UserMutex");

        public static void AddUser(string username) {
            mutex.WaitOne();

            Directory.CreateDirectory(dectionaryPath);
            if (!File.Exists(path)) {
                File.Create(path).Close();
            }

            string[] users = File.ReadAllLines(path);

            bool exists = false;

            foreach (string user in users) {
                if (user == username) {
                    exists = true;
                    break;
                }
            }

            if (!exists) {
                File.AppendAllText(path, username + "\n");
            }

            mutex.ReleaseMutex();
        }

        public static void RemoveUser(string username) {
            mutex.WaitOne();

            Directory.CreateDirectory(dectionaryPath);
            if (File.Exists(path)) {
                List<string> users = new List<String>(File.ReadAllLines(path));

                users.Remove(username);

                File.WriteAllLines(path, users);
            }

            mutex.ReleaseMutex();
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
