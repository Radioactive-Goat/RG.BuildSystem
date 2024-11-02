using System.Collections.Generic;
using UnityEditor;

namespace RG.BuildSystem
{
    public class Manifest
    {
        public class Config
        {
            public string name;
            public BuildPlayerOptions buildOptions;
        }

        public class BuildReport
        {
            public string timeStamp;
            public string configName;
            public string result;
            public ulong totalSize;
            public string totalTime;
            public int totalErrors;
            public int totalWarnings;
        }
        
        public string projectName;
        public List<Config> configs;
        public Config activeConfig;
        public List<Config> buildQueue;
        public List<BuildReport> buildReports;
    }
}
