using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            // --- Video 1 ---
            Video video1 = new Video("C# Basics for Beginners: Learn OOP", "CodeWithMosh", 720);
            video1.AddComment(new Comment("Alex", "Great explanation of classes!"));
            video1.AddComment(new Comment("Sarah_Dev", "Finally understood what encapsulation means. Thanks!"));
            video1.AddComment(new Comment("John_Doe", "Could you make a video on interfaces next?"));
            videos.Add(video1);

            // --- Video 2 ---
            Video video2 = new Video("Top 10 Best Gaming Laptops 2026", "TechZone", 900);
            video2.AddComment(new Comment("GamerPro99", "Asus ROG is definitely the winner this year."));
            video2.AddComment(new Comment("Brian", "Is the battery life good on the HP Omen?"));
            video2.AddComment(new Comment("Clara", "Nice review, very straight to the point."));
            video2.AddComment(new Comment("David", "Thanks for including the price breakdown!"));
            videos.Add(video2);

            // --- Video 3 ---
            Video video3 = new Video("How to Make Homemade Pizza from Scratch", "ChefMario", 480);
            video3.AddComment(new Comment("Elena", "Tried this recipe today, the crust was perfect!"));
            video3.AddComment(new Comment("Mike", "How long should I let the dough rest?"));
            video3.AddComment(new Comment("Sophi_A", "My family loved it. Subscribed!"));
            videos.Add(video3);

            // --- Display All Videos Information ---
            Console.WriteLine("==================================================");
            Console.WriteLine("          YOUTUBE VIDEO TRACKING SYSTEM           ");
            Console.WriteLine("==================================================\n");

            foreach (Video video in videos)
            {
                Console.WriteLine($"Title:  {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Total Comments: {video.GetCommentCount()}");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Comments:");

                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($" - {comment.Name}: \"{comment.Text}\"");
                }

                Console.WriteLine("\n==================================================\n");
            }
        }
    }
}