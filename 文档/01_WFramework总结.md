# Wframework 总结

## 1 基本示例(按钮点击菜单格式)

```csharp
#if UNITY_EDITOR
    [UnityEditor.MenuItem("WFramework/Example/1.复制文本到剪贴板", false, 1)]
#endif
    private static void MenuClicked()
    {
        CommonUtil.CopyText("想要复制的文字");
    }
```

**总结:**

&ensp;The MenuItem attribute allows you to add menu items to the main menu and inspector [^1] context menus;

&ensp;The MenuItem attribute turns any static function into a menu command. Only static functions can use the MenuItem attribute;

**欠缺:**


[^1]:inspector:检视器


## 2 复制文本到剪贴板
 ```csharp
    public static void CopyText(string text)
    {
      GUIUtility.systemCopyBuffer = text;
    }
 ```

**总结:**

1. GUIUtility.systemCopyBuffer:
    * public static string systemCopyBuffer;
    * Get access to the system-wide [^2] clipboard;
    * Note: tvOs does not support this feature;

[^2]:system-wide:全系统的,系统范围的
2. EditorGUIUtility.systemCopyBuffer:
    * public static string systemCopyBuffer;
    * The system copy buffer;
    * Use this to make Copy and Paste work for your own application . The systemCopyBuffer captures[^3] any text that is selected on the machine. This dose not specifically have to be text that is selected in Unity. Reading and writing systemCopyBuffer is possible.

[^3]:captures:捕获,夺得(负数)

## 3 补充 EditorGUIUtility.systemCopyBuffer


## 4 MenuItem 复用

```csharp
  private static void MenuClicked(){
    EditorUtil.CallMenuItem("WFramework/Example/1.复制文本到剪贴板")
  }
```

## 5 扩展方法

  * Extension methods are defined as static methods but are using instance method syntax[^4].

  [^4]:syntax:语句语法

  ```csharp
    namespace ExtensionMethods
    {
      public static class MyExtensions
      {
          public static int WordCount(this String str){
            return str.Split(new char[]{' ' , '.' , '?'},
                              StringSplitOptions.RemoveEmptyEntries.Lenght;
            );
          }
      }
    }
  ```

  ```csharp
  public static class GameObjectExtension
  {
    public static void Show(this Transform transform)
    {
      transform.gameObject.SetActive(true);
    }
  }
  ```

## 6 数学方法(概率函数)

```csharp
  public partical class MathUtil
  {
    //概率函数
    public static bool Percent(int percent)
    {
      reutrn Random.Range(0,100) <= percent;
    }

    //随机函数
    public static T GetRandomValueFrom<T>(params T[] inputs)
    {
      return inputs[Random.Range(0 , inputs.Lenght)];
    }
  }
```

## 7 延时调用功能(需继承自MonoBehaviourSimplify)

```csharp
public abstract partial class MonoBehaviourSimplify:MonoBehaviour
{
  #region Delay

  public void Delay(float seconds , Action onFinished)
  {
    StartCououtine(DelayCououtine(seconds,onFinished));
  }

  private IEnumerator DelayCououtine(float seconds, Action onFinished)
  {
    yield return new WaitForSeconds(secondes);
    onFinished();
  }

  #endregion
}
```


## 8 简易消息机制实现及使用

