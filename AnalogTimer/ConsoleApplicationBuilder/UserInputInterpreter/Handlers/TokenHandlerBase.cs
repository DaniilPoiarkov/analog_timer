namespace ConsoleApplicationBuilder.UserInputInterpreter.Handlers;

internal class TokenHandlerBase
{
    private TokenHandlerBase? _next;

    internal void Add(TokenHandlerBase next)
    {
        if (_next is null)
        {
            _next = next;
        }
        else
        {
            _next.Add(next);
        }
    }

    internal virtual InputToken? Handle(string token, int index, List<string> splitted) =>
        _next?.Handle(token, index, splitted);

    protected static bool StartWithSpecialSymbol(string token)
    {
        return token.StartsWith('-') || token.StartsWith('\'') || token.StartsWith('\"');
    }
}
