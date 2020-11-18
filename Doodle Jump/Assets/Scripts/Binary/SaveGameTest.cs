﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameTest : MonoBehaviour
{
    public Game game = new Game();

    public List<Game> savedGames;

    private void Update()
    {
        savedGames = SaveLoad.savedGames;
    }

    private void Start()
    {
        Game.current = game;
    }

    private void OnGUI()
    {
        if(GUILayout.Button ("Save"))
        {
            SaveLoad.Save(Game.current);
        }

        if (GUILayout.Button("Load"))
        {
            SaveLoad.Load();
        }
    }
}
