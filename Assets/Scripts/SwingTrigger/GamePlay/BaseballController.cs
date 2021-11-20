using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

// Abhiwan added the namespace
namespace SwingTriger
{
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

        private int timer = 50;

        public int endPoses;
        public static int pitchTypes;
        public static PitchType pitchTypeEnum;

        [Range(.1f, 10)] public float tweenLength = 3;
        public AnimationCurve tweenSpeed;
        private float tweenTimer = 0;
        public static bool isTweening = false;
        [SerializeField]
        private LineRenderer lineRenderer;
        [SerializeField]
        private Material lineRendererMat_G;
        [SerializeField]
        private Material lineRendererMat_R;
        internal bool isBall;
        internal bool isStrikes;
        internal float startTimeAbhiwan;
        internal bool isballthrough;
        internal bool isSwing = false;
        internal bool playAgain = true;

        public TextMeshProUGUI decisionMade;
        public TextMeshProUGUI Restul;
        public TextMeshProUGUI pitchType;
        public TextMeshProUGUI BallType;

        public static BaseballController instance;

        public GameObject blurEffectPanel;
        private void Awake()
        {
            // Debug.Log("Disable line Render");
            instance = this;
            lineRenderer.enabled = false;
        }

        void Start()
        {
            posADefault = posA;
           //Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition}");

            /*Balls.Add(1);
            Balls.Add(9);
            Balls.Add(11);
            Balls.Add(14);
            Balls.Add(16);
            Balls.Add(18);
            Balls.Add(24);
            Balls.Add(29);

            // Added by Abhiwan
            // ===============================
            Strikes.Add(0);
            Strikes.Add(2);
            Strikes.Add(3);
            Strikes.Add(4);
            Strikes.Add(5);
            Strikes.Add(6);
            Strikes.Add(7);
            Strikes.Add(8);
            Strikes.Add(10);
            Strikes.Add(12);
            Strikes.Add(13);
            Strikes.Add(15);
            Strikes.Add(17);
            Strikes.Add(19);
            Strikes.Add(20);
            Strikes.Add(21);
            Strikes.Add(22);
            Strikes.Add(23);
            Strikes.Add(25);
            Strikes.Add(26);
            Strikes.Add(27);
            Strikes.Add(28);
            Strikes.Add(30);*/

            //Balls.Add(0);
            Balls.Add(1);
           // Balls.Add(3);
            Balls.Add(5);
          //  Balls.Add(8);
            Balls.Add(9);
            Balls.Add(14);
            Balls.Add(16);
           // Balls.Add(18);
            Balls.Add(24);
            Balls.Add(21);
            Balls.Add(29);

            
            Strikes.Add(0);
            Strikes.Add(3);
            Strikes.Add(2);
            Strikes.Add(4);
            //Strikes.Add(5);
            Strikes.Add(6);
            Strikes.Add(7);
            Strikes.Add(8);
            Strikes.Add(10);
            Strikes.Add(11);
            Strikes.Add(12);
            Strikes.Add(13);
            Strikes.Add(15);
            Strikes.Add(18);
            Strikes.Add(17);
            Strikes.Add(19);
            Strikes.Add(20);
           // Strikes.Add(21);
            Strikes.Add(22);
            Strikes.Add(23);
            Strikes.Add(25);
            Strikes.Add(26);
            Strikes.Add(27);
            Strikes.Add(28);
            Strikes.Add(30);
        }

