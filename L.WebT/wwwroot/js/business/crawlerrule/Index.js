layui.use(['layer'], function () {
    var layer = layui.layer,
        services = layui.services;

    $("#btn-add").click(function () {
        layer.open({
            title: "添加规则",
            type: 2,
            content: '/CrawlerRule/AddOrEditRule',
            area: ['100%', '100%']
        });
    });
});