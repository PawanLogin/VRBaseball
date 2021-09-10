using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BaseballController1 : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;
    [SerializeField]
    private VideoPlayer videoPlayer1;
    [SerializeField]
    private VideoPlayer videoPlayer2;

    public GameObject correct;
    public GameObject incorrect;

    private MeshRenderer rend1;
    private MeshRenderer rend2;

    public Transform posA;
    public Transform posB;
    public Transform posX;
    public Transform posY;
    public Transform handle;

    private Transform posADefault;
    public Transform posBDefault;
    public Transform handleDefault;
    public float percent = 0;
    public int curveResolution = 10;
    private float speedMultiplier = 5;

    private bool doOnce = true;

    private int timer = 200;

    int endPoses;
    public static int pitchTypes;
    public int pitcher = 1;

    [Range(.1f, 10)] public float tweenLength = 3;
    public AnimationCurve tweenSpeed;
    private float tweenTimer = 0;
    public static bool isTweening = false;
    public static bool hasChosenAnswer = true;
    public static bool hasThrownOne = false;
    public static bool playingVid;


    void Start()
    {
        posADefault = posA;

        rend1 = correct.GetComponent<MeshRenderer>();
        rend2 = incorrect.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (videoPlayer1.isPlaying)
        {
            playingVid = true;
        }
        else
        {
            playingVid = false;
        }

        if (ScoreHandler1.GameOver)
        {
            videoPlayer.Pause();
            videoPlayer1.Pause();
            videoPlayer2.Pause();
        }

        if (videoPlayer.frame > 1 && videoPlayer.frame <= 60) //This is the code that controls the "correct" and "incorrect" words
        {
            rend1.enabled = false;
            rend2.enabled = false;
            ScoreHandler1.strikeZoneVisible = true;
            hasChosenAnswer = false;
            //we need to know whether or not they got the answer correct, then enable the true one here   
        }
        else
        {
            ScoreHandler1.strikeZoneVisible = false;

        }

        //Future Tip:    When going to appositeHandedness of pitcher, just adjust flip the normal of the x value


        //This part chooses what type of ball to throw


        if (isTweening)
        {
            switch (pitchTypes)
            {
                case 0:
                    //4S Fastball
                    handle.localPosition = handleDefault.localPosition;
                    break;

                case 1:
                    //CurveBall
                    handle.localPosition = new Vector3(handleDefault.localPosition.x + -.4f, handleDefault.localPosition.y + .4f, handleDefault.localPosition.z - .4f);
                    break;

                case 2:
                    //Slider
                    handle.localPosition = new Vector3(handleDefault.localPosition.x + .5f, handleDefault.localPosition.y, handleDefault.localPosition.z);
                    break;

                case 3:
                    //2S Fastball
                    handle.localPosition = new Vector3(handleDefault.localPosition.x - 1.5f, handleDefault.localPosition.y, handleDefault.localPosition.z);
                    break;

                case 4:
                    //ChangeUp
                    handle.localPosition = new Vector3(handleDefault.localPosition.x + .3f, handleDefault.localPosition.y + .8f, handleDefault.localPosition.z - .2f);
                    break;
            }

            //Chooses between 31 different ending positions
            switch (endPoses)
            {
                case 0:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x, posBDefault.localPosition.y + .83f, posBDefault.localPosition.z);
                    break;

                case 1:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .8f, posBDefault.localPosition.y + .7f, posBDefault.localPosition.z);
                    break;

                case 2:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .4f, posBDefault.localPosition.y + .6f, posBDefault.localPosition.z);
                    break;

                case 3:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x, posBDefault.localPosition.y + .6f, posBDefault.localPosition.z);
                    break;

                case 4:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .27f, posBDefault.localPosition.y + .6f, posBDefault.localPosition.z);
                    break;

                case 5:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .62f, posBDefault.localPosition.y + .32f, posBDefault.localPosition.z);
                    break;

                case 6:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .4f, posBDefault.localPosition.y + .32f, posBDefault.localPosition.z);
                    break;

                case 7:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x, posBDefault.localPosition.y + .32f, posBDefault.localPosition.z);
                    break;

                case 8:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .27f, posBDefault.localPosition.y + .32f, posBDefault.localPosition.z);
                    break;

                case 9:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .55f, posBDefault.localPosition.y + .32f, posBDefault.localPosition.z);
                    break;

                case 10:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .62f, posBDefault.localPosition.y, posBDefault.localPosition.z);
                    break;

                case 11:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .4f, posBDefault.localPosition.y, posBDefault.localPosition.z);
                    break;

                case 12:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x, posBDefault.localPosition.y, posBDefault.localPosition.z);
                    break;

                case 13:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .27f, posBDefault.localPosition.y, posBDefault.localPosition.z);
                    break;

                case 14:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .55f, posBDefault.localPosition.y, posBDefault.localPosition.z);
                    break;

                case 15:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .24f, posBDefault.localPosition.y - .16f, posBDefault.localPosition.z);
                    break;

                case 16:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .7f, posBDefault.localPosition.y - .16f, posBDefault.localPosition.z);
                    break;

                case 17:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .13f, posBDefault.localPosition.y - .16f, posBDefault.localPosition.z);
                    break;

                case 18:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .62f, posBDefault.localPosition.y - .5f, posBDefault.localPosition.z);
                    break;

                case 19:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .4f, posBDefault.localPosition.y - .5f, posBDefault.localPosition.z);
                    break;

                case 20:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x, posBDefault.localPosition.y - .99f, posBDefault.localPosition.z);
                    break;

                case 21:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .62f, posBDefault.localPosition.y - .99f, posBDefault.localPosition.z);
                    break;

                case 22:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x, posBDefault.localPosition.y - .5f, posBDefault.localPosition.z);
                    break;

                case 23:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .27f, posBDefault.localPosition.y - .5f, posBDefault.localPosition.z);
                    break;

                case 24:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .55f, posBDefault.localPosition.y - .5f, posBDefault.localPosition.z);
                    break;

                case 25:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .62f, posBDefault.localPosition.y - .75f, posBDefault.localPosition.z);
                    break;

                case 26:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .4f, posBDefault.localPosition.y - .75f, posBDefault.localPosition.z);
                    break;

                case 27:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x, posBDefault.localPosition.y - .75f, posBDefault.localPosition.z);
                    break;

                case 28:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .27f, posBDefault.localPosition.y - .75f, posBDefault.localPosition.z);
                    break;

                case 29:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .55f, posBDefault.localPosition.y - .75f, posBDefault.localPosition.z);
                    break;

                case 30:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .27f, posBDefault.localPosition.y - .99f, posBDefault.localPosition.z);
                    break;
            }
        }


        //This removes the ball when the ball reaches the end of the line
        if (transform.position.z <= .53f)
        {
            transform.position = new Vector3(0, -20, 0);
            isTweening = false;
            tweenTimer = 0;
        }


        //This triggers a new ball to be spawned at a random pitcher location in order to prove that this is a variable location
        if (!ScoreHandler1.GameOver && !isTweening && !videoPlayer.isPlaying && hasChosenAnswer)
        {
            timer++;
            if (timer > 60)
            {
                timer = 0;
                playVid();
            }

        }

        if (videoPlayer.frame >= 100 && doOnce && videoPlayer.frame <= 104)
        {

            doOnce = false;
            PlayTween();

        }

        if (videoPlayer.frame >= 110)
        {
            //videoPlayer.frame = 1;
            videoPlayer.Pause();
            videoPlayer1.Pause();
            videoPlayer2.Pause();
            hasThrownOne = true;
        }


        if (isTweening)
        {
            rend1.enabled = false;
            rend2.enabled = false;
            if (hasThrownOne)
            {
                hasChosenAnswer = false;
            }

            //Controlls baseball speed with the settings menu
            switch (RayCasting.velocitySetting)
            {
                case 1:
                    print("changed: 1");
                    speedMultiplier = 1;
                    RayCasting.velocitySetting = 0;
                    break;

                case 2:
                    print("changed: 2");
                    speedMultiplier = 2.5f;
                    RayCasting.velocitySetting = 0;
                    break;

                case 3:
                    print("changed: 3");
                    speedMultiplier = 5;
                    RayCasting.velocitySetting = 0;
                    break;

                case 4:
                    print("changed: 4");
                    speedMultiplier = 7.5f;
                    RayCasting.velocitySetting = 0;
                    break;

                case 5:
                    print("changed: 5");
                    speedMultiplier = 9;
                    RayCasting.velocitySetting = 0;
                    break;

                case 6:
                    print("changed: 6");
                    speedMultiplier = 12;
                    RayCasting.velocitySetting = 0;
                    break;

                case 0:

                    break;
            }


            tweenTimer += Time.deltaTime * speedMultiplier;
            float p = tweenTimer / tweenLength;
            percent = tweenSpeed.Evaluate(p);

            if (tweenTimer > tweenLength)
            {
                tweenTimer = 0;
                percent = 0;
                isTweening = false;
                transform.position = new Vector3(0, -20, 0);
            }
        }
        else
        {
            if (hasChosenAnswer && !ScoreHandler1.GameOver && hasThrownOne)   //I think the problem is that "hasChosenAnswer" is correct after the first answer, and never resets
            {
                if (ScoreHandler1.correctScore)
                {
                    rend1.enabled = true;
                    rend2.enabled = false;
                }
                else
                {
                    rend2.enabled = true;
                    rend1.enabled = false;
                }
            }
        }

        if (percent > 0)
        {
            transform.position = CalcPositionOnCurve(percent);
        }
        else
        {
            transform.position = new Vector3(0, -20, 0);
        }
        if (percent > 99)
        {
            transform.position = new Vector3(0, -20, 0);
        }
    }

    public void playVid()
    {
        videoPlayer.frame = 1;
        videoPlayer1.frame = 1;
        videoPlayer2.frame = 1;

        videoPlayer.Play();
        videoPlayer1.Play();
        videoPlayer2.Play();
        rend1.enabled = false;
        rend2.enabled = false;

        doOnce = true;
    }

    public void PlayTween()
    {
        Vector3 pitcherOffset = new Vector3(0, 0, 0);


        switch (RayCasting.pitcher)
        {
            //Leave this one alone. Pitcher one should be the default position
            case 1:
                posA.position = new Vector3(posADefault.position.x, posADefault.position.y, posADefault.position.z);
                break;

            //Change amount needed to adjust for pitcher positioning here
            case 2:
                posA.position = posX.position;
                break;

            //Change amount needed to adjust for pitcher positioning here
            case 3:
                posA.position = posY.position;
                break;
        }


        tweenTimer = 0;
        isTweening = true;
        endPoses = Random.Range(0, 31);
        pitchTypes = Random.Range(0, 5);

    }

    private Vector3 CalcPositionOnCurve(float percent)
    {
        Vector3 c = AnimMath.Lerp(posA.position, handle.position, percent);
        Vector3 d = AnimMath.Lerp(handle.position, posB.position, percent);

        Vector3 f = AnimMath.Lerp(c, d, percent);

        return f;
    }

    private void OnDrawGizmos()
    {
        Vector3 p1 = posA.position;
        for (int i = 1; i < curveResolution; i++)
        {
            float p = i / (float)curveResolution;
            Vector3 p2 = CalcPositionOnCurve(p);

            Gizmos.DrawLine(p1, p2);
            p1 = p2;
        }
        Gizmos.DrawLine(p1, posB.position);
    }
}