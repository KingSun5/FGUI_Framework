using Boo.Lang;
using FairyGUI;

namespace SunFramework
{
	/// <summary>
	/// time:2019/3/24
	/// author:Sun
	/// description:Panel基类
	/// </summary>
	public abstract class PanelBase
	{
		/// <summary>
		/// 当前Panel加载后显示在Top的窗口页面
		/// </summary>
		public abstract string FirstWinName { get; }
		/// 是否卸载
		/// </summary>
		public abstract bool IsUnLoad { get; }
		/// <summary>
		/// 包名 
		/// </summary>
		public abstract string PackageName { get; }
		/// <summary>
		/// 资源
		/// </summary>
		public abstract string[] AssetsGroup { get; }
		/// <summary>
		/// 场景调整数据
		/// </summary>
		protected object PanelData;
		/// <summary>
		/// 場景名
		/// </summary>
		public string PanelName;

		/// <summary>
		/// 进入场景
		/// </summary>
		public void Enter()
		{
			//加载资源
			for (int i = 0; i < AssetsGroup.Length; i++)
			{
				if (!string.IsNullOrEmpty(AssetsGroup[i]))
				{
					UIPackage.AddPackage(AssetsGroup[i]);
				}
			}
			UiManager.Instance.ShowWind(FirstWinName);
			FairyGUI.GRoot.inst.touchable = true;
		}

		/// <summary>
		/// 离开场景
		/// </summary>
		public void Leave()
		{
			if (IsUnLoad)
			{
				//卸载资源
				for (int i = 0; i < AssetsGroup.Length; i++)
				{
					UIPackage.RemovePackage(AssetsGroup[i]);
				}
			}
		}
		
		/// <summary>
		/// 跳转场景数据设置
		/// </summary>
		/// <param name="data"></param>
		public void SetData(object data)
		{
			if (data!=null)
			{
				PanelData = data;
			}
		}

		/// <summary>
		/// Destroy
		/// </summary>
		public void OnDestroy()
		{
			
		}
		


	}
}
