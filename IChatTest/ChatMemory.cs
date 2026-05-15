using System;
using System.Collections.Generic;
using System.Text;

namespace IChatTest {
    internal class ChatMemory {
        public static List<String> Messages = [];
        public static object MessageLock = new();
    }
}
