using System.IO; //Memory input/output
using System.Collections.Generic; //For making List<>
using System.Runtime.Serialization.Formatters.Binary; //Serializing to Binary
using UnityEngine;

//This is simple way - there are other ways if system is complex
public static class SaveLoad 
{
    public static List<Game> savedGames = new List<Game>();

    /// <summary>
    /// This saves the game.
    /// </summary>
    /// <param name="_game">Pass in Game reference _game.</param>
    public static void Save(Game _game)
    {
        savedGames.Add(_game);
        //Good practise for saving to binary/memory (IDesposable)
        BinaryFormatter formatter = new BinaryFormatter();

        //Create file and store all information of ALL saved games in that file (savedGames.gd)
        using (FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd"))
        {
            formatter.Serialize(file, SaveLoad.savedGames);
            file.Close();
        }
    }

    /// <summary>
    /// This function is to load all the info from the save files all at once.
    /// </summary>
    public static void Load()
    {
        //If the file exists then open it.
        if(File.Exists(Application.persistentDataPath + "/savedScores.gd"))
        {
            BinaryFormatter formatter = new BinaryFormatter();

                                   //File.Open = generic save file
            using (FileStream file = File.Open(Application.persistentDataPath + "/savedScores.gd", FileMode.Open))
            {
                //Load all the saved file
                SaveLoad.savedGames = (List<Game>)formatter.Deserialize(file); //Cast back to list of high scores which is what the information coming back is.
                file.Close();
            }
        }
    }
}