```csharp
  public class MsgDispatcher:MonoBehaviour
  {
    static Dictionary<string , Action<object>> _mRegisteredMsgs = new Dictionary<string, Action<object>>();

    public static void Register(string msgName ,  Action<object> onMsgReceived)
    {
      if(!_mRegisteredMsgs.ContainsKey(msgName)){
        _mRegisteredMsgs.Add(msgName , _ => {});
      }
      _mRegisteredMsgs[msgName] += onMsgReceived;
    }

    public static void UnRegisterAll(string msgName)
    {
      _mRegisteredMsgs.Remove(msgName);
    }

    public static void UnRegister(string msgName)
    {
      if(_mRegisteredMsgs.ContainsKey(msgName))
      {
        _mRegisteredMsgs[msgName] -= onMsgReceived;
      }
    }

    public static void Send(string msgName , object data)
    {
      if(_mRegisteredMsgs.ContainsKey(msgName))
      {
        _mRegisteredMsgs[msgName](data);
      }
    }
  }

  //上述方法简单使用示例:
  private static void MenuClicked()
       {
           MsgDispatcher.UnRegisterAll("消息1");

           MsgDispatcher.Register("消息1", OnMsgReceived);
           MsgDispatcher.Register("消息1", OnMsgReceived);

           MsgDispatcher.Send("消息1" , "hello world");

           MsgDispatcher.UnRegister("消息1", OnMsgReceived);

           MsgDispatcher.Send("消息1", "hello");
       }

  static void OnMsgReceived(object data)
       {
           Debug.LogFormat("消息1:{0}", data);
       }
```

## 9 简易消息机制的框架使用
```csharp
    public abstract partial class MonoBehaviourSimplify:MonoBehaviour
    {
      #region MsgDispatcher

      protected abstract void OnBeforeDestroy();

      List<MsgRecord> _mMsgRecorder = new　List<MsgRecord>();

      class MsgRecord
      {
        private MsgRecord(){}

        public string Name{get;set}
        public Action<object> OnMsgReveived{get;set;}

        static Stack<MsgRecord> _mMsgRecordPool = new Stack<MsgRecord>();

        public static MsgRecrod Allocate(string msgName, Action<object> onMsgReceived)
        {
          var retRecord = _mMsgRecordPool.Count > 0 ? _mMsgRecordPool.Pop(): new MsgRecord();
          retRecord.Name = msgName;
          retRecord.OnMsgReceived = onMsgReceived;
          return retRecord;
        }

        public void Recycle(){
          Name = null;
          OnMsgReceived = null;
          _mMsgRecordPool.Push(this);
        }
      }

      public void RegistMsg(string msgName, Action<object> onMsgReveived)
      {
        MsgDispatcher.Register(msgName , onMsgReveived);
        _mMsgRecorder.Add(MsgRecord.Allocate(msgName, onMsgReveived))
      }

      public void SendMsg(string msgName , object data)
      {
        MsgDispatcher.Send(msgName, data)
      }

      public void UnRegisterMsg(string msgName){
        var selectedRecords = _mMsgRecorder.FindAll(record => record.Name == msgName);
        selectedRecords.ForEach(record=>{
          MsgDispatcher.UnRegister(record.Name, record.OnMsgReveived);
          _mMsgRecorder.Remove(record);
          record.Recycle();
          });

            selectedRecords.Clear();
      }

      private void OnDestroy(){
        OnBeforeDestory();
        foreach(var msgRecord in _mMsgRecorder){
          MsgDispatcher.Unregister(msgRecord.Name, msgRecord.OnMsgReceived);
          msgRecord.Recycle();
        }
      }
      #endregion
    }
```


