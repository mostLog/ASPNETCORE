layui.config({
    base: '../js/business/logger/' //layui自定义layui组件目录
}).extend({
});
layui.use(['table', 'layer', 'laydate', 'form', 'loggerservice'], function () {
    var layer = layui.layer,
        form = layui.form,
        laydate = layui.laydate,
        service = layui.loggerservice,
        table = layui.table;

    var logTable = table.render({
        elem: '#log-table',
        url: '/Logger/GetPagedList/',
        request: {
            pageName: 'PageIndex',
            limitName: 'PageSize'
        },
        cols: [[
            {
                field: 'logLevel',
                title: '日志等级',
                width: 100,
                templet: '#log-level'
            },
            {
                field: 'dateTime',
                title: '时间',
                width: 200
            },
            {
                field: 'msg',
                title: '信息',
                width: 600
            },
            {
                field: 'duration',
                title: '总时间',
                width: 200,
                templet: '#duration'
            },
            {
                field: 'className',
                title: '类名',
                width: 200
            },
            {
                field: 'actionName',
                title: '方法名',
                width: 200
            }
        ]],
        width: 1606,
        page: true,
        height: 'full-200'
    });
    //下拉列表选择后触发
    form.on('select(search-log-level)', function (data) {
        var v = data.value;
        var datetime = $("input[name='search-record-date']").val();
        logTable.reload({
            where: {
                dateTime: datetime,
                logLevel: v
            }
        });
    });
    laydate.render({
        elem: '#search-record-date',
        done: function (value, date, endDate) {
            var level = $("#search-log-level-hidden").val();
            logTable.reload({
                where: {
                    dateTime: value,
                    logLevel: level
                }
            });
        }
    });
});