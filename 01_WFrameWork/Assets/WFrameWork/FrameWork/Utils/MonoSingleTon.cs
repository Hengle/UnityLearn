using UnityEngine;

namespace WFramework
{
    public class MonoSingleTon<T> : MonoBehaviour where T:MonoSingleTon<T>
    {
        protected static T _mInstance = null;

        public static T Instance
        {
            get
            {
                if (_mInstance == null)
                {
                    _mInstance = FindObjectOfType<T>();

                    if (FindObjectsOfType<T>().Length > 1)
                    {
                        Debug.LogWarning("More than 1");
                        return _mInstance;
                    }

                    if (_mInstance == null)
                    {
                        var instanceName = typeof(T).Name;
                        Debug.LogFormat("Instance Name {0}", instanceName);

                        var instanceObj = GameObject.Find(instanceName);

                        if (!instanceObj)
                        {
                            instanceObj = new GameObject(instanceName);
                        }

                        _mInstance = instanceObj.AddComponent<T>();
                        DontDestroyOnLoad(instanceObj); //保证实例不会被释放

                        Debug.LogFormat("Add New Singleton <color=aqua>{0}</color> in Game!", instanceName);
                    }
                    else
                    {
                        Debug.LogFormat("Already exist: <color=aqua>{0}</color>", _mInstance.name);
                    }

                }

                return _mInstance;
            }
        }
        
        protected virtual void OnDestroy(){
            _mInstance = null;
        }
    }
    
  
}