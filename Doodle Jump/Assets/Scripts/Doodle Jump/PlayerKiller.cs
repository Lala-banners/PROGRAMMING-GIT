using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    public static PlayerKiller instance = null; //Singleton because there is only one player killer

    public GameObject playerObject;
    public GameObject gameOver;

    private float offset;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        offset = playerObject.transform.position.y - transform.position.y;
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    private void OnTriggerEnter2D(Collider2D collision) //When player collides with the player killer collider
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            gameOver.SetActive(true); //Make game over appear
            Time.timeScale = 0; //Stop time
            player.HighScore();

            Destroy(playerObject.gameObject); //Destroy player on collision 
        }
    }

    public void Move()
    {
        Vector3 playerpos = playerObject.transform.position;

        transform.position = new Vector3(playerpos.x, playerpos.y - offset, playerpos.z);
    }
}
