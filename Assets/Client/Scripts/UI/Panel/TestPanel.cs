using System;
using System.Collections;
using System.Collections.Generic;
using SunFramework;
using UnityEngine;

/// <summary>
/// time:2019/3/28
/// author:Sun
/// description:测试Panel
/// </summary>
public class TestPanel : PanelBase
{
    /// <summary>
    /// 当前Panel的初始窗口名字
    /// </summary>
    public override string FirstWinName
    {
        get { return "FirstWin"; }
    }

    /// <summary>
    /// 当前Panel隐藏后是否卸载
    /// </summary>
    public override bool IsUnLoad
    {
        get { return true; }
    }
    
    /// <summary>
    /// 当前Panel的包名
    /// </summary>
    public override string PackageName
    {
        get { return "03_Game"; }
    }

    /// <summary>
    /// 当前Panel的资源依赖
    /// </summary>
    public override string[] AssetsGroup
    {
        get { return new []{"FGUI/03_Game"}; }
    }
}
