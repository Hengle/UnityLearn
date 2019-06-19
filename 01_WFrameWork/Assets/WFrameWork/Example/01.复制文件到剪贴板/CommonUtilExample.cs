using UnityEditor;
using UnityEngine;

namespace WFramework
{
    public class CommonUtilExample
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("WFramework/Example/1.复制文本到剪贴板", false, 1)]
#endif
        private static void MenuClicked()
        {
            CommonUtil.CopyText("想要复制的文字");
        }
    }

    public class SystemCopyBufferExample : EditorWindow
    {
        private string[] _savedCopies = new string[5];
        
        bool _load = false;

        [MenuItem("WFramework/Example/19.复制文本到剪贴板补充", false, 19)]
        static void systemCopyBufferExample()
        {
            SystemCopyBufferExample window = EditorWindow.GetWindow<SystemCopyBufferExample>();
            window.Show();
        }


        void OnGUI()
        {
            _load = EditorGUILayout.Toggle("Load:", _load);

            EditorGUILayout.BeginHorizontal();
            for (var i = 0; i < _savedCopies.Length; i++)
            {
                if(GUILayout.Button(i.ToString()))
                    if (_load)
                        EditorGUIUtility.systemCopyBuffer = _savedCopies[i];
                    else
                        _savedCopies[i] = EditorGUIUtility.systemCopyBuffer;
            }
            
            EditorGUILayout.EndHorizontal();

            for (var j = 0; j < _savedCopies.Length; j++)
            {
                EditorGUILayout.LabelField("Saved " + j, _savedCopies[j]);
            }

            EditorGUILayout.LabelField("Current buffer:", EditorGUIUtility.systemCopyBuffer);
            if(GUILayout.Button("Clear all saves"))
                for (var s = 0; s < _savedCopies.Length; s++)
                    _savedCopies[s] = "";
        }

        void OnInspectorUpdate()
        {
            this.Repaint();
        }

    }
}