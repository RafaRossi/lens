using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class AutoBuilder
{
    static void PerformBuild ()
    {
        string[] scenes = { "Assets/Scenes/Main Menu.unity", "Assets/Scenes/Gameplay.unity" };

        string buildPath = "../../../Build/WebGL";

        // Create build folder if not yet exists
        Directory.CreateDirectory(buildPath);

        BuildPipeline.BuildPlayer(scenes, buildPath, BuildTarget.WebGL, BuildOptions.None);
    }
}
