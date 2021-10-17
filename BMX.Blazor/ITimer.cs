﻿using System;

namespace BMX.Blazor
{
    public interface ITimer : IDisposable
    {
        double Interval { get; set; }
        long TimeSinceLastTick { get; }

        event EventHandler Elapsed;

        void Start();
        void Stop();
    }
}
