using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //get or set veriables needed for method
    bool gameHasEnded = false;
    public GameObject endPoint;
    public GameObject player;
    public float restartDelay = 4f;
    public GameObject completeLevelUI;
    public bool instantReplay = false;
    public bool endPlaced = false;
    float replayStartTime;

    void Start()
    {
        //set player variable
        Client playerMovement = FindObjectOfType<Client>();
        player = playerMovement.gameObject;

        //reset score 
        Score.scoreNumber = 0;

        //only have instant replay if there are commands in queue
        if (CommandLog.commands.Count > 0)
        {
            //set instant replay on and give start time
            instantReplay = true;
            replayStartTime = Time.timeSinceLevelLoad;
        }
    }

    private void Update()
    {
        //run instant replay if flag is set
        if (instantReplay)
        {
            InstantReplay();
        }
    }

    public void CompleteLevel()
    {
        //pull level complete panel when trigger hit
        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        //check if player has lost
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }

    public void Restart()
    {
        //reload current screen and reset score
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Score.scoreNumber = 0;
    }

    //doesn't work too well
    void InstantReplay()
    {
        // Stop running replay if queue is empty
        if (CommandLog.commands.Count == 0)
        {
            CommandLog.commands.Clear();
            instantReplay = false;
            return;
        }

        //load command and execute only if timing is similar
        Command command = CommandLog.commands.Peek();
        if (Time.timeSinceLevelLoad >= command.timestamp + replayStartTime)
        {
            command = CommandLog.commands.Dequeue();
            Debug.Log(CommandLog.commands.Count);
            command.mplayer = player;
            Invoker invoker = new Invoker();
            invoker.disableLog = true;
            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }

    }
}
