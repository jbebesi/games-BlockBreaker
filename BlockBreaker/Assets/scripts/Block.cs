using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class Block : MonoBehaviour
{
    [SerializeField]
    private GameObject mParticleEffect;
    [SerializeField]
    private int maxHits;
    private int mHits = 0;
    [SerializeField]
    private float mVelocity;
    [SerializeField]
    private GameObject mSceneLoader;
    [SerializeField]
    private AudioClip mBreakSound;
    private Level mLevel;
    [SerializeField]
    public int mPointsValue = 1;

    [SerializeField]
    Sprite[] mSprites;


    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, mVelocity);
        mLevel = FindObjectOfType<Level>();
        if (gameObject.tag != "Unbreakable Block")
            mLevel.AddBlock(gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(mBreakSound, Camera.main.transform.position);
        if (gameObject.tag == "Block")
        {
            mHits++;
            FindObjectOfType<GameStatus>().AddScore(mPointsValue);
            if (maxHits - mHits < 1)
            {
                Destroy(gameObject);
            }
            else
            {
                SpriteRenderer renderer = GetComponent<SpriteRenderer>();
                renderer.sprite = mSprites[mHits - 1];
            }
        }
        //else if(gameObject.tag == "Unbreakable Block")
        //{

        //}
    }

    private void OnDestroy()
    {
        TriggerSparklesVFX();
        mLevel.RemoveBlock(gameObject);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = GameObject.Instantiate(mParticleEffect,gameObject.transform.position, gameObject.transform.rotation);
    }

}
