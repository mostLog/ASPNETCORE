layui.define(['jquery'], function (exports) {
    "use strict";
    var $ = layui.$,
        module_name = 'novelservice';
    var Service = {
        startOrStopEmailPush: function (param) {
            return $.ajax({
                type: 'POST',
                url: '/Novel/StartOrStopEmailPush',
                data: param
            });
        }
    };
    exports(module_name, Service);
});