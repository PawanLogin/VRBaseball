using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SwingTriger
{
    public class FinalResultsCanvasController : MonoBehaviour
    {
        public GameObject myAnswerTextPrefab, expectedAnswerTextPrefab, reactionTimeTextPrefab, ballTypeTextPrefeb;
        public GameObject myAnswerTextHolder, expectedAnswerTextHolder, reactionTimeTextHolder, ballTypeTextHoder;
        public TextMeshProUGUI performanceTextObject, averageTimeTextObject;
        public int correctAnsCount;

        public static FinalResultsCanvasController instance;
        void Start()
        {
            instance = this;
        }

        void Update()
        {

        }
        private void ClearAllHolders()
        {
            myAnswerTextHolder.ClearButNotZeroIndex();
            expectedAnswerTextHolder.ClearButNotZeroIndex();
            ballTypeTextHoder.ClearButNotZeroIndex();
            reactionTimeTextHolder.Clear();
        }
        public void ClearAndAddEntries()
        {
            ClearAllHolders();

            AddMyAnswersEntries();
            AddCorrectAnswersEntries();
            AddReactionTimeEntries();
            AddBallTypeEntries();
            AssignTimeTextObject();
            AssignPerformanceTextObject(correctAnsCount, 15);
        }
        public void AddMyAnswersEntries()
        {
            foreach (var item in GameplayController.instance.myAnswersPitchList)
            {
                var instantiatedObject = Instantiate(myAnswerTextPrefab, myAnswerTextHolder.transform);
                var textObject = instantiatedObject.GetComponentInChildren<TextMeshProUGUI>();
                if (item == "Didn’t SwingCorrect")
                {
                    textObject.text = "Didn’t Swing";
                    textObject.color = Color.green;

                }
                else if(item == "SwingIncorrect")
                {
                    textObject.text = "Swing";
                    textObject.color = Color.red;
                }
                else if (item == "SwingCorrect")
                {
                    textObject.text = "Swing";
                    textObject.color = Color.green;
                }
                else if (item == "Didn’t SwingIncorrect")
                {
                    textObject.text = "Didn’t Swing";
                    textObject.color = Color.red;
                }
            }
        }
        public void AddCorrectAnswersEntries()
        {
            foreach (var item in GameplayController.instance.correctAnswersPitchList)
            {
                var instantiatedObject = Instantiate(expectedAnswerTextPrefab, expectedAnswerTextHolder.transform);
                var textObject = instantiatedObject.GetComponentInChildren<TextMeshProUGUI>();
                // Debug.Log(item);
                textObject.text = item;
            }
        }
        public void AddReactionTimeEntries()
        {
            foreach (var item in GameplayController.instance.reactionTimeList)
            {
                var instantiatedObject = Instantiate(reactionTimeTextPrefab, reactionTimeTextHolder.transform);
                var textObject = instantiatedObject.GetComponentInChildren<TextMeshProUGUI>();
                textObject.text = item.ToString("0.000");
            }
        }

        public void AddBallTypeEntries()
        {
            foreach (var item in GameplayController.instance.BallTypeList)
            {
                var instantiatedObject = Instantiate(ballTypeTextPrefeb, ballTypeTextHoder.transform);
                var textObject = instantiatedObject.GetComponentInChildren<TextMeshProUGUI>();
                textObject.text = item;
            }
        }

        public void AssignPerformanceTextObject(int myAnswersCount, int totalAnswersCount)
        {
            performanceTextObject.text = myAnswersCount + "/" + totalAnswersCount;
        }
        public void AssignTimeTextObject()
        {
            float totalTime = 0;
            foreach (var item in GameplayController.instance.reactionTimeList)
            {
                totalTime += item;
            }
            var averageVal = totalTime / GameplayController.instance.reactionTimeList.Count;
            averageTimeTextObject.text = averageVal.ToString("0.000") + "\n <size=50%>milliseconds</size>";
        }
    }

}
