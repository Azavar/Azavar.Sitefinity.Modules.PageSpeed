<%@ Control Language="C#" %>
<%@ Register TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" Assembly="Telerik.Sitefinity" %>
<%@ Import Namespace="Telerik.Sitefinity.Web" %>


<sf:ResourceLinks ID="kendoStyles" runat="server" UseEmbeddedThemes="True" UseBackendTheme="True">
    <sf:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.Kendo.styles.kendo_common_min.css" Static="true" />
    <sf:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.Kendo.styles.kendo_default_min.css" Static="true" />
    <sf:ResourceFile Name="Telerik.Sitefinity.Resources.Themes.Light.Styles.Grid.css" Static="true" />    
    <sf:ResourceFile Name="Telerik.Sitefinity.Resources.Themes.Light.Styles.Window.css" Static="true" />   
    <%--<sf:ResourceFile Name="Azavar.Sitefinity.Modules.PageSpeed.Styles.PageSpeedStyles.min.css" AssemblyInfo="Azavar.Sitefinity.Modules.PageSpeed.Web.UI.Views.PageSpeedView, Azavar.Sitefinity.Modules.PageSpeed" Static="true" /> todo: figure this out--%> 
</sf:ResourceLinks>




<sf:ResourceLinks id="ResourceLibraryScripts" runat="server" UseEmbeddedThemes="True" UseBackendTheme="True">
    <sf:ResourceFile JavaScriptLibrary="JQuery" />
</sf:ResourceLinks>

<script type="text/javascript" src="<%= UrlPath.AddAppVirtualPath("/ExtRes/Telerik.Sitefinity.Resources.Scripts.Kendo.kendo.all.min.js") %>"></script>

<style> /*todo: use embedded resource*/
    #page-speed-grid tr.fail {
  background-color: #ffb9b9;
}
#page-speed-grid tr.success {
  background-color: #dbf1df;
}
#page-speed-grid tr.warning {
  background-color: #ffc;
}
#details-template tr td .rule-result-details {
  color: #666;
  text-decoration: underline;
  cursor: pointer;
}
#details-template tr td .rule-result-details:hover {
  text-decoration: none;
}
#grid-urls td,
#grid-urls th {
  padding: 8px;
}
#rule-result-details-window h3 {
  padding-bottom: 15px;
}
#treeview span.k-in {
  border: none;
}
#treeview span.k-state-hover,
#treeview span.k-state-selected,
#treeview span.k-state-focused {
  background-color: transparent;
  color: #000;
  background-image: none;
  box-shadow: none;
}

.sfButtonArea {
    margin-bottom: 40px;
}

.sfContentCentered {
    margin-left: auto;
    margin-right: auto;
    padding-bottom: 45px;
    width: 620px;
}

.sfContentCentered h1.sfBreadCrumb, h1.sfBreadCrumbCentered {
    padding-left: 0;
    padding-right: 0;
}
</style>


