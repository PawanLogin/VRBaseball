using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler1 : MonoBehaviour
{
    public static bool GameOver = true;
    public static bool strikeZoneVisible = false;

    public GameObject strikeZone;
    private MeshRenderer rend;

    public static bool correctScore = false;
    public static int correctAnswerChecking = 0;
    public static int correctScoreCount;

    private Vector3 leftPos;
    private Vector3 rightPos;
    private int idNum = 0;

    //    private float totalFrames = 0;
    //    private float correctFrames = 0;

    public static bool doOnce = true;
    private int pitchNumber = 0;
    public TextMeshProUGUI pitchText;

    public static List<string> scores = new List<string>();
   // public static List<string> ballTypes = new List<string>();
     public static List<int> ballTypes = new List<int>();

    public List<string> leaderboardYouranswer = new List<string>();
    public List<int> leaderboardYouranswerColor = new List<int>();
    public List<string> leaderboardCorrectAnswer = new List<string>();

    public GameObject containerYouranswer;
    public GameObject containerCorrectAnswer;
    public GameObject YouranswerPrefeb;
    public GameObject CorrectAnswerPrefeb;

    public TextMeshProUGUI totalCorrectOutofTotal;
    public TextMeshProUGUI avarageScoreText;

    public Text yourAnswer;
    public Text correctAnswer;

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

        yourAnswer.text = "...";
        correctAnswer.text = "0%";
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
           
            pitchNumber = 0;
            idNum = 0;
            pitchText.text = "0 of 15";
           
          //s  print("clearingValues");
           
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
        pitchText.text = idNum.ToString() + " of 15";
        //Score takes the guess, and ballType takes the correct answer

        ballTypes.Add(BaseballController1.pitchTypes);
        scores.Add(RayCasting.guess);

        int nun = ballTypes.Count;

        //print("Saving Guess: " + RayCasting.guess);
        //print("Saving Throw: " + BaseballController1.pitchTypes);




        updateText(RayCasting.guess, BaseballController1.pitchBallBoth);
        if (idNum > 14)
        {
            StartCoroutine(endGame());
            idNum = 0;
        }

    }

    private IEnumerator endGame()
    {
        yield return new WaitForSeconds(2f);
        UIController.finalResultForBinary = true;
        ResultPanel();
        //SetValues();
        GameOver = true;
        clearValues();

    }

    public void clearValues()
    {

        scores.Clear();
        ballTypes.Clear();

        leaderboardYouranswer.Clear();
        leaderboardYouranswerColor.Clear();
        leaderboardCorrectAnswer.Clear();

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

    private void updateText(string guess, string correctAnswer)
    {

        //0 1 2 3
        //0 1 2 3 4 5 6 


        if (guess.Equals(correctAnswer))
        {
            correctAnswerChecking = 1;
            correctScore = true;
            correctScoreCount++;
            leaderboardYouranswerColor.Add(0);

            Debug.Log($"this is correct Answer {correctAnswer} and this is guess ans {guess}");
        }
        else if(!guess.Equals(correctAnswer))
        {
            correctAnswerChecking = 2;
            correctScore = false;
            leaderboardYouranswerColor.Add(1);

            Debug.Log($"this is correct Answer {correctAnswer} and this is guess ans {guess}");
        }

       // Debug.Log($"this is correct Answer {correctAnswer} and this is guess ans {guess}");
        switch (correctAnswer)
        {
            case "00":
                this.correctAnswer.text = "Fastball-Strike";
                break;
            case "01":
                this.correctAnswer.text = "Fastball-Ball";
                break;
            case "10":
                this.correctAnswer.text = "Curveball -Strike";
                break;
            case "11":
                this.correctAnswer.text = "Curveball -Ball";
                break;
            case "20":
                this.correctAnswer.text = "Sliderball -Strike";
                break;

            case "21":
                this.correctAnswer.text = "Sliderball -Ball";
                break;

            case "30":
                this.correctAnswer.text = "Changeball -Strike";
                break;

            case "31":
                this.correctAnswer.text = "Changeball -Ball";
                break;
        }

        leaderboardCorrectAnswer.Add(this.correctAnswer.text);

        switch (guess)
        {
            case "00":
                yourAnswer.text = "Fastball-Strike";
                break;
            case "01":
                yourAnswer.text = "Fastball-Ball";
                break;
            case "10":
                yourAnswer.text = "Curveball -Strike";
                break;
            case "11":
                yourAnswer.text = "Curveball -Ball";
                break;
            case "20":
                yourAnswer.text = "Sliderball -Strike";
                break;

            case "21":
                yourAnswer.text = "Sliderball -Ball";
                break;

            case "30":
                yourAnswer.text = "Changeball -Strike";
                break;

            case "31":
                yourAnswer.text = "Changeball -Ball";
                break;
        }

        leaderboardYouranswer.Add(yourAnswer.text);



    }


    public void ResultPanel()
    {
        ClearAllHolders();

        foreach (var item in leaderboardCorrectAnswer)
        {
            var instantiatedObject = Instantiate(CorrectAnswerPrefeb, containerCorrectAnswer.transform);
            var textObject = instantiatedObject.GetComponentInChildren<TextMeshProUGUI>();
            // Debug.Log(item);
            textObject.text = item;
        }


        for (int i = 0; i < leaderboardYouranswer.Count; i++)
        {
            var instantiatedObject = Instantiate(YouranswerPrefeb, containerYouranswer.transform);
            var textObject = instantiatedObject.GetComponentInChildren<TextMeshProUGUI>();

            if (leaderboardYouranswerColor[i] == 0)
            {
                textObject.text = leaderboardYouranswer[i];
                textObject.color = Color.green;
            }
            else if(leaderboardYouranswerColor[i] == 1)
            {
                textObject.text = leaderboardYouranswer[i];
                textObject.color = Color.red;
            }
        }
       

        avarageScoreText.text = Avarage();
        totalCorrectOutofTotal.text = Score();


    }

    public string Avarage()
    {
        float avarageScore = 0;
       
        avarageScore = ((correctScoreCount*100) / 15);
        return avarageScore.ToString("0.0") + "%";
    }

    public string Score()
    {
        string avarageScore;

        avarageScore = $"{correctScoreCount}/15";
        return avarageScore;
    }

    private void ClearAllHolders()
    {
        containerYouranswer.ClearButNotZeroIndex();
        containerCorrectAnswer.ClearButNotZeroIndex();

        avarageScoreText.text = "0";
        totalCorrectOutofTotal.text = "0";
    }


    private void SetValues1()
    {
        score1.text = (scores[0]);
        score2.text = (scores[1]);
        score3.text = (scores[2]);
        score4.text = (scores[3]);
        score5.text = (scores[4]);
        score6.text = (scores[5]);
        score7.text = (scores[6]);
        score8.text = (scores[7]);
        score9.text = (scores[8]);
        score10.text = (scores[9]);

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

        score1.text = (scores[10]);
        score2.text = (scores[11]);
        score3.text = (scores[12]);
        score4.text = (scores[13]);
        score5.text = (scores[14]);
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