
namespace WFramework
{
    public class EditorUtilExample
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("WFramework/Example/2.MenuItem 复用", false, 2)]
#endif
        private static void MenuClicked()
        {
            EditorUtil.CallMenuItem("WFramework/Example/1.复制文本到剪贴板");
        }
    }
}