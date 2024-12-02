using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//单例管理器
public abstract class SingletonManager<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance!=null) return _instance;
            //在场景中寻找是否已经存在相同的管理器
            var go = GameObject.Find(typeof(T) + "").GetComponent<T>();
            if (go != null)
            {
                _instance = go;
                return _instance;
            }
            var ins = new GameObject(typeof(T) + "");
            _instance = ins.AddComponent<T>();
            Debug.Log($"创建{typeof(T)}");
            return _instance;
        }
        private set{}
    }

    protected virtual void Awake()
    {
        //防止单例在加载中销毁
        DontDestroyOnLoad(gameObject);
    }
}
