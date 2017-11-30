(function () {
    "use strict";
    var $ = layui.$;
    //创建服务
    var service = core.util.createService("spidertaskservice");
    service.addOrUpdateTask = function (model) {
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
    };
    service.deleteTask = function (param) {
        return $.ajax({
            type: 'POST',
            url: '/SpiderTask/DeleteTask',
            data: param
        });
    };
    service.spiderStart = function (param) {
        return $.ajax({
            type: 'POST',
            url: '/SpiderTask/RunTask',
            data: param
        });
    };
    //跨域请求
    service.startOrStopRecurrentTask=function (param) {
        return $.ajax({
            type: 'POST',
            url: 'http://localhost:8888/api/Pathogen/RunOrStopPathogen',
            data: param,
            xhrFields: {
                withCredentials: true
            }
        });
    }
})();