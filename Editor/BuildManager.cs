using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.Events;

namespace RG.BuildSystem
{
    public static class BuildManager
    {
        private static readonly string _projectRoot = Path.GetFullPath(Path.Combine(Application.dataPath, "../"));
        private static Manifest _manifest;
        private static readonly UnityEvent<Manifest.BuildReport> _onBuildCompleted = new();
        
        internal static string projectRoot => _projectRoot;
        internal static Manifest manifest => _manifest;
        internal static UnityEvent<Manifest.BuildReport> OnBuildCompleted => _onBuildCompleted;

        internal static bool LoadConfig()
        {
            string manifestText = File.ReadAllText(_projectRoot + "rgbs.json");
            _manifest = JsonUtility.FromJson<Manifest>(manifestText);
            
            if(_manifest == null)
                return false;

            return true;
        }

        internal static void StartSingleBuild()
        {
            var report = BuildSingleConfig(manifest.activeConfig);
            
            OnBuildCompleted.Invoke(report);
            
            EditorUtility.DisplayDialog
            (
                $"Build Report: {report.result}",
                $"Target: {manifest.activeConfig.name}\n" +
                $"Time Taken: {report.totalTime}\n" +
                $"Build Size: {report.totalSize}\n" +
                $"Errors: {report.totalErrors}\n" +
                $"Warnings: {report.totalWarnings}",
                "OK!"
            );
        }

        internal static void StartMultiBuild()
        {
            foreach (var config in manifest.buildQueue)
            {
                var report = BuildSingleConfig(config);
                OnBuildCompleted.Invoke(report);
            }
        }

        private static Manifest.BuildReport BuildSingleConfig(Manifest.Config config)
        {
            string timeStamp = DateTime.Now.ToString("u");
            BuildReport report = BuildPipeline.BuildPlayer(config.buildOptions);

            _manifest.buildReports.Add(new Manifest.BuildReport
            {
                configName = config.name,
                timeStamp = timeStamp,
                result = report.summary.result.ToString(),
                totalSize = report.summary.totalSize,
                totalTime = report.summary.totalTime.ToString("g"),
                totalErrors = report.summary.totalErrors,
                totalWarnings = report.summary.totalWarnings
            });

            return _manifest.buildReports.Last();
        }
    }
}
