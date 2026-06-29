using System;
using BCrypt.Net;

class Program {
    static void Main() {
        string correctHash = BCrypt.Net.BCrypt.HashPassword("admin123");
        Console.WriteLine("CORRECT HASH: " + correctHash);
    }
}
