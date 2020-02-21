using UnityEngine;
using System.Collections;

// refactured https://www.youtube.com/watch?v=mC9BfAqwU2Q

public abstract class Command
{
    public GameObject mplayer;
    public float mforce;
    public float timestamp;
    public float horizontal, vertical;
    public abstract void Execute();
}

class Movement : Command
{
    //get rigidobdy from player and force
    public Movement(GameObject player, float force)
    {
        timestamp = Time.timeSinceLevelLoad;
        mplayer = player;
        mforce = force;
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
    }

    //add force to player
    public override void Execute()
    {
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        mplayer.transform.Translate(direction.normalized * Time.deltaTime * mforce);
    }
}