using UnityEngine;

namespace WFrameWork
{
    public class GameObjectSimplify
    {
        public static void Show(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        public static void Hide(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }
    }
}