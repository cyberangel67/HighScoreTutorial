using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{

    public TMP_InputField score;

    //***********************************************************************************************************
    //
    //***********************************************************************************************************
    private void Start()
    {
        score.ActivateInputField();
    }

    //***********************************************************************************************************
    //
    //***********************************************************************************************************
    public void AddScore()
    {
        ScoreManager.Instance.AddScore( int.Parse(score.text));
    }

    //***********************************************************************************************************
    //
    //***********************************************************************************************************
    public void RandomScore()
    {
        int MaxScore = 999999;

        score.text = Random.Range(0, MaxScore).ToString();
    }
}
