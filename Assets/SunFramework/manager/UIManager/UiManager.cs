

using System;
using System.Collections.Generic;
using FairyGUI;

namespace SunFramework
{
	/// <summary>
	/// time:2019/3/24
	/// author:Sun
	/// description:UI窗口基类
	/// </summary>
	public class UiManager:Singleton<UiManager>{
		
		/// <summary>
		/// 所有Windows
		/// </summary>
		private Dictionary<string,UiBase> _uIArray = new Dictionary<string, UiBase>();
		

		public override void Init()
		{
			//设置FGUI的分辨率
			GRoot.inst.SetContentScaleFactor(UiConfig.Instance.DefaultResolutionX,UiConfig.Instance.DefaultResolutionY);
		}
		
		/// <summary>
		/// 获取窗口页面
		/// </summary>
		/// <param name="uiName"></param>
		/// <returns></returns>
		public UiBase GetWindow(string uiName)
		{
			UiBase wind = null;
			foreach (string name in _uIArray.Keys)
			{
				if (name == uiName)
				{
					wind = _uIArray[name];
					break;
				}
			}
			return wind;
		}

		/// <summary>
		/// 创建Ui实例
		/// </summary>
		/// <param name="uiName"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public UiBase CreateWindow(string uiName)
		{
			UiBase wind = null;
			wind = Activator.CreateInstance(Type.GetType(uiName,true)) as UiBase;
			if (wind==null)
			{
				throw new Exception("不存在"+uiName+"页面");
			}
			return wind;
		}
		
		/// <summary>
		/// 得到所有处于打开状态的窗口页面
		/// </summary>
		/// <returns></returns>
		public List<string> GetAllOpenWindows()
		{
			List<string> list = new List<string>();
			foreach(string uiName in _uIArray.Keys)
			{
				if (IsOpenWindow(uiName))
				{
					list.Add(uiName);
				}
			}
			return list;
		}
		
		/// <summary>
		/// 关闭所有打开的窗口
		/// </summary>
		/// <param name="isMode"></param>
		public void DeleteAllWindows()
		{
			
		}	
		
		/// <summary>
		/// 窗口是否处于打开状态
		/// </summary>
		/// <param name="uiName"></param>
		/// <returns></returns>
		public bool IsOpenWindow(string uiName)
		{
			UiBase wind = GetWindow(uiName);
			if (wind != null)
			{
				return wind.isShowing;
			}
			return false;
		}

		/// <summary>
		/// 展示窗口
		/// </summary>
		/// <param name="baseUi"></param>
		public void ShowWind(string winName)
		{
			UiBase baseUi = GetWindow(winName);
			if (baseUi==null)
			{
				baseUi =CreateWindow(winName);
				_uIArray.Add(baseUi.WinName,baseUi);
			}
			baseUi.Show();
		}
		
		/// <summary>
		/// 隐藏窗口
		/// </summary>
		/// <param name="baseUi"></param>
		public void CloseWind(string winName)
		{
			UiBase baseUi = GetWindow(winName);
			if (baseUi==null)
			{
				throw new Exception("该页面不存在！");
			}
			baseUi.Hide();
		}
	}
}
