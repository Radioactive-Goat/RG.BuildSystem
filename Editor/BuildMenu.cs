using UnityEditor;
using System.Diagnostics;
using UnityEngine;

namespace RG.BuildSystem
{
    public class BuildMenu 
    {
        [MenuItem("Radioactive Goat/Build System/Configurator")]
        public static void OpenConfigurator()
        {
            ConfiguratorWindow wnd = EditorWindow.GetWindow<ConfiguratorWindow>();
            wnd.titleContent = new GUIContent("Build Configurator");
        }
    }
}
