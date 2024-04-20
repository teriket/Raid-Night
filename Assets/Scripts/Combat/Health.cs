using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine;
/**
Author:         Tanner Hunt
Date:           4/19/2024
Version:        0.1.0
Description:    This Code handles camera movements and rotations around the player character.
ChangeLog:      V 0.1.0 -- 4/19/2024
                    --Added a stack of damage absorbs above the healthbar
                    --currentHealth takes damage when the stack is depleted
                    --started the empty playerDeath() method;
                    --commented out variables that are not yet implemented
                    --NYI: consider changing absorbs data structure, since absorb buffs 
                           may fall off of players and need to be removed.  
                    --NYI: Implement a delegate for damage procs.  
                    --NYI: Implement player deaths. Players will lose control of their character,
                           but should be able to be revived through extensive healing.  
                    --NYI: Implement a Damage Mitigation Layer
                    --dev Time: 15 minutes

*/
namespace Combat{
public class Health : MonoBehaviour {
    private Stack<int> absorbs;
//  private int maxHealth = 100;
    private int currentHealth = 100;
    private bool isDead = false;

/// <summary>
/// Deals damage to the player. Damage is passed through any absorb shields on the 
/// player before it reduces their current HP.
/// </summary>
/// <param name="dam">the amount of damage to be taken.</param>
    public void damage(int dam){
        if(isDead){
            return;
        }
        //NYI: Damage Mitigation Layer
        while(dam > 0 && absorbs.Count > 0){
            //do damage to top of stack until damage is zeroed, or absorbs disappears
            //do absorbs need to be moved into an interface?
            //absorbs.Peek();
        }
        if(dam > 0){
            currentHealth = currentHealth - dam;
            if(currentHealth < 0){
                playerDeath();
            }
            //delegate for procced damage taken
        }
    }

/// <summary>
/// Handles the players death should their health be reduced below zero.  Freezes their
/// controls, plays a death animation, reduces their healing taken, and revives them if
/// their health is brought back to 100%
/// </summary>
    public void playerDeath(){
        isDead = true;
        //freeze controls
        //death animation
        //reduce healing taken
        //if healed to 100% hp, revive
    }
}
}
