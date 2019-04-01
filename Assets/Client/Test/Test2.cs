using System;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using SunFramework;
using UnityEngine;

public class Test2 : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		PanelManager.Instance.GoToPanel(UiConfig.Instance.DefaultPanel);
		
//		UIPackage.AddPackage("FGUI/03_Game");
//		GComponent mainCom = UIPackage.CreateObject("03_Game", "Main").asCom;
//		GRoot.inst.AddChild(mainCom);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
