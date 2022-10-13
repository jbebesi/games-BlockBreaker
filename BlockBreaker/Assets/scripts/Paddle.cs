using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paddle : MonoBehaviour {

    float mCamera = 16;
    [SerializeField]
    float mMaxPos;
    [SerializeField]
    float mMinPos;
    [SerializeField]
    private GameObject mLoader;

    GameStatus mGameStatus;
    Ball mBall;

    // Use this for initialization
    void Start () {
        mGameStatus = FindObjectOfType<GameStatus>();
        mBall = FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {

        Vector2 paddlePos = new Vector2(0, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetPosX(), mMinPos, mMaxPos);
        transform.position = paddlePos;
	}


    private float GetPosX()
    {

        if (mGameStatus.IsAutoPlayEnabled)
        {
            return mBall.transform.position.x;
        }
        else
        {
            float mousepos = Input.mousePosition.x * 2.5f;
            float screenS = Screen.width;
            float x = (mousepos / screenS) * 16 + mMinPos;
            return x;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Block"))
        {
            mLoader.GetComponent<SceneLoader>().LoadSceneByName(SceneLoader.scenes.LoseGame);
        }
    }
}
