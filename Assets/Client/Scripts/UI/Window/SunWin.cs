using SunFramework;

/// <summary>
/// time:2019/3/31
/// author:Sun
/// description:跳转UI窗口
/// </summary>
public class SunWin : UiBase {

	public override string WinName
	{
		get { return "SunWin"; }
	}

	public override string PanelName
	{
		get { return "03_Game"; }
	}

	protected override void OnInit()
	{
		base.OnInit();
		UiObjs["btn_Return"].asButton.onClick.Add(OnClickReturn);
	}

	/// <summary>
	/// 跳转页面
	/// </summary>
	private void OnClickReturn()
	{
		UiManager.Instance.ShowWind("MainWin");
	}
}
