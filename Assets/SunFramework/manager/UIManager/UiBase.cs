using System;
using System.Collections.Generic;
using DG.Tweening;
using FairyGUI;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace SunFramework
{
	/// <summary>
	/// time:2019/3/24
	/// author:Sun
	/// description:UI窗口基类
	/// </summary>
	public abstract class UiBase: Window
	{

		/// <summary>
		/// 当前窗口名字
		/// </summary>
		public abstract string WinName { get; }
		/// <summary>
		/// 当前窗口所属Panel
		/// </summary>
		public abstract string PanelName{ get; }
		/// <summary>
		/// 动效名字数组
		/// </summary>
		public virtual string[] TionNameArray{
			get { return null; }
		}
		/// <summary>
		/// 默认关闭按钮
		/// </summary>
		protected string CloseBtnName = "Btn_Close";
		/// <summary>
		/// 拖拽区域
		/// </summary>
		protected string DragAreaName = "Img_DragArea";
		/// <summary>
		/// 所有组件
		/// </summary>
		protected Dictionary<string, GObject> UiObjs = new Dictionary<string, GObject>();
		/// <summary>
		/// 所有控制器
		/// </summary>
		protected Dictionary<string, Controller> UiCtrls = new Dictionary<string, Controller>();
		
		/// <summary>
		/// 所有动效
		/// </summary>
		protected Dictionary<string, Transition> UiTions = new Dictionary<string, Transition>();
		/// <summary>
		/// 当前窗口附带信息，可用于跳转场景口的数据传递
		/// </summary>
		protected object WinData;
		public void GetData(object data)
		{
			WinData = data;
		}
		public object GetData()
		{
			return WinData;
		}

		/// <summary>
		/// 展示窗口动画
		/// </summary>
		protected bool IsNeedShowAni = false;
		/// <summary>
		/// 隐藏窗口动画
		/// </summary>
		protected bool IsNeedHideAni = false;
		

		/// <summary>
		/// 窗口初始化
		/// </summary>
		protected override void OnInit()
		{
			base.OnInit();
			//从页面内创建窗口
			GObject windObj = UIPackage.CreateObject(PanelName, WinName);
			if (windObj==null)
			{
				throw new System.Exception("创建"+WinName+"窗口页面失败");
			}
			contentPane = windObj.asCom;
			container.cachedTransform.position = Vector3.zero;
			container.cachedTransform.localScale = Vector3.one;
			contentPane.SetSize(GRoot.inst.width, GRoot.inst.height);
			//页面所有组件
			for (int i = 0;i< contentPane.numChildren;i++)
			{
				GObject gObject = contentPane.GetChildAt(i);
				UiObjs[gObject.name] = gObject;
				if (gObject.name==CloseBtnName)
				{
					closeButton = gObject;
				}

				if (gObject.name==DragAreaName)
				{
					dragArea = gObject;
				}
			}
			//页面所有控制器
			foreach (Controller ctrl in contentPane.Controllers)
			{
				UiCtrls[ctrl.name] = ctrl;
			}
			//页面所有动效
			if (TionNameArray!=null)
			{
				for (int i = 0; i<TionNameArray.Length; i++)
				{
					if (contentPane.GetTransition(TionNameArray[i])==null)
					{
						throw new Exception("动效--["+TionNameArray[i]+"]--不存在！");
					}
					UiTions[TionNameArray[i]] = contentPane.GetTransition(TionNameArray[i]);
				}
			}
			pivot = new Vector2(0.5f, 0.5f);			
		}

		
		
		/// <summary>
		/// 显示页面动画,可重写
		/// </summary>
		protected override void DoShowAnimation()
		{
			if (IsNeedShowAni)
			{
				if(!string.IsNullOrEmpty(UIConfig.globalModalWaiting))
					GRoot.inst.ShowModalWait ();
				scale =  new Vector2(0.6f,0.6f);
				DOTween.To(() => scale, a => scale = a, Vector2.one, 0.3f)
					.SetEase(Ease.OutBounce).OnComplete(() =>
					{
						if (!string.IsNullOrEmpty(UIConfig.globalModalWaiting))
						{
							GRoot.inst.CloseModalWait();
						}
						OnShown();
					})
					.SetUpdate(true)
					.SetTarget(this);
			}
			else
			{
				scale = Vector2.one;
				OnShown();
			}
		}

		/// <summary>
		/// 隐藏页面动画，可重写
		/// </summary>
		protected override void DoHideAnimation()
		{
			if (IsNeedHideAni)
			{
				DOTween.To(() => scale, a => scale = a, Vector2.zero, 0.3f)
					.OnComplete(() => { base.DoHideAnimation(); });
			}
			else
			{
				HideImmediately();
			}
		}
		public override void Dispose()
		{
			OnDestroy();
			base.Dispose();
		}

		protected virtual void OnDestroy()
		{

		}

		/// <summary>
		/// 重写的显示界面
		/// </summary>
		protected override void OnShown()
		{
			base.OnShown();
			this.visible = true;
		}
		
		protected override void OnHide()
		{
			base.OnHide();
		}

		protected virtual void OnBtnClose()
		{
			
		}
		
	}
}
