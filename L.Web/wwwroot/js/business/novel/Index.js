layui.config({
    base: '../js/business/novel/' //layui自定义layui组件目录
}).extend({

});
layui.use(['table', 'layer', 'form','novelservice'], function () {
    var layer = layui.layer,
        form = layui.form,
        service=layui.novelservice,
        table = layui.table;

    var novelTable = table.render({
        elem: '#novel-table',
        url: '/Novel/GetPagedList/',
        request: {
            pageName: 'PageIndex',
            limitName:'PageSize'
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
                width:200
            },
            {
                field: 'newChapter',
                title: '最新章节',
                width:200
            },
            {
                title: '邮件推送',
                width: 200,
                align: 'center',
                toolbar:'#novel-isemail'
            },
            {
                fixed: 'right',
                title: '操作',
                width: 200,
                align: 'center',
                toolbar: '#novel-bar'
            }
        ]],
        width:1206,
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
                    id:currRowData.id
                }
            });
        } else if (layEvent ==='email')
        {
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
    var article = table.render({
        elem: '#article-table',
        cols: [[
            {
                field: 'title',
                title: '标题',
                width: 300
            },
            {
                field: 'url',
                title: '地址',
                width: 400
            },
            {
                field: '字数',
                title: '当前章节字数',
                width: 200
            },
            {
                fixed: 'right',
                title: '操作',
                width: 200,
                align: 'center',
                toolbar: '#article-bar'
            }
        ]],
        width:1106,
        page: false,
        height: 'full-100'
    });
    table.on('tool(article-table)', function (obj) {
        var currRowData = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'view') {
            //查看章节
            parent.layer.open({
                title: currRowData.title,
                shade: [1,"#7d7980"],
                type: 2,
                content: '/Novel/ViewArticle/'+currRowData.id,
                area: ['800px', '100%']
            });
        }
    });

});