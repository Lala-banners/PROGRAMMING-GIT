using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Singleton
    public static ScoreManager Instance = null;
    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance.gameObject);
        Instance = this;
    }
    #endregion

    public HighScores highScores;
    public string fileName; 
    public TMP_Text scoreText; //Text that will update with score (how far the player travels up)
    public TMP_Text highScoreText; //High score when either player wins the level or dies

    public string FullPath => Application.persistentDataPath + $"/{fileName}.gd";

    /// <summary>
    /// Save the High Scores to a file
    /// </summary>
    public void Save(Player player)
    {
        highScores.SetData(player);
        //Good practise for saving to binary/memory (IDesposable)
        BinaryFormatter formatter = new BinaryFormatter();
        //Create file and store all information of ALL saved games in that file (savedGames.gd)
        using (FileStream file = File.Create(FullPath))
        {
            formatter.Serialize(file, highScores);
            file.Close();
        }
    }

    /// <summary>
    /// Load the High Scores (if it exists)
    /// </summary>
    public void Load(Player player)
    {
        //If the file exists then open it.
        if (!File.Exists(FullPath))
            return;
        BinaryFormatter formatter = new BinaryFormatter();
        //File.Open = generic save file
        using (FileStream file = File.Open(FullPath, FileMode.Open))
        {
            //Load all the saved file
            highScores = (HighScores)formatter.Deserialize(file); //Cast back to list of high scores which is what the information coming back is.
            highScores.GetData(player);
            UpdateHighScore(highScores.highScore);
            file.Close();
        }

    }

    public void UpdateScore(float currentScore)
    {
        //Update score text to be current score
        scoreText.text = "Score: " + Mathf.Round(currentScore).ToString();
    }

    public void UpdateHighScore(float currentScore)
    {
        highScoreText.text = " " + Mathf.Round(currentScore).ToString(); //Setting HS text and making it the current score
    }
}
