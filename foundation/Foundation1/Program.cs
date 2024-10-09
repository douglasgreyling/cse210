using System;

class Program
{
    static void Main(string[] args)
    {
        var videos = new List<Video> {
            new Video("Video 1", "Author 1", 60, new List<Comment> {
                new Comment("Comment 1", "Commenter 1"),
                new Comment("Comment 2", "Commenter 2"),
                new Comment("Comment 3", "Commenter 3")
            }),
            new Video("Video 2", "Author 2", 120, new List<Comment> {
                new Comment("Comment 1", "Commenter 1"),
                new Comment("Comment 2", "Commenter 2"),
                new Comment("Comment 3", "Commenter 3")
            }),
            new Video("Video 3", "Author 3", 180, new List<Comment> {
                new Comment("Comment 1", "Commenter 1"),
                new Comment("Comment 2", "Commenter 2"),
                new Comment("Comment 3", "Commenter 3")
            }),
        };

        foreach (var video in videos)
        {
            Console.WriteLine(video.GetDisplayText());

            foreach (var comment in video.Comments)
            {
                Console.WriteLine(comment.GetDisplayText());
            }
        }
    }
}
