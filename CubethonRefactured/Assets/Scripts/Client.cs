using UnityEngine;


public class Client : MonoBehaviour
{
    public iStates currentState;
    public iLevelStates currentLevelState;
    //make force
    private float movementForce = 10f;

    //make variable for game manager
    GameManager gameManager;

    //make new invoker
    Invoker invoker = new Invoker();


    void Start()
    {
        //find gamemanager from scene
        gameManager = FindObjectOfType<GameManager>();
        currentState = new StandingPlayerState();
        currentLevelState = new PlayingState();
    }

    void FixedUpdate()
    {
        currentState.Execute(this);
        currentLevelState.Execute(this);

        //game over if player falls
        if (gameObject.transform.position.y < -1f)
        {
            gameManager.EndGame();
        }
    }

    //game instructions
    void OnGUI()
    {
        GUI.color = Color.black;
        GUI.Label(new Rect(10, 10, 500, 20), "RUN INTO THE BALLS!");
        GUI.Label(new Rect(10, 30, 500, 20), "Move - AWSD");
        GUI.Label(new Rect(10, 50, 500, 20), "Jump - Space");
        GUI.Label(new Rect(10, 70, 500, 20), "Duck - Right Mouse Click");
        GUI.Label(new Rect(10, 90, 500, 20), "Dive - [Jump and] Left Mouse Click");
    }
}