## 10 GUiManager UI加载与层级管理
```csharp
  public enum UILayer
  {
    Bg,
    Common,
    Top,
  }

  public class GUIManager
  {
      private static GameObject _mPrivateUIRoot;

      public static GameObject UIRoot
      {
        get
        {
            if(_mPrivateUIRoot == null)
            {
              _mPrivateUIRoot = Object.Instantiate(Resources.Load<GameObject>("UIRoot"));
              _mPrivateUIRoot.name = "UIRoot";
            }
            return _mPrivateUIRoot;
        }
      }

      private static Dictionary<string , GameObject> _mPanelDict = new Dictonary<string , GameObject>();

      public static void SetResolution(float width , float height, float macWidthOrHeight)
      {
        var canvasScaler = UIRoot.GetComponent<CamvasScaler>();
        canvasScaler.referenceResolution = new Vector2(width, height);
        canvasScaler.macWidthOrHeight = macWidthOrHeight;
      }

      public static void UnLoadPanel(string panelName)
      {
        if(_mPanelDict.ContainsKey(panelName))
          Object.Destroy(_mPanelDict[panelName]);
      }


      public static GameObject LoadPanel(string panelName, UILayer uiLayer)
      {
        var panelPrefab = Resources.Load<GameObject>(panelName);
        var panelObj = Object.Instantiate(panelPrefab);
        panelObj.name = panelName;

        _mPanelDict.Add(panelName, panelObj);

        switch(uiLayer){
          case UILayer.Top:
            panelObj.transform.SetParent(UIRoot.transform.Find("Top"));
            break;
          case UILayer.Common:
            panelObj.transform.SetParent(UIRoot.transfomr.Find("Common"));
            break;
          case UILayer.Bg:
            panelObj.transform.SetPanent(UIRoot.transform.Find("Bg"));
            break;
        }

        var panelRectTrans = panelObj.transform as RectTransform;
        if(!panelRectTrans)
        {
          throw new UnityException("panelObj transform trans RectTransform failed!!!");
        }

        panelRectTrans.offsetMin = Vector2.zero;
        panelRectTrans.offsetMax = Vector2.zero;
        panelRectTrans.anchoredPosition3D = Vector3.zero;
        panelRectTrans.anchorMin = Vector2.zero;
        panelRectTrans.anchorMax = Vector2.one;
        panelRectTrans.localScale = Vector3.one;

        return panelObj;
      }
  }
```

  >层级管理的新手段：使用Canvas 和专用的UI相机，考虑使用代码直接创建出UI层级，每一层都是新的Canvas, 并且每个整体性的UI上也附加Canvas组件， 利用上下关系和OrderInLayer 进行区分（便于特效等的处理， 同时UI相机只渲染UI层的显示，便于多相机处理）

## 11 声音管理
```csharp
public class AudioManager:MonoSingleTon<AudioManager>
{
    private AudioListener _mAudioListener;

    void CheckAudioListener()
    {
        if(!_mAudioListener)
        {
            _mAudioListener = FindObjectOfType<AudioListener>();
        }

        if(!_mAudioListener)
        {
          _mAudioListener = gameObject.AddComponent<AudioListener>();
        }
    }

    public void PlaySound(string soundName)
       {
           CheckAudioListener();
           var coinClip = Resources.Load<AudioClip>(soundName);
           var audioSource = gameObject.AddComponent<AudioSource>();

           audioSource.clip = coinClip;
           audioSource.Play();
       }

       private AudioSource _mMusicSource;

       public void PlayMusic(string musicName, bool loop)
       {
           CheckAudioListener();
           if (!_mMusicSource)
           {
               _mMusicSource = gameObject.AddComponent<AudioSource>();
           }

           var coinClip = Resources.Load<AudioClip>(musicName);

           _mMusicSource.clip = coinClip;
           _mMusicSource.loop = loop;
           _mMusicSource.Play();
       }

       public void StopMusic()
       {
           _mMusicSource.Stop();
       }

       public void PauseMusic()
       {
           _mMusicSource.Pause();
       }

       public void ResumeMusic()
       {
           _mMusicSource.UnPause();
       }

       public void MusicOff()
       {
           _mMusicSource.Pause();
           _mMusicSource.mute = true;
       }

       public void MusicOn()
       {
           _mMusicSource.UnPause();
           _mMusicSource.mute = false;
       }

       public void SoundOff()
       {
           var soundSources = GetComponents<AudioSource>();
           foreach (var soundSource in soundSources)
           {
               if (soundSource != null)
               {
                   soundSource.Pause();
                   soundSource.mute = true;
               }
           }
       }

       public void SoundOn()
       {
           var soundSources = GetComponents<AudioSource>();

           foreach (var soundSource in soundSources)
           {
               if (soundSource != _mMusicSource)
               {
                   soundSource.UnPause();
                   soundSource.mute = false;
               }
           }
       }
}
```

