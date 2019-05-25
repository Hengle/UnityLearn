using UnityEngine;

namespace WFramework
{
    public class GameObjectSimplifyExample
    {
        public class GameObejctSimplifyExample
        {
#if UNITY_EDITOR
            [UnityEditor.MenuItem("WFramework/Example/6.GameObject API 简化", false, 6)]
#endif
            private static void MenuClicked()
            {
                var gameObject = new GameObject();
                gameObject.Hide();
                gameObject.transform.Show();
            }
        }
    }
}