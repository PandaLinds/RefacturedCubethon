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

    void OnGUI()
    {
        GUI.color = Color.black;
        GUI.Label(new Rect(10, 10, 500, 20), "Jump - Space");
        GUI.Label(new Rect(10, 30, 500, 20), "Duck - Right Mouse Click");
        GUI.Label(new Rect(10, 50, 500, 20), "Dive - [Jump and] Left Mouse Click");
    }
}
