layui.config({
    base: '../js/business/images/' //layui自定义layui组件目录
}).extend({
});
layui.use(['flow', 'layer','imagesservice'], function () {
    var layer = layui.layer,
        service = layui.imagesservice,
        flow = layui.flow;

    flow.load({
        elem: '#flow-images',
        done: function (page, next) {
            var lis = [];
            service.getPagedImages({
                pageIndex: page,
                pageSize:10
            }).done(function (res) {
                layui.each(res.data, function (index, item) {
                    lis.push('<li>' + item.name + '</li>');
                }); 
                next(lis.join(''), page < res.count);    
            });
        }
    });

});