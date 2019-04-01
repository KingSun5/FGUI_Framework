using System;
using SunFramework;
using UnityEngine;

/// <summary>
/// time:2019/3/31
/// author:Sun
/// description:加载UI窗口
/// </summary>
public class LoadingWin : UiBase {
	
	public override string WinName
	{
		get { return "Loading"; }
	}

	public override string PanelName
	{
		get { return "02_Loading"; }
	}
	
	public override string[] TionNameArray
	{
		get { return new []{"tran_ShowBtn","tran_Loading","tran_ShowLoading"}; }
	}

	protected override void OnInit()
	{
		base.OnInit();
		UiTions["tran_Loading"].Play();
		UiTions["tran_ShowLoading"].Play(() =>
		{
			UiTions["tran_ShowBtn"].Play();
		});
		UiObjs["btn_Start"].onClick.Add(OnClickStart);
	}

	/// <summary>
	/// 开始按钮点击事件
	/// </summary>
	private void OnClickStart()
	{
		PanelManager.Instance.GoToPanel("GamePanel");
	}
}
