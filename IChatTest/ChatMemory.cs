namespace IChatTest
{
    internal class ChatMemory
    {
        // Shared list for chat history
        public static List<String> Messages = [];
        public static object MessageLock = new();

        // Shared list for active users
        public static List<String> ActiveUsers = [];
        public static object UserLock = new();
    }
}