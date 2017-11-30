layui.config({
    base: '../js/business/chrome/' //layui自定义layui组件目录
}).extend({
});
layui.use(['table', 'layer', 'form', 'chromeservice'], function () {
    var layer = layui.layer,
        $ = layui.$,
        form = layui.form,
        service = layui.chromeservice,
        table = layui.table;

    var taskTable = table.render({
        elem: '#pushtext-table',
        url: '/Chrome/GetPagedList/',
        cellMinWidth: 100,
        cols: [[
            {
                checkbox: true,
                fixed: true
            },
            {
                fixed: 'left',
                title: '操作',
                width: 200,
                align: 'center',
                toolbar: '#pushtext-bar'
            },
            {
                field: 'textType',
                title: '信息类别',
                width: 120
            },
            {
                field: 'pushDateTime',
                title: '推送日期',
                width: 200
            },
            {
                field: 'text',
                title: '推送内容'
            },
            {
                field: 'remark',
                title: '备注信息',
                width:300
            }
        ]],
        page: true,
        height: 315
    });

    //为工具栏绑定事件
    table.on('tool(pushtext-table)', function (obj) {
        var currRowData = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'edit') {
            //编辑
            //layer.open({
            //    title: "编辑任务",
            //    type: 2,
            //    content: '/SpiderTask/AddOrEditSpiderTask/' + currRowData.id,
            //    area: ['100%', '100%']
            //});
        } else if (layEvent === 'del') {
            //layer.confirm('你确定要删除吗？', function (index) {
            //    obj.del();
            //    layer.close(index);
            //    //删除
            //    service.deleteTask({
            //        Id: currRowData.id
            //    }).done(function (data) {
            //        if (!data && data != -1) {
            //            layer.msg("删除成功！");
            //        }
            //    });
            //});
        } else if (layEvent === 'check')
        {
            //审核数据

        }
    });
});