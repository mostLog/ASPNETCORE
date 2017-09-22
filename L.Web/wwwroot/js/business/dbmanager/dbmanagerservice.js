layui.define(['jquery'], function (exports) {
    "use strict";
    var $ = layui.$,
        module_name = 'dbmanagerservice';
    var Service = {
        addDataBackup: function (param) {
            return $.ajax({
                type: 'POST',
                url: '/DbManager/AddDataBackup',
                data: param
            });
        }
    };
    exports(module_name, Service);
});