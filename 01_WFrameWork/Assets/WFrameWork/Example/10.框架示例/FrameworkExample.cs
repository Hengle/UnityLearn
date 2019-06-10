using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WFramework
{
    public class FrameworkExample : MonoBehaviourSimplify
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("WFramework/Example/10.框架示例")]
#endif
        private static void MenuClicked()
        {
            MsgDispatcher.UnRegisterAll("Do");
            MsgDispatcher.UnRegisterAll("OK");

            UnityEditor.EditorApplication.isPlaying = true;

            new GameObject("MsgReceivedObj").AddComponent<FrameworkExample>();
        }


        private void Awake()
        {
            RegisterMsg("Do", DoSomething);
            RegisterMsg("Do", DoSomething);
            RegisterMsg("DO1", _ => { });
            RegisterMsg("DO2", _ => { });
            RegisterMsg("DO3", _ => { });
            
            RegisterMsg("OK", data =>
            {
                Debug.Log(data);

                UnRegisterMsg("OK");
            });
        }


        private IEnumerator Start()
        {
            MsgDispatcher.Send("Do", "hello1");
            yield return new WaitForSeconds(1.0f);
            MsgDispatcher.Send("Do", "hello2");
            SendMsg("OK", "hello");
            SendMsg("OK", "hello");
        }

        void DoSomething(object data)
        {
            Debug.LogFormat("Received Do Msg:{0}", data);
        }



        protected override void OnBeforeDestroy()
        {
        }
    }
}