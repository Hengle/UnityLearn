using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AssetBundleEditor {

    //unity editor 启动时掉调用静态构造函数
    [InitializeOnLoad]
    public static class AssetbundleEditor
    {
        //%:ctrl, #:shift,&alt

        const string kCreateSceneAssetBundles = "Assets/AssetBundels/CreateSceneBundle";

        [MenuItem(kCreateSceneAssetBundles)]
        public static void CreateSceneAssetBundle()
        {
            //清空缓存
            Caching.ClearCache();

            Object[] selObjs = Selection.objects;
            Debug.Log(selObjs.Length);
            for (int i = 0; i < selObjs.Length; i++)
            {
                Debug.Log("运行1次");
                //固定路径(存储打完后AB包的目录)
                string path = Application.streamingAssetsPath +"/Scenes/"+ selObjs[i].name + ".assetbundle";

                string[] levels = { AssetDatabase.GetAssetPath(selObjs[i]) };

                BuildTarget target = BuildTarget.NoTarget;
#if UNITY_EDITOR
                target = BuildTarget.StandaloneWindows64;
#endif
#if UNITY_ANDROID
                target = BuildTarget.Android;
#endif
#if UNITY_IOS
                target = BuildTarget.iOS;
#endif 
                BuildPipeline.BuildPlayer(levels, path, target, BuildOptions.BuildAdditionalStreamedScenes);
                Debug.Log(levels[i]);
                Debug.Log(path);
            }
            AssetDatabase.Refresh();
        }
    }
}