        bool GamePaused = false;
        float FloatingPauseTime = 3;
        void Update()
        {
            /*            if(GamePaused)
                        {
                            FloatingPauseTime -= Time.deltaTime;

                            if (FloatingPauseTime <= 0)
                            {
                                Debug.Log("is pause..");
                                GamePaused = false;
                            }

                            return;
                        }*/

            if (SwingTriger.ScoreHandler.GameOver)
            {
                videoPlayer.Stop();
                videoPlayer1.Stop();
                videoPlayer2.Stop();
                // Debug.Log("1 .............");
            }
            // Debug.Log("videoPlayer.frame "+ videoPlayer.frame);
            if (videoPlayer.frame > 1 && videoPlayer.frame <= 60)
            {
                //Debug.Log("2 .............");
                //SwingTriger.ScoreHandler.strikeZoneVisible = true;
                if (!SwingTriger.ScoreHandler.GameOver && (isBall || isStrikes))
                {
                    // Debug.Log("2.5f .............");
                    // DrawLine();
                    //SwingTriger.UIController.settingsOpen = true;
                    // FloatingPauseTime = 3;
                    // GamePaused = true;
                    // SwingTriger.ScoreHandler.GameOver = true;
                    // Time.timeScale = 0;
                    //SwingTriger.ScoreHandler.GameOver = true;
                    //SwingTriger.ScoreHandler.PitcherIntervalSwingTrigger = true;
                }
            }
            else
            {
                //Debug.Log("3 .............");
                // lineRenderer.enabled = false;
                // SwingTriger.ScoreHandler.strikeZoneVisible = false;
                // SwingTriger.UIController.settingsOpen = false;
            }


            if (videoPlayer.frame > 100 && videoPlayer.frame <= 105)
            {
                blurEffectPanel.SetActive(true);
            }
            else
            {
                blurEffectPanel.SetActive(false);
            }

            //Future Tip:    When going to appositeHandedness of pitcher, just adjust flip the normal of the x value

            //This part chooses what type of ball to throw
            // Debug.LogError($"4 A...isTweening ......{isTweening}....");
            if (isTweening)
            {
                // Debug.Log($"4 B inside condition...pitchTypes ......{pitchTypes}....");
                switch (pitchTypes)
                {
                    case 0:
                        //4S Fastball
                        handle.localPosition = handleDefault.localPosition;
                        pitchType.text = PitchType.Fastball.ToString();
                        pitchTypeEnum = PitchType.Fastball;
                        break;

                    case 1:
                        //CurveBall
                        handle.localPosition = new Vector3(handleDefault.localPosition.x + -.4f, handleDefault.localPosition.y + .4f, handleDefault.localPosition.z - .4f);
                        pitchType.text = PitchType.Curveball.ToString();
                        pitchTypeEnum = PitchType.Curveball;
                        break;

                    case 2:
                        //Slider
                        handle.localPosition = new Vector3(handleDefault.localPosition.x + .5f, handleDefault.localPosition.y, handleDefault.localPosition.z);
                        pitchType.text = PitchType.Slider.ToString();
                        pitchTypeEnum = PitchType.Slider;
                        break;

                    case 3:
                        //2S Fastball
                        handle.localPosition = new Vector3(handleDefault.localPosition.x - 1.5f, handleDefault.localPosition.y, handleDefault.localPosition.z);
                        pitchType.text = PitchType.Fastball.ToString();
                        pitchTypeEnum = PitchType.Fastball;
                        break;

                    case 4:
                        //ChangeUp
                        handle.localPosition = new Vector3(handleDefault.localPosition.x + .3f, handleDefault.localPosition.y + .8f, handleDefault.localPosition.z - .2f);
                        pitchType.text = PitchType.ChangeUp.ToString();
                        pitchTypeEnum = PitchType.ChangeUp;
                        break;
                }

                float sizeMultiplier = 0.12f;
                //Chooses between 31 different ending positions
                // Debug.Log($"5 ...endPoses .........." + endPoses);
                switch (endPoses)
                {
                    case 0:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x, (posBDefault.localPosition.y ) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 1:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x - .8f, (posBDefault.localPosition.y + .7f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 2:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x - .4f, (posBDefault.localPosition.y + .6f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 3:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x, (posBDefault.localPosition.y + .6f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 4:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x + .27f, (posBDefault.localPosition.y + .6f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 5:
                        /* posB.localPosition = new Vector3(posBDefault.localPosition.x - .62f, (posBDefault.localPosition.y + .32f) * sizeMultiplier, posBDefault.localPosition.z);*/

                        posB.localPosition = new Vector3(posBDefault.localPosition.x - .8f, (posBDefault.localPosition.y + .7f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 6:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x - .4f, (posBDefault.localPosition.y + .32f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 7:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x, (posBDefault.localPosition.y + .32f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 8:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x + .27f, (posBDefault.localPosition.y + .32f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 9:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x + .55f, (posBDefault.localPosition.y + .32f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 10:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x - .62f, posBDefault.localPosition.y, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 11:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x - .4f, posBDefault.localPosition.y, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 12:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x, posBDefault.localPosition.y, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 13:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x + .27f, posBDefault.localPosition.y, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 14:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x + .55f, posBDefault.localPosition.y, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 15:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x - .24f, (posBDefault.localPosition.y - .16f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 16:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x + .7f, (posBDefault.localPosition.y - .16f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 17:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x + .13f, (posBDefault.localPosition.y - .16f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 18:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x - .62f, (posBDefault.localPosition.y - .5f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 19:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x - .4f, (posBDefault.localPosition.y - .5f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 20://confuse
                        posB.localPosition = new Vector3(posBDefault.localPosition.x, (posBDefault.localPosition.y - .99f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 21://confuse
                        /*posB.localPosition = new Vector3(posBDefault.localPosition.x - .62f, (posBDefault.localPosition.y - .99f) * sizeMultiplier, posBDefault.localPosition.z);*/

                        posB.localPosition = new Vector3(posBDefault.localPosition.x - .8f, (posBDefault.localPosition.y + .7f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 22:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x, (posBDefault.localPosition.y - .5f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 23:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x + .27f, (posBDefault.localPosition.y - .5f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 24:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x + .55f, (posBDefault.localPosition.y - .5f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 25:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x - .62f, (posBDefault.localPosition.y - .75f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 26:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x - .4f, (posBDefault.localPosition.y - .75f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 27:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x, (posBDefault.localPosition.y - .75f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 28:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x + .27f, (posBDefault.localPosition.y - .75f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 29:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x + .55f, (posBDefault.localPosition.y - .75f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;

                    case 30:
                        posB.localPosition = new Vector3(posBDefault.localPosition.x + .27f, (posBDefault.localPosition.y - .99f) * sizeMultiplier, posBDefault.localPosition.z);
                        Debug.Log($"this is posB {posB.localPosition} and the value is posBDefault x is {posBDefault.localPosition.x}");
                        break;
                }

                
            }

            //Debug.Log($"6A ...transform.position.z .....{transform.position.z}.....");
            //This removes the ball when the ball reaches the end of the line
            if (transform.position.z <= .53f)
            {
                // Debug.Log($"6B inside condition...transform.position.z .....{transform.position.z}.....");
                transform.position = new Vector3(0, -20, 0);
                //isTweening = false;
                //tweenTimer = 0;
            }

            if (!SwingTriger.ScoreHandler.GameOver && !isTweening && !videoPlayer.isPlaying  && playAgain)
            {
               
                timer++;
              
                if (timer > 100)
                {
                  
                    timer = 0;
                    playVid();
                }

            }
            //  Debug.Log($"8 ...videoPlayer.frame ....{videoPlayer.frame}......");
            if (videoPlayer.frame >= 100 && doOnce && videoPlayer.frame <= 104)
            {
                startTimeAbhiwan = Time.time;
                isballthrough = true;
                // Debug.Log("Start time ...."+ startTimeAbhiwan);
                // Debug.Log("4 ...Now I come here ...");
                doOnce = false;
                PlayTween();
               // Debug.Log("videoPlayer.frame........" + videoPlayer.frame);
                //Debug.Log($"8 ...videoPlayer.frame ....{videoPlayer.frame}......");
            }
            //Debug.Log("10 ...videoPlayer.frame .........." + videoPlayer.frame);
            if (videoPlayer.frame >= 110 && videoPlayer.isPlaying)
            {
                // Debug.Log("videoPlayer.frame........" + videoPlayer.frame);
                //videoPlayer.frame = 1;
                videoPlayer.Stop();
                videoPlayer1.Stop();
                videoPlayer2.Stop();

                OpenSettingPanel();
               
                // Time.timeScale = 0;
            }
            // Debug.Log("11 ...isTweening .........." + isTweening);
            if (isTweening)
            {
                //Controlls baseball speed with the settings menu
                // Debug.Log("11 B..inside   .isTweening .........." + isTweening);
                switch (SwingTriger.RayCasting.velocitySetting)
                {
                    case 1:
                        print("changed: 1");
                        speedMultiplier = 1;
                        SwingTriger.RayCasting.velocitySetting = 0;
                        break;

                    case 2:
                        print("changed: 2");
                        speedMultiplier = 2.5f;
                        SwingTriger.RayCasting.velocitySetting = 0;
                        break;

                    case 3:
                        print("changed: 3");
                        speedMultiplier = 5;
                        SwingTriger.RayCasting.velocitySetting = 0;
                        break;

                    case 4:
                        print("changed: 4");
                        speedMultiplier = 7.5f;
                        SwingTriger.RayCasting.velocitySetting = 0;
                        break;

                    case 5:
                        print("changed: 5");
                        speedMultiplier = 9;
                        SwingTriger.RayCasting.velocitySetting = 0;
                        break;

                    case 6:
                        print("changed: 6");
                        speedMultiplier = 12;
                        SwingTriger.RayCasting.velocitySetting = 0;
                        break;

                    case 0:
                        break;
                }

                tweenTimer += Time.deltaTime * speedMultiplier;
                float p = tweenTimer / tweenLength;
                percent = tweenSpeed.Evaluate(p);
                //  Debug.Log($"11 ...tweenTimer ..{tweenTimer }........tweenLength { tweenLength}");
                if (tweenTimer > tweenLength)
                {
                    tweenTimer = 0;
                    percent = 0;
                    isTweening = false;
                    transform.position = new Vector3(0, -20, 0);
                    //  Time.timeScale = 0;
                }
            }
            //Debug.Log("12 ...percent .........." + percent);
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

        bool isFirstTime = true;
        bool isDelay;
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
            SwingTriger.ScoreHandler.strikeZoneVisible = true;

            if (!SwingTriger.ScoreHandler.GameOver && (isBall || isStrikes))
            {
                playAgain = false;
                yield return new WaitForSeconds(1f);
                SwingTriger.UIController.settingsOpen = true;
                DrawLine();
                yield return new WaitForSeconds(6f);
                SwingTriger.UIController.settingsOpen = false;
                StartCoroutine(BallRotator.instance.DestroyObject());
                lineRenderer.enabled = false;
                SwingTriger.ScoreHandler.strikeZoneVisible = false;
                playAgain = true;
            }
        }

        IEnumerator Delay()
        {
            yield return new WaitForSeconds(0);
           // Debug.Log("3 ...NOw I Called play video ... ");
            videoPlayer.frame = 1;
            videoPlayer1.frame = 1;
            videoPlayer2.frame = 1;

           // Debug.Log($"videoPlayer.frame........{ videoPlayer.frame} , {videoPlayer1.frame} , {videoPlayer2.frame} , {videoPlayer.frameCount} , {videoPlayer1.frameCount} , {videoPlayer2.frameCount}");

            videoPlayer.Play();
            videoPlayer1.Play();
            videoPlayer2.Play();
            doOnce = true;

        }

        //internal void StopVideo()
        //{
        //    Debug.Log("stop vidoe is callex...");
        //    videoPlayer.Stop();
        //    videoPlayer1.Stop();
        //    videoPlayer2.Stop();
        //}


        public void PlayTween()
        {
            //  Debug.Log("5 ..Now i called the play tween ...");
            // Debug.Log($"9 ...PlayTween .SwingTriger.RayCasting.pitcher...{SwingTriger.RayCasting.pitcher}..");
            Vector3 pitcherOffset = new Vector3(0, 0, 0);

            switch (SwingTriger.RayCasting.pitcher)
            {
                //Leave this one alone. Pitcher one should be the default position
                case 0:

                    posA.position = new Vector3(posADefault.position.x, posADefault.position.y, posADefault.position.z);
                    break;

                //Change amount needed to adjust for pitcher positioning here
                case 1:
                    posA.position = posY.position;

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
            // Abhiwan call this function to add the delay ..............
            //StartCoroutine("AddDelay");
            pitchTypes = Random.Range(0, 5);
            // Debug.Log($"9B ...tweenTimer {tweenTimer}.......pitchTypes...{pitchTypes}..");
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
            switch (SwingTriger.RayCasting.accuracySetting)
            {
                case 0: // Just does the code like it used to, as there are 50/50 ball and strike options
                        // print("9D  ..........0");

                   endPoses = Random.Range(0, 31);
                   // endPoses = 6;
                  //  Debug.Log($"111 ...............{endPoses}");
                    break;

                case 1:
                    int i = Random.Range(0, 101);
                    if (i <= 85) //use balls
                    {
                        print("9D  ......... 1");
                        int temp = Random.Range(0, Balls.Count + 1);
                        endPoses = Balls[temp];

                    }
                    else //use Strikes
                    {
                        print("9D  .........1");
                        int temp = Random.Range(0, Strikes.Count + 1);
                        endPoses = Strikes[temp];
                    }
                    break;

                case 2:
                    int x = Random.Range(0, 101);
                    if (x <= 95) // use balls
                    {
                        print("9D  if.........2");
                        int temp = Random.Range(0, Balls.Count + 1);
                        endPoses = Balls[temp];
                    }
                    else //use Strikes
                    {
                        print("9D  .........2");
                        int temp = Random.Range(0, Strikes.Count + 1);
                        endPoses = Strikes[temp];
                    }
                    break;
            }
            // Invoke("DrawLine",0.5f);
            // DrawLine();
            if (Strikes.Contains(endPoses))
            {
                 // Debug.Log($"111 ...............{endPoses}");
                isStrikes = true;
                isBall = false;
                BallType.text = "Strike";
                GameplayController.instance.correctAnswersPitchList.Add(pitchTypeEnum.ToString() + "-Strike");
                //FloatingPauseTime = 3;
                //GamePaused = true;
            }
            else if (Balls.Contains(endPoses))
            {
               // Debug.Log($"111 ...............{endPoses}");
                isBall = true;
                isStrikes = false;
                BallType.text = "Ball";
                GameplayController.instance.correctAnswersPitchList.Add(pitchTypeEnum.ToString() + "-Ball");
                //FloatingPauseTime = 3;
                //GamePaused = true;
                //  DrawLine();
            }

        }


        private void DrawLine()
        {
            if (isBall && !isSwing)
            {
                lineRenderer.material = lineRendererMat_G;
                //Debug.Log($"this is isBall {isBall} and this is isSwing {isSwing}");
               // Debug.Log($"22222");
                Restul.text = "Correct";
                decisionMade.text = "Didn’t Swing";
                GameplayController.instance.reactionTimeList.Add(ScoreHandler.timeSpan);
                GameplayController.instance.myAnswersPitchList.Add("Didn’t SwingCorrect");
                //GameplayController.instance.correctAnswersPitchList.Add(pitchTypeEnum);
                FinalResultsCanvasController.instance.correctAnsCount++;
            }
            else if (isBall && isSwing)
            {
                lineRenderer.material = lineRendererMat_R;
               //Debug.Log($"this is isBall {isBall} and this is isSwing {isSwing}");
               // Debug.Log($"22222");
                Restul.text = "Incorrect";
                decisionMade.text = "Swing";
                GameplayController.instance.reactionTimeList.Add(ScoreHandler.timeSpan);
                GameplayController.instance.myAnswersPitchList.Add("SwingIncorrect");
               // GameplayController.instance.correctAnswersPitchList.Add(pitchTypeEnum);
            }

            if (isStrikes && isSwing)
            {
                lineRenderer.material = lineRendererMat_G;
                //Debug.Log($"this is isStrikes {isStrikes} and this is isSwing {isSwing}");
               // Debug.Log($"22222");
                Restul.text = "Correct";
                decisionMade.text = "Swing";
                GameplayController.instance.reactionTimeList.Add(ScoreHandler.timeSpan);
                GameplayController.instance.myAnswersPitchList.Add("SwingCorrect");
              //  GameplayController.instance.correctAnswersPitchList.Add(pitchTypeEnum);
                FinalResultsCanvasController.instance.correctAnsCount++;
            }
            else if(isStrikes && !isSwing)
            {
                lineRenderer.material = lineRendererMat_R;
               // Debug.Log($"this is isStrikes {isStrikes} and this is isSwing {isSwing}");
                //Debug.Log($"22222");
                Restul.text = "Incorrect";
                decisionMade.text = "Didn’t Swing";
                GameplayController.instance.reactionTimeList.Add(ScoreHandler.timeSpan);
                GameplayController.instance.myAnswersPitchList.Add("Didn’t SwingIncorrect");
               // GameplayController.instance.correctAnswersPitchList.Add(pitchTypeEnum);
            }
            ScoreHandler.timeSpan = 0;


            lineRenderer.positionCount = curveResolution + 1;

            lineRenderer.startWidth = .1f;
            lineRenderer.endWidth = .01f;

            Vector3 p1 = posA.position;

            for (int i = 1; i < curveResolution; i++)
            {
                float p = i / (float)curveResolution;
                Vector3 p2 = CalcPositionOnCurve(p);
                lineRenderer.enabled = true;
                lineRenderer.SetPosition((i - 1), p1);
                p1 = p2;
                // Debug.Log($"P1 position... {i-1} "+p1);
            }
            lineRenderer.SetPosition(curveResolution - 1, p1);
             //Debug.Log($"posB position... {posB.position}  and local position is {posB.localPosition}"  );
            lineRenderer.SetPosition(curveResolution, posB.position);
            
            // Time.timeScale = 0;
            // Debug.Log(" Time.timeScale " + Time.timeScale);

            isSwing = false;
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


}