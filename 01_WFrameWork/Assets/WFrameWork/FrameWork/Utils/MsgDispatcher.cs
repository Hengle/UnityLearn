using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WFramework
{
    public class MsgDispatcher : MonoBehaviour
    {
        static Dictionary<string, Action<object>> _mRegisteredMsgs = new Dictionary<string, Action<object>>();

        public static void Register(string msgName, Action<object> onMsgReceived)
        {
            if (!_mRegisteredMsgs.ContainsKey(msgName))
            {
                _mRegisteredMsgs.Add(msgName, _ => { });
            }

            _mRegisteredMsgs[msgName] += onMsgReceived;
        }
        
        public static void UnRegisterAll(string msgName)
        {
            _mRegisteredMsgs.Remove(msgName);
        }

        public static void UnRegister(string msgName, Action<object> onMsgReveived)
        {
            if (_mRegisteredMsgs.ContainsKey(msgName))
            {
                 _mRegisteredMsgs[msgName] -= onMsgReveived; //注意委托减法的结果是不可预测的
            }
        }

        public static void Send(string msgName, object data)
        {
            if (_mRegisteredMsgs.ContainsKey(msgName))
            {
                _mRegisteredMsgs[msgName](data);
            }
        }
    }
    
    
  
}