(function () {
    var $ = layui.$,
        form = layui.form,
        layer = layui.layer,
        laydate = layui.laydate,
        service = core.services.spidertaskservice;

    //开启 关闭 事件监听
    //form.on('switch(switchIsRecurrent)', function (data) {
    //    if (data.elem.checked) {
    //        $("#ItemToOpenTime").css("display", "");

    //    } else {
    //        $("#ItemToOpenTime").css("display", "none");
    //    }
    //});

    //监听提交
    form.on('submit(btnSubmit)', function (data) {
        console.log(service);
        var d = data.field;
        if (d.IsRecurrent == "1") {
            d.IsRecurrent = true;
        } else {
            d.IsRecurrent = false;
        }
        console.log(d);
        service.addOrUpdateTask({
            SpiderTask: d
        }).done(function (data) {
            //top.layer.msg("任务添加成功!");
            layer.closeAll("iframe");
            parent.location.reload();
        });
        return false;
    });
})();

