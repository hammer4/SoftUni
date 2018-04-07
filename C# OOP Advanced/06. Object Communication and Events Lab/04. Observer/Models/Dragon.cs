using System;
using System.Collections.Generic;

public class Dragon : ITarget, ISubject
{
    private const string THIS_DIED_EVENT = "{0} dies";

    private string id;
    private int hp;
    private int reward;
    private bool eventTriggered;
    private List<IObserver> observers;

    public Dragon(string id, int hp, int reward)
    {
        this.id = id;
        this.hp = hp;
        this.reward = reward;
        this.observers = new List<IObserver>();
    }

    public bool IsDead { get => this.hp <= 0; }

    public void NotifyObservers()
    {
        foreach (IObserver observer in observers)
        {
            observer.Update(this.reward);
        }
    }

    public void ReceiveDamage(int damage)
    {
        if (!this.IsDead)
        {
            this.hp -= damage;
        }

        if(this.IsDead && !eventTriggered)
        {
            Console.WriteLine(THIS_DIED_EVENT, this);
            this.eventTriggered = true;
        }
    }

    public void Register(IObserver observer)
    {
        this.observers.Add(observer);
    }

    public override string ToString()
    {
        return this.id;
    }

    public void Unregister(IObserver observer)
    {
        this.observers.Remove(observer);
    }
}
