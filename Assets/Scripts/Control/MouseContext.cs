using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
Author:         Tanner Hunt
Date:           4/20/2024
Version:        0.1.0
Description:    This code sets the current mouse context so that the appropriate actions
                occur when the user uses their mouse i.e. they auto attack in the default
                state, but cast a spell instead when a spell is queued, and the camera
                doesn't move when a menu is open.
ChangeLog:      V 0.1.0 -- 4/20/2024
                    --Added panning around the character in a sphere centered at character.
                    --Sends a message to cursor visibility when the mouse context is changed
                    to update whether or not the cursor is visible.
                    --Dev time: 0.25 hours

*/

namespace Control{
public class MouseContext : MonoBehaviour
{
    CursorVisibility messageToCursorVisiblity;

    public enum mouseContext{
        defaultGamePlay,
        menu,
        spellCasting
    }
    mouseContext context;

    public mouseContext getMouseContext(){
        return context;
    }

    public void setMouseContext(mouseContext newContext){
        context = newContext;
        messageToCursorVisiblity.changedMouseContext(newContext);
    }

    void Start(){
        context = mouseContext.defaultGamePlay;
        messageToCursorVisiblity = GetComponent<CursorVisibility>();
    }
}
}