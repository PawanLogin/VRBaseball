using UnityEngine;
using UnityEngine.SceneManagement;

// Abhiwan added the namespace
namespace SwingTriger
{
    public class RayCasting : MonoBehaviour
    {

        //NOTE TO SELF    IMPORTANT     Make sure to have this script completely disable the balls/strikes objects
        //so that they do not block the cast for any other gamemode
        public ScoreHandler scoreHandler;
        public static bool overBall = false;
        public static bool overUI;

        public static bool leftHanded = false;
        public static bool menu1 = true;
        public static bool gameJustStarted = false;
        public static int guess;
        public static bool Count = false;
        public static int gameState;
        private bool resetGame = true;
       

        public static int accuracySetting = 0;
        public static int velocitySetting = 0;
        public static int pitcher = 0;
        public static bool isPause = false;

        public GameObject pauseButton;
        public GameObject ResumeButton;

        int layerMask = 1 << 4;
        int layerMask2 = 1 << 1;

        void Start()
        {
            GameReset();
        }

        // Update is called once per frame
        void Update()
        {
            if (resetGame)
                GameReset();
            InteractRaycast();
            rotateCam();

            if (isPause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        void GameReset()
        {
            resetGame = false;
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("EyeTracking"))
            {
                gameState = 0;
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("BinaryPitch"))
            {
                gameState = 1;
            }
            // Added by Abhiwan
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SwingTrigger"))
            {
                gameState = 2;
            }
        }

        void rotateCam()
        {
            float h = 2 * Input.GetAxis("Mouse X");
            float v = -2 * Input.GetAxis("Mouse Y");
            transform.Rotate(v, h, 0);
        }

        void InteractRaycast()
        {

            RaycastHit intRayHit;
            RaycastHit intRayHit2;
            RaycastHit intRayHit3;

            float rayLength = 30.0f;

            Vector3 p1 = transform.position + Vector3.up * Physics.defaultContactOffset;

            Vector3 p2 = transform.position + (Vector3.up * rayLength) * Physics.defaultContactOffset;

            Debug.DrawLine(p1, p2);

            bool hitFound = Physics.CapsuleCast(p1, p2, .57f, transform.forward, out intRayHit, 30);

            bool hitFound2 = Physics.CapsuleCast(p1, p2, .57f, transform.forward, out intRayHit2, 30, layerMask);

            bool hitFound3 = Physics.CapsuleCast(p1, p2, .57f, transform.forward, out intRayHit3, 30, layerMask2);

            if (hitFound3)
            {
                GameObject hitGameObject = intRayHit3.transform.gameObject;
                if (gameState == 1)
                {
                    if (hitGameObject.name == "FastStrike")
                    {
                        if (!ScoreHandler1.GameOver)
                        {
                            if (Input.anyKeyDown)
                            {
                                Count = true;
                                guess = 0;
                                BaseballController1.hasChosenAnswer = true;
                            }
                            overUI = true;
                        }
                    }

                    if (hitGameObject.name == "FastBall")
                    {
                        if (!ScoreHandler1.GameOver)
                        {
                            if (Input.anyKeyDown)
                            {
                                Count = true;
                                guess = 0;
                                BaseballController1.hasChosenAnswer = true;
                            }
                            overUI = true;
                        }
                    }

                    if (hitGameObject.name == "CurveStrike")
                    {
                        if (!ScoreHandler1.GameOver)
                        {
                            if (Input.anyKeyDown)
                            {
                                Count = true;
                                guess = 1;
                                BaseballController1.hasChosenAnswer = true;
                            }
                            overUI = true;
                        }
                    }

                    if (hitGameObject.name == "CurveBall")
                    {
                        if (!ScoreHandler1.GameOver)
                        {
                            if (Input.anyKeyDown)
                            {
                                Count = true;
                                guess = 1;
                                BaseballController1.hasChosenAnswer = true;
                            }
                            overUI = true;
                        }
                    }

                    if (hitGameObject.name == "SliderStrike")
                    {
                        if (!ScoreHandler1.GameOver)
                        {
                            if (Input.anyKeyDown)
                            {
                                Count = true;
                                guess = 2;
                                BaseballController1.hasChosenAnswer = true;
                            }
                            overUI = true;
                        }
                    }

                    if (hitGameObject.name == "SliderBall")
                    {
                        if (!ScoreHandler1.GameOver)
                        {
                            if (Input.anyKeyDown)
                            {
                                Count = true;
                                guess = 2;
                                BaseballController1.hasChosenAnswer = true;
                            }
                            overUI = true;
                        }
                    }

                    if (hitGameObject.name == "ChangeStrike")
                    {
                        if (!ScoreHandler1.GameOver)
                        {
                            if (Input.anyKeyDown)
                            {
                                Count = true;
                                guess = 3;
                                BaseballController1.hasChosenAnswer = true;
                            }
                            overUI = true;
                        }
                    }

                    if (hitGameObject.name == "ChangeBall")
                    {
                        if (!ScoreHandler1.GameOver)
                        {
                            if (Input.anyKeyDown)
                            {
                                Count = true;
                                guess = 3;
                                BaseballController1.hasChosenAnswer = true;
                            }
                            overUI = true;
                        }
                    }
                }
            }

            if (hitFound2)
            {
                GameObject hitGameObject = intRayHit2.transform.gameObject;
                if (gameState == 0)
                {
                    if (hitGameObject.name == "Baseball_Model")
                    {
                        overBall = true;
                    }
                    else
                    {
                        overBall = false;
                    }
                }
            }
            else
            {
                overBall = false;
            }

            if (hitFound)
            {
                GameObject hitGameObject = intRayHit.transform.gameObject;
                switch (gameState)
                {
                    case 0:
                        if (UIController.settingsOpen)
                        {

                            if (hitGameObject.name == "SwingButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    SceneManager.LoadScene("SwingTrigger", LoadSceneMode.Single);
                                    resetGame = true;
                                }
                            }

                            if (hitGameObject.name == "BudButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    pitcher = 0;
                                }
                            }
                            if (hitGameObject.name == "HiroButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    pitcher = 1;
                                }
                            }
                            if (hitGameObject.name == "DanteButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    pitcher = 2;
                                }
                            }

                            if (hitGameObject.name == "BinaryButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    SceneManager.LoadScene("BinaryPitch", LoadSceneMode.Single);
                                    resetGame = true;
                                }
                            }

