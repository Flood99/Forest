using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public GameObject flashlight;
    public GameObject glowstick;
    public GameObject throwFlare;
    bool flashlightEquipped = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            flashlightEquipped = !flashlightEquipped;
            
        }
        if(flashlightEquipped)
        {
            flashlight.SetActive(true);
            glowstick.SetActive(false);
        }else{
            flashlight.SetActive(false);
            glowstick.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            ThrowFlare();
        }
    }
    void ThrowFlare()
    {
        GameObject flare = Instantiate(throwFlare,glowstick.transform.position,Quaternion.identity);
        

    }
}
