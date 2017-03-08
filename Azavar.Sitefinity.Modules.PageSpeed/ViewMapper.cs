using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azavar.Sitefinity.Modules.PageSpeed.Model;
using Azavar.Sitefinity.Modules.PageSpeed.ViewModels;

namespace Azavar.Sitefinity.Modules.PageSpeed
{
    public class ViewMapper
    {
        public static RuleSetViewModel CreateRuleSetViewModelFrom(List<PageSpeedResult> results, string rule)
        {
            var result = results.First();

            RuleSetViewModel viewModel = null;

            switch (rule)
            {
                case "AvoidLandingPageRedirects":
                    viewModel = new RuleSetViewModel
                    {            
                        LocalizedName = result.FormattedResults.RuleResults.AvoidLandingPageRedirects.LocalizedRuleName,
                        Summary = MapTokensFrom(result.FormattedResults.RuleResults.AvoidLandingPageRedirects.Summary),
                        Urlblocks =
                            MapImpactedUrlsFrom(result.FormattedResults.RuleResults.AvoidLandingPageRedirects.UrlBlocks)
                    };
                    break;
                case "EnableGzipCompression":
                    viewModel = new RuleSetViewModel
                    {
                        LocalizedName = result.FormattedResults.RuleResults.EnableGzipCompression.LocalizedRuleName,
                        Summary = MapTokensFrom(result.FormattedResults.RuleResults.EnableGzipCompression.Summary),
                        Urlblocks =
                            MapImpactedUrlsFrom(result.FormattedResults.RuleResults.EnableGzipCompression.UrlBlocks)
                    };
                    break;
                case "LeverageBrowserCaching":
                    viewModel = new RuleSetViewModel
                    {
                        LocalizedName = result.FormattedResults.RuleResults.LeverageBrowserCaching.LocalizedRuleName,
                        Summary = MapTokensFrom(result.FormattedResults.RuleResults.LeverageBrowserCaching.Summary),
                        Urlblocks =
                            MapImpactedUrlsFrom(result.FormattedResults.RuleResults.LeverageBrowserCaching.UrlBlocks)
                    };
                    break;
                case "OptimizeImages":
                    viewModel = new RuleSetViewModel
                    {
                        LocalizedName = result.FormattedResults.RuleResults.OptimizeImages.LocalizedRuleName,
                        Summary = MapTokensFrom(result.FormattedResults.RuleResults.OptimizeImages.Summary),
                        Urlblocks = MapImpactedUrlsFrom(result.FormattedResults.RuleResults.OptimizeImages.UrlBlocks)
                    };

                    break;
                case "MinimizeRenderBlockingResources":
                    viewModel = new RuleSetViewModel
                    {
                        LocalizedName = result.FormattedResults.RuleResults.MinimizeRenderBlockingResources.LocalizedRuleName,
                        Summary = MapTokensFrom(result.FormattedResults.RuleResults.MinimizeRenderBlockingResources.Summary),
                        Urlblocks =
                            MapImpactedUrlsFrom(
                                result.FormattedResults.RuleResults.MinimizeRenderBlockingResources.UrlBlocks)
                    };
                    break;
                case "MinifyJavaScript":
                    viewModel = new RuleSetViewModel
                    {
                        LocalizedName = result.FormattedResults.RuleResults.MinifyJavaScript.LocalizedRuleName,
                        Summary = MapTokensFrom(result.FormattedResults.RuleResults.MinifyJavaScript.Summary),
                        Urlblocks =
                            MapImpactedUrlsFrom(result.FormattedResults.RuleResults.MinifyJavaScript.UrlBlocks)
                    };
                    break;
                case "MinifyCss":
                    viewModel = new RuleSetViewModel
                    {
                        LocalizedName = result.FormattedResults.RuleResults.MinifyCss.LocalizedRuleName,
                        Summary = MapTokensFrom(result.FormattedResults.RuleResults.MinifyCss.Summary),
                        Urlblocks = MapImpactedUrlsFrom(result.FormattedResults.RuleResults.MinifyCss.UrlBlocks)
                    };
                    break;
                case "MinifyHtml":
                    viewModel = new RuleSetViewModel
                    {
                        LocalizedName = result.FormattedResults.RuleResults.MinifyHtml.LocalizedRuleName,
                        Summary = MapTokensFrom(result.FormattedResults.RuleResults.MinifyHtml.Summary),
                        Urlblocks = MapImpactedUrlsFrom(result.FormattedResults.RuleResults.MinifyHtml.UrlBlocks)
                    };
                    break;
                case "PrioritizeVisibleContent":
                    viewModel = new RuleSetViewModel
                    {
                        LocalizedName = result.FormattedResults.RuleResults.PrioritizeVisibleContent.LocalizedRuleName,
                        Summary = result.FormattedResults.RuleResults.PrioritizeVisibleContent.Summary.ToString(),
                        Urlblocks =
                            MapImpactedUrlsFrom(result.FormattedResults.RuleResults.PrioritizeVisibleContent.UrlBlocks)
                    };
                    break;
                case "MainResourceServerResponseTime":
                    viewModel = new RuleSetViewModel
                    {
                        LocalizedName = result.FormattedResults.RuleResults.MainResourceServerResponseTime.LocalizedRuleName,
                        Summary = MapTokensFrom(result.FormattedResults.RuleResults.MainResourceServerResponseTime.Summary),
                        Urlblocks =
                            MapImpactedUrlsFrom(
                                result.FormattedResults.RuleResults.MainResourceServerResponseTime.UrlBlocks)
                    };
                    break;
            }

            return viewModel;
        }

