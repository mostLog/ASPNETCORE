layui.config({
    base: '../js/layuilib/' //layui自定义layui组件目录
}).extend({

});
layui.use(['layer','spidertaskservice'], function () {
    var layer = layui.layer,
        services = layui.services;

    $("#btn-add").click(function () {
        layer.open({
            title: "添加任务",
            type: 2,
            content: 'SpiderTask/AddOrEditSpiderTask',
            area: ['100%', '100%']
        });
    });
});