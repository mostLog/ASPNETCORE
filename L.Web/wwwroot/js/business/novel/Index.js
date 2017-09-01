layui.config({
    base: '../js/layuilib/' //layui自定义layui组件目录
}).extend({

});
layui.use(['table', 'layer', 'form'], function () {
    var layer = layui.layer,
        form = layui.form,
        table = layui.table;

    var novelTable = table.render({
        elem: '#novel-table',
        url: '/Novel/GetPagedList/',
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
                    Id:currRowData.id
                }
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