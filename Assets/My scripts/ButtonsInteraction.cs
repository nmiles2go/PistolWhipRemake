using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonsInteraction : MonoBehaviour
{

    public GameObject cube;
    public Color myColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor()
    {
        cube.GetComponent<Renderer>().material.color = myColor;
    }
}
