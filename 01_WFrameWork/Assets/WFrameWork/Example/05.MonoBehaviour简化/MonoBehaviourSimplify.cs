using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WFrameWork
{
    public partial class MonoBehaviourSimplify : MonoBehaviour
    {
        public void Show()
        {
            GameObjectSimplify.Show(gameObject);
        }

        public void Hide()
        {
            GameObjectSimplify.Hide(gameObject);
        }

        public void Identity()
        {
            TransformSimplify.Identity(transform);
        }
    }
}