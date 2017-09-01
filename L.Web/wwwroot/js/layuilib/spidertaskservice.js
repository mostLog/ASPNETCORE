layui.define(['jquery'], function (exports) {
    "use strict";
    var $ = layui.$,
        module_name = 'spidertaskservice';
    var Service = {
        addOrUpdateTask: function (model) {
            var index;
            return $.ajax({
                type: 'POST',
                beforeSend: function () {
                    index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
                },
                complete: function () {
                    top.layer.close(index);
                },
                url: '/SpiderTask/AddOrUpdateTask',
                data: model
            });
        },
        deleteTask: function (param) {
            return $.ajax({
                type: 'POST',
                url: '/SpiderTask/DeleteTask',
                data:param
            });
        },
        //启动爬虫
        spiderStart: function (param) {
            return $.ajax({
                type: 'POST',
                url: '/SpiderTask/RunTask',
                data: param
            });
        }
    };
    exports(module_name, Service);
});
