(function () {
    var $ = layui.$;
    //创建服务
    var service = core.util.createService("datatypeservice");
    //添加类型分类
    service.addDataTypeClass = function (model) {
        return $.ajax({
            type: 'POST',
            beforeSend: function () {
            },
            complete: function () {
            },
            url: '/DataType/AddDataTypeClass',
            data: model
        });
    };
    //获取所有分类信息
    service.getDataTypeClasses = function (model) {
        return $.ajax({
            type: 'POST',
            beforeSend: function () {
            },
            complete: function () {
            },
            url: '/DataType/GetDataTypeClasses',
            data: model
        });
    }
    //删除类型分类
    service.delDataTypeClass = function () {
    }
})();