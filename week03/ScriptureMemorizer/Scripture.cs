using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _rand = new Random();

    private bool RegexHasAlphaNum(string text)
    {
        return Regex.IsMatch(text, @"[A-Za-z0-9]");
    }
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ')
                    .Select(t => new Word(t))
                    .ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        var visibleIndices = _words
            .Select((w, i) => new { w, i })
            .Where(x => !x.w.IsHidden() && RegexHasAlphaNum(x.w.GetDisplayText()) ) 
            .Select(x => x.i)
            .ToList();

        if (visibleIndices.Count == 0) return;

        for (int i = visibleIndices.Count - 1; i > 0; i--)
        {
            int j = _rand.Next(i + 1);
            int tmp = visibleIndices[i];
            visibleIndices[i] = visibleIndices[j];
            visibleIndices[j] = tmp;
        }

        int toHide = Math.Min(numberToHide, visibleIndices.Count);
        for (int k = 0; k < toHide; k++)
        {
            _words[visibleIndices[k]].Hide();
        }
    }

    public string GetDisplayText()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < _words.Count; i++)
        {
            if (i > 0) sb.Append(' ');
            sb.Append(_words[i].GetDisplayText());
        }
        sb.AppendLine();
        sb.Append($"-- {_reference.GetDisplayText()}");
        return sb.ToString();
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden() || !w.ContainsAlphaNumeric());
    }
}