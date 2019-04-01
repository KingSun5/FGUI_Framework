

using System;
using System.Collections.Generic;
using System.Reflection;

namespace SunFramework
{
	/// <summary>
	/// time:2019/3/27
	/// author:Sun
	/// description:UIConfig
	/// </summary>
	public class UiConfig:Singleton<UiConfig>
	{
		/// <summary>
		/// 默认加载场景
		/// </summary>
		public string DefaultPanel = "LoadingPanel";
		/// <summary>
		/// 设计分辨率X
		/// </summary>
		public int DefaultResolutionX = 1624;
		/// <summary>
		/// 设计分辨率Y
		/// </summary>
		public int DefaultResolutionY = 750;
	}


}