        public static List<PageSpeedResultViewModel> CreatePageSpeedResultViewModelListFrom(Task<List<PageSpeedResult>> results)
        {
            var viewModels = new List<PageSpeedResultViewModel>();

            foreach (var pageSpeedResult in results.Result)
            {
                viewModels.Add(new PageSpeedResultViewModel
                {
                    Url = pageSpeedResult.Id,
                    Title = pageSpeedResult.Title,
                    Score = pageSpeedResult.RuleGroups.Speed.Score,
                    ContextClass = GetContextClassFromScore(pageSpeedResult.RuleGroups.Speed.Score),
                    ResponseCode = pageSpeedResult.ResponseCode,
                    RuleSets = MapRuleSets(pageSpeedResult)
                });
            }

            return viewModels;
        }

        private static List<RuleSetViewModel> MapRuleSets(PageSpeedResult pageSpeedResult)
        {
            var ruleSets = new List<RuleSetViewModel>
            {
                new RuleSetViewModel
                {
                    LocalizedName = pageSpeedResult.FormattedResults.RuleResults.AvoidLandingPageRedirects.LocalizedRuleName,
                    Impact = pageSpeedResult.FormattedResults.RuleResults.AvoidLandingPageRedirects.RuleImpact,
                    Summary = MapTokensFrom(pageSpeedResult.FormattedResults.RuleResults.AvoidLandingPageRedirects.Summary),
                    Severity = GetSeverityFromRuleImpact(pageSpeedResult.FormattedResults.RuleResults.AvoidLandingPageRedirects.RuleImpact),
                    Url = pageSpeedResult.Id,
                    RuleName = "AvoidLandingPageRedirects"
                },
                new RuleSetViewModel
                {
                    LocalizedName = pageSpeedResult.FormattedResults.RuleResults.EnableGzipCompression.LocalizedRuleName,
                    Impact = pageSpeedResult.FormattedResults.RuleResults.EnableGzipCompression.RuleImpact,
                    Summary = MapTokensFrom(pageSpeedResult.FormattedResults.RuleResults.EnableGzipCompression.Summary),
                    Severity = GetSeverityFromRuleImpact(pageSpeedResult.FormattedResults.RuleResults.EnableGzipCompression.RuleImpact),
                    Url = pageSpeedResult.Id,
                    RuleName = "EnableGzipCompression"
                },
                new RuleSetViewModel
                {
                    LocalizedName = pageSpeedResult.FormattedResults.RuleResults.LeverageBrowserCaching.LocalizedRuleName,
                    Impact = pageSpeedResult.FormattedResults.RuleResults.LeverageBrowserCaching.RuleImpact,
                    Summary = MapTokensFrom(pageSpeedResult.FormattedResults.RuleResults.LeverageBrowserCaching.Summary),
                    Severity = GetSeverityFromRuleImpact(pageSpeedResult.FormattedResults.RuleResults.LeverageBrowserCaching.RuleImpact),
                    Url = pageSpeedResult.Id,
                    RuleName = "LeverageBrowserCaching"
                },
                new RuleSetViewModel
                {
                    LocalizedName = pageSpeedResult.FormattedResults.RuleResults.OptimizeImages.LocalizedRuleName,
                    Impact = pageSpeedResult.FormattedResults.RuleResults.OptimizeImages.RuleImpact,
                    Summary = MapTokensFrom(pageSpeedResult.FormattedResults.RuleResults.OptimizeImages.Summary),
                    Severity = GetSeverityFromRuleImpact(pageSpeedResult.FormattedResults.RuleResults.OptimizeImages.RuleImpact),
                    Url = pageSpeedResult.Id,
                    RuleName = "OptimizeImages"
                },                
                new RuleSetViewModel
                {
                    LocalizedName = pageSpeedResult.FormattedResults.RuleResults.MinimizeRenderBlockingResources.LocalizedRuleName,
                    Impact = pageSpeedResult.FormattedResults.RuleResults.MinimizeRenderBlockingResources.RuleImpact,
                    Summary = MapTokensFrom(pageSpeedResult.FormattedResults.RuleResults.MinimizeRenderBlockingResources.Summary),
                    Severity = GetSeverityFromRuleImpact(pageSpeedResult.FormattedResults.RuleResults.MinimizeRenderBlockingResources.RuleImpact),
                    Url = pageSpeedResult.Id,
                    RuleName = "MinimizeRenderBlockingResources"
                },                
                new RuleSetViewModel
                {
                    LocalizedName = pageSpeedResult.FormattedResults.RuleResults.MinifyJavaScript.LocalizedRuleName,
                    Impact = pageSpeedResult.FormattedResults.RuleResults.MinifyJavaScript.RuleImpact,
                    Summary = MapTokensFrom(pageSpeedResult.FormattedResults.RuleResults.MinifyJavaScript.Summary),
                    Severity = GetSeverityFromRuleImpact(pageSpeedResult.FormattedResults.RuleResults.MinifyJavaScript.RuleImpact),
                    Url = pageSpeedResult.Id,
                    RuleName = "MinifyJavaScript"
                },                
                new RuleSetViewModel
                {
                    LocalizedName = pageSpeedResult.FormattedResults.RuleResults.MinifyCss.LocalizedRuleName,
                    Impact = pageSpeedResult.FormattedResults.RuleResults.MinifyCss.RuleImpact,
                    Summary = MapTokensFrom(pageSpeedResult.FormattedResults.RuleResults.MinifyCss.Summary),
                    Severity = GetSeverityFromRuleImpact(pageSpeedResult.FormattedResults.RuleResults.MinifyCss.RuleImpact),
                    Url = pageSpeedResult.Id,
                    RuleName = "MinifyCss"
                },                
                new RuleSetViewModel
                {
                    LocalizedName = pageSpeedResult.FormattedResults.RuleResults.MinifyHtml.LocalizedRuleName,
                    Impact = pageSpeedResult.FormattedResults.RuleResults.MinifyHtml.RuleImpact,
                    Summary = MapTokensFrom(pageSpeedResult.FormattedResults.RuleResults.MinifyHtml.Summary),
                    Severity = GetSeverityFromRuleImpact(pageSpeedResult.FormattedResults.RuleResults.MinifyHtml.RuleImpact),
                    Url = pageSpeedResult.Id,
                    RuleName = "MinifyHtml"
                },                
                new RuleSetViewModel
                {
                    LocalizedName = pageSpeedResult.FormattedResults.RuleResults.PrioritizeVisibleContent.LocalizedRuleName,
                    Impact = pageSpeedResult.FormattedResults.RuleResults.PrioritizeVisibleContent.RuleImpact,
                    Summary = MapTokensFrom(pageSpeedResult.FormattedResults.RuleResults.PrioritizeVisibleContent.Summary),
                    Severity = GetSeverityFromRuleImpact(pageSpeedResult.FormattedResults.RuleResults.PrioritizeVisibleContent.RuleImpact),
                    Url = pageSpeedResult.Id,
                    RuleName = "PrioritizeVisibleContent"
                },                
                new RuleSetViewModel
                {
                    LocalizedName = pageSpeedResult.FormattedResults.RuleResults.MainResourceServerResponseTime.LocalizedRuleName,
                    Impact = pageSpeedResult.FormattedResults.RuleResults.MainResourceServerResponseTime.RuleImpact,
                    Summary = MapTokensFrom(pageSpeedResult.FormattedResults.RuleResults.MainResourceServerResponseTime.Summary),
                    Severity = GetSeverityFromRuleImpact(pageSpeedResult.FormattedResults.RuleResults.MainResourceServerResponseTime.RuleImpact),
                    Url = pageSpeedResult.Id,
                    RuleName = "MainResourceServerResponseTime"
                }
            };

            return ruleSets.OrderByDescending(rs => rs.Impact).ToList();
        }

