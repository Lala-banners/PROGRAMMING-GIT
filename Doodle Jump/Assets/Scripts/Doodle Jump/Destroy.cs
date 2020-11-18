using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    public GameObject player;
    public GameObject planetPrefabs; 
    private GameObject myPlatform;

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    private void OnTriggerEnter2D(Collider2D collision) //For when killer collides with planet objects
    {
        //If planet killer collides with the planet prefab object
        if (collision.gameObject)
        {
            //Instantiate platforms where the player jumps to
            myPlatform = (GameObject)Instantiate(planetPrefabs,
                                     new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (4 + Random.Range(0.5f, 1f))),
                                     Quaternion.identity);

            //Destroy(collision.gameObject); //Destroy platforms as player jumps on new one
        }
        else
        {
            Destroy(collision.gameObject); //Destroy platforms as player jumps on new one
        }
        
    }



}
