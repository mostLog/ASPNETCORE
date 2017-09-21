layui.config({
    base: '../js/business/proxy/' //layui自定义layui组件目录
}).extend({
});
layui.use(['table', 'layer', 'form', 'proxyservice'], function () {
    var layer = layui.layer,
        $=layui.$,
        form = layui.form,
        service = layui.proxyservice,
        table = layui.table;

    var proxyTable = table.render({
        elem: '#proxy-table',
        url: '/Proxy/GetPagedList/',
        request: {
            pageName: 'PageIndex',
            limitName: 'PageSize'
        },
        cols: [[
            {
                field: 'ip',
                title: 'ip',
                width: 200
            },
            {
                field: 'port',
                title: '端口',
                width: 200
            },
            {
                field: 'type',
                title: '类型',
                width: 200
            },
            {
                field: 'location',
                title: '位置',
                width: 200
            },
            {
                title: '响应速度',
                field:'responseSpeed',
                width: 200
            },
            {
                title: '最后验证时间',
                field:'lastVerifyDateTime',
                width: 200
            },
            {
                fixed: 'right',
                title: '操作',
                width: 200,
                align: 'center',
                toolbar: '#proxy-bar'
            }
        ]],
        width: 1406,
        page: true,
        height: 315
    });
    //为工具栏绑定事件
    table.on('tool(proxy-table)', function (obj) {
        var currRowData = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'edit') {
            //编辑
            layer.open({
                title: "编辑任务",
                type: 2,
                content: '/Proxy/AddOrEditProxy/' + currRowData.id,
                area: ['100%', '100%']
            });
        } else if (layEvent === 'del') {
            layer.confirm('你确定要删除吗？', function (index) {
                obj.del();
                layer.close(index);
                //删除
                service.deleteProxy({
                    Id: currRowData.id
                }).done(function (data) {
                    if (!data && data != -1) {
                        layer.msg("删除成功！");
                    }
                });
            });
        }
    });
    //绑定添加按钮事件
    $("#btn-add").click(function () {
        layer.open({
            title: "添加代理",
            type: 2,
            content: '/Proxy/AddOrEditProxy',
            area: ['50%', '80%']
        });
    });
});