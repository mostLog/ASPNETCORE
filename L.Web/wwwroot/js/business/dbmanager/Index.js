layui.config({
    base: '../js/business/dbmanager/' //layui自定义layui组件目录
}).extend({
});
layui.use(['table', 'layer', 'laydate', 'form', 'dbmanagerservice'], function () {
    var table = layui.table,
        layer = layui.layer,
        laydate = layui.laydate,
        form = layui.form,
        service = layui.dbmanagerservice;

    var dbtable = table.render({
        elem: '#db-table',
        url: '/DbManager/GetTableData',
        cols: [[
            {
                field: 'name',
                title: '表名',
                width: 200
            },
            {
                field: 'rows',
                title: '表中记录数',
                width: 200,
                templet:'#db-rows'
            },
            {
                field: 'reserved',
                title: '表空间大小',
                width: 200,
                templet:'#db-reserved'
            }
        ]],
        width:604
    });

    laydate.render({
        elem: '#search-record-date'
    });

    $("#btn-Data").on('click', function () {
        var dateTime = $("#search-record-date").val();
        if (!dateTime) {
            layer.msg("请选择需要备份的日期！");
            return;
        }
        service.addDataBackup({
            dateTime: dateTime,
            dbName:"CoreTest"
        }).done(function (data) {
            if (!data && data != -1) {
                layer.msg("数据备份成功！");
            }
        });
    })
});