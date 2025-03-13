using chkam05.Tools.ControlsEx.Example.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Example.Utilities
{
    public class AssemblyInfo
    {

        //  VARIABLES

        private Assembly assembly = null;


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> AppInfoContext class constructor. </summary>
        public AssemblyInfo()
        {
            assembly = Assembly.GetExecutingAssembly();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> AppInfoContext class constructor. </summary>
        /// <param name="dllFilePath"> Dynamic linked library file path. </param>
        public AssemblyInfo(string dllFilePath)
        {
            if (string.IsNullOrEmpty(dllFilePath))
                throw new ArgumentException($"{nameof(dllFilePath)} cannot be null or empty.");

            if (!File.Exists(dllFilePath))
                throw new FileNotFoundException($"File \"{dllFilePath}\" cannot be found.");

            assembly = Assembly.LoadFrom(dllFilePath);
        }

        #endregion CONSTRUCTORS

        #region INFO GETTERS

        //  --------------------------------------------------------------------------------
        /// <summary> Get assembly title. </summary>
        /// <returns> Assembly title. </returns>
        public string GetTitle()
        {
            return GetAssemblyAttribute<AssemblyTitleAttribute>(assembly)?.Title;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get assembly description. </summary>
        /// <returns> Assembly description. </returns>
        public string GetDescription()
        {
            return GetAssemblyAttribute<AssemblyDescriptionAttribute>(assembly)?.Description;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get assembly company. </summary>
        /// <returns> Assembly company. </returns>
        public string GetCompany()
        {
            return GetAssemblyAttribute<AssemblyCompanyAttribute>(assembly)?.Company;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get assembly product. </summary>
        /// <returns> Assembly product. </returns>
        public string GetProduct()
        {
            return GetAssemblyAttribute<AssemblyProductAttribute>(assembly)?.Product;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get assembly copyright. </summary>
        /// <returns> Assembly copyright. </returns>
        public string GetCopyright()
        {
            return GetAssemblyAttribute<AssemblyCopyrightAttribute>(assembly)?.Copyright;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get assembly trademark. </summary>
        /// <returns> Assembly trademark. </returns>
        public string GetTrademark()
        {
            return GetAssemblyAttribute<AssemblyTrademarkAttribute>(assembly)?.Trademark;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get assembly version. </summary>
        /// <returns> Assembly version. </returns>
        public string GetVersion()
        {
            var version = assembly.GetName().Version;
            return version.ToString();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get assembly file version. </summary>
        /// <returns> Assembly file version. </returns>
        public string GetFileVersion()
        {
            return FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get assembly guid. </summary>
        /// <returns> Assembly guid. </returns>
        public string GetGuid()
        {
            return GetAssemblyAttribute<GuidAttribute>(assembly)?.Value;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get assembly language. </summary>
        /// <returns> Assembly language. </returns>
        public string GetLanguage()
        {
            return GetAssemblyAttribute<NeutralResourcesLanguageAttribute>(assembly)?.CultureName;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get assembly name. </summary>
        /// <returns> Assembly name. </returns>
        public string GetName()
        {
            return assembly.GetName().Name;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get assembly namespace. </summary>
        /// <returns> Assembly namespace. </returns>
        public string GetNamespace()
        {
            return assembly.EntryPoint?.DeclaringType?.Namespace;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get assembly target framework. </summary>
        /// <returns> Assembly target framework. </returns>
        public string GetTargetFramework()
        {
            return GetAssemblyAttribute<TargetFrameworkAttribute>(assembly)?.FrameworkName;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get assembly output type. </summary>
        /// <returns> Assembly output type. </returns>
        public string GetOutputType()
        {
            if (assembly.EntryPoint == null)
                return StaticResources.ASSEMBLY_TYPE_NAME_CLASS;

            bool isWindowsApp =
                assembly.GetReferencedAssemblies().Any(a => a.Name == StaticResources.ASSEMBLY_TYPE_REF_FORMS_NAME) ||
                assembly.GetReferencedAssemblies().Any(a => a.Name == StaticResources.ASSEMBLY_TYPE_REF_WPF_NAME);

            return isWindowsApp
                ? StaticResources.ASSEMBLY_TYPE_NAME_WIN_APP
                : StaticResources.ASSEMBLY_TYPE_NAME_CLI_APP;
        }

        #endregion INFO GETTERS

        #region UTILITIES

        //  --------------------------------------------------------------------------------
        /// <summary> Gets assembly attribute. </summary>
        /// <typeparam name="T"> Assembly attribute type. </typeparam>
        /// <param name="assembly"> Assembly object. </param>
        /// <returns> Assembly attribute. </returns>
        private T GetAssemblyAttribute<T>(Assembly assembly) where T : Attribute
        {
            return (T)Attribute.GetCustomAttribute(assembly, typeof(T));
        }

        #endregion UTILITIES

    }
}
