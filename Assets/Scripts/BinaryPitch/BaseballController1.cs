using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public GameObject CorrectAnsCanvas;
    public Text CorrectAns;

    public string pitchType;
    public string pitchValue;
    public string BallType;

    public static string pitchBallBoth;



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
    internal bool playAgain = true;
    internal bool isAnswerShowOnce = false;

    private List<int> Balls = new List<int>();
    private List<int> Strikes = new List<int>();


    void Start()
    {
        posADefault = posA;

        rend1 = correct.GetComponent<MeshRenderer>();
        rend2 = incorrect.GetComponent<MeshRenderer>();



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
        Strikes.Add(30);

    }

    void Update()
    {
        if (videoPlayer1.isPlaying)
        {
            //Debug.Log($"is playing {videoPlayer1.isPlaying}");
            playingVid = true;
        }
        else
        {
            playingVid = false;
           // Debug.Log($"is not playing {videoPlayer1.isPlaying}");
        }

        if (ScoreHandler1.GameOver)
        {
            videoPlayer.Stop();
            videoPlayer1.Stop();
            videoPlayer2.Stop();

            rend1.enabled = false;
            rend2.enabled = false;
            CorrectAnsCanvas.gameObject.SetActive(false);
        }

        if (videoPlayer.frame > 1 && videoPlayer.frame <= 60) //This is the code that controls the "correct" and "incorrect" words
        {
            //Debug.Log($"this is vidioPlayer frame {videoPlayer.frame}");
            /*rend1.enabled = false;
            rend2.enabled = false;
            CorrectAnsCanvas.gameObject.SetActive(false);*/
            ScoreHandler1.strikeZoneVisible = true;
            //hasChosenAnswer = false;
            //we need to know whether or not they got the answer correct, then enable the true one here   
        }
        else
        {
            ScoreHandler1.strikeZoneVisible = false;

        }

        //Future Tip:    When going to appositeHandedness of pitcher, just adjust flip the normal of the x value


        //This part chooses what type of ball to throw





        //This removes the ball when the ball reaches the end of the line
        if (transform.position.z <= .53f)
        {
            transform.position = new Vector3(0, -20, 0);
            isTweening = false;
            tweenTimer = 0;
        }


        //This triggers a new ball to be spawned at a random pitcher location in order to prove that this is a variable location
        if (!ScoreHandler1.GameOver && !isTweening && !videoPlayer.isPlaying && hasChosenAnswer && playAgain)
        {
            Debug.Log($"this is gameover {!ScoreHandler1.GameOver} and isTweening {!isTweening} and is vidwoplayer {!videoPlayer.isPlaying} and has chosen answer {hasChosenAnswer}");

            timer++;
            if (timer > 60)
            {
                timer = 0;
                playVid();
            }

        }

        if (videoPlayer.frame >= 100 && doOnce && videoPlayer.frame <= 104)
        {
            Debug.Log($"this is vidioPlayer frame in do once condtion {videoPlayer.frame}");
            doOnce = false;
            PlayTween();

        }

        if (videoPlayer.frame >= 110 && videoPlayer.isPlaying)
        {
          //  Debug.Log($"this is vidioPlayer frame in frame grater than 110 condtion {videoPlayer.frame}");
            //videoPlayer.frame = 1;
            videoPlayer.Stop();
            videoPlayer1.Stop();
            videoPlayer2.Stop();
            hasThrownOne = true;

            OpenSettingPanel();
        }


        if (isTweening)
        {
            Debug.Log($"this is isTweening {isTweening}");
            /* rend1.enabled = false;
             rend2.enabled = false;
             CorrectAnsCanvas.gameObject.SetActive(false);*/
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
           // Debug.Log($"this is isTweening {isTweening}");

        }

        if (hasChosenAnswer && !ScoreHandler1.GameOver && hasThrownOne)   //I think the problem is that "hasChosenAnswer" is correct after the first answer, and never resets
        {


            if (ScoreHandler1.correctScore && isAnswerShowOnce)
            {

                Debug.Log($"this is hasThrownOne {hasThrownOne} and haschosenAnswer {hasChosenAnswer}");

                rend1.enabled = true;
               // rend2.enabled = false;
                CorrectAnsCanvas.gameObject.SetActive(true);
                isAnswerShowOnce = false;
            }
            else if (!ScoreHandler1.correctScore && isAnswerShowOnce)
            {

                Debug.Log($"this is hasThrownOne {hasThrownOne} and haschosenAnswer {hasChosenAnswer}");

                rend2.enabled = true;
                //rend1.enabled = false;
                CorrectAnsCanvas.gameObject.SetActive(true);
                isAnswerShowOnce = false;
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
        StartCoroutine(Delay());
    }

    public void OpenSettingPanel()
    {
        StartCoroutine(OpenPaenl());
    }


    IEnumerator OpenPaenl()
    {
        Debug.Log($"this is openPanel calling fucntion");
        playAgain = false;
        isAnswerShowOnce = true;
        yield return new WaitForSeconds(4f);
        rend1.enabled = false;
        rend2.enabled = false;
        CorrectAnsCanvas.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        playAgain = true;
        
    }
    public void PlayTween()
    {
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



        pitchTypes = Random.Range(0, 5);
        endPoses = Random.Range(1, 31);

        tweenTimer = 0;
        isTweening = true;

        if (isTweening)
        {
            switch (pitchTypes)
            {
                case 0:
                    //4S Fastball
                    handle.localPosition = handleDefault.localPosition;
                    pitchType = "FastBall";
                    pitchValue = "0";


                    break;

                case 1:
                    //CurveBall
                    pitchType = "CurveBall";
                    pitchValue = "1";
                    handle.localPosition = new Vector3(handleDefault.localPosition.x + -.4f, handleDefault.localPosition.y + .4f, handleDefault.localPosition.z - .4f);
                    break;

                case 2:
                    //Slider
                    pitchType = "Slider";
                    pitchValue = "2";
                    handle.localPosition = new Vector3(handleDefault.localPosition.x + -.5f, handleDefault.localPosition.y, handleDefault.localPosition.z);
                    break;

                case 3:
                    //2S Fastball
                    pitchType = "Fastball";
                    pitchValue = "0";
                    handle.localPosition = new Vector3(handleDefault.localPosition.x - 1.5f, handleDefault.localPosition.y, handleDefault.localPosition.z);
                    break;

                case 4:
                    //ChangeUp
                    pitchType = "ChangeUp";
                    pitchValue = "3";
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

        Debug.Log($"this is endpoint {endPoses} and pitch type {pitchTypes}");

        if (Strikes.Contains(endPoses))
        {

            BallType = "Strike";

            CorrectAns.text = $"Answer: {pitchType} - {BallType}";

            pitchBallBoth = pitchValue + "0";

            Debug.Log($"111 ...............{endPoses} pitchType {pitchValue} and 0 correct ans {pitchBallBoth}");
        }
        else if (Balls.Contains(endPoses))
        {

            BallType = "Ball";

            CorrectAns.text = $"Answer: {pitchType} - {BallType}";
            pitchBallBoth = pitchValue + "1";

            Debug.Log($"111 ...............{endPoses} pitchType {pitchValue} and 1 and correct ans {pitchBallBoth}");
        }



    }



    IEnumerator Delay()
    {

        yield return new WaitForSeconds(0f);
        videoPlayer.frame = 1;
        videoPlayer1.frame = 1;
        videoPlayer2.frame = 1;

        videoPlayer.Play();
        videoPlayer1.Play();
        videoPlayer2.Play();
        rend1.enabled = false;
        rend2.enabled = false;
        CorrectAnsCanvas.gameObject.SetActive(false);

        doOnce = true;
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