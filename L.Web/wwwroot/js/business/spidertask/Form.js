﻿layui.config({
    base: '../js/layuilib/' //layui自定义layui组件目录
}).extend({
    elemnts: 'elements'
});
layui.use(['jquery', 'form', 'spidertaskservice'], function () {
    var $ = layui.jquery,
        form = layui.form(),
        service = layui.spidertaskservice;

    form.on('radio(radCrawlerType)', function (data) {
        if (data.value == 0) {
            $("#ItemToCOne").css("display", "");
            $("#ItemToCTwo").css("display", "none");
        } else if (data.value == 1) {
            $("#ItemToCOne").css("display", "none");
            $("#ItemToCTwo").css("display", "");
        }
    });

    //开启 关闭 事件监听
    form.on('switch(switchOpenTime)', function (data) {
        if (data.elem.checked) {
            $("#ItemToOpenTime").css("display", "");
        } else {
            $("#ItemToOpenTime").css("display", "none");
        }
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