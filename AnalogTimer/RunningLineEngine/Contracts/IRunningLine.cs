namespace RunningLineEngine.Contracts;

public interface IRunningLine : IRunningLineSpeed, IRunningLineEvents, IRunningLineAsyncRunnable
{
    void Set(int sentenceLength);

    void Clean();
}
