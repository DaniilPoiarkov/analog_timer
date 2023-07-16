using NLog;
using System.ComponentModel;

namespace AnalogTimer.Helpers;

public class MillisecondDisplayHelper
{
    private BackgroundWorker _worker = new();

    private CancellationTokenSource? _cts;

    private TaskCompletionSource? _tcs;

    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    public event EventHandler<int>? OutputHandler;

    public Task BackgroundDisplay()
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

    public void StopDisplay()
    {
        _cts?.Cancel();
    }

    public void DisplayZero()
    {
        OutputHandler?.Invoke(this, 0);
    }

    private async Task Display(CancellationToken cancellationToken)
    {
        int snapshot = 0;

        for (int i = 0; i < 10 && !cancellationToken.IsCancellationRequested; i++)
        {
            if (i == 9)
            {
                i = 0;
                continue;
            }

            var digit = i switch
            {
                < 3 => 0,
                < 5 => 3,
                < 7 => 5,
                _ => 7
            };

            if (digit == snapshot)
            {
                continue;
            }

            await Task.Delay(10, cancellationToken);

            if (cancellationToken.IsCancellationRequested)
            {
                break;
            }

            OutputHandler?.Invoke(this, digit);

            snapshot = digit;
        }
    }
}
