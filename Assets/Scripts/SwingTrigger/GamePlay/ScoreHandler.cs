using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SwingTriger
{
    public class ScoreHandler : MonoBehaviour
    {
        public static bool GameOver = true;
        public static bool PitcherIntervalSwingTrigger = false;
        public static bool strikeZoneVisible = false;

        public GameObject strikeZone;
        private MeshRenderer rend;
        private MeshRenderer rendFinalPanel;
        private MeshRenderer rendPlayAgain;

        private Vector3 leftPos;
        private Vector3 rightPos;

        private float totalFrames = 0;
        private float correctFrames = 0;

        private bool doOnce = true;
        private int pitchNumber = 0;

        public static List<int> scores = new List<int>();
        public static List<string> ballTypes = new List<string>();
        //public static List<string> reactionTimeList = new List<string>();

        public Text BallType;
        public Text BallScore;
        public TextMeshProUGUI pitcherCounter;

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
        float reactionTime;
        public static float timeSpan;
        bool isEnableObj;

        public GameObject textMeshPro;
       // int currentPitch = 0;

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
            Count();
            HandleStrikeZone();
            movePlayer();

            if (SwingTriger.RayCasting.menu1)
            {
                /////////SetValues1();
            }
            if (!SwingTriger.RayCasting.menu1)
            {
                ///////SetValues2();
            }
            if (SwingTriger.RayCasting.gameJustStarted)
            {
                SwingTriger.RayCasting.gameJustStarted = false;
                clearValues();
                pitchNumber = 0;
                //UIController.isFirstTimePlay = true;
            }
         
            if (Input.GetMouseButtonDown(0))
            {
                if (SwingTriger.BaseballController.instance.isballthrough)
                {
                    reactionTime = Time.time;
                    Debug.Log($"reaction Time {reactionTime}");
                    timeSpan = -SwingTriger.BaseballController.instance.startTimeAbhiwan + reactionTime;
                    textMeshPro.GetComponent<TMPro.TMP_Text>().text = String.Format("{0:0.000}", timeSpan) + " milliseconds";
                    
                    StartCoroutine(RemoveTxt());
                   
                }
                else
                {

                    textMeshPro.GetComponent<TMPro.TMP_Text>().text = String.Format("{0:0.000}", 0) + " milliseconds";
                   // Debug.Log($"reaction Time {textMeshPro.GetComponent<TMPro.TMP_Text>().text}");
                    //reactionTimeList.Add(textMeshPro.GetComponent<TMPro.TMP_Text>().text);
                }
            }
        }

        IEnumerator RemoveTxt()
        {
            yield return new WaitForSeconds(6f);
            textMeshPro.GetComponent<TMPro.TMP_Text>().text = String.Format("{0:0.000}", 0) + " milliseconds";
        }


        private void Count()
        {
            if (SwingTriger.BaseballController.isTweening)
            {
                //Counting Frames 
                totalFrames++;
               // Debug.Log("6 ...Now framecounting start  totalFrames "+ totalFrames);
                doOnce = true;
                if (SwingTriger.RayCasting.overBall)
                {
                    correctFrames++;
                  //  Debug.Log("correctFrames " + correctFrames);
                }
            }
            else
            {
                if (totalFrames != 0 && doOnce)
                {
                    //SwingTriger.BaseballController.instance.StopVideo();
                    SwingTriger.BaseballController.instance.isballthrough = false;
                    doOnce = false;
                    float percentage = (correctFrames / totalFrames);
                    percentage *= 100;
                    int floorPercent = Mathf.FloorToInt(percentage);
                    pitchNumber++;
                    pitcherCounter.text = pitchNumber.ToString();
                    // Debug.Log("pitchNumber "+ pitchNumber);
                    storeData(pitchNumber, floorPercent, converter(SwingTriger.BaseballController.pitchTypes));
                    //Resetting for next pitch
                    totalFrames = 0;
                    // Debug.Log("Else totalFrames " + totalFrames);
                    correctFrames = 0;
                }
            }
        }


        //    IEnumerator Add_Delay()
        //    {
        //        yield return new WaitForSeconds(5);
        //    SwingTriger.BaseballController.instance.isballthrough = false;
        //    doOnce = false;
        //    float percentage = (correctFrames / totalFrames);
        //    percentage *= 100;
        //    int floorPercent = Mathf.FloorToInt(percentage);
        //    pitchNumber++;
        //    // Debug.Log("pitchNumber "+ pitchNumber);
        //    storeData(pitchNumber, floorPercent, converter(SwingTriger.BaseballController.pitchTypes));
        //    //Resetting for next pitch
        //    totalFrames = 0;
        //    // Debug.Log("Else totalFrames " + totalFrames);
        //    correctFrames = 0;
        //}

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

        private IEnumerator FinalResultPanel()
        {
            UIController.finalResultOpen = false;
            yield return new WaitForSeconds(7f);
            UIController.finalResultOpen = true;
        }

        private IEnumerator PlayAgainPanel()
        {

            UIController.playAgainOpen = false;
            
            yield return new WaitForSeconds(3f);
            FinalResultsCanvasController.instance.ClearAndAddEntries();
            yield return new WaitForSeconds(7f);
            UIController.playAgainOpen = true;
            GameplayController.instance.reactionTimeList.Clear();
            GameplayController.instance.myAnswersPitchList.Clear();
            GameplayController.instance.correctAnswersPitchList.Clear();
            pitcherCounter.text = "0";
            FinalResultsCanvasController.instance.correctAnsCount = 0;
        }

        private void storeData(int idNum, int score, string ballType)
        {
            updateText(score, ballType);
            scores.Add(score);
            ballTypes.Add(ballType);

            if (idNum > 14)
            {
                endGame();
                
            }
        }

        private void endGame()
        {
            //SetValues();
            GameOver = true;
            UIController.isFirstTimePlay = false;
            StartCoroutine(PlayAgainPanel());
            StartCoroutine(FinalResultPanel());
            
            //clearValues();

        }

        private void clearValues()
        {
            scores.Clear();
            ballTypes.Clear();
            SwingTriger.BaseballController.instance.isballthrough = false;
        }

       

        private void movePlayer()
        {
           
            if (SwingTriger.RayCasting.leftHanded)
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
            switch (ballType)
            {
                case 0:
                    return "Four Seam";
                case 1:
                    return "Curve Ball";
                case 2:
                    return "Two Seam";
                case 3:
                    return "Slider";
                case 4:
                    return "Change Up";
                case 5:
                    return "Cutter";
            }
            return null;
        }
    }
}
//0 four seam
//1 curveball
//2 two seam
//3 slider
//4 changeUp
//5 cutter