<div class="sfWorkArea" id="input-view">
    
    <div class="sfContentCentered">
        <h1 class="sfBreadCrumb">PageSpeed Insights</h1>
        
        <div data-bind="invisible: hasApiKey">
            <div class="sfMBottom25 sfNeutral">
                <p class="sfMBottom25">Please obtain an <a href="https://developers.google.com/speed/docs/insights/v2/first-app" target="_blank">API key</a> and add it to the module settings under Settings &gt; Advanced &gt; PageSpeed &gt; ApiKey</p>
                <p><a class="sfGoto" href="/Sitefinity/Administration/Settings/Advanced">Change Settings</a></p>
            </div>
        </div>        

        <div class="sfMBottom25">
            <h2>About PageSpeed Insights</h2>
            <p>PageSpeed Insights analyzes the content of a web page, then generates suggestions to make that page faster. <a target="_blank" href="https://developers.google.com/speed/docs/insights/about?hl=en-US&utm_source=PSI&utm_medium=incoming-link&utm_campaign=PSI">Learn more</a>.</p>
        </div>
        
        <div data-bind="visible: hasApiKey">

        <div>
	        <label>
	          <input type="radio" name="page-speed-mode" value="manual" checked="checked" data-bind="checked: selectedMode, events: {change: pageSpeedModeChange } ">
	          Use the following urls
	        </label>
        </div>
        <div>
	        <label>
	          <input type="radio" name="page-speed-mode" value="auto" data-bind="disabled: isLocalHost, checked: selectedMode, events: { change: pageSpeedModeChange }">
	          Use the following pages from this site
	        </label>
            <div class="sfNeutral" data-bind="visible: isLocalHostMessageVisiable">
                <p>Submitting pages from localhost is not supported as PageSpeed Insights requires a live url.</p>
            </div>
        </div>

            <div data-bind="visible: isManualModeVisible">
                <div class="sfForm">
                    <div class="sfFormIn">
                        <ul>
                            <li class="sfTitleField sfShortField310 sfMBottom10">
                                <div>
                                    <input id="url" type="url" class='k-textbox sfTxt' data-bind="value: url" required="required" placeholder="http://www.example.com" style="width: 100%;" />
                                    <div class="sfFailure" data-bind="visible: displayUrlValidationMessage" style="display: none;">
                                        <p>Please enter a valid url.</p>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <div class="sfClearfix">
                                    <input type="button" id="add" data-bind="click: addUrl" class="sfLinkBtn" value="Add" />
                                </div>
                            </li>
                        </ul>

                        <table id="grid-urls" style="display: none;">
                            <thead>
                                <tr>
                                    <th>Url</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody data-bind="source: urls" data-template="urlTemplate">
                            </tbody>
                        </table>

                        <script type="text/x-kendo-template" id="urlTemplate">
                    <tr>
                        <td><a href="#= Url #" target="_blank">#= Url #</a></td>
                        <td><input type="button" class="sfLinkBtn sfDelete" data-bind="click: removeUrl" value="Remove" /></td>
                    </tr>
                        </script>
                    </div>
                </div>
                <div class="sfButtonArea">
                    <input type="button" value="Run" class="sfLinkBtn sfSave" id="btn-run-page-speed" data-bind="click: runPageSpeedManual, visible: isManualRunButtonVisible" style="display: none;">
                </div>
            </div>

            <div data-bind="visible: isAutoModeVisible">
                <div class="sfForm">
                    <div class="sfFormIn">
                        <div id="treeview"></div>
                    </div>
                </div>
                <div class="sfButtonArea">
                    <input type="button" value="Run" class="sfLinkBtn sfSave" data-bind="click: runPageSpeedAuto, visible: isAutoRunButtonVisible" style="display: none;">
                </div>
            </div>
        </div>
    </div>
</div>

<div id="results-view" style="display: none;">

    <h1 class="sfBreadCrumb">PageSpeed Insights Results</h1>

    <div class="sfMain sfClearfix">
        <div class="sfAllToolsWrapper">
            <div class="sfAllTools">
                <div class="sfActions">
                    <ul>
                        <li class="sfMainAction"><a href="Page-Speed" class="sfLinkBtn sfSave">Return</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="sfWorkArea">
            <div id="page-speed-grid"></div>            
        </div>
    </div>

    <div id="rule-result-details-window" class="sfSelectorDialog"></div>

</div>

<script type="text/x-kendo-template" id="details-template">
    <div id="details-template">        
        <table>
            <thead>
                <tr>
                    <td>Name</td>
                    <td>Impact</td>
                    <td>Summary</td>
                    <td>Details</td>
                <tr>
            </thead>
            <tbody>
        # for(var i = 0; i < RuleSets.length; i++){ #
        
            <tr class="#= RuleSets[i].Severity #">
                <td>#= RuleSets[i].LocalizedName #</td>
                <td>#= RuleSets[i].Impact #</td>
                <td>#= RuleSets[i].Summary #</td>
                <td><span data-url="#= RuleSets[i].Url #" data-rule-name="#= RuleSets[i].RuleName #" data-rule-localized-name="#= RuleSets[i].LocalizedName #" class="rule-result-details">Details</span></td>                    
            </tr>                      

        # } #
            </tbody>
        </table>
    </div>

</script>


<script type="text/x-kendo-template" id="rule-result-details-template">        
        <h1>#= Summary #</h1>  
                
        # for (var i = 0; i < Urlblocks.length; i++) { #
        
        <h3>#= Urlblocks[i].Header #</h3>
        
        <ul>

            # for (var j = 0; j < Urlblocks[i].Links.length; j++) { #
        
                    <li>#= Urlblocks[i].Links[j] #</li>

            # } # 
        </ul>      

        # } #                
</script>

<%-- sitemap service --%>
<asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnServiceUrl" />
<asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnIsLocalHost" />
<asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnBaseUrl" />
<asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnPagesServiceUrl" />
<asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnServiceUrlRunPageSpeedOnPageIds" />
<asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnHasApiKey" />