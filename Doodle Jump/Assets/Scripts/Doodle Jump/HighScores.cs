
[System.Serializable]
//This script will contain the high score data
public class HighScores 
{
    public string name;
    public string scorePosition;
    public string rank;
    public float highScore;

    public void SetData(Player player)
    {
        name = player.doodlerName;
        scorePosition = player.scorePosition;
        rank = player.rank;
        highScore = player.score;
    }

    public void GetData(Player player)
    {
        player.doodlerName = name;
        player.scorePosition = scorePosition;
        player.rank = rank;
        player.currentHighScore = highScore;
    }
}
