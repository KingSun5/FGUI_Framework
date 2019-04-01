using SunFramework;
using UnityEngine;

/// <summary>
/// time:2019/3/31
/// author:Sun
/// description:游戏入口
/// </summary>
public class GameEnter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PanelManager.Instance.GoToPanel(UiConfig.Instance.DefaultPanel);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
