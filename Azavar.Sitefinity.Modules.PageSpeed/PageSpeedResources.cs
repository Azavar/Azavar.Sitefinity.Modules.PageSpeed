using System;
using System.Linq;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace Azavar.Sitefinity.Modules.PageSpeed
{
    /// <summary>
    /// Localizable strings for the PageSpeed module
    /// </summary>
    /// <remarks>
    /// You can use Sitefinity Thunder to edit this file.
    /// To do this, open the file's context menu and select Edit with Thunder.
    /// 
    /// If you wish to install this as a part of a custom module,
    /// add this to the module's Initialize method:
    /// App.WorkWith()
    ///     .Module(ModuleName)
    ///     .Initialize()
    ///         .Localization<PageSpeedResources>();
    /// </remarks>
    /// <see cref="http://www.sitefinity.com/documentation/documentationarticles/developers-guide/how-to/how-to-import-events-from-facebook/creating-the-resources-class"/>
    [ObjectInfo("PageSpeedResources", ResourceClassId = "PageSpeedResources", Title = "PageSpeedResourcesTitle", TitlePlural = "PageSpeedResourcesTitlePlural", Description = "PageSpeedResourcesDescription")]
    public class PageSpeedResources : Resource
    {
        #region Construction
        /// <summary>
        /// Initializes new instance of <see cref="PageSpeedResources"/> class with the default <see cref="ResourceDataProvider"/>.
        /// </summary>
        public PageSpeedResources()
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="PageSpeedResources"/> class with the provided <see cref="ResourceDataProvider"/>.
        /// </summary>
        /// <param name="dataProvider"><see cref="ResourceDataProvider"/></param>
        public PageSpeedResources(ResourceDataProvider dataProvider) : base(dataProvider)
        {
        }
        #endregion

        #region Class Description
        /// <summary>
        /// PageSpeed Resources
        /// </summary>
        [ResourceEntry("PageSpeedResourcesTitle",
            Value = "PageSpeed module labels",
            Description = "The title of this class.",
            LastModified = "2016/12/22")]
        public string PageSpeedResourcesTitle
        {
            get
            {
                return this["PageSpeedResourcesTitle"];
            }
        }

        /// <summary>
        /// PageSpeed Resources Title plural
        /// </summary>
        [ResourceEntry("PageSpeedResourcesTitlePlural",
            Value = "PageSpeed module labels",
            Description = "The title plural of this class.",
            LastModified = "2016/12/22")]
        public string PageSpeedResourcesTitlePlural
        {
            get
            {
                return this["PageSpeedResourcesTitlePlural"];
            }
        }

        /// <summary>
        /// Contains localizable resources for PageSpeed module.
        /// </summary>
        [ResourceEntry("PageSpeedResourcesDescription",
            Value = "Contains localizable resources for PageSpeed module.",
            Description = "The description of this class.",
            LastModified = "2016/12/22")]
        public string PageSpeedResourcesDescription
        {
            get
            {
                return this["PageSpeedResourcesDescription"];
            }
        }


        [ResourceEntry("PageSpeedPageTitle", Value = "Page Speed", Description = "phrase: Page Speed", LastModified = "2016/12/22")]
        public string PageSpeedPageTitle
        {
            get
            {
                return this["PageSpeedPageTitle"];
            }
        }

        [ResourceEntry("PageSpeedPageUrlName", Value = "Page-Speed", Description = "phrase: Page Speed", LastModified = "2016/12/22")]
        public string PageSpeedPageUrlName
        {
            get
            {
                return this["PageSpeedPageUrlName"];
            }
        }
        #endregion
    }
}