
[System.Serializable]
public class Game 
{
    public static Game current;
    public Character knight;
    public Character rogue;
    public Character wizard;

    public Game() //Default constructor to hold the Characters
    {
        knight = new Character();
        rogue = new Character();
        wizard = new Character();
    }

    public Game(Character _knight, Character _rogue, Character _wizard)
    {
        this.knight = _knight;
        this.rogue = _rogue;
        this.wizard = _wizard;
    }
}
