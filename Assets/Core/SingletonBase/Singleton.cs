using UnityEngine;

public class Singleton<T> where T : new()
{
    private static T _instance;
    /// <summary>
    /// 线程锁
    /// </summary>
    private static readonly object _lock = new object();

    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                lock(_lock)
                {
                    if (_instance == null)
                    {
                        Debug.Log("实例化音乐");
                        _instance = new T();
                    }
                }
            }
            return _instance;
        }
    }
}
