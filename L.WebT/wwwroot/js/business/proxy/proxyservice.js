﻿layui.define(['jquery'], function (exports) {
    "use strict";
    var $ = layui.$,
        module_name = 'proxyservice';
    var Service = {
        addOrUpdateProxy: function (model) {
            var index;
            return $.ajax({
                type: 'POST',
                beforeSend: function () {
                    index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
                },
                complete: function () {
                    top.layer.close(index);
                },
                url: '/Proxy/AddOrUpdateProxy',
                data: model
            });
        },
        pingProxy: function () {
            return $.ajax({
                type: 'GET',
                url: '/Proxy/PingProxy'
            });
        },

    };
    exports(module_name, Service);
});