$(function () {

    window._console = window.console;//将原始console对象缓存
    window.console = (function (orgConsole) {
        return {//构造的新console对象
            log: getConsoleFn("log"),
            debug: getConsoleFn("debug"),
            info: getConsoleFn("info"),
            warn: getConsoleFn("warn"),
            exception: getConsoleFn("exception"),
            assert: getConsoleFn("assert"),
            dir: getConsoleFn("dir"),
            dirxml: getConsoleFn("dirxml"),
            trace: getConsoleFn("trace"),
            group: getConsoleFn("group"),
            groupCollapsed: getConsoleFn("groupCollapsed"),
            groupEnd: getConsoleFn("groupEnd"),
            profile: getConsoleFn("profile"),
            profileEnd: getConsoleFn("profileEnd"),
            count: getConsoleFn("count"),
            clear: getConsoleFn("clear"),
            time: getConsoleFn("time"),
            timeEnd: getConsoleFn("timeEnd"),
            timeStamp: getConsoleFn("timeStamp"),
            table: getConsoleFn("table"),
            error: getConsoleFn("error"),
            memory: getConsoleFn("memory"),
            markTimeline: getConsoleFn("markTimeline"),
            timeline: getConsoleFn("timeline"),
            timelineEnd: getConsoleFn("timelineEnd")
        };
        function getConsoleFn(name) {
            return function actionConsole() {
                if (typeof (orgConsole) !== "object") return;
                if (typeof (orgConsole[name]) !== "function") return;//判断原始console对象中是否含有此方法，若没有则直接返回
                return orgConsole[name].apply(orgConsole, Array.prototype.slice.call(arguments));//调用原始函数
            };
        }
    }(window._console));

});
function isIE() { //ie?
    if (!!window.ActiveXObject || "ActiveXObject" in window)
        return true;
    else
        return false;
}
/**
 * 将form里面的内容序列化成json
 * 相同的checkbox用分号拼接起来
 * @param {dom} 指定的选择器
 * @param {obj} 需要拼接在后面的json对象
 * @method serializeJson
 * */
$.fn.serializeJson = function (otherString) {
    var serializeObj = {},
        array = this.serializeArray();
    $(array).each(function () {
        if (serializeObj[this.name]) {
            serializeObj[this.name] += ';' + this.value;
        } else {
            serializeObj[this.name] = this.value;
        }
    });

    if (otherString != undefined) {
        var otherArray = otherString.split(';');
        $(otherArray).each(function () {
            var otherSplitArray = this.split(':');
            serializeObj[otherSplitArray[0]] = otherSplitArray[1];
        });
    }
    return serializeObj;
};

//验证
(function ($) {
    /** 
     * jQuery EasyUI 1.4 --- 功能扩展 
     *  
     * Copyright (c) 2009-2015 RCM 
     * 
     * 新增 validatebox 校验规则 
     * 
     */
    $.extend($.fn.validatebox.defaults.rules, {
        idcard: {
            validator: function (value, param) {
                //return idCardNoUtil.checkIdCardNo(value);
                return /^[1][3578][\d]{9}$/.test(value);
            },
            message: '请输入正确的手机号码'
        },
        checkNum: {
            validator: function (value, param) {
                return /^([0-9]+)$/.test(value);
            },
            message: '请输入整数'
        },
        checkFloat: {
            validator: function (value, param) {
                return /^[+|-]?([0-9]+\.[0-9]+)|[0-9]+$/.test(value);
            },
            message: '请输入合法数字'
        },

        length: {
            validator: function (value, param) {
                return value.length >= param[0] && value.length <= param[1];
            },
            message: '长度应介于{0}-{1}之间'
        },
        required: {
            validator: function (value, param) {
                return $.trim(value) != '';
            },
            message: '内容开头不能为空格！'
        }

    });
})(jQuery);


//获取数据
var getJson = function (url, valueField, textField) {
    var json = {};
    $.ajax({
        type: "post",
        url: url,
        async: false,
        success: function (data) {
            //data = eval("("+data+")");
            for (var i in data) {
                json[data[i][valueField]] = data[i][textField];
            }
        }
    });
    return json;
}

