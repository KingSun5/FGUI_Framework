using System;
using System.Collections;
using System.Collections.Generic;
using SunFramework;
using UnityEngine;

public class FirstWin : UiBase
{

    public override string WinName
    {
        get { return "Main"; }
    }

    public override string PanelName
    {
        get { return "03_Game"; }
    }

    protected override void OnInit()
    {
        base.OnInit();
        UiObjs["n2"].asButton.onClick.Add(() =>
        {
            Debug.Log("11111");
        });
    }
}
