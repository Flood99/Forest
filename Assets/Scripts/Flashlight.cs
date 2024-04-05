using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Light flashlight;
    private bool lightOn = true;
    // Start is called before the first frame update
    void Start()
    {
        flashlight =  GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            lightOn =!lightOn;
            Debug.Log("Light");
        }
        if(lightOn)
        {
            flashlight.intensity = 10;
        }else{
            flashlight.intensity = 0;
        }
    }
}
