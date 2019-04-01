using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> where T:class,new()
{
	protected static T _instance = null;

	public static T Instance
	{
		get
		{
			if (_instance==null)
			{
				_instance = new T();
			}
			return _instance;
		}
	}

	public Singleton()
	{
		Init();
	}

	public virtual void Init()
	{
		
	}
}
