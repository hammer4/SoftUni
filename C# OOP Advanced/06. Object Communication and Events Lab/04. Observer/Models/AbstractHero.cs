using System;
public abstract class AbstractHero : IAttacker, IObserver
{
    private const string TARGET_NULL_MESSAGE = "Target is null.";
    private const string NO_TARGET_MESSAGE = "{0} has no target.";
    private const string TARGET_DEAD_MESSAGE = "{0} is dead.";
    private const string SET_TARGET_MESSAGE = "{0} targets {1}.";

    private string id;
    private int damage;
    private ITarget target;
    private IHandler logger;

    public AbstractHero(string id, int damage, IHandler logger)
    {
        this.id = id;
        this.damage = damage;
        this.logger = logger;
    }

    public void Attack()
    {
        if(this.target == null)
        {
            Console.WriteLine(NO_TARGET_MESSAGE, this);
        }
        else if(this.target.IsDead)
        {
            Console.WriteLine(TARGET_DEAD_MESSAGE, this.target);
        }
        else
        {
            this.ExecuteClassSpecificAttack(this.target, this.damage);
        }
    }

    public void SetTarget(ITarget target)
    {
        if(target == null)
        {
            Console.WriteLine(TARGET_NULL_MESSAGE);
        }
        else
        {
            this.target = target;

            Console.WriteLine(SET_TARGET_MESSAGE, this, target);
        }
    }

    protected abstract void ExecuteClassSpecificAttack(ITarget target, int damage);

    public override string ToString()
    {
        return this.id;
    }

    public void Update(int val)
    {
        throw new NotImplementedException();
    }
}
