﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NZBDash.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class MockData {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MockData() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NZBDash.Resources.MockData", typeof(MockData).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///    &quot;timeleft&quot;:&quot;0:00:00&quot;,
        ///    &quot;mb&quot;:854.697841,
        ///    &quot;noofslots&quot;:1,
        ///    &quot;paused&quot;:true,
        ///    &quot;mbleft&quot;:854.697841,
        ///    &quot;diskspace2&quot;:21.980682,
        ///    &quot;diskspace1&quot;:21.980682,
        ///    &quot;kbpersec&quot;:0.000000,
        ///    &quot;jobs&quot;:[
        ///        {&quot;msgid&quot;:&quot;3066202&quot;,
        ///        &quot;filename&quot;:
        ///        &quot;Ubuntu 8.04 (Hardy Heron) - Desktop CD x64&quot;,
        ///        &quot;mbleft&quot;:854.697841,&quot;id&quot;:&quot;SABnzbd_nzo_zt2syz&quot;,
        ///        &quot;mb&quot;:854.697841}
        ///    ]
        ///}.
        /// </summary>
        public static string Sabnzbd_Queue {
            get {
                return ResourceManager.GetString("Sabnzbd_Queue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [
        ///  {
        ///    &quot;seriesId&quot;: 1,
        ///    &quot;episodeFileId&quot;: 0,
        ///    &quot;seasonNumber&quot;: 1,
        ///    &quot;episodeNumber&quot;: 1,
        ///    &quot;title&quot;: &quot;Mole Hunt&quot;,
        ///    &quot;airDate&quot;: &quot;2009-09-17&quot;,
        ///    &quot;airDateUtc&quot;: &quot;2009-09-18T02:00:00Z&quot;,
        ///    &quot;overview&quot;: &quot;Archer is in trouble with his Mother and the Comptroller because his expense account is way out of proportion to his actual expenses. So he creates the idea that a Mole has breached ISIS and he needs to get into the mainframe to hunt him down (so he can cover his tracks!). All this leads to a [rest of string was truncated]&quot;;.
        /// </summary>
        public static string Sonarr_Episode {
            get {
                return ResourceManager.GetString("Sonarr_Episode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [
        ///  {
        ///    &quot;title&quot;: &quot;Archer (2009)&quot;,
        ///    &quot;seasonCount&quot;: 5,
        ///    &quot;episodeCount&quot;: 47,
        ///    &quot;episodeFileCount&quot;: 47,
        ///    &quot;status&quot;: &quot;continuing&quot;,
        ///    &quot;overview&quot;: &quot;At ISIS, an international spy agency, global crises are merely opportunities for its highly trained employees to confuse, undermine, betray and royally screw each other. At the center of it all is suave master spy Sterling Archer, whose less-than-masculine code name is \&quot;Duchess.\&quot; Archer works with his domineering mother Malory, who is also his bo [rest of string was truncated]&quot;;.
        /// </summary>
        public static string Sonarr_Series {
            get {
                return ResourceManager.GetString("Sonarr_Series", resourceCulture);
            }
        }
    }
}