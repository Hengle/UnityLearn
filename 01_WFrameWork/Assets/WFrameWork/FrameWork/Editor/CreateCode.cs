using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;

namespace WFramework
{
    public class CreateCode
    {
        [MenuItem("Assets/Create/Script/MyLua", false, 1)]
        private static void CreateLua()
        {
        }


        [MenuItem("Assets/Create/Script/MyExampleC#", false, 2)]
        private static void CreateExampleCSharpe()
        {
        }


        public static string GetSelectPathOrFallback()
        {
            var path = "Assets";

            foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets))
            {
                path = AssetDatabase.GetAssetPath(obj);
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    path = Path.GetDirectoryName(path);
                    break;
                }
            }

            return path;
        }
    }

    class CreateTestScriptAsset : EndNameEditAction
    {
        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            //创建资源
            UnityEngine.Object obj = CreateScriptAssetFormTemplate(pathName, resourceFile);
            ProjectWindowUtil.ShowCreatedAsset(obj); //高亮显示新创建的资源
        }

        internal static UnityEngine.Object CreateScriptAssetFormTemplate(string pathName, string resoureceFile)
        {
            //获取要创建资源的绝对路径
            var fullPath = Path.GetFullPath(pathName);

            //读取本地模版文件
            var streamReader = new StreamReader(resoureceFile);
            var text = streamReader.ReadToEnd();
            streamReader.Close();

            //获取文件名,不含扩展名
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);
            Debug.Log("text ==== " + text);

            //将模版类中的类名替换成你创建的文件名
            text = Regex.Replace(text, "CLASSNAME", fileNameWithoutExtension);
            var encoderShouldEmitUtf8Identifier = true; //参数指定是否提供 Unicode 字节顺序标记
            var throwOnInvalidBytes = false; //是否在检测到无效的编码时引发异常

            UTF8Encoding encoding = new UTF8Encoding(encoderShouldEmitUtf8Identifier, throwOnInvalidBytes);
            var append = false;

            //写入文件
            StreamWriter streamWriter = new StreamWriter(fullPath, append, encoding);
            streamWriter.Write(text);
            streamWriter.Close();

            //刷新资源管理器
            AssetDatabase.ImportAsset(pathName);
            AssetDatabase.Refresh();
            return AssetDatabase.LoadAssetAtPath(pathName, typeof(UnityEngine.Object));
        }
    }
}