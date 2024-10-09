using System;

class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length, List<Comment> comments)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = comments;
    }

    public List<Comment> Comments
    {
        get { return _comments; }
    }

    public string GetDisplayText() {
        return $"{_title} by {_author} ({_length} seconds)";
    }
}
