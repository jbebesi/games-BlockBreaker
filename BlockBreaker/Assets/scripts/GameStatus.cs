using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStatus : MonoBehaviour {

    [SerializeField][Range(0.1f,10f)]
    private float mGameSpeed =1f;
    [SerializeField]
    private int mScore = 0;
    [SerializeField]
    private bool mIsAutoPlayEnabled = false;

    [SerializeField]
    TextMeshProUGUI mScoreText;
    [SerializeField]
    private string mScoreString = "Score=";

    internal bool IsAutoPlayEnabled { get { return false; } }

    //Cached GameObject
    private Game mGame;

    private void Awake()
    {
        if(FindObjectsOfType<GameStatus>().Length > 1)
        {
            // disable the gameobject, so it will not be available for other instances.
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        mGame = FindObjectOfType<Game>();
        SetScoreText();
    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = mGameSpeed;
	}

    public void AddScore(int mPoints)
    {
        mScore += mPoints;
        if (mScore + 1 % 10 == 0)
        {
            mGame.CreateBall();
        }
        SetScoreText();
    }
    private void SetScoreText()
    {
        if (mScoreText != null)
            mScoreText.text = mScoreString + mScore.ToString();
    }

    public void LoseGame()
    {
        mScore = 0;
    }



}
