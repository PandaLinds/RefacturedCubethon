﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingPlayerState : iStates
{
    public void Enter(Client player)
    {
        player.currentState = this;
        
    }

    public void Execute(Client player)
    {
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
        if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S))
        {
            MovingPlayerState movingState = new MovingPlayerState();
            movingState.Enter(player);
        }
    }
}

public class MovingPlayerState : iStates
{
    public float mforce = 10;
    public void Enter(Client player)
    {
        player.currentState = this;
        
    }

    public void Execute(Client player)
    {
        if (!Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.D)&&!Input.GetKey(KeyCode.W)&&!Input.GetKey(KeyCode.S))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }
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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        player.transform.Translate(direction.normalized * Time.deltaTime * mforce, Space.World);
        
    }
}

public class DuckingPlayerState : iStates
{
    public float mforce = 10;
    public void Enter(Client player)
    {
        player.currentState = this;
        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.transform.localScale *= 0.5f;
    }

    public void Execute(Client player)
    {
        if (!Input.GetMouseButton(0))
        {
            Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
            rbPlayer.transform.localScale *= 2f;
            StandingPlayerState StandingState = new StandingPlayerState();
            StandingState.Enter(player);
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        player.transform.Translate(direction.normalized * Time.deltaTime * mforce, Space.World);
    }
}

public class JumpingPlayerState : iStates
{
    public float mforce = 10;
    public void Enter(Client player)
    {
        player.currentState = this;
        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.AddForce(0,400*Time.deltaTime,0,ForceMode.VelocityChange);
    }

    public void Execute(Client player)
    {
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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        player.transform.Translate(direction.normalized * Time.deltaTime * mforce, Space.World);
    }
}

public class DivingPlayerState : iStates
{
    public float mforce = 10;
    public void Enter(Client player)
    {
        player.currentState = this;
        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.AddForce(0,-2000*Time.deltaTime,0,ForceMode.VelocityChange);
    }

    public void Execute(Client player)
    {
        if(Physics.Raycast(player.transform.position, Vector3.down, 0.55f))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        player.transform.Translate(direction.normalized * Time.deltaTime * mforce, Space.World);
    }
}
