﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToo : GAction
{

    public override bool PrePerform()
    {

        Debug.Log("Hello");

        //Find the current target
        //target = this.inventory.FindItemWithTag("GoToo");

        if(target == null)
        {
            return false;
        }

        return true;
    }

    public override bool PostPerform()
    {
        //Remove the current target
        //inventory.RemoveItem(target);

        beliefs.RemoveState("exhausted");

        return true;
    }

}
