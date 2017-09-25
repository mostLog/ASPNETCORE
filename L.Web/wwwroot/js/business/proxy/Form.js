layui.config({
    base: '../../js/business/proxy/' //layui自定义layui组件目录
}).extend({
});
layui.use(['form', 'layer', 'laydate', 'proxyservice'], function () {
    var $ = layui.$,
        form = layui.form,
        layer = layui.layer,
        laydate = layui.laydate,
        service = layui.proxyservice;

    //监听提交
    form.on('submit(btnSubmit)', function (data) {
        var d = data.field;
        service.addOrUpdateProxy({
            Proxy: d
        }).done(function (data) {
            //top.layer.msg("任务添加成功!");
            layer.closeAll("iframe");
            parent.location.reload();
        });
        return false;
    });
});