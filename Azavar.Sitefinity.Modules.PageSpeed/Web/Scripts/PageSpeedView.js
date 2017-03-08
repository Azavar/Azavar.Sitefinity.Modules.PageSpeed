
$(document).ready(function () {

    var isLocal = ($("#hdnIsLocalHost").val() == "true");

    var hasApiKey = ($("#hdnHasApiKey").val() == "true");

    function bindPageSpeedGridDataSource(results) {

        var pageSpeedGridDataSource = new kendo.data.DataSource({
            data: JSON.parse(results),
            schema: {
                model: {
                    fields: {
                        Score: { type: "number" },
                        ContextClass: { type: "string" },
                        ResponseCode: { type: "number" },
                        Title: { type: "string" },
                        Url: { type: "string" }
                    }
                }
            },
            pageSize: 20
        });

        var pageSpeedGrid = $("#page-speed-grid").data("kendoGrid");

        pageSpeedGrid.setDataSource(pageSpeedGridDataSource);
        pageSpeedGrid.dataSource.read();
    };


    var viewModel = kendo.observable({
        urls: [],
        url: null,
        displayUrlValidationMessage: false,
        hasApiKey: hasApiKey,
        isLocalHost: isLocal,
        isLocalHostMessageVisiable: isLocal,
        isManualRunButtonVisible: false,
        isAutoRunButtonVisible: false,
        addUrl: function (e) {

            if (!document.getElementById("url").checkValidity()) {
                this.set("displayUrlValidationMessage", true);
                return;
            };

            this.set("displayUrlValidationMessage", false);

            $("#grid-urls").css("display", "block");

            this.get("urls").push({
                Url: this.get("url")
            });
            this.set("url", "");

            this.set("isManualRunButtonVisible", true);
        },
        removeUrl: function (e) {

            var that = this;

            $.each(that.urls,
                function (idx, url) {

                    if (e.data.uid === url.uid) {
                        that.urls.splice(idx, 1);
                        return true;
                    }
                });
        },
        runPageSpeedAuto: function (e) {

            //show progress indicator
            kendo.ui.progress($("#input-view"), true);

            $.ajax({
                type: "POST",
                url: $("#hdnServiceUrlRunPageSpeedOnPageIds").val(),
                contentType: "application/json",
                dataType: "json",
                data: JSON.stringify({
                    ids: this.get("pageIds").join(),
                    baseUrl: $("#hdnBaseUrl").val()
                }),
                success: function (result) {

                    //console.log(result);

                    var results = JSON.stringify(result["RunPageSpeedOnPageIdsResult"]);

                    bindPageSpeedGridDataSource(results);
                }
            });


        },
        runPageSpeedManual: function (e) {
            //disable the button
            $("#btn-run-page-speed").prop("disabled", true);

            //show progress indicator
            kendo.ui.progress($("#input-view"), true);

            var urlsToScan = [];

            for (var i = 0; i < viewModel.urls.length; i++) {

                urlsToScan.push(viewModel.urls[i].Url);
            }

            $.ajax({
                type: "POST",
                url: $("#hdnServiceUrl").val(),
                contentType: "application/json",
                dataType: "json",
                data: JSON.stringify({
                    urls: urlsToScan.join()
                }),
                success: function (result) {

                    var results = JSON.stringify(result["RunPageSpeedOnUrlsResult"]);

                    bindPageSpeedGridDataSource(results);
                }
            });
        },
        selectedMode: "manual",
        pageSpeedModeChange: function (e) {
            if (this.get("selectedMode") === "manual") {
                this.set("isManualModeVisible", true);
                this.set("isAutoModeVisible", false);
            } else {
                this.set("isManualModeVisible", false);
                this.set("isAutoModeVisible", true);
            }
        },
        isManualModeVisible: true,
        isAutoModeVisible: false,
        pageIds: []
    });

    kendo.bind(document.body.children, viewModel);

    $("#page-speed-grid").kendoGrid({
        autoBind: false,
        dataBound: function (e) {

            var items = e.sender.items();

            items.each(function (index, e) {
                var dataItem = $("#page-speed-grid").data("kendoGrid").dataItem(this);

                this.className += " " + dataItem.ContextClass;
            });

            $("#btn-run-page-speed").prop("disabled", false);
            kendo.ui.progress($("#input-view"), false);

            $("#results-view").css("display", "block");
            $("#input-view").css("display", "none");
        },
        filterable: false,
        sortable: true,
        pageable: false,
        columns: [
            {
                field: "Score",
                title: "Score",
                width: "100px"
            },
            {
                field: "ResponseCode",
                title: "Response Code",
                width: "150px"
            },
            {
                field: "Title",
                title: "Title"
            },
            {
                field: "Url",
                title: "Url",
                template: "<a href='#= Url #' target='_blank' class='sfMoreDetails'><span class='sfTooltip'>#= Url #</span></a>"
            }
        ],
        detailTemplate: kendo.template($("#details-template").html()),
        detailInit: detailInit
    });


    //rule result details config
    $("#rule-result-details-window").kendoWindow({
        actions: [
            "Close"
        ],
        draggable: false,
        modal: true,
        pinned: true,
        refresh: function (e) {
            e.sender.center();
            kendo.ui.progress($("#page-speed-grid"), false);
            this.open();
        },
        visible: false,
        width: "800px"
    }).data("kendoWindow").center();

    var pagesDataSource = new kendo.data.HierarchicalDataSource({
        transport: {
            read: {
                url: $("#hdnPagesServiceUrl").val(),
                dataType: "json",
                data: function (options) {
                    return {
                        root: options.Id,
                        itemType: "Telerik.Sitefinity.Pages.Model.PageNode",
                        hierarchyMode: "true"
                    };
                }
            }
        },
        schema: {
            parse: function (response) {
                return response.Items;
            },
            model: {
                id: "Id",
                hasChildren: "HasChildren"
            }
        }
    });

    $("#treeview").kendoTreeView({
        checkboxes: {
            checkChildren: false
        },
        check: onCheck,
        dataSource: pagesDataSource,
        dataTextField: "Title.Value"
    });

    // function that gathers IDs of checked nodes
    function checkedNodeIds(nodes, checkedNodes) {
        for (var i = 0; i < nodes.length; i++) {
            if (nodes[i].checked) {
                checkedNodes.push(nodes[i].id);
            }

            if (nodes[i].hasChildren) {
                checkedNodeIds(nodes[i].children.view(), checkedNodes);
            }
        }
    }

    // show checked node IDs on datasource change
    function onCheck() {
        var checkedNodes = [];
        var treeView = $("#treeview").data("kendoTreeView");

        //checkedNodeIds(treeView.dataSource.view(), checkedNodes);

        var nodes = treeView.dataSource.view();

        for (var i = 0; i < nodes.length; i++) {
            if (nodes[i].checked) {
                checkedNodes.push(nodes[i].id);
            }

            if (nodes[i].hasChildren) {
                checkedNodeIds(nodes[i].children.view(), checkedNodes);
            }
        }

        viewModel.set("pageIds", checkedNodes); //todo: refactor this?

        if (checkedNodes.length > 0) {
            viewModel.set("isAutoRunButtonVisible", true);
        } else {
            viewModel.set("isAutoRunButtonVisible", false);
        }
    }
});

function detailInit(e) {
    var detailRow = e.detailRow;

    $(".rule-result-details").click(function () {

        //console.log("clicked");

        kendo.ui.progress($("#page-speed-grid"), true);

        var detailsWindow = $("#rule-result-details-window").data("kendoWindow");

        detailsWindow.content("");

        var url = $(this).data("url");

        var ruleName = $(this).data("rule-name");

        var localizedName = $(this).data("rule-localized-name");

        detailsWindow.refresh({
            url: "/Sitefinity/Services/PageSpeed.svc/Details",
            data: {
                uri: url,
                ruleName: ruleName
            },
            dataType: "json",
            template: kendo.template($("#rule-result-details-template").html())
        }).title(localizedName);
    });

}