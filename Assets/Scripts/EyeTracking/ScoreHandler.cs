using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public static bool GameOver = true;
    public static bool strikeZoneVisible = false;

    public GameObject strikeZone;
    private MeshRenderer rend;

    private Vector3 leftPos;
    private Vector3 rightPos;

    private float totalFrames = 0;
    private float correctFrames = 0;

    private bool doOnce = true;
    private int pitchNumber = 0;
    public TextMeshProUGUI pitchText;

    public static List<int> scores = new List<int>();
    public static List<int> ballTypes = new List<int>();

    public  List<string> leaderboardScore = new List<string>();
    public  List<string> leaderboardBallType = new List<string>();

    public GameObject containerBallType;
    public GameObject containerScore;
    public GameObject BallTypePrefeb;
    public GameObject ScorePrefeb;

    public TextMeshProUGUI avarageScoreText;
    public BaseballController bs;

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
        BallScore.text =  "0%";
        rend = strikeZone.GetComponent<MeshRenderer>();

        //Debug.Log(GameObject.Find("Player"));
    }

    void Update()
    { 
        Count();

        HandleStrikeZone();

        movePlayer();

        if (RayCasting.menu1)
        {
            /////////SetValues1();

        }
        if (!RayCasting.menu1)
        {
            ///////SetValues2();
        }
        if (RayCasting.gameJustStarted)
        {
            RayCasting.gameJustStarted = false;
            clearValues();
            pitchNumber = 0;
            pitchText.text = "0 of 15";
        }

    }

    private void Count()
    {

        if (BaseballController.isTweening)
        {
            //Counting Frames 
            totalFrames++;
            doOnce = true;
            if (RayCasting.overBall)
            {
                correctFrames++;
            }
        }
        else
        {
            if (totalFrames != 0 && doOnce)
            {
                doOnce = false;
                float percentage = (correctFrames / totalFrames);
                percentage *= 100;
                int floorPercent = Mathf.FloorToInt(percentage);
                pitchNumber++;
                pitchText.text = pitchNumber.ToString() + " of 15";
                storeData(pitchNumber, floorPercent, converter(BaseballController.pitchTypes));
                

                //Resetting for next pitch
                totalFrames = 0;
                correctFrames = 0;
            }
        }

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

    private void FinalResultPanel()
    {
        UIController.finalResultOpen = true;
    }
    private IEnumerator PlayAgainPanel()
    {

       // UIController.playAgainOpen = false;

        yield return new WaitForSeconds(0f);
        //FinalResultsCanvasController.instance.ClearAndAddEntries();
        yield return new WaitForSeconds(0f);
        UIController.playAgainOpen = true;
        // GameplayController.instance.reactionTimeList.Clear();
        // GameplayController.instance.myAnswersPitchList.Clear();
        // GameplayController.instance.correctAnswersPitchList.Clear();
        pitchText.text = "0 of 15";
        //FinalResultsCanvasController.instance.correctAnsCount = 0;
    }

    private void storeData(int idNum, int score, string ballType)
    {
        int tempNum = 0;
        switch (BaseballController.pitchTypes)
        {
            case 0:
                tempNum = 0;
                break;

            case 1:
                tempNum = 1;
                break;

            case 2:
                tempNum = 3;
                break;

            case 3:
                tempNum = 0;
                break;

            case 4:
                tempNum = 4;
                break;
        }

        ballTypes.Add(tempNum);

        updateText(score, converter(tempNum));
        scores.Add(score);

        if (idNum > 14)
        {
            endGame();
        }

    }

    private void endGame()
    {
        ResultPanel();
        //SetValues();
        GameOver = true;
        UIController.isFirstTimePlay = false;
        StartCoroutine(PlayAgainPanel());
        FinalResultPanel();
       
       // UIController.finalResultOpen = true;
        //clearValues();

    }

    private void clearValues()
    {

        scores.Clear();
        ballTypes.Clear();

        leaderboardBallType.Clear();
        leaderboardScore.Clear();
    }

    private void ClearAllHolders()
    {
        containerBallType.ClearButNotZeroIndex();
        containerScore.ClearButNotZeroIndex();

       
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

    private void updateText(int score, string ballType)
    {

        BallType.text = ballType;
        BallScore.text = score + "%";

        leaderboardBallType.Add(ballType);
        leaderboardScore.Add(score + "%");

    }

    public void ResultPanel()
    {
        ClearAllHolders();

        foreach (var item in leaderboardScore)
        {
            var instantiatedObject = Instantiate(ScorePrefeb, containerScore.transform);
            var textObject = instantiatedObject.GetComponentInChildren<TextMeshProUGUI>();
            // Debug.Log(item);
            textObject.text = item;
        }

        foreach (var item in leaderboardBallType)
        {
            var instantiatedObject = Instantiate(BallTypePrefeb, containerBallType.transform);
            var textObject = instantiatedObject.GetComponentInChildren<TextMeshProUGUI>();
            // Debug.Log(item);
            textObject.text = item;
        }

        avarageScoreText.text = Avarage();
    }

    public string Avarage()
    {
        float avarageScore = 0;
        foreach (var item in scores)
        {
            avarageScore = avarageScore + item;
           
        }
        avarageScore = avarageScore / scores.Count;
        return avarageScore.ToString("0.0") + "%";
    }

    private void SetValues1()
    {
        score1.text = scores[0] + "%";
        score2.text = scores[1] + "%";
        score3.text = scores[2] + "%";
        score4.text = scores[3] + "%";
        score5.text = scores[4] + "%";
        score6.text = scores[5] + "%";
        score7.text = scores[6] + "%";
        score8.text = scores[7] + "%";
        score9.text = scores[8] + "%";
        score10.text = scores[9] + "%";

        ball1.text = "01. " + ballTypes[0];
        ball2.text = "02. " + ballTypes[1];
        ball3.text = "03. " + ballTypes[2];
        ball4.text = "04. " + ballTypes[3];
        ball5.text = "05. " + ballTypes[4];
        ball6.text = "06. " + ballTypes[5];
        ball7.text = "07. " + ballTypes[6];
        ball8.text = "08. " + ballTypes[7];
        ball9.text = "09. " + ballTypes[8];
        ball10.text = "10. " + ballTypes[9];
    }

    private void SetValues2()
    {
        score1.text = scores[10] + "%";
        score2.text = scores[11] + "%";
        score3.text = scores[12] + "%";
        score4.text = scores[13] + "%";
        score5.text = scores[14] + "%";
        score6.text = scores[15] + "%";
        score7.text = scores[16] + "%";
        score8.text = scores[17] + "%";
        score9.text = scores[18] + "%";
        score10.text = scores[19] + "%";

        ball1.text = "11. " + ballTypes[0];
        ball2.text = "12. " + ballTypes[1];
        ball3.text = "13. " + ballTypes[2];
        ball4.text = "14. " + ballTypes[3];
        ball5.text = "15. " + ballTypes[4];
        ball6.text = "16. " + ballTypes[5];
        ball7.text = "17. " + ballTypes[6];
        ball8.text = "18. " + ballTypes[7];
        ball9.text = "19. " + ballTypes[8];
        ball10.text = "20. " + ballTypes[9];
    }

    private string converter(int ballType)
    {
        Debug.Log("Here is the Answer");
        //switch (ballType)
        //{
        //    case 0:
        //    //return "Four Seam";
        //    return "ChangeUp";
        //    case 1:
        //        return "Curve Ball";
        //    case 2:
        //        return "Two Seam";
        //    case 3:
        //        return "Slider";
        //    case 4:
        //        return "ChangeUp";
        //    case 5:
        //        return "Cutter";
        //}
        if (!string.IsNullOrEmpty(bs.PitchBallType))
            return bs.PitchBallType;
        return null;
    }
}
//0 four seam
//1 curveball
//2 two seam
//3 slider
//4 changeUp
//5 cutter