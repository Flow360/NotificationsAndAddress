using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPushButton : MonoBehaviour
{
    public float pressedTimer = 0.0f;
    public float release;
    public float clampedTimer;
    public bool buttonIsPressedDown = false;
   

    //public int pressedTimerInt;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    
    void Update()
    {
        if (buttonIsPressedDown == true)
        {
            pressedTimer += Time.deltaTime * 3.0f;
            clampedTimer = Mathf.Clamp(pressedTimer, 0, 1);
            anim.SetFloat("Blend", clampedTimer);
        }

        if (buttonIsPressedDown == false)
        {
            
            pressedTimer = 0.0f;
            anim.SetFloat("Blend", 0);
        }
    }

    public void FingerDown()
    {
        buttonIsPressedDown = true;
    }

    public void FingerUp()
    {
        buttonIsPressedDown = false;
    }
}
