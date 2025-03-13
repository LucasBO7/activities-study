using System;

public interface IUnit
{
    IUnitState State { get; set; }
    bool CanMove { get; }
    int Damage { get; }
}

public interface IUnitState
{
    bool CanMove { get; }
    int Damage { get; }
}

public class SiegeState : IUnitState
{
    public SiegeState()
    {
    }

    public bool CanMove => false;
    public int Damage => 20;
}

public class TankState : IUnitState
{
    public TankState()
    {
    }

    public bool CanMove => true;
    public int Damage => 5;
}

public class Tank : IUnit
{
    public IUnitState State { get; set; }
    public bool CanMove => State.CanMove;
    public int Damage => State.Damage;
    
    public Tank()
    {
      State = new TankState();
    }
}

