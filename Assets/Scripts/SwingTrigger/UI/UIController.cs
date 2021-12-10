using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abhiwan added the namespace
namespace SwingTriger
{
    public class UIController : MonoBehaviour
    {
        private int gameState;
        public int UIType;
       // public GameObject rend;
        public Canvas rend;
        public static bool settingsOpen = false;
        public static bool settingsPanel = false;
        public static bool playAgainOpen = false;
        public static bool finalResultOpen = false;
        public static bool isFirstTimePlay = true;
        public static bool isInstructionOpen = false;

        void Start()
        {
            rend = GetComponent<Canvas>();
            rend.enabled = true;
           // rend.SetActive(true);
        }

        void Update()
        {
            gameState = SwingTriger.RayCasting.gameState;
            Visible();
           
            //Debug.Log("Game state ... "+ gameState);

        }

        private void Visible()
        {
           // Debug.Log("gameState "+ gameState);
            switch (gameState)
            {
                #region not in use
                /*  case 0:
                      // Debug.Log("ScoreHandler.GameOver ... " + !ScoreHandler.GameOver);
                      if (!ScoreHandler.GameOver)
                      {
                          //Debug.Log("UIType ... " + UIType);
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
                          // Debug.Log("UIType ... " + UIType);
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
                      break;*/
                #endregion

                #region not in use
               /* case 1:
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
                        }
                    }
                    break;*/
                #endregion


                case 2:
                     //Debug.Log("!SwingTriger.ScoreHandler.GameOver ... " + !SwingTriger.ScoreHandler.GameOver);
                    if (!SwingTriger.ScoreHandler.GameOver)
                    {
                       // Debug.Log("if ... ");
                        // Debug.Log($"this gameobj nam {this.gameObject.name} ... uitype {UIType}");
                        switch (UIType)
                        {
                            case 0:
                                if (settingsPanel)
                                {
                                    rend.enabled = true;
                                   // rend.SetActive(true);
                                }
                                else
                                {
                                    rend.enabled = false;
                                   // rend.SetActive(false);
                                }
                                break;
                            case 1:
                                 rend.enabled = false;
                               // rend.SetActive(false);
                                break;
                            case 2:

                                 rend.enabled = false;
                               // rend.SetActive(false);
                                break;
                            case 3:

                                 rend.enabled = true;
                               // rend.SetActive(true);
                                break;
                            case 4:
                              // rend.SetActive(false);
                                rend.enabled = false;
                                break;
                            case 5:
                                //  Debug.Log($"this gameobj nam {this.gameObject.name}called from 5 if .....");
                                // this condition is added by abhiwan ......
                                if (settingsOpen)
                                {
                                    // Debug.Log($"this gameobj nam {this.gameObject.name} called from 5 else ....."+ settingsOpen);
                                    rend.enabled = true;
                                  //  rend.SetActive(true);
                                }
                                else
                                {
                                    // Debug.Log($"this gameobj nam {this.gameObject.name} called from 5 else ....."+ settingsOpen);
                                   rend.enabled = false;
                                   // rend.SetActive(false);
                                }
                                break;
                            case 6:
                                if (isInstructionOpen)
                                {
                                    // Debug.Log($"this gameobj nam {this.gameObject.name} called from 5 else ....."+ settingsOpen);
                                     rend.enabled = true;
                                  //  rend.SetActive(true);
                                }
                                else
                                {
                                    // Debug.Log($"this gameobj nam {this.gameObject.name} called from 5 else ....."+ settingsOpen);
                                   rend.enabled = false;
                                   // rend.SetActive(false);
                                }
                                break;
                        }
                    }
                    else if(isFirstTimePlay)
                    {
                        //Debug.Log("else ... ");
                        // Debug.Log($"this gameobj nam {this.gameObject.name} else UIType ... " + UIType);
                        switch (UIType)
                        {
                            case 0:
                                if (settingsPanel)
                                {
                                    rend.enabled = true;
                                    //rend.SetActive(true);
                                }
                                else
                                {
                                    rend.enabled = false;
                                   // rend.SetActive(false);
                                }
                                break;
                            case 1:
                                rend.enabled = true;
                               // rend.SetActive(true);
                                break;
                            case 2:
                                rend.enabled = true;
                                //rend.SetActive(true);
                                break;
                            case 3:
                                rend.enabled = false;
                                //rend.SetActive(false);
                                break;
                            case 4:
                                rend.enabled = false;
                                //rend.SetActive(false);
                                break;
                            case 5:
                                if (settingsOpen)
                                {
                                   
                                    rend.enabled = true;
                                   // rend.SetActive(true);
                                }
                                else
                                {
                                   
                                    rend.enabled = false;
                                   // rend.SetActive(false);
                                }
                                break;
                            case 6:
                                if (isInstructionOpen)
                                {
                                    
                                    rend.enabled = true;
                                   // rend.SetActive(true);
                                }
                                else
                                {
                                    
                                   rend.enabled = false;
                                   // rend.SetActive(false);
                                }
                                break;
                        }
                    }
                    else
                    {
                        //Debug.Log("else ... ");
                        // Debug.Log($"this gameobj nam {this.gameObject.name} else UIType ... " + UIType);
                        switch (UIType)
                        {
                            case 0:
                                if (settingsPanel)
                                {
                                   rend.enabled = true;
                                   // rend.SetActive(true);
                                }
                                else
                                {
                                    rend.enabled = false;
                                   // rend.SetActive(false);
                                }
                                break;
                            case 1:
                                if (playAgainOpen)
                                {
                                    //Debug.Log($"this is playAgain panel");
                                   rend.enabled = true;
                                  //  rend.SetActive(true);
                                }
                                else
                                {
                                    rend.enabled = false;
                                  //  rend.SetActive(false);
                                }
                                break;
                            case 2:
                                rend.enabled = true;
                                //rend.SetActive(true);
                                break;
                            case 3:
                                rend.enabled = false;
                                //rend.SetActive(false);
                                break;
                            case 4:

                                if (finalResultOpen)
                                {
                                    rend.enabled = true;
                                   // rend.SetActive(true);
                                    // Debug.Log($"this is final result panel");
                                }
                                else
                                {
                                    rend.enabled = false;
                                   // rend.SetActive(false);
                                }
                                break;
                            case 5:
                                if (settingsOpen)
                                {
                                   
                                    rend.enabled = true;
                                   // rend.SetActive(true);
                                }
                                else
                                {
                                   
                                    rend.enabled = false;
                                   // rend.SetActive(false);
                                }
                                break;
                            case 6:
                                if (isInstructionOpen)
                                {
                                    // Debug.Log($"this gameobj nam {this.gameObject.name} called from 5 else ....."+ settingsOpen);
                                    rend.enabled = true;
                                   // rend.SetActive(true);
                                }
                                else
                                {
                                    // Debug.Log($"this gameobj nam {this.gameObject.name} called from 5 else ....."+ settingsOpen);
                                    rend.enabled = false;
                                   // rend.SetActive(false);
                                }
                                break;
                        }
                    }
                    break;
            }
        }

        bool isInvokeCalled;
        IEnumerator IntervalBetweenPitcher()
        {
           
                Debug.Log("1 ...Again start the applicatio ......");
                isInvokeCalled = true;
                Debug.Log("2.........Again start the applicatio ......");
                yield return new WaitForSeconds(3f);
                Debug.Log("3...called after 3 second interval.....Again start the applicatio ......");
                SwingTriger.RayCasting.gameJustStarted = true;
                SwingTriger.ScoreHandler.GameOver = false;
                isInvokeCalled = false;
            }
        }

    }