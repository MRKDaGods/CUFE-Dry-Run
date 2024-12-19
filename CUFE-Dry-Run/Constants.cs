using MRK.Models;
using System;

namespace MRK
{
    public static class Constants
    {
        /// <summary>
        /// Current app version
        /// </summary>
        public static readonly Version Version = new("2.5.0.1");

        /// <summary>
        /// Supported features
        /// </summary>
        public static readonly UpdateFeatures FeatureSet = UpdateFeatures.XLSX | UpdateFeatures.Regex;
    }
}
