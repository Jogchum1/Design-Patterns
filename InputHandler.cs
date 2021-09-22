using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{
    public ICommand GunScript;
    
    public void HandleInput()
    {
        
        if(Input.GetButton("Fire1"))
        {
            GunScript.Execute();         
        }
    }
}
