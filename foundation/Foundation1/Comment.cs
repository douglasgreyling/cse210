using System;

class Comment
{
    private string _text;
    private string _author;

    public Comment(string text, string author)
    {
        _text = text;
        _author = author;
    }

    public string GetDisplayText() {
        return $"{_text} by {_author}";
    }
}