                            if (hitGameObject.name == "WildButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    accuracySetting = 0;
                                }
                            }
                            if (hitGameObject.name == "AverageButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    accuracySetting = 1;
                                }
                            }
                            if (hitGameObject.name == "PinPointButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    accuracySetting = 2;
                                }
                            }

                            if (hitGameObject.name == "SpeedOne")
                            {
                                if (Input.anyKeyDown)
                                {
                                    velocitySetting = 1;
                                }
                            }
                            if (hitGameObject.name == "SpeedTwo")
                            {
                                if (Input.anyKeyDown)
                                {
                                    velocitySetting = 2;
                                }
                            }
                            if (hitGameObject.name == "SpeedThree")
                            {
                                if (Input.anyKeyDown)
                                {
                                    velocitySetting = 3;
                                }
                            }
                            if (hitGameObject.name == "SpeedFour")
                            {
                                if (Input.anyKeyDown)
                                {
                                    velocitySetting = 4;
                                }
                            }
                            if (hitGameObject.name == "SpeedFive")
                            {
                                if (Input.anyKeyDown)
                                {
                                    velocitySetting = 5;
                                }
                            }
                            if (hitGameObject.name == "SpeedSix")
                            {
                                if (Input.anyKeyDown)
                                {
                                    velocitySetting = 6;
                                }
                            }
                            if (hitGameObject.name == "ExitSettingsButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    UIController.settingsOpen = false;
                                }
                            }
                            if (hitGameObject.name == "RightHand")
                            {
                                if (Input.anyKeyDown && ScoreHandler.GameOver)
                                {
                                    leftHanded = false;
                                }
                                overUI = true;

                            }

                            if (hitGameObject.name == "LeftHand")
                            {
                                if (Input.anyKeyDown && ScoreHandler.GameOver)
                                {
                                    leftHanded = true;
                                }
                                overUI = true;
                            }
                        }

                        if (hitGameObject.name == "SettingsButton" && ScoreHandler.GameOver)
                        {
                            if (Input.anyKeyDown)
                            {
                                UIController.settingsOpen = true;
                            }
                        }

                        // Debug.Log($"hitGameObject.name {hitGameObject.name}");
                        if (hitGameObject.name == "PlayButton")
                        {

                            if (Input.anyKeyDown && ScoreHandler.GameOver)
                            {
                                // Debug.Log($"Input.anyKeyDown {Input.anyKeyDown } ScoreHandler.GameOver {ScoreHandler.GameOver}");
                                ScoreHandler.GameOver = false;
                                gameJustStarted = true;
                            }
                            overUI = true;
                        }

                        if (hitGameObject.name == "BackButton")
                        {

                            if (Input.anyKeyDown)
                            {
                                ScoreHandler.GameOver = true;
                            }
                            overUI = true;

                        }

                        if (hitGameObject.name == "ExitButton")
                        {
                            if (Input.anyKeyDown && ScoreHandler.GameOver)
                            {
                                Application.Quit();

                            }
                            overUI = true;

                        }
                        if (hitGameObject.name == "RightArrowHitBox")
                        {
                            if (ScoreHandler.GameOver)
                            {
                                if (Input.anyKeyDown)
                                {
                                    menu1 = false;
                                }
                                overUI = true;
                            }

                        }

                        if (hitGameObject.name == "LeftArrowHitBox")
                        {
                            if (ScoreHandler.GameOver)
                            {
                                if (Input.anyKeyDown)
                                {
                                    menu1 = true;
                                }
                                overUI = true;
                            }
                        }
                        break;

                    case 1:

                        if (UIController.settingsOpen)
                        {
                            if (hitGameObject.name == "SwingButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    //SceneManager.LoadScene("SwingTrigger", LoadSceneMode.Single);         // un-comment this once swing trigger is built
                                    //resetGame = true;
                                }
                            }
                            if (hitGameObject.name == "EyeButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    SceneManager.LoadScene("EyeTracking", LoadSceneMode.Single);
                                    resetGame = true;
                                }
                            }
                            if (hitGameObject.name == "SpeedOne")
                            {
                                if (Input.anyKeyDown)
                                {
                                    velocitySetting = 1;
                                }
                            }
                            if (hitGameObject.name == "SpeedTwo")
                            {
                                if (Input.anyKeyDown)
                                {
                                    velocitySetting = 2;
                                }
                            }
                            if (hitGameObject.name == "SpeedThree")
                            {
                                if (Input.anyKeyDown)
                                {
                                    velocitySetting = 3;
                                }
                            }
                            if (hitGameObject.name == "SpeedFour")
                            {
                                if (Input.anyKeyDown)
                                {
                                    velocitySetting = 4;
                                }
                            }
                            if (hitGameObject.name == "SpeedFive")
                            {
                                if (Input.anyKeyDown)
                                {
                                    velocitySetting = 5;
                                }
                            }
                            if (hitGameObject.name == "SpeedSix")
                            {
                                if (Input.anyKeyDown)
                                {
                                    velocitySetting = 6;
                                }
                            }

                            if (hitGameObject.name == "WildButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    accuracySetting = 0;
                                }
                            }
                            if (hitGameObject.name == "AverageButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    accuracySetting = 1;
                                }
                            }
                            if (hitGameObject.name == "PinPointButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    accuracySetting = 2;
                                }
                            }
                            if (hitGameObject.name == "ExitSettingsButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    UIController.settingsOpen = false;
                                }
                            }

                            if (hitGameObject.name == "RightHand")
                            {
                                if (Input.anyKeyDown && ScoreHandler1.GameOver)
                                {
                                    leftHanded = false;
                                }
                                overUI = true;

                            }

                            if (hitGameObject.name == "LeftHand")
                            {
                                if (Input.anyKeyDown && ScoreHandler1.GameOver)
                                {
                                    leftHanded = true;
                                }
                                overUI = true;

                            }
                        }

                        if (hitGameObject.name == "SettingsButton" && ScoreHandler.GameOver)
                        {
                            if (Input.anyKeyDown)
                            {
                                UIController.settingsOpen = true;
                            }
                        }


                        if (hitGameObject.name == "PlayButton")
                        {
                            if (Input.anyKeyDown && ScoreHandler1.GameOver)
                            {
                                ScoreHandler1.GameOver = false;
                                gameJustStarted = true;
                            }
                            overUI = true;
                        }

                        if (hitGameObject.name == "BackButton")
                        {

                            if (Input.anyKeyDown)
                            {
                                ScoreHandler1.GameOver = true;
                            }
                            overUI = true;

                        }

                        if (hitGameObject.name == "ExitButton")
                        {
                            if (Input.anyKeyDown && ScoreHandler1.GameOver)
                            {
                                Application.Quit();

                            }
                            overUI = true;

                        }

                        if (hitGameObject.name == "RightArrowHitBox")
                        {
                            if (ScoreHandler1.GameOver)
                            {
                                if (Input.anyKeyDown)
                                {
                                    menu1 = false;
                                }
                                overUI = true;
                            }

                        }

                        if (hitGameObject.name == "LeftArrowHitBox")
                        {
                            if (ScoreHandler1.GameOver)
                            {
                                if (Input.anyKeyDown)
                                {
                                    menu1 = true;
                                }
                                overUI = true;
                            }
                        }
                        break;
