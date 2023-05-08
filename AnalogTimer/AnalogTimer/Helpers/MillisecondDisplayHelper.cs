﻿using AnalogTimer.DigitDrawers;
using AnalogTimer.DisplayHandlers;
using NLog;
using System.ComponentModel;

namespace AnalogTimer.Helpers;

public static class MillisecondDisplayHelper
{
    private static BackgroundWorker _worker = new();

    private static CancellationTokenSource? _cts;

    private static TaskCompletionSource? _tcs;

    private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

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

    private static async Task Display(CancellationToken cancellationToken)
    {
        var handler = new MatrixDisplayHandler();
        int snapshot = 0;

        var mutex = new Mutex();

        while (!cancellationToken.IsCancellationRequested)
        {
            for (int i = 0; i < 10; i++)
            {
                var digit = i switch
                {
                    < 3 => 0,
                    < 7 => 3,
                    _ => 7
                };

                if (digit == snapshot)
                    continue;

                await Task.Delay(10, cancellationToken);
                var drawer = DigitDrawerProvider.GetDrawer(digit);
                mutex.WaitOne();
                handler.DisplayPattern(drawer.Pattern, 91);
                mutex.ReleaseMutex();
                snapshot = digit;

                UIHelper.SetCursor();
            }
        }
    }
}