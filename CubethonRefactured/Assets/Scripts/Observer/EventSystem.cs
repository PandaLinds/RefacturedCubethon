﻿using UnityEngine;

//reference from https://www.youtube.com/watch?v=Yy7Dt2usGy0

// this is a change 

public class EventSystem : MonoBehaviour
{
    
    
    private void Start()
    {
        //In player collision, there will be 2 broadcasters registered here
        PlayerCollision.OnPlayerCollision += Pts;
        PlayerCollision.OnPlayerCollisionPlayer += ColorChange;
    }

    private void OnDestroy()
    {
        //broadcasters unregistered
        PlayerCollision.OnPlayerCollision -= Pts;
        PlayerCollision.OnPlayerCollisionPlayer -= ColorChange;
    }

    private void Pts(GameObject Obstical)
    {
        Client client = FindObjectOfType<Client>();
        //depending on the tag of the game object, different points will be rewarded then delete the object
        if (Obstical.tag == "Normal")
        {
            Score.scoreNumber++;
            Destroy(Obstical, 0.75f);
        }
        else if (Obstical.tag == "Extra Points")
        {
            if(client.currentState.ToString() == "DivingPlayerState")
            {
                Score.scoreNumber+=50;
            }
            else
            {
                Score.scoreNumber+=5;
            }
            Destroy(Obstical, 0.75f);
        }
        else if (Obstical.tag == "Obstacle")
        {
            if(client.currentState.ToString() == "DuckingPlayerState")
            {
                Score.scoreNumber+=10;
            }
            else
            {
                Score.scoreNumber--;
            }
            Destroy(Obstical, 0.75f);
        }
    }

    public Material OrigPlayerMat;
    public Material NewPlayerMat;
    private void ColorChange(GameObject Player)
    {
        //change the color between 2 materials when this is called
        if (Player.GetComponent<MeshRenderer>().material.color == OrigPlayerMat.color)
        {
            Player.GetComponent<MeshRenderer>().material = NewPlayerMat;
        }        
        else if(Player.GetComponent<MeshRenderer>().material.color == NewPlayerMat.color)
        {
            Player.GetComponent<MeshRenderer>().material = OrigPlayerMat;
        }
    }
}
