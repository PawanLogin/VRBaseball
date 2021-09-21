using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorCode : MonoBehaviour
{
    private int gameState;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameState = RayCasting.gameState;
      //  Debug.Log("gameState "+ gameState);
        ChangeColor();
    }

    void ChangeColor()
    {
        switch (gameState)
        {
            case 0:
               
                if (RayCasting.overBall)// && !ScoreHandler.GameOver)
                {
                    GetComponent<Image>().color = Color.green;
                }
               // 
                else if (RayCasting.overUI && ScoreHandler.GameOver)
                {
                    GetComponent<Image>().color = Color.gray;
                }
                else
                {
                    GetComponent<Image>().color = Color.red;
                }
                break;

            case 1:
                if (RayCasting.overUI && ScoreHandler.GameOver)
                {
                    GetComponent<Image>().color = Color.gray;
                }
                else
                {
                    GetComponent<Image>().color = Color.red;
                }
                break;

            case 2:
                if (RayCasting.overUI && ScoreHandler.GameOver)
                {
                    GetComponent<Image>().color = Color.gray;
                }
                else
                {
                    GetComponent<Image>().color = Color.red;
                }
                break;

        }


    }
    
}
