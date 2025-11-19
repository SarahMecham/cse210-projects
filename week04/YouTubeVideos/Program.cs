using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        //Video 1
        Video video1 = new Video("Puppy Playing Ball", "Tom Jones", 180);
        video1.AddComment(new Comment("Sarah", "So Cute!!!"));
        video1.AddComment(new Comment("Emily", "I love it so much!"));
        video1.AddComment(new Comment("Brian", "Love that puppy!"));
        video1.AddComment(new Comment("Hailey", "Such a cute puppy! I want one just like it!"));
        videos.Add(video1);

        //Video 2
        Video video2 = new Video("Sourdough Bread Tutoral", "Betty Crocker", 520);
        video2.AddComment(new Comment("Rachel", "So helpful and yummy!"));
        video2.AddComment(new Comment("Judy", "Thank you, I have been trying to make sourdough successfully for years!"));
        video2.AddComment(new Comment("Evelyn", "This recipe is so good!"));
        video2.AddComment(new Comment("John", "Best bread tutorial I've seen!"));
        videos.Add(video2);

        //Video 3
        Video video3 = new Video("Cat Video Compilation", "Animal Fun", 300);
        video3.AddComment(new Comment("Sam", "So Cute!"));
        video3.AddComment(new Comment("Jane", "My kids love this!"));
        video3.AddComment(new Comment("Carlos", "LOL"));
        videos.Add(video3);

        //Video 4
        Video video4 = new Video("Learn C# in 10 Minutes", "CodeMaster", 600);
        video4.AddComment(new Comment("Eli", "Thanks for the help!"));
        video4.AddComment(new Comment("Aliya", "Can you make a part 2?"));
        video4.AddComment(new Comment("Harvey", "Great explanation"));
        video4.AddComment(new Comment("Keira", "That was fun to learn, Thanks!"));
        videos.Add(video4);

        foreach(Video vid in videos)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Title: {vid._title}");
            Console.WriteLine($"Author: {vid._author}");
            Console.WriteLine($"Length: {vid._length} seconds");
            Console.WriteLine($"Number of Comment: {vid.GetCommentCount()}");
            Console.WriteLine("\nComments:");

            foreach (Comment c in vid._comments)
            {
                Console.WriteLine($"-{c._commenterName}: {c._text}");
            }

            Console.WriteLine();
        }
    }
}