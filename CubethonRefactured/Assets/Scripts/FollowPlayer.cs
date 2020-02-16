using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    private GameObject player;
    private Vector3 offset = new Vector3(0, 1, -5);
    private Vector3 camRotation = new Vector3(0,0,0);

    void Start () 
    {
        //find player
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        //follow player slightly behind with no rotation
        transform.position = player.transform.position + offset;
        transform.rotation=Quaternion.Euler(camRotation);
    }
}
