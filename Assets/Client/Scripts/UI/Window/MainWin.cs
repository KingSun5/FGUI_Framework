using SunFramework;

/// <summary>
/// time:2019/3/31
/// author:Sun
/// description:游戏主UI窗口
/// </summary>
public class MainWin : UiBase {

	public override string WinName
	{
		get { return "MainWin"; }
	}

	public override string PanelName
	{
		get { return "03_Game"; }
	}
	
	public override string[] TionNameArray
	{
		get { return new []{"tran_wel"}; }
	}

	protected override void OnInit()
	{
		base.OnInit();
		UiTions["tran_wel"].Play();
		UiObjs["btn_Next"].asButton.onClick.Add(OnClickNext);
	}

	/// <summary>
	/// 跳转页面
	/// </summary>
	private void OnClickNext()
	{
		UiManager.Instance.ShowWind("SunWin");
	}
}
