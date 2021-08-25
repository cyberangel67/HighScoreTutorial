using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public GameObject HighScorePrefab;
    public GameObject HighscoreTable;

    //***********************************************************************************************************
    //
    //***********************************************************************************************************
    private void Start()
    {
        DisplayScores();
    }

    //***********************************************************************************************************
    //
    //***********************************************************************************************************
    public void AddScore(int currentScore)
    {
        int children = HighscoreTable.transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            GameObject go = HighscoreTable.transform.GetChild(i).gameObject;
            Destroy(go);
        }

        List<Score> Highscores = GetHighscoreData();

        int index = 0;
        foreach (Score score in Highscores)
        {

            if (currentScore >= score.score)
            {
                for (int kk = Highscores.Count - 1; kk > index; kk--)
                {
                    Highscores[kk].score = Highscores[kk - 1].score;
                }
                score.score = currentScore;
                break;
            }
            index++;
        }

        DisplayScores();
    }

    //***********************************************************************************************************
    //
    //***********************************************************************************************************
    private static List<Score> GetHighscoreData()
    {
        return GameDataManager.Instance.gameData.HighScores;
    }

    //*******************************************************************************************************
    //	
    //*******************************************************************************************************
    private void DisplayScores()
    {
        List<Score> scores = GetHighscoreData();

        int count = 0;
        foreach (Score score in scores)
        {
            GameObject go = Instantiate(HighScorePrefab, HighscoreTable.transform);
            Transform index = go.transform.GetChild(0);
            Transform Score = go.transform.GetChild(2);

            index.GetComponent<TMP_Text>().text = count.ToString();
            Score.GetComponent<TMP_Text>().text = score.score.ToString("N0");
            count++;
        }

    }
}
