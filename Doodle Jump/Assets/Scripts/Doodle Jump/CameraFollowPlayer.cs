using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Player player;

    private Vector3 offset; //Offset distance between player and camera

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called every frame, if the Behaviour is enabled
    private void LateUpdate()
    {
        if (player != null) //if player exists
        {
            //Set position of camera to the same as the player but with offset
            transform.position = player.transform.position + offset;
        }
        else 
        {
            player = null;
        }
    }
}
