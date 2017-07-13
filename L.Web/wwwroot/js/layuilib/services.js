layui.define(['jquery'], function (exports) {
    "use strict";
    var $ = layui.jquery,
        module_name = 'services';
    var Service = {
        addOrUpdateTask: function (model) {
            return $.ajax({
                type: 'POST',
                url: '/SpiderTask/AddOrUpdateTask',
                data: model
            });
        }
    };
    exports(module_name, Service );
})