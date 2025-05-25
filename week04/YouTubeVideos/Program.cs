// Program.cs
class Program
{
    static void Main(string[] args)
    {
        // Create videos
        var video1 = new Video("How to Code in C#", "Programming Guru", 600);
        var video2 = new Video("Learn OOP in 10 Minutes", "CodeMaster", 300);
        var video3 = new Video("C# Tips and Tricks", "DotNetExpert", 450);

        // Add comments to video1
        video1.AddComment(new Comment("User1", "Great tutorial!"));
        video1.AddComment(new Comment("User2", "Very helpful, thanks! Bockarie Junior Manasaray"));
        video1.AddComment(new Comment("User3", "I learned a lot, thanks MR.Mansaray."));

        // Add comments to video2
        video2.AddComment(new Comment("Dev4", "Short and sweet!"));
        video2.AddComment(new Comment("Dev5", "Perfect for beginners."));
        video2.AddComment(new Comment("Dev6", "Could use more examples."));

        // Add comments to video3
        video3.AddComment(new Comment("Coder7", "Awesome tips!"));
        video3.AddComment(new Comment("Coder8", "Didn't know this trick."));
        video3.AddComment(new Comment("Coder9", "Saved me hours of work."));

        // Store videos in a list
        var videos = new List<Video> { video1, video2, video3 };

        // Display video details
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}