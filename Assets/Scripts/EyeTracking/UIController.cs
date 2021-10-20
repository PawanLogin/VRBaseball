using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private int gameState;
    public int UIType;
    public Canvas rend;
    public static bool settingsOpen = false;
    public static bool isInstructionOpen = false;
    public static bool isFirstTimePlay = true;
    public static bool finalResultOpen = false;
    public static bool playAgainOpen = false;

    

    void Start()
    {
        rend = GetComponent<Canvas>();
        rend.enabled = true;
    }

    void Update()
    {
        Visible();
        gameState = RayCasting.gameState;
        //Debug.Log("Game state ... "+ gameState);

    }

    private void Visible()
    {
        switch (gameState)
        {

            case 0:
                // Debug.Log("ScoreHandler.GameOver ... " + !ScoreHandler.GameOver);
                if (!ScoreHandler.GameOver)
                {
                    //Debug.Log("UIType ... " + UIType + " and " + gameState) ;
                    switch (UIType)
                    {
                        case 1:
                            rend.enabled = false;
                            break;
                        case 2:
                            if (finalResultOpen)
                            {
                                rend.enabled = true;
                                // Debug.Log($"this is final result panel");
                            }
                            else
                            {
                                rend.enabled = false;
                            }
                            break;
                        case 3:
                            rend.enabled = true;
                            break;
                        case 4:
                            rend.enabled = false;
                            break;
                        case 5:
                            rend.enabled = false;
                            break;
                        case 6:
                            if (isInstructionOpen)
                            {
                                // Debug.Log($"this gameobj nam {this.gameObject.name} called from 5 else ....."+ settingsOpen);
                                rend.enabled = true;
                            }
                            else
                            {
                                // Debug.Log($"this gameobj nam {this.gameObject.name} called from 5 else ....."+ settingsOpen);
                                rend.enabled = false;
                            }
                            break;

                    }
                }
                else if (isFirstTimePlay)
                {
                   // Debug.Log("UIType ... " + UIType + " and " + gameState);
                    switch (UIType)
                    {
                        case 1:
                            rend.enabled = true;
                            break;
                        case 2:
                            rend.enabled = false;
                            break;
                        case 3:
                            rend.enabled = false;
                            break;
                        case 4:
                            rend.enabled = false;
                            break;
                        case 5:
                            if (settingsOpen)
                            {
                                rend.enabled = true;
                            }
                            else
                            {
                                rend.enabled = false;
                            }
                            break;
                        case 6:
                            if (isInstructionOpen)
                            {
                                // Debug.Log($"this gameobj nam {this.gameObject.name} called from 5 else ....."+ settingsOpen);
                                rend.enabled = true;
                            }
                            else
                            {
                                // Debug.Log($"this gameobj nam {this.gameObject.name} called from 5 else ....."+ settingsOpen);
                                rend.enabled = false;
                            }
                            break;
                    }
                }
                else
                {
                    Debug.Log("UIType ... " + UIType + " and " + gameState);
                    switch (UIType)
                    {
                        case 1:
                            rend.enabled = true;
                            break;
                        case 2:
                            if (finalResultOpen)
                            {
                                rend.enabled = true;
                                // Debug.Log($"this is final result panel");
                            }
                            else
                            {
                                rend.enabled = false;
                            }
                            break;
                        case 3:
                            rend.enabled = false;
                            break;
                        case 4:
                            rend.enabled = false;
                            break;
                        case 5:
                            if (settingsOpen)
                            {
                                rend.enabled = true;
                            }
                            else
                            {
                                rend.enabled = false;
                            }
                            break;
                        case 6:
                            if (isInstructionOpen)
                            {
                                // Debug.Log($"this gameobj nam {this.gameObject.name} called from 5 else ....."+ settingsOpen);
                                rend.enabled = true;
                            }
                            else
                            {
                                // Debug.Log($"this gameobj nam {this.gameObject.name} called from 5 else ....."+ settingsOpen);
                                rend.enabled = false;
                            }
                            break;
                    }
                }
                break;

            case 1:
                // Debug.Log("ScoreHandler.GameOver ... " + !ScoreHandler1.GameOver);
                if (!ScoreHandler1.GameOver)
                {
                    //  Debug.Log("UIType ... " + UIType);
                    switch (UIType)
                    {
                        case 1:
                            rend.enabled = false;
                            break;
                        case 2:
                            rend.enabled = false;
                            break;
                        case 3:
                            rend.enabled = true;
                            break;
                        case 4:
                            if (!BaseballController1.hasChosenAnswer && !BaseballController1.isTweening && BaseballController1.hasThrownOne)
                            {
                                rend.enabled = true;
                            }
                            else
                            {
                                rend.enabled = false;
                            }
                            break;
                        case 5:
                            rend.enabled = false;
                            break;
                        case 6:
                            if (isInstructionOpen)
                            {
                                // Debug.Log($"this gameobj nam {this.gameObject.name} called from 5 else ....."+ settingsOpen);
                                rend.enabled = true;
                            }
                            else
                            {
                                // Debug.Log($"this gameobj nam {this.gameObject.name} called from 5 else ....."+ settingsOpen);
                                rend.enabled = false;
                            }
                            break;
                    }
                }
                else
                {
                    //  Debug.Log("UIType ... " + UIType);
                    switch (UIType)
                    {
                        case 1:
                            rend.enabled = true;
                            break;
                        case 2:
                            rend.enabled = true;
                            break;
                        case 3:
                            rend.enabled = false;
                            break;
                        case 4:
                            rend.enabled = false;
                            break;
                        case 5:
                            if (settingsOpen)
                            {
                                rend.enabled = true;
                            }
                            else
                            {
                                rend.enabled = false;
                            }
                            break;
                        case 6:
                            if (isInstructionOpen)
                            {
                                // Debug.Log($"this gameobj nam {this.gameObject.name} called from 5 else ....."+ settingsOpen);
                                rend.enabled = true;
                            }
                            else
                            {
                                // Debug.Log($"this gameobj nam {this.gameObject.name} called from 5 else ....."+ settingsOpen);
                                rend.enabled = false;
                            }
                            break;
                    }
                }
                break;
            case 2:
                // Debug.Log("ScoreHandler.GameOver ... " + !ScoreHandler.GameOver);
                if (!ScoreHandler.GameOver)
                {
                    // Debug.Log("if UIType ... " + UIType);
                    switch (UIType)
                    {
                        case 1:
                            rend.enabled = false;
                            break;
                        case 2:
                            rend.enabled = false;
                            break;
                        case 3:
                            rend.enabled = true;
                            break;
                        case 4:
                            rend.enabled = false;
                            break;
                        case 5:
                            rend.enabled = false;
                            break;
                    }
                }
                else
                {
                    // Debug.Log("else UIType ... " + UIType);
                    switch (UIType)
                    {
                        case 1:
                            rend.enabled = true;
                            break;
                        case 2:
                            rend.enabled = true;
                            break;
                        case 3:
                            rend.enabled = false;
                            break;
                        case 4:
                            rend.enabled = false;
                            break;
                        case 5:
                            if (settingsOpen)
                            {
                                rend.enabled = true;
                            }
                            else
                            {
                                rend.enabled = false;
                            }
                            break;
                    }
                }
                break;


        }
    }

}
