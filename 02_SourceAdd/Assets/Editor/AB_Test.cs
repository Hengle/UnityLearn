using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AB_Test {

	[MenuItem("Tools/打包")]
	public static void MenuClicked1()
	{
		BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.ChunkBasedCompression,
			EditorUserBuildSettings.activeBuildTarget);
		AssetDatabase.Refresh();
	}
}
