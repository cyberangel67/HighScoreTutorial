using UnityEngine;
using System;

using TMPro;

public class GameDataManager : Singleton<GameDataManager>
{
    [NonSerialized] public TMP_Text TestUI;

    private GameData _gameData;
    public GameData gameData {
        get {
            if (_gameData == null)
                _gameData = new GameData();

            return _gameData;
        }
    }

    //***********************************************************************************************************
    //
    //***********************************************************************************************************
    public void LoadGameData()
    {
        if (PlayerPrefs.HasKey("HighScore1Score"))
        {
            int i = 1;
            foreach (Score score in gameData.HighScores)
            {
                score.score = PlayerPrefs.GetInt("HighScore" + i + "Score");
                score.name = PlayerPrefs.GetString("HighScore" + i + "Name");
                i++;
            }
        }
    }

    //***********************************************************************************************************
    //
    //***********************************************************************************************************
    public void SaveGameData()
    {
        int i = 1;

        foreach (Score score in gameData.HighScores)
        {
            PlayerPrefs.SetString("HighScore" + i + "Name", score.name);
            PlayerPrefs.SetInt("HighScore" + i + "Score", score.score);
            i++;
        }
        PlayerPrefs.Save();
    }

    //***********************************************************************************************************
    //
    //***********************************************************************************************************
    private void OnEnable()
    {
        LoadGameData();
    }

    //***********************************************************************************************************
    //
    //***********************************************************************************************************
    private void OnApplicationQuit()
    {
        SaveGameData();
    }
}


