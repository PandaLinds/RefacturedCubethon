using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter()
    {
        // Stop player from moving so player can choose option
        // run complete level function
        // FindObjectOfType<Client>().movementForce = 0f;
        gameManager.CompleteLevel();
    }
}
