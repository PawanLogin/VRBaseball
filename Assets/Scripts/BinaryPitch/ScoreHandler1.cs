using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler1 : MonoBehaviour
{
    public static bool GameOver = true;
    public static bool strikeZoneVisible = false;

    public GameObject strikeZone;
    private MeshRenderer rend;

    public static bool correctScore = false;

    private Vector3 leftPos;
    private Vector3 rightPos;
    private int idNum = 0;

    //    private float totalFrames = 0;
    //    private float correctFrames = 0;

    public static bool doOnce = true;
    private int pitchNumber = 0;

    public static List<int> scores = new List<int>();
   // public static List<string> ballTypes = new List<string>();
     public static List<int> ballTypes = new List<int>();

    public Text BallType;
    public Text BallScore;

    public Text score1;
    public Text score2;
    public Text score3;
    public Text score4;
    public Text score5;
    public Text score6;
    public Text score7;
    public Text score8;
    public Text score9;
    public Text score10;

    public Text ball1;
    public Text ball2;
    public Text ball3;
    public Text ball4;
    public Text ball5;
    public Text ball6;
    public Text ball7;
    public Text ball8;
    public Text ball9;
    public Text ball10;

    private void Start()
    {
        Screen.lockCursor = true;
        rightPos = new Vector3(-.38f, 1.638f, -.12f);
        leftPos = new Vector3(1.21f, 1.638f, -.12f);

        BallType.text = "...";
        BallScore.text = "0%";
        rend = strikeZone.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (RayCasting.Count)
        {
            Count();
            RayCasting.Count = false;
        }

        HandleStrikeZone();

        movePlayer();

        //Changes what score menu page we are on
        if (RayCasting.menu1)
        {
            //print("Menu1");
           // SetValues1();
        }
        else
        {
          //  SetValues2();
        }

        if (RayCasting.gameJustStarted)
        {
            RayCasting.gameJustStarted = false;
            clearValues();
            print("clearingValues");
            pitchNumber = 0;
        }

    }

    private void Count()
    {
        storeData();
    }

    private void HandleStrikeZone()
    {
        if (strikeZoneVisible)
        {
            rend.enabled = true;
        }
        else
        {
            rend.enabled = false;
        }
    }

    //private void storeData(int idNum, int ballType)
    private void storeData()
    {

        idNum++;

        //Score takes the guess, and ballType takes the correct answer

        ballTypes.Add(BaseballController1.pitchTypes);
        scores.Add(RayCasting.guess);

        int nun = ballTypes.Count;

        //print("Saving Guess: " + RayCasting.guess);
        //print("Saving Throw: " + BaseballController1.pitchTypes);




        updateText(RayCasting.guess, BaseballController1.pitchTypes);
        if (idNum > 14)
        {
            endGame();
            idNum = 0;
        }

    }

    private void endGame()
    {
        //SetValues();
        GameOver = true;
        //clearValues();

    }

    private void clearValues()
    {

        scores.Clear();
        ballTypes.Clear();

    }

    private void movePlayer()
    {

        if (RayCasting.leftHanded)
        {
            transform.position = leftPos;
        }
        else
        {
            transform.position = rightPos;
        }

    }

    private void updateText(int score, int ballType)
    {

        //0 1 2 3
        //0 1 2 3 4 5 6 


        if (score == ballType)
        {
            correctScore = true;
        }
        else
        {
            correctScore = false;
        }

        /* switch (ballType)
        {
            case 0:
                BallType.text = "Four Seam";
                break;
            case 1:
                BallType.text = "Curve Ball";
                break;
            case 2:
                BallType.text = "Slider";
                break;
            case 3:
                BallType.text = "Two Seam";
                break;
            case 4:
                BallType.text = "Change Up";
                break;
        }

        BallScore.text = score + "%";
        */
    }

    private void SetValues1()
    {
        score1.text = converter(scores[0]);
        score2.text = converter(scores[1]);
        score3.text = converter(scores[2]);
        score4.text = converter(scores[3]);
        score5.text = converter(scores[4]);
        score6.text = converter(scores[5]);
        score7.text = converter(scores[6]);
        score8.text = converter(scores[7]);
        score9.text = converter(scores[8]);
        score10.text = converter(scores[9]);

        ball1.text = converter(ballTypes[0]);
        ball2.text = converter(ballTypes[1]);
        ball3.text = converter(ballTypes[2]);
        ball4.text = converter(ballTypes[3]);
        ball5.text = converter(ballTypes[4]);
        ball6.text = converter(ballTypes[5]);
        ball7.text = converter(ballTypes[6]);
        ball8.text = converter(ballTypes[7]);
        ball9.text = converter(ballTypes[8]);
        ball10.text = converter(ballTypes[9]);
    }

    private void SetValues2()
    {

        score1.text = converter(scores[10]);
        score2.text = converter(scores[11]);
        score3.text = converter(scores[12]);
        score4.text = converter(scores[13]);
        score5.text = converter(scores[14]);
        score6.text = "..."; //converter(scores[15]);
        score7.text = "..."; //converter(scores[16]);
        score8.text = "..."; //converter(scores[17]);
        score9.text = "..."; //converter(scores[18]);
        score10.text = "...";  //converter(scores[19]);

        ball1.text = converter(ballTypes[10]);
        ball2.text = converter(ballTypes[11]);
        ball3.text = converter(ballTypes[12]);
        ball4.text = converter(ballTypes[13]);
        ball5.text = converter(ballTypes[14]);
        ball6.text = "...";//converter(ballTypes[15]);
        ball7.text = "...";//converter(ballTypes[16]);
        ball8.text = "...";//converter(ballTypes[17]);
        ball9.text = "...";//converter(ballTypes[18]);
        ball10.text = "...";//converter(ballTypes[19]);
    }

    private string converter(int ballType)
    {
        switch (ballType)
        {
            case 0:
                return "Four Seam";
            case 1:
                return "Curve Ball";
            case 2:
                return "Slider";
            case 3:
                return "Two Seam";
            case 4:
                return "Change Up";
            case 20:
                return "...";
        }
        return "confused";
        //return null;
    }
}
//0 four seam
//1 curveball
//2 two seam
//3 slider
//4 changeUp
//5 cutter