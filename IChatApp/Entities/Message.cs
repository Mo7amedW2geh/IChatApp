namespace IChatApp.Entities {
    internal class Message {
        public string Sender { get; set; }
        public string Text { get; set; }
        public string Type { get; set; } // "user", "system"
        public string Time { get; set; }
    }
}
