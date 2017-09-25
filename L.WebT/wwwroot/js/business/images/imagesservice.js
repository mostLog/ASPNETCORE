layui.define(['jquery'], function (exports) {
    "use strict";
    var $ = layui.$,
        module_name = 'imagesservice';
    var Service = {
        getPagedImages: function (param) {
            return $.ajax({
                type: 'POST',
                url: '/Images/GetPagedList',
                data: {
                    pageIndex: param.pageIndex,
                    pageSize: param.pageSize
                }
            });
        }
    };
    exports(module_name, Service);
});