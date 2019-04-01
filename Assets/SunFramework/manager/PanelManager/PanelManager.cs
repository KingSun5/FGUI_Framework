using System;
using System.Collections.Generic;
using UnityEngine;


namespace SunFramework
{
	
	/// <summary>
	/// time:2019/3/26
	/// author:Sun
	/// description:Panel管理
	/// </summary>
	public class PanelManager:Singleton<PanelManager> 
	{

		/// <summary>
		/// 存储生成的Panel
		/// </summary>
		private Dictionary<string, PanelBase> panelDict = new Dictionary<string, PanelBase>();
		
		/// <summary>
		/// 现在场景
		/// </summary>
		public PanelBase CurrentScene = null;
		
		/// <summary>
		/// 以前的頁面
		/// </summary>
		public Queue<PanelBase> OldScenes = new Queue<PanelBase>();

		/// <summary>
		/// 跳转页面
		/// </summary>
		/// <param name="panelName"></param> 页面名字
		/// <param name="t"></param> 类型
		/// <param name="func"></param> 实例
		/// <param name="param"></param> 数据
		public void GoToPanel(string panelName,object param = null)
		{
			FairyGUI.GRoot.inst.touchable = false;
			PanelBase panel = GetPanel(panelName);
			
			if (panel == null)
			{
				panel = CreatePanel(panelName);
				panel.PanelName = panelName;
				panelDict.Add(panelName, panel);
			}
			if (CurrentScene != null && panelName == CurrentScene.PackageName)
			{
				Debug.LogError("当前场景和要到的目标场景重复"+panelName);
			}
			else
			{
				if (CurrentScene != null)
				{
					CurrentScene.Leave();
					OldScenes.Enqueue(CurrentScene);
				}
				CurrentScene = panelDict[panelName];
				CurrentScene.Enter();
				CurrentScene.SetData(param);
			}
		}

		/// <summary>
		/// 获取Panel
		/// </summary>
		/// <param name="panelName"></param>
		/// <returns></returns>
		private PanelBase GetPanel(string panelName)
		{
			if (panelDict.ContainsKey(panelName))
			{
				return panelDict[panelName];
			}
			return null;
		}

		/// <summary>
		/// Destroy
		/// </summary>
		public virtual void OnDestroy()
		{
			foreach (PanelBase panel in panelDict.Values)
			{
				panel.OnDestroy();
			}
		}
		
		/// <summary>
		/// 创建panel实例
		/// </summary>
		/// <param name="uiName"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public PanelBase CreatePanel(string panelName)
		{
			PanelBase panel = null;
			panel = Activator.CreateInstance(Type.GetType(panelName,true)) as PanelBase;
			if (panel==null)
			{
				throw new Exception("不存在"+panelName+"页面");
			}
			return panel;
		}

		

	}
}
