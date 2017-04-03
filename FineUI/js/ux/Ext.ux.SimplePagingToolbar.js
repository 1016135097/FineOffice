
// added by 30372245@qq.com on 2009-7-4

(function() {

    var T = Ext.Toolbar;

    Ext.ux.SimplePagingToolbar = Ext.extend(Ext.Toolbar, {

        pageSize: 20,
        pageIndex: 0,
        recordCount: 0,
        pageCount: 0,

        displayMsg: 'Displaying {0} - {1} of {2}',

        emptyMsg: 'No data to display',

        beforePageText: "Page",

        afterPageText: "of {0}",

        firstText: "First Page",

        prevText: "Previous Page",

        nextText: "Next Page",

        lastText: "Last Page",

        initComponent: function() {
            var pagingItems = [this.first = new T.Button({
                tooltip: this.firstText,
                overflowText: this.firstText,
                iconCls: "x-tbar-page-first",
                disabled: true,
                handler: this.onClick,
                scope: this
            }), this.prev = new T.Button({
                tooltip: this.prevText,
                overflowText: this.prevText,
                iconCls: "x-tbar-page-prev",
                disabled: true,
                handler: this.onClick,
                scope: this
            }), '-', this.beforePageText,
            this.inputItem = new Ext.form.NumberField({
				cls: 'x-tbar-page-number',
				allowDecimals: false,
				allowNegative: false,
				enableKeyEvents: true,
				selectOnFocus: true,
				submitValue: false,
				listeners: {
					scope: this,
					keydown: this.onPagingKeyDown,
					blur: this.onPagingBlur
				}
			}), this.afterTextItem = new T.TextItem({
                text: String.format(this.afterPageText, 1)
            }), '-', this.next = new T.Button({
                tooltip: this.nextText,
                iconCls: "x-tbar-page-next",
                disabled: true,
                handler: this.onClick,
                scope: this
            }), this.last = new T.Button({
                tooltip: this.lastText,
                iconCls: "x-tbar-page-last",
                disabled: true,
                handler: this.onClick,
                scope: this
            })];


            var userItems = this.items || this.buttons || [];
			if (this.prependButtons) {
				this.items = userItems.concat(pagingItems);
			}else{
				this.items = pagingItems.concat(userItems);
			}
			delete this.buttons;
			if(this.displayInfo){
				this.items.push('->');
				this.items.push(this.displayItem = new T.TextItem({}));
			}
            Ext.ux.SimplePagingToolbar.superclass.initComponent.call(this);

            this.on('afterlayout', this.onFirstLayout, this, { single: true });
        },


        load: function(options) {
            Ext.apply(this, options);
            this.onLoad();
        },

        // private
        onFirstLayout: function() {
            this.onLoad();
        },
		
		// private
        onLoad: function() {
            var d = this.getPageData(), ap = d.activePage, ps = d.pages;

            this.afterTextItem.setText(String.format(this.afterPageText, d.pages));
            this.inputItem.setValue(ap);
            this.first.setDisabled(ap == 1);
            this.prev.setDisabled(ap == 1);
            this.next.setDisabled(ap == ps);
            this.last.setDisabled(ap == ps);
            this.updateInfo();
        },

        // private
        updateInfo: function() {
            if (this.displayItem) {
                var msg = '';
                if (this.recordCount == 0) {
                    msg = this.emptyMsg;
                }
                else {
                    var endPoint = (this.pageIndex + 1) * this.pageSize;
                    endPoint = endPoint < this.recordCount ? endPoint : this.recordCount;
                    msg = String.format(this.displayMsg, this.pageIndex * this.pageSize + 1, endPoint, this.recordCount);
                }
                this.displayItem.setText(msg);
            }
        },

        // private
        getPageData: function() {
            return {
                total: this.recordCount,
                activePage: this.pageIndex + 1,
                pages: this.pageCount <= 0 ? 1 : this.pageCount
            };
        },

        // private
        readPage: function(d) {
            var v = this.inputItem.getValue(), pageNum;
            if (!v || isNaN(pageNum = parseInt(v, 10))) {
                this.inputItem.setValue(d.activePage);
                return false;
            }
            return pageNum;
        },

        onPagingFocus: function() {
            this.inputItem.select();
        },

        //private
        onPagingBlur: function(e) {
            this.inputItem.setValue(this.getPageData().activePage);
        },

        // private
		onPagingKeyDown : function(field, e){
			var k = e.getKey(), d = this.getPageData(), pageNum;
			if (k == e.RETURN) {
				e.stopEvent();
				pageNum = this.readPage(d);
				if(pageNum !== false){
					pageNum = Math.min(Math.max(1, pageNum), d.pages) - 1;
					this.onLoadPage(pageNum);
				}
			}else if (k == e.HOME || k == e.END){
				e.stopEvent();
				pageNum = k == e.HOME ? 1 : d.pages;
				field.setValue(pageNum);
			}else if (k == e.UP || k == e.PAGEUP || k == e.DOWN || k == e.PAGEDOWN){
				e.stopEvent();
				if((pageNum = this.readPage(d))){
					var increment = e.shiftKey ? 10 : 1;
					if(k == e.DOWN || k == e.PAGEDOWN){
						increment *= -1;
					}
					pageNum += increment;
					if(pageNum >= 1 & pageNum <= d.pages){
						field.setValue(pageNum);
					}
				}
			}
		},


        // private
        onClick: function(button) {
            switch (button) {
                case this.first:
                    this.onLoadPage(0);
                    break;
                case this.prev:
                    var page = this.pageIndex - 1;
                    page = page < 0 ? 0 : page;
                    this.onLoadPage(page);
                    break;
                case this.next:
                    var page = this.pageIndex + 1;
                    page = page >= this.pageCount ? this.pageCount - 1 : page;
                    this.onLoadPage(page);
                    break;
                case this.last:
                    this.onLoadPage(this.pageCount - 1);
                    break;
            }
        },

        // overrided by user to do page navigation
        onLoadPage: function(pageIndex) {

        },

        // private
        onDestroy: function() {
            Ext.ux.SimplePagingToolbar.superclass.onDestroy.call(this);
        }

    });

})();

Ext.reg('ux-simplepaging', Ext.ux.SimplePagingToolbar);
