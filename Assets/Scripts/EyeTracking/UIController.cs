using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private int gameState;
    public int UIType;
    public Canvas rend;
    public static bool settingsOpen = false;

    void Start()
    {
        rend = GetComponent<Canvas>();
        rend.enabled = true;
    }

    void Update()
    {
        Visible();
        gameState = RayCasting.gameState;
    }

    private void Visible()
    {
        switch (gameState)
        {
            case 0:
                if (!ScoreHandler.GameOver)
                {
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

            case 1:
                if (!ScoreHandler1.GameOver)
                {
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
                            if (!BaseballController1.hasChosenAnswer && !BaseballController1.isTweening && BaseballController1.hasThrownOne && !BaseballController1.playingVid)
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
                    }
                }
                else
                {
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