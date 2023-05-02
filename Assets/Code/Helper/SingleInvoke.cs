using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleInvoke
{
    private bool flag = false;
    private Action action;

    public SingleInvoke(Action action_)
    {
        action = action_;
    }

    public void Invoke()
    {
        if (!flag)
        {
            flag = true;
            action();
        }
    }

    public void Reset()
    {
        flag = false;
    }


}
