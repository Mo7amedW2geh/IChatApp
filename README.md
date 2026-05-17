# IChatApp

A simple local chat application built with **C# WinForms** using **shared files**, **mutex synchronization**, and a graphical user interface.

This project demonstrates:

* Interprocess communication (IPC)
* Shared memory concepts using files
* Synchronization using Mutex
* Real-time chat updates
* Multi-window communication on the same machine

---

# Features

* Multiple users can chat on the same machine
* Real-time message updates
* User online list
* Join/leave system messages
* Heartbeat system for inactive user removal
* Multiline messages
* Enter to send
* Shift + Enter for new line
* Message bubbles:

  * Your messages on the right
  * Other users on the left
  * System messages centered

* Duplicate username prevention
* Shared synchronization using Mutex

---

# Technologies Used

* C#
* .NET WinForms
* File-based IPC
* Mutex synchronization
* JSON serialization

---

# Project Structure

```text
IChatApp
│
├── Entities
│   ├── Message.cs
│   └── User.cs
│
├── Mangers
│   ├── MessagesFile.cs
│   └── UsersFile.cs
│
├── SharedFiles
│   ├── chat.json
│   └── users.txt
│
├── Forms
│   ├── ChatWindow.cs
│   └── UsernameForm.cs
│
└── Program.cs
```

---

# How It Works

## Messages

Messages are stored inside:

```text
SharedFiles/chat.json
```

Each line contains a serialized JSON message object.

Example:

```json
{
  "Sender":"Ahmed",
  "Text":"Hello",
  "Type":"user",
  "Time":"10:30:15"
}
```

---

## Users

Users are stored inside:

```text
SharedFiles/users.txt
```

Each user contains:

```text
Username|LastSeenTime
```

Example:

```text
Ahmed|2026-05-18T10:30:15.1234567
```

---

# Synchronization

The application uses two global mutexes:

## Chat Mutex

```csharp
Global\\ChatMutex
```

Protects message writing operations.

---

## User Mutex

```csharp
Global\\UserMutex
```

Protects user list modifications.

---

# Heartbeat System

Each running client periodically updates its `LastSeen` value.

Inactive users are automatically removed if they do not update within 5 seconds.

This prevents ghost users when the application closes unexpectedly.

---

# User Interface

## Chat Layout

* Left bubbles → other users
* Right bubbles → current user
* Center bubbles → system messages

---

## Keyboard Controls

| Key           | Action       |
| ------------- | ------------ |
| Enter         | Send message |
| Shift + Enter | New line     |

---

# Running the Application

## 1. Open the solution

Open:

```text
IChatApp.slnx
```

using Visual Studio.

---

## 2. Run multiple instances

To simulate multiple users:

* Run the application
* Run it again
* Join with different usernames

Each window acts as a separate chat client.

---

# Important Notes

* This project works only on the same machine.
* Communication is file-based, not network-based.
* The application uses polling with a timer for refreshing chat and users.
* File sharing and synchronization are handled using Mutex.

---

# Future Improvements

Possible upgrades:

* Socket-based networking
* Real-time server/client architecture
* Async communication
* Message encryption
* Database storage
* User authentication
* Modern UI design
* Emoji and image support

---

# Educational Concepts Demonstrated

This project demonstrates important operating systems and networking concepts:

* Interprocess communication
* Shared resources
* Synchronization
* Mutex usage
* File sharing
* Polling systems
* Heartbeat systems
* Concurrent access handling
* GUI programming