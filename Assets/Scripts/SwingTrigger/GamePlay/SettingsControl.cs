using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace SwingTriger
{
    public class SettingsControl : MonoBehaviour
    {

        public int type;
        public int subType;
        private Vector3 originalScale;

        private CanvasRenderer rend;

        // Start is called before the first frame update
        void Start()
        {
            rend = GetComponent<CanvasRenderer>();
            originalScale = transform.localScale;
        }




        // Update is called once per frame
        void Update()
        {
            switch (type)
            {
                case 0://HandedMode
                    if (SwingTriger.RayCasting.leftHanded)
                    {
                        switch (subType)
                        {
                            case 0:
                                transform.localScale = originalScale;
                                break;
                            case 1:
                                transform.localScale = Vector3.zero;
                                break;
                        }
                    }
                    else
                    {
                        switch (subType)
                        {
                            case 0:
                                transform.localScale = Vector3.zero;
                                break;
                            case 1:
                                transform.localScale = originalScale;
                                break;
                        }
                    }
                    break;

                case 1://Pitcher
                    if (SwingTriger.RayCasting.pitcher == subType)
                    {
                        transform.localScale = originalScale;
                    }
                    else
                    {
                        transform.localScale = Vector3.zero;
                    }
                    break;

                case 2://VelocitySetting
                    if (SwingTriger.RayCasting.velocitySetting == subType + 1)
                    {
                        transform.localScale = originalScale;
                    }
                    else
                    {
                        transform.localScale = Vector3.zero;
                    }
                    break;

                case 3://AccuracySetting

                    if (SwingTriger.RayCasting.accuracySetting == subType)
                    {
                        transform.localScale = originalScale;
                    }
                    else
                    {
                        transform.localScale = Vector3.zero;
                    }
                    break;
            }
        }
    }

}
