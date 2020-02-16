using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    public static event Action<GameObject> OnPlayerCollision;
    public static event Action<GameObject> OnPlayerCollisionPlayer;
    void OnCollisionEnter(Collision collisionInfo)
    {
        //for points
        if (OnPlayerCollision != null)
        {
            OnPlayerCollision(collisionInfo.gameObject);
        }

        //for color change
        if (OnPlayerCollisionPlayer != null)
        {
            OnPlayerCollisionPlayer(gameObject);
        }
    }


}
