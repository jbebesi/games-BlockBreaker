using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    [SerializeField]
    public GameObject mPedal1;
    bool started = false;
    [SerializeField]
    private Vector2 mStartSpeed;
    [SerializeField]
    private AudioClip[] mBallSounds;
    [SerializeField]
    private Vector2 mAddVelocity;
    [SerializeField]
    private Vector2 mMinVelocity;
    [SerializeField]
    private Vector2 mMaxVelocity;


    private Level mLevel;
    private Rigidbody2D mRigidbody;

    // Use this for initialization
    void Start () {
        mLevel = FindObjectOfType<Level>();
        mLevel.AddBall();
        mRigidbody = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        if(!started)
            MoveBallWithPedal();
        if (Input.GetMouseButtonUp(0) && !started)
        {
            StartBall();
        }
    }

    private void StartBall()
    {
        mRigidbody.constraints = RigidbodyConstraints2D.None;
        mRigidbody.velocity = mStartSpeed;
        started = true;
    }

    void MoveBallWithPedal()
    {
        gameObject.transform.position = new Vector2(mPedal1.transform.position.x, mPedal1.transform.position.y+1.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0,mAddVelocity.x), Random.Range(0, mAddVelocity.y));
        if (started)
        {
            AudioSource audio = GetComponent<AudioSource>();
            AudioClip clip = mBallSounds[Random.Range(0, mBallSounds.Length)];
            audio.PlayOneShot(clip);
            mRigidbody.velocity += velocityTweak;
        }
    }


    private void OnDestroy()
    {
        mLevel.RemoveBall();
    }


}
