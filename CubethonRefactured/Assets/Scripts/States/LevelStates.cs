using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingState : iLevelStates
{
    GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
    public void Enter(Client player)
    {
        player.currentLevelState = this;
        gameManager.endPoint.SetActive(false);
    }

    public void Execute(Client player)
    {
        GameObject[] NormPoints = GameObject.FindGameObjectsWithTag("Normal");
        if (NormPoints.Length == 0)
        {
            CompleteState completeState = new CompleteState();
            completeState.Enter(player);
        }
    }
}

public class CompleteState : iLevelStates
{
    GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
    public void Enter(Client player)
    {
        player.currentLevelState = this;
        gameManager.endPoint.SetActive(true);
    }

    public void Execute(Client player)
    {
        GameObject[] NormPoints = GameObject.FindGameObjectsWithTag("Normal");
        var endPointPlaced = GameObject.FindObjectOfType<GameManager>();
        if (NormPoints.Length > 0)
        {
            PlayingState playingState = new PlayingState();
            playingState.Enter(player);
        }
    }
}