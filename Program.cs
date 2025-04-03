using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CyberSecurityChatbot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Path to your .wav file
            TypeText("loading greeting audio..... ");
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greetings.wav"); // Change this to your audio file path

            // Play voice greeting
            PlayGreeting(filePath);

            // Display ASCII art logo
            DisplayAsciiArt();

            // Ask user for their name and personalize interaction
            GreetUser();
        }
        // Method to play the greeting sound
        private static void PlayGreeting(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    using (SoundPlayer player = new SoundPlayer(filePath))
                    {
                        player.PlaySync(); // Play the greeting synchronously
                    }
                }
                else
                {
                    TypeText("Greeting sound file not found.\n");
                }
            }
            catch (Exception ex)
            {
                TypeText($"Error playing greeting sound: {ex.Message}\n");
            }
        }

        // Method to display ASCII art logo
        private static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
   ____             _                          _               _   _             
  / ___| ___   ___ | |_ _ __ ___   __ _ _ __ | |__   __ _ _ __| |_| |_ ___ _ __ 
 | |  _ / _ \ / _ \| __| '_ ` _ \ / _` | '_ \| '_ \ / _` | '__| __| __/ _ \ '__|
 | |_| | (_) | (_) | |_| | | | | | (_| | | | | | | | (_| | |  | |_| ||  __/ |   
  \____|\___/ \___/ \__|_| |_| |_|\__,_|_| |_|_| |_|\__,_|_|   \__|\__\___|_|   
");
            Console.ResetColor();
        }

        // Method to greet the user and ask for their name
        private static void GreetUser()
        {
            TypeText("Welcome to the Cybersecurity Awareness Bot!\n");
            TypeText("What is your name? ");
            string name = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                name = "Guest";
            }

            TypeText($"Hello, {name}! I'm here to help you stay safe online.\n");
            Thread.Sleep(1000); // Add a slight delay for effect
        }
        // Method to add a typing effect delay
        private static void TypeText(string text, int delay = 30)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }
    }
}
    
