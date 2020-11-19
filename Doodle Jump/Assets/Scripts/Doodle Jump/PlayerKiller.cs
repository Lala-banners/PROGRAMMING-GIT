using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject gameOver;
    public Player player;

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    private void OnTriggerEnter2D(Collider2D collision) //When player collides with the player killer collider
    {
        Destroy(playerObject.gameObject); //Destroy player on collision 
        gameOver.SetActive(true); //Make game over appear
        Time.timeScale = 0; //Stop time
        player.topScore = player.finalScore; //Supposed to make the score equal to final score
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
