﻿layui.config({
    base: '../js/business/spidertask/' //layui自定义layui组件目录
}).extend({
});
layui.use(['table', 'layer', 'form', 'spidertaskservice'], function () {
    var layer = layui.layer,
        $=layui.$,
        form = layui.form,
        service = layui.spidertaskservice,
        table = layui.table,
        socket;

    var taskTable = table.render({
        elem: '#task-table',
        url: '/SpiderTask/GetPagedList/',
        cols: [[
            {
                checkbox: true,
                fixed: true
            },
            {
                field: 'spiderId',
                title: '任务id',
                width: 120
            },
            {
                field: 'name',
                title: '任务名称',
                width: 200
            },
            {
                field: 'description',
                title: '任务描述',
                width: 300
            },
            {
                field: 'crawlerType',
                title: '爬取模式',
                width: 120,
                templet: '#task-crawlerType'
            },
            {
                field: 'urls',
                title: '爬取地址',
                width: 400
            },
            {
                field: 'isRecurrent',
                title: '定时任务',
                width: 140,
                align: 'center',
                templet: '#is-recurrent'
            },
            {
                fixed: 'right',
                title: '操作',
                width: 200,
                align: 'center',
                toolbar: '#task-bar'
            },
            {
                fixed: 'right',
                title: '测试',
                width: 100,
                align: 'center',
                toolbar: '#task-isrun'
            }
        ]],
        page: true,
        height: 315,
        width:1638
    });

    //为工具栏绑定事件
    table.on('tool(task-table)', function (obj) {
        var currRowData = obj.data;
        var layEvent = obj.event;
        console.log(currRowData);
        if (layEvent === 'edit') {
            //编辑
            layer.open({
                title: "编辑任务",
                type: 2,
                content: '/SpiderTask/AddOrEditSpiderTask/' + currRowData.id,
                area: ['100%', '100%']
            });
        } else if (layEvent === 'del') {
            layer.confirm('你确定要删除吗？', function (index) {
                obj.del();
                layer.close(index);
                //删除
                service.deleteTask({
                    Id: currRowData.id
                }).done(function (data) {
                    if (!data && data != -1) {
                        layer.msg("删除成功！");
                    }
                });
            });
        } else if (layEvent === 'run') {
            var ck = $(this).prev("input[lay-event='run']").get(0).checked;
            //如果开启
            if (ck) {
                var uris = [];
                if (currRowData.urls != null) {
                    uris = currRowData.urls.split("\n");
                }
                //向服务器发送消息
                sendMsg(socket, {
                    spiderId: currRowData.spiderId,
                    uris: uris
                });
            }
        } else if (layEvent === 'isRecurrent') {
            var ck = $(this).prev("input[lay-event='isRecurrent']").get(0).checked;
            if (ck) {
                var uris = [];
                if (currRowData.urls != null) {
                    uris = currRowData.urls.split("\n");
                }
                //开启自动爬取
                service.startOrStopRecurrentTask({
                    isRecurrent: ck,
                    spiderId: currRowData.spiderId,
                    recurrentCron: currRowData.recurrentCron,
                    uris: uris
                }).done(function () {
                    layer.msg("操作成功！");
                }).fail(function () {
                    layer.msg("操作失败！");
                });
            } else {
                //关闭自动爬取
                service.startOrStopRecurrentTask({
                    isRecurrent: ck,
                    spiderId: currRowData.spiderId
                }).done(function () {
                    layer.msg("操作成功！");
                }).fail(function () {
                    layer.msg("操作失败！");
                });
            }
        }
    });
    //绑定添加按钮事件
    $("#btn-add").click(function () {
        layer.open({
            title: "添加任务",
            type: 2,
            content: '/SpiderTask/AddOrEditSpiderTask',
            area: ['100%', '100%']
        });
    });
    /**
     * 建立连接
     * @param url 地址
     */
    function doConnect() {
        var uri = "ws://" + window.location.host + "/Notice";
        socket = new WebSocket(uri);
        socket.onopen = function (e) {
            console.log("连接已开启");
        };
        socket.onclose = function (e) {
            console.log("连接已关闭");
        };
        socket.onmessage = function (e) {
            //接收消息
            $("#TaskInfo").prepend(e.data + "\r\n");
        };
        socket.onerror = function (e) {
            console.log(e);
        };
        return socket;
    }
    doConnect();
    function sendMsg(s, param) {
        s.send(JSON.stringify(param));
    }
});