## 12 关卡管理
```csharp
public class LevelManager
   {
       private static List<string> _mLevelNames;

       public static int Index { get; set; }

       public static void Init(List<string> levelNames)
       {
           _mLevelNames = levelNames;
           Index = 0;
       }

       public static void LoadCurrent()
       {
           SceneManager.LoadScene(_mLevelNames[Index]);
       }

       public static void LoadNext()
       {
           Index++;
           if (Index >= _mLevelNames.Count)
           {
               Index = 0;
           }
           SceneManager.LoadScene(_mLevelNames[Index]);
       }
   }
```

## 13 单例(泛型与反射的初步认识)

**1：普通单例父类：（非Mono类单例）**
```csharp
  public class SingleTon<T> where T:SigleTon<T>
  {
    private static T _mInstance;
    public static T Instance{
      get{
        if(_mInstance == null){
          var ctors = typeof(T).GetConstructors(BindingFlags.Instance|BindingFlags.NonPublic);
          var ctor = Arry.Find(ctors, c => c.GetParameters().Length == 0 );
          if (ctor == null)
            throw new Exception("Non-public ctor() not found!");
          _mInstance = ctor.Invoke(null) as T;
        }
        return _mInstance;
      }
    }

    protected Singleton(){

    }
  }

  //上述单例父类待验证（不建议使用，一个项目中的单例没有多少，正常单个写即可）
```

**2：继承自Mono的单例父类:**

```csharp
  public class MonoSingleTon<T>:MonoBehaviour where T:MonoSingleTon<T>
  {
    protected static T _mInstance = null;

    public static T Instance
    {
      get
      {
        if(_mInstance == null)
        {
            _mInstance = FindObjectOfType<T>();
            if(FindObjectsOfType<T>.Length > 1)
            {
              Debug.LogWarning("More Than 1");
              return _mInstance;
            }

            if _mInstance == null
            {
              var instanceName = typeof(T).Name;
              Debug.LogFormat("Instance Name { 0 }" , instanceName);

              var instanceObj = GameObject.Find(instanceName);
              if(!instanceObj)
              {
                  instanceObj = new GameObject(instanceName);
              }
              _mInstance = instanceObj.AddComponent<T>();
              DontDestoryOnLoad(instanceObj); //保证实例不会被释放

              Debug.Log("Add New Singleton <color=aqua>{0}</color> in Game!", instanceName);
            }
            else
            {
              Debug.LogFormat("Already exist: <color=aqua>{0}</color>", _mInstance.name);
            }
        }

        return _mInstance;
      }
    }
  }
```

## 14 简易对象池

```csharp
public interface IPool<T>
  {
      T Allocate();
      bool Recycle(T obj);
  }

  public interface IObjectFactory<T>
  {
      T Create();
  }

  public abstract class Pool<T> : IPool<T>
  {

      protected Stack<T> MCacheStack = new Stack<T>();

      protected IObjectFactory<T> MFactory;

      public int CurCount => MCacheStack.Count;

      public T Allocate()
      {
          return MCacheStack.Count > 0 ? MCacheStack.Pop() : MFactory.Create();
      }

      public abstract bool Recycle(T obj);
  }

  public class CustomObjectFactory<T> : IObjectFactory<T>
  {
      private Func<T> _mFactoryMethod;

      public CustomObjectFactory(Func<T> factoryMethod)
      {
          _mFactoryMethod = factoryMethod;
      }

      public T Create()
      {
          return _mFactoryMethod();
      }
  }

  public class SimpleObjectPool<T> : Pool<T>
  {
      private Action<T> _mResetMethod;

      public SimpleObjectPool(Func<T> factoryMethod, Action<T> resetMethod = null, int initCount = 0)
      {
          MFactory = new CustomObjectFactory<T>(factoryMethod);
          _mResetMethod = resetMethod;
          for (var i = 0; i < initCount; i++)
          {
              MCacheStack.Push(MFactory.Create());
          }
      }

      public override bool Recycle(T obj)
      {
          if (_mResetMethod != null)
          {
              _mResetMethod(obj);
          }

          MCacheStack.Push(obj);
          return true;
      }
  }
```


>上面就是框架的初始阶段，后续会继续补充（上面这些只是单个的片段，后续会整理一套完整的游戏流程出来，包括框架启动，服务器连接，到结束等。）
