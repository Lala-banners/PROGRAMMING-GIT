using UnityEngine;

public class DestroyPlatforms : MonoBehaviour
{
    public GameObject player;
    public GameObject[] planetPrefabs;
    public Transform level;
    private GameObject myPlatform;

    //OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    private void OnTriggerEnter2D(Collider2D collision) //For when killer collides with planet objects
    {
        if (collision.gameObject.tag == "Platform")
        {
            int planets = Random.Range(0, planetPrefabs.Length);

            //Instantiate platforms where the player jumps to
            myPlatform = (GameObject)Instantiate(planetPrefabs[planets],
                                     new Vector2(Random.Range(-10f, 10f), player.transform.position.y + (4 + Random.Range(5f, 5f))),
                                     Quaternion.identity, level);

            Destroy(collision.gameObject); //Destroy platforms as player jumps on new one
        }
    }
}