//图片等比例缩小
var scaleImage = function (o, w, h) {
    var img = new Image();
    img.src = o.src;
    if (img.width > 0 && img.height > 0) {
        if (img.width / img.height >= w / h) {
            if (img.width > w) {
                o.width = w;
                o.height = (img.height * w) / img.width;
            }
            else {
                o.width = img.width;
                o.height = img.height;
            }
            o.alt = img.width + "x" + img.height;
        }
        else {
            if (img.height > h) {
                o.height = h;
                o.width = (img.width * h) / img.height;
            }
            else {
                o.width = img.width;
                o.height = img.height;
            }
            o.alt = img.width + "x" + img.height;
        }
    }
}

$.fn.InitGrid = function (url, title, columns, pagelist, queryData) {
    //控制器名
    var controllername = url.split('/')[2];
    //视图名
    var actionname = url.split('/')[3];
    //url构造方法
    var getUrl = function (e) {
        return '/Admin/' + controllername + '/' + e + actionname;
    }
    //表格对象
    var datagrid = $(this);
    //弹出框对象
    var dialog;
    //表格参数
    var tablecolumns = [];
    //表单参数
    var formcolumns = [];
    //表单ue对象name
    var uename = "";
    for (var i in columns) {
        if (columns[i].isFormBody) formcolumns[columns[i].isFormBody - 1] = columns[i];
        if (columns[i].isTableBody) tablecolumns[columns[i].isTableBody - 1] = columns[i];
        if (columns[i].url) columns[i].data = getJson(columns[i].url, columns[i].valueField, columns[i].textField);
    }
    var ue;
    var editor;
    //创建搜索表单
    var createSearch = function () {
        var searchForm = document.createElement("form");
        searchForm.setAttribute('id', 'searchForm');
        var filedTxt = "";
        for (var i in tablecolumns) {

            //创建元素
            var input = document.createElement('input');
            input.setAttribute("name", tablecolumns[i].field);
            switch (tablecolumns[i].type) {
                case "text":
                    if (tablecolumns[i].field.toLowerCase().indexOf('title') < 0) {  //&& tablecolumns[i].field.toLowerCase().indexOf('name') < 0
                        continue;
                    }
                    input.setAttribute("placeholder", tablecolumns[i].title);
                    break;
                case "select":
                    //$(input).combobox({
                    //    url: tablecolumns[i].url,
                    //    valueField: tablecolumns[i].valueField,
                    //    textField: tablecolumns[i].textField
                    //});
                    input = "<input id=\"" + tablecolumns[i].field + "\" class=\" romance \" name=\"" + tablecolumns[i].field + "\" data-options=\"valueField:'" + tablecolumns[i].valueField + "',textField:'" + tablecolumns[i].textField + "',url:'" + tablecolumns[i].url + "'\">";
                    break;
                //case "radio":
                //    var radiogroupbuilder = "";
                //    for (var j = 0, radiocount = tablecolumns[i].radiocount ? tablecolumns[i].radiocount : 2; j < radiocount; j++) {
                //        var inputclone = $(input).clone()[0];
                //        inputclone.setattribute("type", "radio");
                //        inputclone.setattribute("name", tablecolumns[i].field);
                //        inputclone.setattribute("value", j);
                //        if (j == 0) inputclone.setattribute("checked", "true");
                //        radiogroupbuilder += inputclone.outerhtml + tablecolumns[i].formatter(j);
                //    }
                //    input = radiogroupbuilder;
                //    break;
                default:
                    continue;
                    break;
            }
            $(searchForm).append(tablecolumns[i].title);
            $(input).addClass("search");
            if (searchInfo != null && searchInfo[$(input).attr("Id")] != "") {
                input.defaultValue = searchInfo[$(input).attr("Id")];
            }
            $(searchForm).append($(input));

        }
        $(searchForm).append("<input style='width:60px;height;30px;padding:5px;margin:0 auto;border-radius:5px;background-color:lightblue;' type='button' value='检索' id='searchBtn'>");
        return searchForm;
    };

    var isSearch = null;
    var searchInfo = null;
    var _ImgUploadDirectory = "/image/";
    //定位到Table标签进行数据绑定
    $(this).datagrid({
        url: getUrl('get'), //指向后台的Action来获取当前菜单的信息的Json格式的数据
        title: title,
        iconCls: 'icon-view',
        loadMsg: "正在加载数据，请稍等...",
        height: function () { return document.body.clientHeight },
        width: function () { return document.body.clientWidth * 0.9 },
        nowrap: false,
        autoRowHeight: false,
        striped: true,
        collapsible: true,
        pagination: true,
        pageSize: 10,
        //如不设置显示条数则为默认显示条数 10,20,30
        pageList: (function () { var defaultlist = [10, 20, 30]; if (pagelist == undefined) return defaultlist; else return pagelist; })(),
        rownumbers: true,
        //sortName: 'ID',    //根据某个字段给easyUI排序
        sortOrder: 'asc',
        remoteSort: false,
        idField: 'ID',
        queryParams: queryData,  //异步查询的参数
        columns: [
            tablecolumns
        ],
        toolbar: [{
            id: 'btnAdd',
            text: '添加',
            iconCls: 'icon-add',
            handler: function () { btnAdd(); }
        }, '-', {
            id: 'btnEdit',
            text: '修改',
            iconCls: 'icon-edit',
            handler: function () { btnEdit(); }
        }, '-', {
            id: 'btnDelete',
            text: '删除',
            iconCls: 'icon-remove',
            handler: function () { btnDelete(); }

        },
        // '-', {
        //    id: 'btnView',
        //    text: '查看',
        //    iconCls: 'icon-search',
        //    handler: function () { btnView(); }
            //}, 
            '-', {
                id: 'btnReload',
                text: '刷新',
                iconCls: 'icon-reload',
                handler: function () {
                    datagridReload();
                }
            }
            , '-'
            , {
                id: 'btnview',
                text: createSearch(),
                iconcls: 'icon-search'

            }
        ],
        onDblClickRow: function (rowIndex, rowData) {
            $('#grid').datagrid('uncheckAll');
            $('#grid').datagrid('checkRow', rowIndex);
            ShowEditOrViewDialog();
        },
        onBeforeLoad: function (rowIndex, rowData) {
            $(".romance").each(function () {
                var options = $(this).attr("data-options");
                var data={
                    url: options.url,
                    valueField: options.valueField,
                    textField: options.textField
                };

                $(this).combobox(data);
                if (searchInfo != null && searchInfo[$(this).attr("Id")] != "") {
                    $("#" + $(this).attr("Id")).combobox('setValue', searchInfo[$(this).attr("Id")]);
                }
            });
        },
        onLoadSuccess: function (rowIndex, rowData) {

        }
    });


    $("#searchBtn").click(function () {
        
                        setTimeout(searchCtrl, 200);
    })

    function searchCtrl() {
        if (isSearch == null) {
            isSearch = 1;
            searchInfo = $("#searchForm").serializeJson();
            search();
        }
        else {
            isSearch = null;
        }
    }

    function search() {
        console.log(JSON.stringify(searchInfo));
        $("#grid").datagrid("load", searchInfo);
    }

    //if (isIE) {
    //    $(document).on('propertychange', '#searchForm', function () {
    //        alert();
    //    })
    //    document.getElementById("searchForm").onpropertychange = search();
    //    } else {  //需要用addEventListener来注册事件  
    //    document.getElementById("searchForm").addEventListener("click", search, [{ once: false }]);
    //    }

    //$(createSearch()).appendTo(".datagrid-toolbar td :last");

    //$('#stitle').searchbox({
    //    width: 180,
    //    searcher: dosearch,
    //    prompt: '请输入标题'
    //});

    //$('#useraccount').searchbox({
    //    width: 180,
    //    //searcher: dosearch,
    //    prompt: '请输入标题'
    //});

    //function dosearch() {


    //    $("#grid").datagrid("load", {
    //        "stitle": $("#stitle").val()
    //    });
    //}]



    //创建表单
    var createForm = function () {
        //构造弹出框div
        var div = document.createElement('div');
        div.setAttribute("id", "pagedialog");
        div.setAttribute("style", "display:none;");
div.setAttribute("style", "padding:15px;");
        //构造弹出框表单
        var form = document.createElement('form');
        form.setAttribute("id", "dialog_form");
        //form.setAttribute("href", '/' + controllername + '/add' + actionname);
        form.setAttribute("class", 'easyui-form');
        form.setAttribute("method", 'post');
        form.setAttribute("data-options", 'enableValidation:true');//开启表单验证

        //构造表格
        var table = document.createElement('table');
        table.setAttribute("style", "padding:15px;");
        table.setAttribute("cellspacing", "10");

        //创建tr元素容器
        var domlist = [];
        //创建元素
        for (var i in formcolumns) {
            //创建tr
            var tr = document.createElement('tr');
            if (formcolumns[i].type == "hidden") tr.setAttribute("style", "display:none;");
            //创建title容器td
            var tdlable = document.createElement('td');
            tdlable.innerText = formcolumns[i].title;
            //创建元素容器td
            var tdinput = document.createElement('td');
            //创建元素
            var input = document.createElement('input');
            if (formcolumns[i].type == "select") input = document.createElement('select');
            if (formcolumns[i].type == "ue") { input = document.createElement('textarea'); uename = formcolumns[i].field; }
            input.setAttribute("name", formcolumns[i].field);
            //装填表单元素到td
            $(tdinput).append(input);
            //根据类型构造元素
            switch (formcolumns[i].type) {
                case "hidden":
                    input.setAttribute("type", "hidden");
                    break;
                case "text":
                    $(input).css("width", "350px");
                    $(input).css("height", "25px");
                    $(input).validatebox({
                        required: true,
                        validType: formcolumns[i].validType,

                        missingMessage:"此信息必填"
                    });
                    
                    if (formcolumns[i].field.toLowerCase().indexOf('keyword')>0)
                    {
                        $(tdinput).append("<span style=\"color:red;margin-left:20px;\">*关键字之间用/分隔</span>");
                    }
                    break;
                case "date":
                    $(input).datebox({
                        required: true,
                        missingMessage: "此信息必填"
                    });
                    break;
                case "datetime":
                    $(input).datetimebox({
                        required: true,
                        showSeconds: true,
                        missingMessage: "此信息必填"
                    });
                    break;
                case "select":
                    $(input).combobox({
                        url: formcolumns[i].url,
                        required: true,
                        valueField: formcolumns[i].valueField,
                        textField: formcolumns[i].textField,
                        //missingMessage: "此信息必填"
                        //onLoadSuccess: function () { //加载完成后,设置选中第一项
                        //    var val = $(this).combobox("getData");
                        //    for (var item in val[0]) {
                        //        if (item == $(this).combobox("options").valueField) {
                        //            $(this).combobox("select", val[0][item]);
                        //        }
                        //    }
                        //}
                    });
                    break;
                case "file":
                    input.setAttribute("type", "text");
                    input.setAttribute("class", "fileName");
                    input.setAttribute("value", "请选择要上传的图片");
                    var inputHTML = input.outerHTML;
                    var input1 = document.createElement('input');
                    var input2 = document.createElement('input');
                    input1.setAttribute("type", "file");
                    input1.setAttribute("class", "file");
                    input1.setAttribute("style", "display:none");

                    input2.setAttribute("type", "button");
                    input2.setAttribute("class", "fileBtn");
                    input2.setAttribute("value", "选择图片");
                    input2.setAttribute("onclick", "$(this).parent().find('.file').click()");


                    tdinput.innerHTML = input.outerHTML + input1.outerHTML + input2.outerHTML;
                    if(formcolumns[i].Size)
                    {
                        tdinput.innerHTML = tdinput.innerHTML + $("<span style=\"color:red;margin-left:20px;\">只能上传图片大小为（单位：px）:" + formcolumns[i].Size + "</span>")[0].outerHTML;
                    }
                    break;
                case "ue":
                    input.setAttribute("id", "editor");
                    break;
                case "radio":
                    var radioGroupBuilder = "";
                    for (var j = 0, radioCount = formcolumns[i].radioCount ? formcolumns[i].radioCount : 2; j < radioCount; j++) {
                        var inputClone = $(input).clone()[0];
                        inputClone.setAttribute("type", "radio");
                        inputClone.setAttribute("name", formcolumns[i].field);
                        inputClone.setAttribute("value", j);
                        if (j == 0) inputClone.setAttribute("checked", "true");
                        radioGroupBuilder += inputClone.outerHTML + formcolumns[i].formatter(j);
                    }
                    tdinput.innerHTML = radioGroupBuilder;

                    if (formcolumns[i].NoLunBo) {
                        tdinput.innerHTML = tdinput.innerHTML + $("<span style=\"color:red;margin-left:20px;\">不轮播图片大小为（单位：px）:" + formcolumns[i].NoLunBo + "</span>")[0].outerHTML;
                    }
                    if (formcolumns[i].LunBo)
                    {
                        tdinput.innerHTML = tdinput.innerHTML + $("<span style=\"color:red;margin-left:20px;\">轮播图片大小为（单位：px）:" + formcolumns[i].LunBo + "</span>")[0].outerHTML;
                    }
                    break;
                case "textarea":
                    
                    tdinput.innerHTML = $("<textarea name='" + formcolumns[i].field + "' style='width:500px;height:80px;'></textarea>")[0].outerHTML;

                    break;

                default:
                    $(input).validatebox({
                        required: true,
                        validType: "text",
                        missingMessage: "此信息必填"
                    });
                    break;
            }
            //装填元素到tr
            $(tr).append(tdlable);
            $(tr).append(tdinput);
            //装填tr到容器
            domlist.push(tr);
        };
        for (var i in domlist) $(table).append(domlist[i]);
        $(form).append(table);
        $(div).append(form);
        return div;
    };

    //datagrid添加按钮
    var btnAdd = function () {
        $(dialog = createForm()).dialog({
            iconCls: 'icon-add',
            title: "新增信息",
            height: window.innerHeight * 0.9,
            width: 1000,
            modal: true,
            buttons: [{
                id: "add_btn",
                text: '添 加',
                handler: function () {
                    $("#dialog_form").form("submit", {
                        url: getUrl("add"),
                        onSubmit: function () {
                            if ($(this).form('validate')) {
                                fileupload();
                                $('#add_btn').linkbutton('disable');
                                return true;
                            }
                            else {
                                $('#add_btn').linkbutton('enable');
                                return false;
                            }
                        },
                        success: function (data) {
                            var result = eval('(' + data + ')');
                            if (result.Success) {
                                dialogClose();
                            } else {
                                $('#add_btn').linkbutton('enable');
                            }
                            $.messager.alert("提示", result.Message, "info", function () { datagridReload(); });

                            //else {
                            //    $('#akmaterial_add_btn').linkbutton('enable');
                            //    $.show_warning("提示", result.Message);
                            //}
                        }
                    });
                }
            },
            { id: "close_btn", text: '关 闭', handler: function () { dialogClose(); } }],
            onLoad: function () { },
            onClose: function () { dialogClose(); }
        });
        if ($("#editor", dialog).length > 0)
        {
            //KindEditor.ready(function (K) {
            //    editor = K.create('textarea#editor', {
            //        uploadJson: "../../../script/asp.net/upload_json.ashx",
            //        allowFileManager: true,
            //        allowImageUpload: true,
            //        allowFileManager: true,
            //        afterUpload: function () {
            //            this.sync();
            //        },
            //        afterBlur: function () {
            //            this.sync();
            //        }
            //    });
            //    K('input[name=getHtml]').click(function (e) {
            //        alert(editor.html());
            //    });
            //    K('input[name=isEmpty]').click(function (e) {
            //        alert(editor.isEmpty());
            //    });
            //    K('input[name=getText]').click(function (e) {
            //        alert(editor.text());
            //    });
            //    K('input[name=selectedHtml]').click(function (e) {
            //        alert(editor.selectedHtml());
            //    });
            //    K('input[name=setHtml]').click(function (e) {
            //        editor.html('<h3>Hello KindEditor</h3>');
            //    });
            //    K('input[name=setText]').click(function (e) {
            //        editor.text('<h3>Hello KindEditor</h3>');
            //    });
            //    K('input[name=insertHtml]').click(function (e) {
            //        editor.insertHtml('<strong>插入HTML</strong>');
            //    });
            //    K('input[name=appendHtml]').click(function (e) {
            //        editor.appendHtml('<strong>添加HTML</strong>');
            //    });
            //    K('input[name=clear]').click(function (e) {
            //        editor.html('');
            //    });
            //});
            UE.getEditor('editor', {
                initialFrameWidth: 800,
                initialFrameHeight: 300
            });
            //uploadeditor.ready(function () {
            //    uploadeditor.addlistener("beforeinsertimage", _beforeinsertimage);
            //    uploadeditor.addlistener("afterupfile", _afterupfile);
            //});

            //// 自定义按钮绑定触发多图上传和上传附件对话框事件
            //document.getelementbyid('j_upload_img_btn').onclick = function () {
            //    var dialog = uploadeditor.getdialog("insertimage");
            //    dialog.title = '多图上传';
            //    dialog.render();
            //    dialog.open();
            //};

            //document.getelementbyid('j_upload_file_btn').onclick = function () {
            //    var dialog = uploadeditor.getdialog("attachment");
            //    dialog.title = '附件上传';
            //    dialog.render();
            //    dialog.open();
            //};

            //// 多图上传动作
            //function _beforeinsertimage(t, result) {
            //    var imagehtml = '';
            //    for (var i in result) {
            //        imagehtml += '<li><img src="' + result[i].src + '" alt="' + result[i].alt + '" height="150"></li>';
            //    }
            //    document.getelementbyid('upload_img_wrap').innerhtml = imagehtml;
            //}

            //// 附件上传
            //function _afterupfile(t, result) {
            //    var filehtml = '';
            //    for (var i in result) {
            //        filehtml += '<li><a href="' + result[i].url + '" target="_blank">' + result[i].url + '</a></li>';
            //    }
            //    document.getelementbyid('upload_file_wrap').innerhtml = filehtml;
            //}

        }
    };

    //datagrid编辑按钮
    var btnEdit = function () {
        var rows = $(datagrid).datagrid('getSelections');
        if (rows.length < 1) return $.messager.alert("提示", "请选择要进行修改的数据", "warning", function () { datagridReload(); });
        if (rows.length > 1) return $.messager.alert("提示", "请选择单行数据进行修改", "warning", function () { datagridReload(); });
        //dialog = createForm();
        //$(dialog)
        $(dialog = createForm()).dialog({
            iconCls: 'icon-edit',
            title: "修改信息",
            height: window.innerHeight * 0.9,
            width: 1000,
            modal: true,
            buttons: [{
                id: "add_edit",
                text: '修 改',
                handler: function () {
                    $("#dialog_form").form("submit", {
                        url: getUrl("edit"),
                        onSubmit: function () {
                            if ($(this).form('validate')) {
                                fileupload();
                                $('#add_edit').linkbutton('disable');

                                $(".fileName", this).each(function () {
                                    if (this.value != this.defaultValue) {
                                        this.value = _ImgUploadDirectory + this.value;
                                    }
                                });
                                console.debug(this);
                                return true;
                            }
                            else {
                                $('#add_edit').linkbutton('enable');
                                return false;
                            }
                        },
                        success: function (data) {

                            var result = eval('(' + data + ')');
                            if (result.Success) {
                                dialogClose();
                            } else {
                                $('#add_edit').linkbutton('enable');
                            }
                            $.messager.alert("提示", result.Message, "info", function () { datagridReload(); });


                            //var result = eval('(' + data + ')');
                            //if (result.Success) {
                            //    $(dialog).dialog('destroy');
                            //    $.show_warning("提示", result.Message);
                            //    akmaterial_databind();
                            //} else {
                            //    $('#akmaterial_add_btn').linkbutton('enable');
                            //    $.show_warning("提示", result.Message);
                            //}
                        }
                    });
                }
            },
            { id: "close_btn", text: '关 闭', handler: function () { dialogClose(); datagridReload(); } }],
            onLoad: function () { },
            onClose: function () { dialogClose(); datagridReload(); }
        });
        if ($("#editor", dialog).length > 0)
           ue= UE.getEditor('editor', {
                initialFrameWidth: 800,
                initialFrameHeight: 300
            });
        $("#dialog_form").form('load', rows[0]);
        $("#dialog_form .fileName").each(function () {
            if ($(this).val()) this.defaultValue = $(this).val();
        });
        if ($("#editor", dialog).length > 0){
	  ue.ready(function() {
            var ueid = $("[id^=ueditor]").attr("id")
            var ueditor = window.frames[ueid].contentDocument.getElementsByTagName("body");//$("[id^=ueditor]")[0].contentDocument.getElementsByTagName("body");
            $(ueditor).html(rows[0][uename]);
	  });
        }
    };

    //datagrid删除按钮
    var btnDelete = function () {
        var rows = $(datagrid).datagrid('getSelections');
        if (rows.length == 0) return $.messager.alert("提示", "请选择要删除的数据", "warning", function () { $(datagrid).datagrid('reload'); })
        if(confirm("确认要删除吗?")){
        var key = (function () { for (var i in tablecolumns) if (tablecolumns[i].checkbox) return tablecolumns[i].field; })();
        var ids = [];
        for (var i in rows) {
            ids.push(rows[i][key]);
        }
        ids = ids.join(',');
        $.post(getUrl("delete"), { ids: ids }, function (data, status) {
            data == 0 ?
                $.messager.alert("提示", "删除成功", "info", function () { datagridReload() }) :
                $.messager.alert("提示", "删除失败", "warning", function () { datagridReload() })
        })
        }
    }

    //datagrid查看按钮
    var btnView = function () {
        var rows = $(datagrid).datagrid('getSelections');
        if (rows.length < 1) return $.messager.alert("提示", "请选择要进行预览的数据", "warning", function () { datagridReload(); });
        if (rows.length > 1) return $.messager.alert("提示", "请选择单行数据进行预览", "warning", function () { datagridReload(); });
    }

    //弹出框关闭
    var dialogClose = function () {
        if ($("#editor", dialog).length > 0)
            UE.getEditor('editor').destroy();
        $(dialog).dialog('destroy');
    }

    //表格刷新
    var datagridReload = function () { $(datagrid).datagrid('reload'); $(datagrid).datagrid('clearSelections'); }

    //文件上传
    var fileupload = function () {
        var past = true;
        if ($(".file").length > 0) {
            $(".file").each(function () {
                if ($(this).val != "") {; }
                else
                {
                    if (!this.files[0]) {
                        $.messager.alert("提示", "请选择要上传的图片", "warning");
                        past = false;
                    }
                }
            });
            if (!past) return false;
            var fd = new FormData();
            $(".file").each(function () {
                fd.append('file[]', this.files[0]);
            });
            $.ajax({
                url: "/upload/index",
                type: "post",
                data: fd,
                async: false,
                cache: false,
                contentType: false,
                processData: false,
                success: function (data) {
                    if (!data.Success) {
                        $.messager.alert("提示", "图片上传失败,请重新提交", "warning");
                        return false;
                    }
                    else
                        return true;
                }
            });
        }
    }

    //选中文件添加预览按钮
    $(document).on('change', '.file', function () {
        //var path = this.value;
        $(this).parent().find('.fileName').val(this.files[0].name);
        if ($(this).parent().find('.scan').length == 0) {
            //$(this).parent().append("<a class='scan' href='javascript:void(0);' path='" + path + "'>预览</a><div style='position:relative;display:inline;' class='container'></div>");
            $(this).parent().append("<a class='scan' href='javascript:void(0);' style='margin-left:10px;'>预览</a><div style='position:relative;display:inline;' class='container'></div>");
        }
        //else {
        //    $(this).parent().find('.scan').attr("path", path);
        //}
    });

    //预览效果
    $(document).on('mouseover mouseout', '.scan', function (event) {
        if (event.type == "mouseover") {
            //鼠标悬浮
            var file = $(this).parent().find(".file")[0];
            var container = $(this).parent().find(".container")[0];
            //console.log(file);
            if (file.files && file.files[0]) {
                var reader = new FileReader();
                reader.onload = function (evt) {
                    var style = "position:absolute;top:14px;left:-24px;z-index:9100;border:1px solid #808080;padding:2px;background:#fff";
                    var img = $("<img class='img' src=\"" + evt.target.result + "\" style='" + style + "' onload='scaleImage(this,300,300)'/>")[0];
                    container.appendChild(img);
                }
                reader.readAsDataURL(file.files[0]);
            } else {
                container.innerHTML = '<div class="img" style="filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale,src=\'' + file.value + '\'"></div>';
            }
            //$(this).parent().append("<img class='img' src='" + $(this).attr("path") + "' style='position:absolute;' width='280' height='200'/>");
        } else if (event.type == "mouseout") {
            //鼠标离开
            $(".img").remove();
        }
    });

    //$(document).on('click', '.file', function () {
    //});

    //分页控件设置
    $('#grid').datagrid('getPager').pagination({
        beforePageText: '第',//页数文本框前显示的汉字 
        afterPageText: '页    共 {pages} 页',
        displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录',
    });


};