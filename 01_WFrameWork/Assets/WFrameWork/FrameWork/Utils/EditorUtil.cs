using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif


namespace WFramework
{
    public partial class EditorUtil
    {
      
        /// <summary>
        /// 打开对应的文件夹
        /// </summary>
        /// <param name="folderpath">文件路径(以Assets文件为基点)</param>
        public static void OPenInFolder(string folderpath)
        {
            Application.OpenURL("file://" + folderpath);
        }

#if UNITY_EDITOR
        
        /// <summary>
        /// Editor MenuItem 复用
        /// </summary>
        /// <param name="menuPath">MenuItem中的菜单路径</param>
        public static void CallMenuItem(string menuPath)
        {
            EditorApplication.ExecuteMenuItem(menuPath);
        }
        
        /// <summary>
        /// 导出包,这里默认递归导出
        /// </summary>
        /// <param name="assetPathName">导出的包</param>
        /// <param name="fileName">包的命名</param>
        public static void ExportPackage(string assetPathName, string fileName)
        {
            AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse); 
        }
#endif
    }
}