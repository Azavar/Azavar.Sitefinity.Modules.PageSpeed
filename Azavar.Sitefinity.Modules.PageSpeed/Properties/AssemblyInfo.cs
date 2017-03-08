using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using Azavar.Sitefinity.Modules.PageSpeed;
using Azavar.Sitefinity.Modules.PageSpeed.Web.UI.Views;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Azavar.Sitefinity.Modules.PageSpeed")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Azavar Technologies")]
[assembly: AssemblyProduct("Azavar.Sitefinity.Modules.PageSpeed")]
[assembly: AssemblyCopyright("Copyright © Azavar Technologies 2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Registers PageSpeedInstaller.PreApplicationStart() to be executed prior to the application start
[assembly: PreApplicationStartMethod(typeof(PageSpeedInstaller), "PreApplicationStart")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("6f2fdf62-a1e0-4fdf-8f44-08b710be9b60")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: WebResource(PageSpeedView.PageSpeedPageScript, "application/x-javascript")]
[assembly: WebResource("Azavar.Sitefinity.Modules.PageSpeed.Styles.PageSpeedStyles.min.css", "text/css", PerformSubstitution = true)]