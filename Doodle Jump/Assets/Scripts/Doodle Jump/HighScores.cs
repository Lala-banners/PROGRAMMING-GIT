
[System.Serializable]
//This script will contain the high score data
public class HighScores 
{
    public string name;
    public string scorePos;
    public string rank;
    public float highScore;

    public void SetData(Player player)
    {
        name = player.doodlerName;
        scorePos = player.scorePosition;
        rank = player.rank;
        highScore = player.currentScore;
    }

    public void GetData(Player player)
    {
        player.doodlerName = name;
        //TODO : Lara : Fix dis
        player.scorePosition = scorePos;
        player.rank = rank;
        player.currentScore = highScore;
    }
}
