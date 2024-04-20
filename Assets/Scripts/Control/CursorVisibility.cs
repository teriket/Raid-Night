using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
Author:         Tanner Hunt
Date:           4/20/2024
Version:        0.1
Description:    Makes the cursor visible depending on the mouse context the player is in
ChangeLog:      V 0.1 -- 4/20/2024
                    --Implemented Code
                    --Dev time: 0.25 Hours
*/

namespace Control{
public class CursorVisibility : MonoBehaviour
{
    void Start(){
        Cursor.visible = false;
    }

    public void changedMouseContext(MouseContext.mouseContext context)
    {
        switch(context){
            case MouseContext.mouseContext.menu:
                Cursor.visible = true;
                break;
            default:
                Cursor.visible = false;
                break;
        }
    }
}
}