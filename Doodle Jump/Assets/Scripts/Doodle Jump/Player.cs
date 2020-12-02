using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody2D rb2D;
    private float move;
    private SpriteRenderer spriteRenderer;

    #region Score Data
    public float currentHighScore = 0f; //The current high score
    public float score = 0f; //The score that changes when player jumps higher
    public string scorePosition; //location of the score
    public string rank; //What rank player acheived 
    public string doodlerName; //Name of player
    #endregion

    /* #region Player Singleton
     * public static Player instance = null;  
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
     }#endregion*/

    // Start is called before the first frame update
    void Start()
    {
        currentHighScore = 0f;
        score = 0f;
        Time.timeScale = 1;
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); //Get access to sprite renderer of astronaut doodler
        ScoreManager.Instance.Load(this);
    }


    // Update is called once per frame
    void Update()
    {
        //To flip doodler
        if (move < 0) //If facing right then dont flip sprite
        {
            spriteRenderer.GetComponent<SpriteRenderer>().flipX = false;
        }
        else //if facing left then flip sprite
        {
            spriteRenderer.GetComponent<SpriteRenderer>().flipX = true;
        }

        move = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(move * speed, rb2D.velocity.y);
        SetScore();
    }

    //Set score to the players y position
    public void SetScore()
    {
        //If player current position is greater than current score (0)
        if (rb2D.velocity.y > 0 && transform.position.y > score)
        {
            //make current score equal to the player position
            score = transform.position.y;
        }
        ScoreManager.Instance.UpdateScore(score);
    }

    public void HighScore() //Function for setting the high score
    {
        //If current score is greater than current high score
        if (score > currentHighScore)
        {
            currentHighScore = score;
            ScoreManager.Instance.UpdateHighScore(score);
        }
        else //Make current score equal current high score
        {
            currentHighScore = score;
        }
        ScoreManager.Instance.Save(this);
    }
}
