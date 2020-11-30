using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody2D rb2D;
    private float move;

    #region Score Data
    public float currentScore = 0f; //The score that changes when player jumps higher
    public string scorePos; //location of the score
    public string rank; //What rank player acheived 
    public string doodlerName; //Name of player
    public TMP_Text scoreText; //Text that will update with score (how far the player travels up)
    public TMP_Text highScoreText; //High score when either player wins the level or dies
    #endregion

   /* #region Player Singleton
    public static Player instance;

    private void Awake()
    {
        if(instance != null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is more than one instance of Player");
        }
    }
    #endregion*/

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(move * speed, rb2D.velocity.y);

        SetScore();
    }

    //Set score to the players y position
    public void SetScore()
    {
        //If player current position is greater than top score (0)
        if (rb2D.velocity.y > 0 && transform.position.y > currentScore)
        {
            //make top score equal to the player position
            currentScore = transform.position.y;
        }
        //Update score text to be top score
        scoreText.text = "Score: " + Mathf.Round(currentScore).ToString();
    }

    public void HighScore()
    {
        highScoreText.text = "High Score: " + Mathf.Round(currentScore).ToString();
    }
}
