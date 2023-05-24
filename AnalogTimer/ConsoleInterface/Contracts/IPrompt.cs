namespace ConsoleInterface.Contracts;

public interface IPrompt<TEntity>
{
    string Name { get; }

    string Shortcut { get; }

    string Instruction { get; }

    Task Proceed(string input, TEntity entity);
}
