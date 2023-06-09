namespace ConsoleApplicationBuilder.Contracts;

public interface IShortcutFlag<TEntity>
{
    string Shortcut { get; }

    Task Handle(string value, TEntity entity);
}
