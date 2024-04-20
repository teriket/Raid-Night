using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
Author:         Tanner Hunt
Date:           4/19/2024
Version:        0.1.0
Description:    Exits the application if the player presses the quit game button
ChangeLog:      V 0.1.0 -- 4/19/2024
                    --NYI: May need to be expanded for server side functions.
                    --Dev time: 0.125 hours
*/
namespace UI{
public class QuitGame : MonoBehaviour
{
/// <summary>
/// Quits the application.
/// </summary>
    public void Quit(){
        Application.Quit();
    }
}
}