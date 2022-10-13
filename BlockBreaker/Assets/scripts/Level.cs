using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {

    public List<GameObject> mBlocks = new List<GameObject>();
    private int mBallCount;
    private SceneLoader mLoader;

	// Use this for initialization
	void Start () {
        mLoader = FindObjectOfType<SceneLoader>();
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void AddBlock(GameObject nBlock)
    {
        mBlocks.Add(nBlock);
        Debug.Log("Blocks=" + mBlocks.Count);
    }

    public void RemoveBlock(GameObject nBlock)
    {
        mBlocks.Remove(nBlock);
        Debug.Log("Remaining Blocks=" + mBlocks.Count);
        
        if(mBlocks.Count < 1 && mBallCount > 0)
        {
            mLoader.LoadNextScene();
        }
        
    }

    public void AddBall()
    {
        mBallCount++;
    }

    public void RemoveBall()
    {
        mBallCount--;
        if(mBallCount < 1 && mBlocks.Count > 0)
        {
            FindObjectOfType<GameStatus>().LoseGame();
            mLoader.LoadSceneByName(SceneLoader.scenes.LoseGame);
        }
    }
}

