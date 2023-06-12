using NLog;
using System.ComponentModel;

namespace AnalogTimer.Helpers;

public static class MillisecondDisplayHelper
{
    private static BackgroundWorker _worker = new();

    private static CancellationTokenSource? _cts;

    private static TaskCompletionSource? _tcs;

    private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    public static event EventHandler<int>? OutputHandler;

    public static Task BackgroundDisplay()
    {
        _tcs = new TaskCompletionSource();
        _worker = new BackgroundWorker();
        _cts = new CancellationTokenSource();

        _worker.DoWork += (o, args) =>
        {
            try
            {
                args.Result = Display(_cts.Token);
            }
            catch (AggregateException ae)
            {
                ae.Handle(ex =>
                {
                    _logger.Error(ex);
                    return true;
                });
            }
        };

        _worker.RunWorkerCompleted += (o, args) =>
        {
            if (_cts.Token.IsCancellationRequested)
            {
                _tcs.SetCanceled();
            }

            if (args.Error is not null)
            {
                _tcs.SetException(args.Error);
            }
            else
            {
                if(!_tcs.Task.IsCompleted)
                    _tcs.SetResult();
            }
        };

        _worker.RunWorkerAsync();
        return _tcs.Task;
    }

    public static void StopDisplay()
    {
        _cts?.Cancel();
    }

    public static void DisplayZero()
    {
        OutputHandler?.Invoke(null, 0);
    }

    private static async Task Display(CancellationToken cancellationToken)
    {
        int snapshot = 0;

        while (!cancellationToken.IsCancellationRequested)
        {
            for (int i = 0; i < 10; i++)
            {
                var digit = i switch
                {
                    < 3 => 0,
                    < 5 => 3,
                    < 7 => 5,
                    _ => 7
                };

                if (digit == snapshot)
                    continue;

                await Task.Delay(10, cancellationToken);
                
                OutputHandler?.Invoke(null, i);

                snapshot = digit;
            }
        }
    }
}
