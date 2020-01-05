using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Builder
{
    public static void AndroidBiild()
    {
        var output = "";
        var args = System.Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "-outputPath":
                    output = args[i + 1];   //出力先の設定
                    break;
                default:
                    break;
            }
        }

        string[] scenes = { "Assets/Scenes/SampleScene.unity" };

        var option = new BuildPlayerOptions();
        option.locationPathName = output;
        option.target = BuildTarget.Android; //ビルドターゲットを設定. 今回はAndroid
        option.scenes = scenes;
        var result = BuildPipeline.BuildPlayer(option);
        if (result.summary.result == UnityEditor.Build.Reporting.BuildResult.Succeeded)
        {
            Debug.Log("BUILD SUCCESS");
        }
        else
        {
            Debug.LogError("BUILD FAILED");
        }
    }
}
