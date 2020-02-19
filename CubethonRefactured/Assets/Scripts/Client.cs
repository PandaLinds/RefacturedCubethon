using UnityEngine;


public class Client : MonoBehaviour
{
    public iStates currentState;
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
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S))
        {
            Command Movement = new Movement(gameObject, movementForce);
            invoker.SetCommand(Movement);
            invoker.ExecuteCommand();
        }

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
        GUI.Label(new Rect(10, 30, 500, 20), "Press A to move left");
        GUI.Label(new Rect(10, 50, 500, 20), "Press D to move Right");
    }
}
