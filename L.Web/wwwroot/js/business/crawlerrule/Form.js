layui.use(['jquery', 'form'], function () {
    var $ = layui.jquery,
        form = layui.form();

    //添加规则绑定单击事件
    $("#btn-add-rule").click(function () {
    });

    //监听提交
    form.on('submit(btnSubmit)', function (data) {
        //console.log(data.field);
        service.addOrUpdateTask({
            SpiderTask: data.field
        }).done(function (data) {
        });
        return false;
    });
});