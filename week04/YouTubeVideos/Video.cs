using System;
using System.Transactions;

public class Video
{
    public string _title;
    public string _author;
    public int _length;
    public List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }
    public int GetCommentCount()
    {
        int count = 0;

        foreach (Comment c in _comments)
        {
            count++;
        }

        return count;
    }

    public void AddComment(Comment newComment)
    {
        _comments.Add(newComment);
    }
}