#if UNITY_EDITOR
using UnityEditor;
#endif
namespace WFramework
{
    public class CommonUtilExample
    {
#if UNITY_EDITOR

        [MenuItem("WFramework/Example/1.复制文本到剪贴板" ,false,1)]
        private static void MenuClicked()
        {
            CommonUtil.CopyText("想要复制的文字");
        }

#endif
    }
}