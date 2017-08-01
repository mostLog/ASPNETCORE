layui.config({
    base: '../js/layuilib/' //layui自定义layui组件目录
}).extend({

});
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