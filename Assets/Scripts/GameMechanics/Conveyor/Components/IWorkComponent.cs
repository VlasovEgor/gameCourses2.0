
using System;

public interface IWorkComponent
{
    event Action OnStartWork;
    event Action OnFinishWork;
    event Action<float> OnProgress;
    bool IsWorking { get; }

    float Progress { get; }
}
