using chkam05.Tools.ControlsEx.Example.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Example.Utilities
{
    public static class AppUtilities
    {

        //  VARIABLES

        public static readonly AssemblyInfo AssemblyInfo = new AssemblyInfo();


        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get application settings directory path. </summary>
        /// <returns> Application settings directory path. </returns>
        public static string GetAppSettingsDirectory()
        {
            var appData = Environment.GetEnvironmentVariable("APPDATA");
            var appName = AssemblyInfo.GetName();
            return Path.Combine(appData, appName);
        }

    }
}
