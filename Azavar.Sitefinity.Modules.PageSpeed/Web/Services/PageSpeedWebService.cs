using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Azavar.Sitefinity.Modules.PageSpeed.Configuration;
using Azavar.Sitefinity.Modules.PageSpeed.Model;
using Azavar.Sitefinity.Modules.PageSpeed.ViewModels;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity.Web;

namespace Azavar.Sitefinity.Modules.PageSpeed.Web.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class PageSpeedWebService : IPageSpeedWebService
    {
        private int _totalPages;
        private int _pagesComplete;

        public List<PageSpeedResultViewModel> RunPageSpeedOnUrls(string urls)
        {
            var config = Config.Get<PageSpeedConfig>();

            var pageSpeedService = new PageSpeedService(config.ApiKey, new Uri(config.PageSpeedUrl));         

            pageSpeedService.PageScanned += OnPageScanned;

            var uris = Utilities.ParseUrisFromString(urls);

            var results = pageSpeedService.RunPageSpeedAsync(uris);

            var viewModel = ViewMapper.CreatePageSpeedResultViewModelListFrom(results);

            return viewModel;
        }

        private void OnPageScanned(object sender, PageScannedEventArgs e)
        {
            _totalPages = e.TotalPages;
            _pagesComplete = e.PagesComplete;
        }


        public PageSpeedStatus GetStatus()
        {
            return new PageSpeedStatus
            {
                CurrentProgress = _pagesComplete * 100 / _totalPages,
                StatusMessage = "STILL GOING!" //todo: figure out what to do with this
            };
        }

        public RuleSetViewModel Details(string uri, string ruleName)
        {
            Uri aUri;

            Uri.TryCreate(uri, UriKind.RelativeOrAbsolute, out aUri);

            var config = Config.Get<PageSpeedConfig>();

            var pageSpeedService = new PageSpeedService(config.ApiKey, new Uri(config.PageSpeedUrl));

            var results = pageSpeedService.RunPageSpeedAsync(new List<Uri> {aUri}, ruleName);

            return ViewMapper.CreateRuleSetViewModelFrom(results.Result, ruleName);
        }

        public List<PageSpeedResultViewModel> RunPageSpeedOnPageIds(string ids, string baseUrl)
        {
            var guids = Utilities.ParseGuidsFromString(ids);

            var pageManager = PageManager.GetManager();

            var pages = new List<PageNode>();

            foreach (var guid in guids)
            {
                var node = pageManager.GetPageNode(guid);

                if (node != null)
                    pages.Add(node);
            }

            var uris = new List<Uri>();

            foreach (var pageNode in pages)
            {
                Uri uri;

                var pageUrl = UrlPath.ResolveUrl(pageNode.GetUrl());

                if (Uri.TryCreate(string.Concat(baseUrl, pageUrl), UriKind.Absolute, out uri))
                {
                    uris.Add(uri);
                }
            }

            var config = Config.Get<PageSpeedConfig>();

            var pageSpeedService = new PageSpeedService(config.ApiKey, new Uri(config.PageSpeedUrl));

            pageSpeedService.PageScanned += OnPageScanned;

            var results = pageSpeedService.RunPageSpeedAsync(uris);

            var viewModel = ViewMapper.CreatePageSpeedResultViewModelListFrom(results);

            return viewModel;
        }
    }
}