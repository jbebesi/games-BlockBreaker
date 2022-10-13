
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    [SerializeField]
    private GameObject mBlockPrefab;
    [SerializeField]
    private Transform mStart;
    [SerializeField]
    private float mXDelta;
    [SerializeField]
    private float mStartDist;
    [SerializeField]
    private float mEndLength;
    [SerializeField]
    private GameObject mBallPrefab;
    private int mCount = 5;
    private float mTimeElapsed = 0;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int mMax = (int)Time.time;
        if (mTimeElapsed + 5 < mMax && false)
        {
            Debug.Log("Create:" + mCount.ToString());
            mTimeElapsed = mMax;
            for (int i = 0; i < mCount; i++)
            {
                float newX = mStart.position.x + i * mXDelta + mStartDist;
                while (newX > mEndLength)
                    newX -= mEndLength;

                Vector2 pos = new Vector2(newX, mStart.position.y);
                GameObject block = Instantiate(mBlockPrefab, pos, Quaternion.identity);
                block.transform.parent = gameObject.transform;
            }
            mCount++;
        }
    }

    public void CreateBall()
    {
        GameObject ball = Instantiate(mBallPrefab, gameObject.transform);
        ball.transform.parent = gameObject.transform;
        ball.GetComponent<Ball>().mPedal1 = gameObject;
        ball.gameObject.transform.localScale = new Vector3(36, 36, 36);

    }
}