// this block belong to the eyetracking mode of the game .................................................................................................
                    // This block of the code is added by Abhiwan ....................................
                    case 2:

                        if (SwingTriger.UIController.settingsPanel)
                        {
                            if (hitGameObject.name == "BinaryButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    SceneManager.LoadScene("BinaryPitch", LoadSceneMode.Single);         // un-comment this once swing trigger is built
                                    resetGame = true;
                                }
                            }
                            if (hitGameObject.name == "EyeButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    SceneManager.LoadScene("EyeTracking", LoadSceneMode.Single);
                                    resetGame = true;
                                }
                            }

                            if (hitGameObject.name == "BudButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    pitcher = 0;
                                }
                            }
                            if (hitGameObject.name == "HiroButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    pitcher = 1;
                                }
                            }
                            if (hitGameObject.name == "DanteButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    pitcher = 2;
                                }
                            }

                            if (hitGameObject.name == "SpeedOne")
                            {
                                if (Input.anyKeyDown)
                                {
                                    velocitySetting = 1;
                                }
                            }
                            if (hitGameObject.name == "SpeedTwo")
                            {
                                if (Input.anyKeyDown)
                                {
                                    velocitySetting = 2;
                                }
                            }
                            if (hitGameObject.name == "SpeedThree")
                            {
                                if (Input.anyKeyDown)
                                {
                                    velocitySetting = 3;
                                }
                            }
                            if (hitGameObject.name == "SpeedFour")
                            {
                                if (Input.anyKeyDown)
                                {
                                    velocitySetting = 4;
                                }
                            }
                            if (hitGameObject.name == "SpeedFive")
                            {
                                if (Input.anyKeyDown)
                                {
                                    velocitySetting = 5;
                                }
                            }
                            if (hitGameObject.name == "SpeedSix")
                            {
                                if (Input.anyKeyDown)
                                {
                                    velocitySetting = 6;
                                }
                            }

                            if (hitGameObject.name == "WildButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    accuracySetting = 0;
                                }
                            }
                            if (hitGameObject.name == "AverageButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    accuracySetting = 1;
                                }
                            }
                            if (hitGameObject.name == "PinPointButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    accuracySetting = 2;
                                }
                            }

                            if (hitGameObject.name == "ExitSettingsButton")
                            {
                                if (Input.anyKeyDown)
                                {
                                    SwingTriger.UIController.settingsPanel = false;
                                }
                            }

                            if (hitGameObject.name == "RightHand")
                            {
                                if (Input.anyKeyDown && SwingTriger.ScoreHandler.GameOver)
                                {
                                    leftHanded = false;
                                }
                                overUI = true;

                            }
                            if (hitGameObject.name == "LeftHand")
                            {
                                if (Input.anyKeyDown && SwingTriger.ScoreHandler.GameOver)
                                {
                                    leftHanded = true;
                                }
                                overUI = true;

                            }
                        }

                        if (hitGameObject.name == "SettingsButton" && SwingTriger.ScoreHandler.GameOver)
                        {
                            if (Input.anyKeyDown)
                            {
                                SwingTriger.UIController.settingsPanel = true;
                            }
                        }
                        // Debug.Log($"hitGameObject.name {hitGameObject.name}");
                        if (hitGameObject.name == "PlayButton")
                        {
                           // Debug.Log($"SwingTriger.ScoreHandler.GameOver {SwingTriger.ScoreHandler.GameOver}");
                            if (Input.anyKeyDown && SwingTriger.ScoreHandler.GameOver)
                            {
                               // Debug.Log("Hi ..."+ Input.anyKeyDown);
                                SwingTriger.ScoreHandler.GameOver = false;
                                SwingTriger.UIController.settingsPanel = false;
                                gameJustStarted = true;
                            }
                            overUI = true;
                        }

                        if (hitGameObject.name == "BackButton")
                        {
                            if (Input.anyKeyDown)
                            {
                                SwingTriger.ScoreHandler.GameOver = true;
                                scoreHandler.pitcherCounter.text = "0";
                                UIController.isFirstTimePlay = true;
                                SwingTriger.UIController.settingsOpen = false;
                                SwingTriger.ScoreHandler.strikeZoneVisible = false;
                                SwingTriger.BaseballController.instance.lineRenderer.enabled = false;

                                GameplayController.instance.reactionTimeList.Clear();
                                GameplayController.instance.myAnswersPitchList.Clear();
                                GameplayController.instance.correctAnswersPitchList.Clear();

                                FinalResultsCanvasController.instance.correctAnsCount = 0;
                            }
                            overUI = true;
                        }

                        if (hitGameObject.name == "Pause")
                        {

                            if (Input.anyKeyDown)
                            {
                                isPause = true;
                                //Time.timeScale = 0;
                                pauseButton.gameObject.SetActive(false);
                                ResumeButton.gameObject.SetActive(true);
                                Debug.LogError($"this is back button {hitGameObject.name}");
                            }
                            overUI = true;

                        }

                        if (hitGameObject.name == "Resume")
                        {

                            if (Input.anyKeyDown)
                            {
                                isPause = false;
                                pauseButton.gameObject.SetActive(true);
                                ResumeButton.gameObject.SetActive(false);
                                Debug.LogError($"this is back button {hitGameObject.name}");
                            }
                            overUI = true;

                        }

                        if (hitGameObject.name == "ExitButton")
                        {
                            if (Input.anyKeyDown && SwingTriger.ScoreHandler.GameOver)
                            {
                                // Below Lines edit by Abhiwan
                                // Quit the application in editor mode as well.
#if UNITY_EDITOR
                                UnityEditor.EditorApplication.isPlaying = false;
#else
                            Application.Quit();
#endif

                            }
                            overUI = true;

                        }

                        if (hitGameObject.name == "RightArrowHitBox")
                        {
                            if (SwingTriger.ScoreHandler.GameOver)
                            {
                                if (Input.anyKeyDown)
                                {
                                    menu1 = false;
                                }
                                overUI = true;
                            }

                        }

                        if (hitGameObject.name == "LeftArrowHitBox")
                        {
                            if (SwingTriger.ScoreHandler.GameOver)
                            {
                                if (Input.anyKeyDown)
                                {
                                    menu1 = true;
                                }
                                overUI = true;
                            }
                        }

                        if (hitGameObject.name == "InstructionsButton")
                        {
                            if (Input.anyKeyDown)
                            {
                                UIController.isInstructionOpen = true;
                                isPause = true;
                            }
                            overUI = true;
                        }

                        if (hitGameObject.name == "Ok")
                        {
                            if (Input.anyKeyDown)
                            {
                                UIController.isInstructionOpen = false;
                                isPause = false;
                            }
                            overUI = true;
                        }

                        break;
                }
            }
            else
            {
                overUI = false;
            }

        }
    }
}