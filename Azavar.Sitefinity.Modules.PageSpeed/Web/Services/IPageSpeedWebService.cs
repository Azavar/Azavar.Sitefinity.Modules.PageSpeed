using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Azavar.Sitefinity.Modules.PageSpeed.ViewModels;

namespace Azavar.Sitefinity.Modules.PageSpeed.Web.Services
{

    [ServiceContract]
    public interface IPageSpeedWebService
    {
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat  = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        List<PageSpeedResultViewModel> RunPageSpeedOnUrls(string urls);


        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat  = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        List<PageSpeedResultViewModel> RunPageSpeedOnPageIds(string ids, string baseUrl);

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        PageSpeedStatus GetStatus();

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        RuleSetViewModel Details(string uri, string ruleName);
    }
}