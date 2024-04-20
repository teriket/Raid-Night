using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Control;
/**
Author:         Tanner Hunt
Date:           4/20/2024
Version:        0.1.1
Description:    This code toggles on and off the escape menu if the player presses the escape key
ChangeLog:      V 0.1.0 -- 4/19/2024
                    --Dev time: 0.25 Hours
                V 0.1.1 -- 4/20/2024
                    --added mouse context functionality, which stops camera movements
                    if the menu is open
                    --Dev time: 0 Hours

*/

namespace UI{
public class EscapeMenu : MonoBehaviour
{
    GameObject escapeMenuCanvas;        //the menu to be opened
    bool isActive = false;              //whether the menu should be open or closed
    MouseContext playerMouseContext;

/// <summary>
/// Cache a reference to the escape menu, then close the menu.
/// </summary>
    void Start(){
        escapeMenuCanvas = transform.Find("Escape Menu").gameObject;
        escapeMenuCanvas.SetActive(isActive);
        playerMouseContext = GameObject.Find("Character").GetComponent<MouseContext>();
    }

/// <summary>
/// Listens for input into the escape key.  Opens and closes the menu each time the
/// key is pressed.
/// </summary>
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            isActive = !isActive;
            escapeMenuCanvas.SetActive(isActive);
            if(isActive){
            playerMouseContext.setMouseContext(MouseContext.mouseContext.menu);
            }
            else{
                playerMouseContext.setMouseContext(MouseContext.mouseContext.defaultGamePlay);
            }

        }
    }
}
}