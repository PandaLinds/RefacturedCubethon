﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingPlayerState : iStates
{
    public void Enter(Player player)
    {
        Debug.Log("Entering standing");
        player.currentState = this;
        
    }

    public void Execute(Player player)
    {
        Debug.Log("executing standing");
        if (Input.GetMouseButton(0))
        {
            DuckingPlayerState DuckingState = new DuckingPlayerState();
            DuckingState.Enter(player);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            JumpingPlayerState jumpingState = new JumpingPlayerState();
            jumpingState.Enter(player);
        }
    }
}


public class DuckingPlayerState : iStates
{
    public void Enter(Player player)
    {
        Debug.Log("Entering ducking");
        player.currentState = this;
        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.transform.localScale *= 0.5f;
    }

    public void Execute(Player player)
    {
        Debug.Log("executing ducking");
        if (!Input.GetMouseButton(0))
        {
            Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
            rbPlayer.transform.localScale *= 2f;
            StandingPlayerState StandingState = new StandingPlayerState();
            StandingState.Enter(player);
        }
    }
}

public class JumpingPlayerState : iStates
{
    public void Enter(Player player)
    {
        Debug.Log("Entering Jumping");
        player.currentState = this;
        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.AddForce(0,400*Time.deltaTime,0,ForceMode.VelocityChange);
    }

    public void Execute(Player player)
    {
        Debug.Log("executing Jumping");
        if(Physics.Raycast(player.transform.position, Vector3.down, 0.55f))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            DivingPlayerState DivingState = new DivingPlayerState();
            DivingState.Enter(player);
        }
        else if (Input.GetMouseButton(0))
        {
            DuckingPlayerState DuckingState = new DuckingPlayerState();
            DuckingState.Enter(player);
        }
    }
}

public class DivingPlayerState : iStates
{
    public void Enter(Player player)
    {
        Debug.Log("Entering Diving");
        player.currentState = this;
        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.AddForce(0,-1000*Time.deltaTime,0,ForceMode.VelocityChange);
    }

    public void Execute(Player player)
    {
        Debug.Log("executing diving");
        if(Physics.Raycast(player.transform.position, Vector3.down, 0.55f))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }
    }
}
