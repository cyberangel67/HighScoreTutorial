using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public List<Score> HighScores = new List<Score>();
    public int CollectedCoins = 0;

    public GameData()
    {
        InitHighscoreData();
    }

    private void InitHighscoreData()
    {
        //Initialize Highscore data
        for (int count = 0; count < 10; count++)
        {
            Score _temp = new Score();
            _temp.name = string.Empty;
            _temp.score = 0;
            HighScores.Add(_temp);
        }
    }
}

[Serializable]
public class Score
{
    public int score = 0;
    public string name;
}
