using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WFramework
{
    public class TransformSimplifyExample
    {
        #if UNITY_EDITOR
        [UnityEditor.MenuItem("WFramework/Example/4.Transform API 简化", false, 4)]
#endif
        static void MenuClicked()
        {
            GameObject gameObject = new GameObject();

            gameObject.transform.SetLocalPosX(5.0f);
            gameObject.transform.SetLocalPosY(5.0f);

            gameObject.transform.Identity();
            
            var parentTrans = new GameObject("ParentTrans").transform;
            var childTrans =  new GameObject("ChildTrans").transform;
            parentTrans.AddChild(childTrans);
        }
    }
}