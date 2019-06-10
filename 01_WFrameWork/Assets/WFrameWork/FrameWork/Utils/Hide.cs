using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WFramework
{
    public class Hide : MonoBehaviourSimplify
    {
        private void Awake()
        {
            this.Hide();
        }

        protected override void OnBeforeDestroy()
        {
        }
    }
}