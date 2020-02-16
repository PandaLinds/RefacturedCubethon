using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class StandingState : State<Client>
{
    private static StandingState _instance;

    private StandingState()
    {
        if(_instance == null)
        {
            return;
        }

        _instance = this;
    }

    public static StandingState Instance
    {
        get
        {
            if(_instance == null)
            {
                new StandingState();
            }
            return _instance;
        }
    }

    public override void EnterState(Client _owner)
    {
        Debug.Log("Entering Standing State");
    }

    public override void ExitState(Client _owner)
    {
        Debug.Log("Exiting Standing State");
    }

    public override void UpdateState(Client _owner)
    {
        Debug.Log("Updating Standing State");
    }
}

public class DuckingState : State<Client>
{
    public override void EnterState(Client _owner)
    {
    }

    public override void ExitState(Client _owner)
    {
    }

    public override void UpdateState(Client _owner)
    {
    }
}