using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public iStates currentState;

    private void Start()
    {
        currentState = new StandingPlayerState();
    }

    private void Update()
    {
        currentState.Execute(this);
    }
}
