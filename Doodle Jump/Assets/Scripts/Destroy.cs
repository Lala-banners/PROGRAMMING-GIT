using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    public GameObject player;
    public GameObject planetPrefab;
    private GameObject myPlatform;

    //public Sprite planets = new GameObject();

    //List<GameObject> gameObjects = new List<GameObject>() { }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    private void OnTriggerEnter2D(Collider2D collision) //When player collides with this collider
    {
        //Instantiate platforms where the player jumps to then destory the platforms
        myPlatform = (GameObject)Instantiate(planetPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (4 + Random.Range(0.5f, 1f))), Quaternion.identity);
        Destroy(collision.gameObject); //Destroy platforms as player jumps on new ones
    }



}
