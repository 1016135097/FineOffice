// Create user extension namespace
Ext.namespace('Ext.ux');

/**
* @class Ext.ux.SwfUploadPanel
* @extends Ext.grid.GridPanel

* Makes a Panel to provide the ability to upload multiple files using the SwfUpload flash script.
*
* @author Stephan Wentz
* @author Michael Giddens (Original author)
* @created 2008-02-26
* @version 0.5
* 
* known_issues 
*      - Progress bar used hardcoded width. Not sure how to make 100% in bbar
*      - Panel requires width / height to be set.  Not sure why it will not fit
*      - when panel is nested sometimes the column model is not always shown to fit until a file is added. Render order issue.
*      
* @constructor
* @param {Object} config The config object
*/
Ext.ux.SwfUploadPanel = Ext.extend(Ext.grid.GridPanel, {

    /**
    * @cfg {Object} strings
    * All strings used by Ext.ux.SwfUploadPanel
    */
    strings: {
        text_add: '添加文件',
        text_upload: '上传',
        text_cancel: '取消上传',
        text_clear: '清空队列',
        text_progressbar: 'Progress Bar',
        text_remove: 'Remove File',
        text_remove_sure: 'Are you sure you wish to remove this file from queue?',
        text_error: 'Error',
        text_uploading: '正在上传文件: {0} ({1} of {2})',
        header_filename: '文件名',
        header_size: '大小',
        header_status: '状态',
        status: {
            0: '队列',
            1: '上传中...',
            2: '完成',
            3: '错误',
            4: '已取消'
        },
        error_queue_exceeded: 'The selected file(s) exceed(s) the maximum number of {0} queued files.',
        error_queue_slots_0: 'There is no slot left',
        error_queue_slots_1: 'There is only one slot left',
        error_queue_slots_2: 'There are only {0} slots left',
        error_size_exceeded: 'The selected files size exceeds the allowed limit of {0}.',
        error_zero_byte_file: 'Zero byte file selected.',
        error_invalid_filetype: 'Invalid filetype selected.',
        error_file_not_found: 'File not found 404.',
        error_security_error: 'Security Error. Not allowed to post to different url.'
    },
    single_select: false,
    confirm_delete: true,
    file_types: "*.*",
    file_types_description: "All Files",
    file_size_limit: "1048576",
    file_upload_limit: "0",
    file_queue_limit: "0",
    file_post_name: "Filedata",
    flash_url: "swfupload.swf",
    debug: false,
    autoExpandColumn: 'name',
    enableColumnResize: false,
    enableColumnMove: false,
    rightMenu: null,
    upload_cancelled: false,

    // private
    initComponent: function () {

        this.addEvents(
      
            'swfUploadLoaded',
     
            'fileQueued',
      
            'startUpload',
      
            'fileUploadError',
      
            'fileUploadSuccess',
       
            'fileUploadComplete',
       
            'allUploadsComplete',
       
            'removeFiles',
       
            'removeAllFiles'
        );

        this.rec = Ext.data.Record.create([
             { name: 'name' },
             { name: 'size' },
             { name: 'id' },
             { name: 'type' },
             { name: 'creationdate', type: 'date', dateFormat: 'm/d/Y' },
             { name: 'status' }
        ]);

        this.store = new Ext.data.Store({
            reader: new Ext.data.JsonReader({
                id: 'id'
            }, this.rec)
        });

        this.columns = [{
            id: 'name',
            header: this.strings.header_filename,
            dataIndex: 'name'
        }, {
            id: 'size',
            header: this.strings.header_size,
            width: 80,
            dataIndex: 'size',
            renderer: this.formatBytes
        }, {
            id: 'status',
            header: this.strings.header_status,
            width: 80,
            dataIndex: 'status',
            renderer: this.formatStatus.createDelegate(this)
        }];

        this.sm = new Ext.grid.RowSelectionModel({
            singleSelect: this.single_select
        });


        this.progress_bar = new Ext.ProgressBar({
            text: this.strings.text_progressbar
        });

        var a = Ext.id();
        var b = this;
        this.addBtn = new Ext.Button({
            text: this.strings.text_add,
            iconCls: "icon-utils-s-add",
            xhandler: function () {
                if (this.single_select) {
                    this.suo.selectFile()
                } else {
                    this.suo.selectFiles()
                }
            },
            listeners: {
                render: function (d) {
                    var c = d.el.child("em");
                    c.setStyle({
                        position: "relative",
                        display: "block"
                    });
                    c.createChild({
                        tag: "div",
                        id: a
                    });
                    b.suo = new SWFUpload({
                        button_placeholder_id: a,
                        button_width: 66,
                        button_height: c.getHeight(),
                        button_cursor: SWFUpload.CURSOR.HAND,
                        button_window_mode: SWFUpload.WINDOW_MODE.TRANSPARENT,
                        upload_url: b.upload_url,
                        post_params: b.post_params,
                        file_post_name: b.file_post_name,
                        file_size_limit: b.file_size_limit,
                        file_queue_limit: b.file_queue_limit,
                        file_types: b.file_types,
                        file_types_description: b.file_types_description,
                        file_upload_limit: b.file_upload_limit,
                        flash_url: b.flash_url,
                        swfupload_loaded_handler: b.swfUploadLoaded.createDelegate(b),
                        file_dialog_start_handler: b.fileDialogStart.createDelegate(b),
                        file_queued_handler: b.fileQueue.createDelegate(b),
                        file_queue_error_handler: b.fileQueueError.createDelegate(b),
                        file_dialog_complete_handler: b.fileDialogComplete.createDelegate(b),
                        upload_start_handler: b.uploadStart.createDelegate(b),
                        upload_progress_handler: b.uploadProgress.createDelegate(b),
                        upload_error_handler: b.uploadError.createDelegate(b),
                        upload_success_handler: b.uploadSuccess.createDelegate(b),
                        upload_complete_handler: b.uploadComplete.createDelegate(b),
                        debug: b.debug,
                        debug_handler: b.debugHandler
                    });
                    Ext.get(b.suo.movieName).setStyle({
                        position: "absolute",
                        top: 0,
                        left: 0
                    })
                }
            }
        });

        this.clearBtn = new Ext.Button({
            text: this.strings.text_clear,
            iconCls: "icon-utils-s-delete",
            handler: this.removeAllFiles,
            scope: this,
            hidden: false
        });
        this.uploadBtn = new Ext.Button({
            text: this.strings.text_upload,
            iconCls: "icon-file-upload",
            handler: this.startUpload,
            scope: this,
            hidden: true
        });
        this.cancelBtn = new Ext.Button({
            text: this.strings.text_cancel,
            iconCls: "icon-file-cancel",
            handler: this.stopUpload,
            scope: this,
            hidden: true
        });
        this.tbar = [this.addBtn, "-", this.cancelBtn, this.uploadBtn, this.clearBtn];
        this.bbar = [this.progress_bar];

        this.addListener({
            keypress: {
                fn: function (c) {
                    if (this.confirm_delete) {
                        if (c.getKey() == c.DELETE) {
                            Ext.MessageBox.confirm(this.strings.text_remove, this.strings.text_remove_sure,
                            function (d) {
                                if (d == "yes") {
                                    this.removeFiles()
                                }
                            },
                            this)
                        }
                    } else {
                        this.removeFiles(this)
                    }
                },
                scope: this
            },
            contextmenu: function (c) {
                c.stopEvent()
            },
            render: {
                fn: function () {
                    this.resizeProgressBar();
                    this.on("resize", this.resizeProgressBar, this)
                },
                scope: this
            }
        });
        this.on('rowcontextmenu', function (grid, rowIndex, e) {
            var menus = new Ext.menu.Menu
                ([
                    {
                        text: "删除", pressed: true, icon: "../images/delete.png",
                        handler: function () {
                            grid.deleteHandler(grid, rowIndex);
                        }
                    }
                ]);
            grid.getSelectionModel().selectRow(rowIndex);
            e.preventDefault();
            menus.showAt(e.getPoint());
        });

        this.on("render",
        function () { },
        this);
        Ext.ux.SwfUploadPanel.superclass.initComponent.call(this);
    },

    deleteHandler: function (grid, rowIndex) {
        Ext.MessageBox.confirm("删除提示", "确定要删除吗？",
                            function (d) {
                                if (d == "yes") {
                                    var record = grid.getSelectionModel().getSelected();
                                    grid.suo.cancelUpload(record.id);
                                    grid.store.remove(record);
                                    if (grid.suo.getStats().files_queued === 0) {
                                        grid.uploadBtn.hide();
                                    }
                                }
                            });
    },

    resizeProgressBar: function () {
        this.progress_bar.setWidth(this.getBottomToolbar().el.getWidth() - 5);
    },

    /**
    * SWFUpload debug handler
    * @param {Object} line
    */
    debugHandler: function (line) {
        if (window.console) {
            console.log(line);
        }
    },

    /**
    * Formats file status
    * @param {Integer} status
    * @return {String}
    */
    formatStatus: function (status) {
        return this.strings.status[status];
    },

    /**
    * Formats raw bytes into kB/mB/GB/TB
    * @param {Integer} bytes
    * @return {String}
    */
    formatBytes: function (size) {
        if (!size) {
            size = 0;
        }
        var suffix = ["B", "KB", "MB", "GB"];
        var result = size;
        size = parseInt(size, 10);
        result = size + " " + suffix[0];
        var loop = 0;
        while (size / 1024 > 1) {
            size = size / 1024;
            loop++;
        }
        result = Math.round(size) + " " + suffix[loop];

        return result;

        if (isNaN(bytes)) {
            return ('');
        }

        var unit, val;

        if (bytes < 999) {
            unit = 'B';
            val = (!bytes && this.progressRequestCount >= 1) ? '~' : bytes;
        } else if (bytes < 999999) {
            unit = 'kB';
            val = Math.round(bytes / 1000);
        } else if (bytes < 999999999) {
            unit = 'MB';
            val = Math.round(bytes / 100000) / 10;
        } else if (bytes < 999999999999) {
            unit = 'GB';
            val = Math.round(bytes / 100000000) / 10;
        } else {
            unit = 'TB';
            val = Math.round(bytes / 100000000000) / 10;
        }

        return (val + ' ' + unit);
    },

    /**
    * SWFUpload swfUploadLoaded event
    */
    swfUploadLoaded: function () {
        if (this.debug) console.info('SWFUPLOAD LOADED');

        this.fireEvent('swfUploadLoaded', this);
    },

    /**
    * SWFUpload fileDialogStart event
    */
    fileDialogStart: function () {
        if (this.debug) console.info('FILE DIALOG START');

        this.fireEvent('fileDialogStart', this);
    },

    /**
    * Add file to store / grid
    * SWFUpload fileQueue event
    * @param {Object} file
    */
    fileQueue: function (file) {
        if (this.debug) console.info('FILE QUEUE');

        file.status = 0;
        r = new this.rec(file);
        r.id = file.id;
        this.store.add(r);

        this.fireEvent('fileQueued', this, file);
    },

    /**
    * Error when file queue error occurs
    * SWFUpload fileQueueError event
    * @param {Object}  file
    * @param {Integer} code
    * @param {string}  message
    */
    fileQueueError: function (file, code, message) {
        if (this.debug) console.info('FILE QUEUE ERROR');

        switch (code) {
            case -100:
                var slots;
                switch (message) {
                    case '0':
                        slots = this.strings.error_queue_slots_0;
                        break;
                    case '1':
                        slots = this.strings.error_queue_slots_1;
                        break;
                    default:
                        slots = String.format(this.strings.error_queue_slots_2, message);
                }
                Ext.MessageBox.alert(this.strings.text_error, String.format(this.strings.error_queue_exceeded + ' ' + slots, this.file_queue_limit));
                break;

            case -110:
                Ext.MessageBox.alert(this.strings.text_error, String.format(this.strings.error_size_exceeded, this.formatBytes(this.file_size_limit * 1024)));
                break;

            case -120:
                Ext.MessageBox.alert(this.strings.text_error, this.strings.error_zero_byte_file);
                break;

            case -130:
                Ext.MessageBox.alert(this.strings.text_error, this.strings.error_invalid_filetype);
                break;
        }
        this.fireEvent('fileQueueError', this, file, code, message);
    },

    /**
    * SWFUpload fileDialogComplete event
    * @param {Integer} file_count
    */
    fileDialogComplete: function (file_count) {
        if (this.debug) console.info('FILE DIALOG COMPLETE');

        if (file_count > 0) {
            this.uploadBtn.show();
        }

        this.addBtn.show();
        this.clearBtn.show();

        this.fireEvent('fileDialogComplete', this, file_count);
    },

    /**
    * SWFUpload uploadStart event
    * @param {Object} file
    */
    uploadStart: function (file) {
        if (this.debug) console.info('UPLOAD START');

        this.fireEvent('uploadStart', this, file);

        return true;
    },

    /**
    * SWFUpload uploadProgress event
    * @param {Object}  file
    * @param {Integer} bytes_completed
    * @param {Integer} bytes_total
    */
    uploadProgress: function (file, bytes_completed, bytes_total) {
        if (this.debug) console.info('UPLOAD PROGRESS');

        this.store.getById(file.id).set('status', 1);
        this.store.getById(file.id).commit();
        this.progress_bar.updateProgress(bytes_completed / bytes_total, String.format(this.strings.text_uploading, file.name, this.formatBytes(bytes_completed), this.formatBytes(bytes_total)));

        this.fireEvent('uploadProgress', this, file, bytes_completed, bytes_total);
    },

    /**
    * SWFUpload uploadError event
    * Show notice when error occurs
    * @param {Object} file
    * @param {Integer} error
    * @param {Integer} code
    * @return {}
    */
    uploadError: function (file, error, code) {
        if (this.debug) console.info('UPLOAD ERROR');

        switch (error) {
            case -200:
                Ext.MessageBox.alert(this.strings.text_error, this.strings.error_file_not_found);
                break;

            case -230:
                Ext.MessageBox.alert(this.strings.text_error, this.strings.error_security_error);
                break;

            case -290:
                this.store.getById(file.id).set('status', 4);
                this.store.getById(file.id).commit();
                break;
        }

        this.fireEvent('fileUploadError', this, file, error, code);
    },

    /**
    * SWFUpload uploadSuccess event
    * @param {Object} file
    * @param {Object} response
    */
    uploadSuccess: function (file, response) {
        if (this.debug) console.info('UPLOAD SUCCESS');

        var data = Ext.decode(response);
        if (data.Success) {
            this.store.remove(this.store.getById(file.id));
        } else {
            this.store.getById(file.id).set('status', 3);
            this.store.getById(file.id).commit();
            if (data.Msg != null) {
                Ext.MessageBox.alert(this.strings.text_error, data.Msg);
            }
        }
        this.fireEvent('fileUploadSuccess', this, file, data);
    },

    /**
    * SWFUpload uploadComplete event
    * @param {Object} file
    */
    uploadComplete: function (file) {
        if (this.debug) console.info('UPLOAD COMPLETE');

        this.progress_bar.reset();
        this.progress_bar.updateText(this.strings.text_progressbar);

        if (this.suo.getStats().files_queued && !this.upload_cancelled) {
            this.suo.startUpload();
        } else {
            this.fireEvent('fileUploadComplete', this, file);

            this.allUploadsComplete();
        }

    },

    /**
    * SWFUpload allUploadsComplete method
    */
    allUploadsComplete: function () {
        this.cancelBtn.hide();
        this.addBtn.show();
        this.clearBtn.show();

        this.fireEvent('allUploadsComplete', this);
    },

    /**
    * SWFUpload setPostParams method
    * @param {String} name
    * @param {String} value
    */
    addPostParam: function (name, value) {
        if (this.suo) {
            this.suo.settings.post_params[name] = value;
            this.suo.setPostParams(this.suo.settings.post_params);
        } else {
            this.post_params[name] = value;
        }
    },

    /**
    * Start file upload
    * SWFUpload startUpload method
    */
    startUpload: function () {
        if (this.debug) console.info('START UPLOAD');

        this.cancelBtn.show();
        this.uploadBtn.hide();
        this.clearBtn.hide();
        //		this.addBtn.hide();

        this.upload_cancelled = false;

        this.fireEvent('startUpload', this);

        this.suo.startUpload();
    },

    /**
    * SWFUpload stopUpload method
    * @param {Object} file
    */
    stopUpload: function (file) {
        if (this.debug) console.info('STOP UPLOAD');

        this.suo.stopUpload();

        this.upload_cancelled = true;

        this.getStore().each(function () {
            if (this.data.status == 1) {
                this.set('status', 0);
                this.commit();
            }
        });

        this.cancelBtn.hide();
        if (this.suo.getStats().files_queued > 0) {
            this.uploadBtn.show();
        }
        this.addBtn.show();
        this.clearBtn.show();

        this.progress_bar.reset();
        this.progress_bar.updateText(this.strings.text_progressbar);

    },

    /**
    * Delete one or multiple rows
    * SWFUpload cancelUpload method
    */
    removeFiles: function () {
        if (this.debug) console.info('REMOVE FILES');

        var selRecords = this.getSelections();
        for (var i = 0; i < selRecords.length; i++) {
            if (selRecords[i].data.status != 1) {
                this.suo.cancelUpload(selRecords[i].id);
                this.store.remove(selRecords[i]);
            }
        }

        if (this.suo.getStats().files_queued === 0) {
            this.uploadBtn.hide();
        }

        this.fireEvent('removeFiles', this);
    },

    /**
    * Clear the Queue
    * SWFUpload cancelUpload method
    */
    removeAllFiles: function () {
        if (this.debug) console.info('REMOVE ALL');

        if (this.suo == null)
            return;
        // mark all internal files as cancelled
        var files_left = this.suo.getStats().files_queued;

        while (files_left > 0) {
            this.suo.cancelUpload();
            files_left = this.suo.getStats().files_queued;
        }

        this.store.removeAll();

        this.cancelBtn.hide();
        this.uploadBtn.hide();
        this.fireEvent('removeAllFiles', this);
    }
});