using System;
using System.Collections.Generic;
using System.Text;

public interface ISubject
{
    void Register(IObserver observer);
    void Unregister(IObserver observer);
    void NotifyObservers();
}
