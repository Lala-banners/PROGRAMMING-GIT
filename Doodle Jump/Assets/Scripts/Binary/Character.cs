
// This makes this class be able to be stored in any sort of serialization system
// such as Unity Inspector, Binary or JSON (text format that is completely language independent 
// but uses conventions that are familiar to programmers of the C-family of languages, 
// including C, C++, C#, Java, JavaScript etc)
[System.Serializable] 
public class Character 
{
    public string name;
    public int health;
    public int mana;
    public int level;
    public float experience;

    public Character() //Reference to variables
    {
        this.name = "";
        this.health = 0;
        this.mana = 0;
        this.level = 0;
        this.experience = 0;
    }

    //Takes in values
    public Character(string _name, int _baseHealth, int _mana, int _level, float _experience)
    {
        this.name = _name;
        this.health = _baseHealth;
        this.mana = _mana;
        this.level = _level;
        this.experience = _experience;
    }
}
