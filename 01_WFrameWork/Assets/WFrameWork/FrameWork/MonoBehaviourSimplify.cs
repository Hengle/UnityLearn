using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WFramework
{
    public abstract partial class MonoBehaviourSimplify : MonoBehaviour
    {
        protected abstract void OnBeforeDestroy();

        #region Delay

        public void Delay(float seconds, Action onFinished)
        {
            StartCoroutine(DelayCoroutine(seconds, onFinished));
        }


        private IEnumerator DelayCoroutine(float seconds, Action onFinished)
        {
            yield return new WaitForSeconds(seconds);
            onFinished();
        }

        #endregion

        #region MsgDispatcher

        List<MsgRecord> _mMsgRecorder = new List<MsgRecord>();

        class MsgRecord
        {
            private MsgRecord()
            {
            }

            static Stack<MsgRecord> _mMsgRecordPool = new Stack<MsgRecord>();

            public static MsgRecord Allocate(string msgName, Action<object> onMsgReceived)
            {
                var retRecord = _mMsgRecordPool.Count > 0 ? _mMsgRecordPool.Pop() : new MsgRecord();
                retRecord.Name = msgName;
                retRecord.OnMsgReceived = onMsgReceived;
                return retRecord;
            }

            public void Recycle()
            {
                Name = null;
                OnMsgReceived = null;
                _mMsgRecordPool.Push(this);
            }

            public string Name { get; set; }
            public Action<object> OnMsgReceived { get; set; }
        }


        public void RegisterMsg(string msgName, Action<object> onMsgReceived)
        {
            MsgDispatcher.Register(msgName, onMsgReceived);
            _mMsgRecorder.Add(MsgRecord.Allocate(msgName, onMsgReceived));
        }

        public void SendMsg(string msgName, object data)
        {
            MsgDispatcher.Send(msgName, data);
        }

        public void UnRegisterMsg(string msgName)
        {
            var selectedRecords = _mMsgRecorder.FindAll(record => record.Name == msgName);
            selectedRecords.ForEach(record =>
            {
                MsgDispatcher.UnRegister(record.Name, record.OnMsgReceived);
                _mMsgRecorder.Remove(record);
                record.Recycle();
            });

            selectedRecords.Clear();
        }

        private void OnDestroy()
        {
            OnBeforeDestroy();
            foreach (var msgRecord in _mMsgRecorder)
            {
                MsgDispatcher.UnRegister(msgRecord.Name, msgRecord.OnMsgReceived);
                msgRecord.Recycle();
            }

            _mMsgRecorder.Clear();
        }

        #endregion
    }
}