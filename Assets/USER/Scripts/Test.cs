using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    public GameObject[] orderArray;
    public int stepNumber = -1;

    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i<= orderArray.Length; i++)
        orderArray[i].SetActive(false);
        //orderArray[1].SetActive(false);
        //orderArray[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ToggleOrderControl(orderArray);
    }

    public void ToggleOrderControl(GameObject[] workingArray)
    {

        if(OVRInput.GetDown(OVRInput.Button.One))
        {
            stepNumber++;
        }

        //if (Input.GetKeyDown(KeyCode.Space)) //SPACE REPRESENTS IF TASK IS DONE SUCCESSFULLY
        //{
        //}
    
        if (stepNumber >= 0 && stepNumber < workingArray.Length)
        {
            workingArray[stepNumber].SetActive(true);
        }

        //switch(stepNumber)
        //{
        //    case 1:
        //        workingArray[0].SetActive(true);
        //        workingArray[1].SetActive(false);
        //        workingArray[2].SetActive(false);
        //        break;

        //    case 2:
        //        break;

        //    case 3:
        //        break;

        //    default:
        //        break;
        //}
    }
}
