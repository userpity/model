using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����������
public abstract class SingletonManager<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance!=null) return _instance;
            //�ڳ�����Ѱ���Ƿ��Ѿ�������ͬ�Ĺ�����
            var go = GameObject.Find(typeof(T) + "").GetComponent<T>();
            if (go != null)
            {
                _instance = go;
                return _instance;
            }
            var ins = new GameObject(typeof(T) + "");
            _instance = ins.AddComponent<T>();
            Debug.Log($"����{typeof(T)}");
            return _instance;
        }
        private set{}
    }

    protected virtual void Awake()
    {
        //��ֹ�����ڼ���������
        DontDestroyOnLoad(gameObject);
    }
}
