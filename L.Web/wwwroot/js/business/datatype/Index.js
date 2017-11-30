(function () {
    var layer = layui.layer,
        form = layui.form,
        $ = layui.$,
        table = layui.table;

    var novelTable = table.render({
        elem: '#datatype-table',
        url: '/Novel/GetPagedList/',
        request: {
            pageName: 'PageIndex',
            limitName: 'PageSize'
        },
        cols: [[
            {
                field: 'name',
                title: '小说名称',
                width: 200
            },
            {
                field: 'author',
                title: '作者',
                width: 200
            },
            {
                field: '',
                title: '当前章节数量',
                width: 200
            },
            {
                field: 'newChapter',
                title: '最新章节',
                width: 200
            },
            {
                title: '邮件推送',
                width: 200,
                align: 'center',
                toolbar: '#novel-isemail'
            },
            {
                fixed: 'right',
                title: '操作',
                width: 200,
                align: 'center',
                toolbar: '#novel-bar'
            }
        ]],
        page: true,
        height: 315
    });
    //为工具栏绑定事件
    table.on('tool(novel-table)', function (obj) {
        var currRowData = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'viewChapters') {
            //获取小说章节列表
            article.reload({
                url: '/Novel/GetAritcles/',
                where: {
                    id: currRowData.id
                }
            });
        } else if (layEvent === 'email') {
            //推送email
            var ck = $(this).prev("input[lay-event='email']").get(0).checked;
            service.startOrStopEmailPush({
                id: currRowData.id,
                isOpenEmail: ck
            }).done(function (data, textStatus, jqXHR) {
                if (textStatus = "success") {
                    layer.msg("操作成功！");
                }
            }).fail(function (jqXHR, textStatus, errorThrown) {
                layer.msg(errorThrown);
            });
        }
    });
})();