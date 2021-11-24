using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BaseballController : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;
    [SerializeField]
    private VideoPlayer videoPlayer1;
    [SerializeField]
    private VideoPlayer videoPlayer2;


    public Transform posA;
    public Transform posX;
    public Transform posY;
    public Transform posB;
    public Transform handle;

    private List<int> Balls = new List<int>();
    private List<int> Strikes = new List<int>();

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

    [Range(.1f, 10)] public float tweenLength = 3;
    public AnimationCurve tweenSpeed;
    private float tweenTimer = 0;
    public static bool isTweening = false;

    public GameObject blurEffectPanel;
    void Start()
    {
        posADefault = posA;

        Balls.Add(6);
        Balls.Add(7);
        Balls.Add(8);
        Balls.Add(11);
        Balls.Add(12);
        Balls.Add(13);
        Balls.Add(15);
        Balls.Add(17);
        Balls.Add(19);
        Balls.Add(22);
        Balls.Add(23);
        Balls.Add(26);
        Balls.Add(27);
        Balls.Add(28);

        Strikes.Add(1);
        Strikes.Add(2);
        Strikes.Add(3);
        Strikes.Add(4);
        Strikes.Add(5);
        Strikes.Add(9);
        Strikes.Add(10);
        Strikes.Add(14);
        Strikes.Add(16);
        Strikes.Add(18);
        Strikes.Add(20);
        Strikes.Add(21);
        Strikes.Add(24);
        Strikes.Add(25);
        Strikes.Add(29);
    }

    void Update()
    {

        if (ScoreHandler.GameOver)
        {
            videoPlayer.Pause();
            videoPlayer1.Pause();
            videoPlayer2.Pause();
        }

        if (videoPlayer.frame > 1 && videoPlayer.frame <= 60)
        {
            ScoreHandler.strikeZoneVisible = true;
        }
        else
        {
            ScoreHandler.strikeZoneVisible = false;
        }

     /*   if (videoPlayer.frame > 100 && videoPlayer.frame <= 105)
        {
            blurEffectPanel.SetActive(false);
        }
        else
        {
            blurEffectPanel.SetActive(false);
        }*/

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

            float sizeMultiplier = 0.12f;
            //Chooses between 31 different ending positions

            switch (endPoses)
            {
                case 0:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x, (posBDefault.localPosition.y + .83f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 1:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .8f, (posBDefault.localPosition.y + .7f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 2:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .4f, (posBDefault.localPosition.y + .6f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 3:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x, (posBDefault.localPosition.y + .6f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 4:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .27f, (posBDefault.localPosition.y + .6f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 5:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .62f, (posBDefault.localPosition.y + .32f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 6:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .4f, (posBDefault.localPosition.y + .32f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 7:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x, (posBDefault.localPosition.y + .32f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 8:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .27f, (posBDefault.localPosition.y + .32f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 9:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .55f, (posBDefault.localPosition.y + .32f) * sizeMultiplier, posBDefault.localPosition.z);
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
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .24f, (posBDefault.localPosition.y - .16f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 16:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .7f, (posBDefault.localPosition.y - .16f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 17:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .13f, (posBDefault.localPosition.y - .16f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 18:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .62f, (posBDefault.localPosition.y - .5f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 19:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .4f, (posBDefault.localPosition.y - .5f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 20://confuse
                    posB.localPosition = new Vector3(posBDefault.localPosition.x, (posBDefault.localPosition.y - .99f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 21://confuse
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .62f, (posBDefault.localPosition.y - .99f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 22:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x, (posBDefault.localPosition.y - .5f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 23:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .27f, (posBDefault.localPosition.y - .5f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 24:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .55f, (posBDefault.localPosition.y - .5f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 25:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .62f, (posBDefault.localPosition.y - .75f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 26:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x - .4f, (posBDefault.localPosition.y - .75f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 27:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x, (posBDefault.localPosition.y - .75f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 28:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .27f, (posBDefault.localPosition.y - .75f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 29:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .55f, (posBDefault.localPosition.y - .75f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;

                case 30:
                    posB.localPosition = new Vector3(posBDefault.localPosition.x + .27f, (posBDefault.localPosition.y - .99f) * sizeMultiplier, posBDefault.localPosition.z);
                    break;
            }
        }


        //This removes the ball when the ball reaches the end of the line
        if (transform.position.z <= .53f)
        {
            transform.position = new Vector3(0, -20, 0);
           // isTweening = false;
           // tweenTimer = 0;
        }

        // Debug.Log($"ScoreHandler.GameOver {!ScoreHandler.GameOver} !isTweening {!isTweening} !videoPlayer.isPlaying {!videoPlayer.isPlaying}");
        if (!ScoreHandler.GameOver && !isTweening && !videoPlayer.isPlaying)
        {
            // Debug.Log("timer "+ timer);
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
        }

        if (isTweening)
        {
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
        doOnce = true;
    }

    public void PlayTween()
    {
        Debug.Log("Play tweening is called....");
        Vector3 pitcherOffset = new Vector3(0, 0, 0);

        switch (RayCasting.pitcher)
        {
            //Leave this one alone. Pitcher one should be the default position
            case 0:

                posA.position = new Vector3(posADefault.position.x, posADefault.position.y, posADefault.position.z);
                break;

            //Change amount needed to adjust for pitcher positioning here
            case 1:
                posA.position = posX.position;

                break;

            //Change amount needed to adjust for pitcher positioning here
            case 2:
                posA.position = posY.position;

                break;
        }

        //posA.position = posADefault.position;
        //posA.position = new Vector3(posA.position.x + pitcherOffset.x, posA.position.y + pitcherOffset.y, posA.position.z + pitcherOffset.z);


        tweenTimer = 0;
        isTweening = true;
        pitchTypes = Random.Range(0, 5);

        //Number Notes:
        /*
         * Balls: 6, 7, 8, 11, 12, 13, 15, 17, 19, 22, 23, 26, 27, 28
         * Strikes: 1, 2, 3, 4, 5, 9, 10, 14, 16, 18, 20, 21, 24, 25, 29
         * 
         * Roll normally for 50/50 chance
         * 
         * Make method that adjusts endPoses before it goes into this new function
         * 
         */
        switch (RayCasting.accuracySetting)
        {
            case 0: // Just does the code like it used to, as there are 50/50 ball and strike options
                print("0");
                endPoses = Random.Range(0, 31);
                Debug.Log($"this is end point {endPoses} of WildButton");
                break;

            case 1:
                int i = Random.Range(0, 101);
                if (i <= 85) //use balls
                {
                    print("1");
                    int temp = Random.Range(0, Balls.Count);
                    endPoses = Balls[temp];
                    Debug.Log($"this is end point {endPoses} of AverageButton");

                }
                else //use Strikes
                {
                    print("1");
                    int temp = Random.Range(0, Strikes.Count);
                    endPoses = Strikes[temp];
                    Debug.Log($"this is end point {endPoses} of AverageButton");
                }
                break;

            case 2:
                int x = Random.Range(0, 101);
                if (x <= 95) // use balls
                {
                    print("2");
                    int temp = Random.Range(0, Balls.Count);
                    endPoses = Balls[temp];
                    Debug.Log($"this is end point {endPoses} of PinPointButton");
                }
                else //use Strikes
                {
                    print("2");
                    int temp = Random.Range(0, Strikes.Count);
                    endPoses = Strikes[temp];
                    Debug.Log($"this is end point {endPoses} of PinPointButton");
                }
                break;
        }


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