        public static UrlblockViewModel[] MapImpactedUrlsFrom(Urlblock[] urlBlocks)
        {
            var viewModels = new List<UrlblockViewModel>();

            if (urlBlocks != null)
            {
                foreach (var urlblock in urlBlocks)
                {
                    var links = new List<string>();

                    var viewModel = new UrlblockViewModel
                    {
                        Header = MapTokensFrom(urlblock.Header)
                    };

                    if (urlblock.Urls == null) continue;

                    foreach (var url in urlblock.Urls)
                    {                        

                        links.Add(MapTokensFrom(url.Result));                       
                    }

                    viewModel.Links = links.ToArray();

                    viewModels.Add(viewModel);
                }                
            }

            return viewModels.ToArray();
        }

        public static string GetContextClassFromScore(int score)
        {
            var indication = "success";

            if (score < 90 && score >= 60)
                indication = "warning";

            if (score < 60)
                indication = "fail";

            return indication;
        }

        public static string GetSeverityFromRuleImpact(double ruleImpact)
        {
            var severity = "passed";

            if (ruleImpact > 0 && ruleImpact  <= 10)
                severity = "consider-fixing";

            if (ruleImpact > 10)
                severity = "should-fix";

            return severity;
        }

        public static string MapTokensFrom(IPageSpeedFormattable formattable)
        {
            if (formattable == null)
                return string.Empty;

            if (formattable.Args == null)
                return formattable.Format;

            string returnString = formattable.Format;

            for (int i = 0; i < formattable.Args.Length; i++)
            {
                var key = formattable.Args[i].Key;

                switch (key)
                {
                    case "LINK":
                        returnString = returnString
                            .Replace("{{BEGIN_LINK}}", $"<a href='{formattable.Args[i].Value}' target='_blank'>")
                            .Replace("{{END_LINK}}", "</a>");
                        break;
                    case "NUM_REDIRECTS":
                        returnString = returnString.Replace("{{NUM_REDIRECTS}}", formattable.Args[i].Value);
                        break;
                    case "NUM_CSS":
                        returnString = returnString.Replace("{{NUM_CSS}}", formattable.Args[i].Value);
                        break;
                    case "NUM_SCRIPTS":
                        returnString = returnString.Replace("{{NUM_SCRIPTS}}", formattable.Args[i].Value);
                        break;
                    case "URL":
                        returnString = returnString.Replace("{{URL}}", $"<a href='{formattable.Args[i].Value}' target='_blank'>{ Utilities.ShortenUrl(formattable.Args[i].Value) }</a>");
                        break;
                    case "SIZE_IN_BYTES":
                        returnString = returnString.Replace("{{SIZE_IN_BYTES}}", formattable.Args[i].Value);
                        break;
                    case "PERCENTAGE":
                        returnString = returnString.Replace("{{PERCENTAGE}}", formattable.Args[i].Value);
                        break;
                    case "LIFETIME":
                        returnString = returnString.Replace("{{LIFETIME}}", formattable.Args[i].Value);
                        break;
                }
            }

            return returnString;
        }
    }
}