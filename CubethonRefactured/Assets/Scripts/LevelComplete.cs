using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public void replay()
    {
        //restart the scene and run replay
        FindObjectOfType<GameManager>().Restart();
    }

    public void LoadNextLevel()
    {
        //clear commands and load next scene
        CommandLog.commands.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
