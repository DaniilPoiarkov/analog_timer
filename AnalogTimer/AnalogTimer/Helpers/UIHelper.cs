using System.Text;

namespace AnalogTimer.Helpers;

public static class UIHelper
{
    private static readonly Stack<char> _chars = new();

    public static int CursorPosition => _chars.Count;

    public static void Add(char c) => _chars.Push(c);

    public static string GetInput()
    {
        var sb = new StringBuilder();

        foreach (char c in Enumerable.Reverse(_chars))
        {
            sb.Append(c);
        }

        _chars.Clear();

        return sb.ToString()
            .TrimEnd()
            .TrimStart()
            .Trim();
    }

    public static void RemoveLast()
    {
        if(_chars.Any())
            _chars.Pop();
    }
}
