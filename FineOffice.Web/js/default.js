function onReady() {
    var btnExpandAll = Ext.getCmp(IDS.btnExpandAll);
    var btnCollapseAll = Ext.getCmp(IDS.btnCollapseAll);
    var btnRefreshTab = Ext.getCmp(IDS.btnRefreshTab);

    var mainMenu = Ext.getCmp(IDS.accMenu);
    var mainTabStrip = Ext.getCmp(IDS.tbsRight);

    function getExpandedPanel() {
        var panel = null;
        mainMenu.items.each(function (item) {
            if (!item.collapsed) {
                panel = item;
            }
        });
        return panel;
    }

    // 点击全部展开按钮
    btnExpandAll.on('click', function () {
        if (IDS.menuType == "menu") {
            mainMenu.expandAll();
        } else {
            var expandedPanel = getExpandedPanel();
            if (expandedPanel) {
                expandedPanel.items.itemAt(0).expandAll();
            }
        }
    });

    // 点击全部折叠按钮
    btnCollapseAll.on('click', function () {
        if (IDS.menuType == "menu") {
            mainMenu.collapseAll();
        } else {
            var expandedPanel = getExpandedPanel();
            if (expandedPanel) {
                expandedPanel.items.itemAt(0).collapseAll();
            }
        }
    });

    // 刷新当页面
    btnRefreshTab.on('click', function () {
        var currentTab = mainTabStrip.getActiveTab();
        if (window.frames[currentTab.id].location != null)
            window.frames[currentTab.id].location.reload();
    });

    // 公开添加示例标签页的方法
    window.addExampleTab = function (id, url, text, icon) {
        X.util.addMainTab(mainTabStrip, id, url, text, icon);
    };

    X.util.initTreeTabStrip(mainMenu, mainTabStrip, null, true);

    // 公开添加示例标签页的方法
    window.addExampleTab = function (id, url, text, icon) {
        X.util.addMainTab(mainTabStrip, id, url, text, icon);
    };

    //关闭指定的窗体
    window.closeTabWindow = function (tabID) {
        Ext.Msg.confirm('确认对话框', '确定要关闭吗？',
            function (btn) {
                if (btn == 'yes') {
                    var currentTab = mainTabStrip.getTab("dynamic_added_tab" + tabID);
                    mainTabStrip.remove(currentTab);
                }
            }, this);
    };

    window.closeRefreshRunProcess = function () {
        mainTabStrip.remove(mainTabStrip.getActiveTab());
        var runTabID = "dynamic_added_tab_FrmToHandleList";
        var runTab = window.frames[runTabID];
        var myWorkTab = window.frames["dynamic_added_tab_FrmMyWorkRun"];

        if (runTab != null) {
            mainTabStrip.setActiveTab(runTabID);
            runTab.refreshData();
        }
        if (myWorkTab != null) {
            myWorkTab.refreshData();
        }
    };

    window.closeCurrentTab = function () {
        var currentTab = mainTabStrip.getActiveTab();
        mainTabStrip.remove(currentTab);
    };

    window.refreshRunProcess = function () {
        var toHandleListTab = window.frames["dynamic_added_tab_FrmToHandleList"];
        if (toHandleListTab != null)
            toHandleListTab.refreshData();
    };

    window.refreshAttach = function (tabID) {
        var id = "dynamic_added_tab" + tabID;
        window.frames[id].refreshAttach();
    };
}
