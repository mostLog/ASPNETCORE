layui.config({
    base: '../js/layuilib/' //layui自定义layui组件目录
}).extend({

});
layui.use(['jquery', 'laypage', 'layer', 'spidertaskservice'], function () {
    var laypage = layui.laypage
        , $ = layui.jquery
        , layer = layui.layer
        , services = layui.services;

    $("#btn-add").click(function () {
        layer.open({
            title: "添加任务",
            type: 2,
            content: 'SpiderTask/AddOrEditSpiderTask',
            area: ['100%', '100%']
        });
    });

    //
    laypage({
        cont: 'paged'  //元素id
        , pages: 100 //总页数
        , groups: 5 //连续显示分页数
    });
    //var nums = 5; //每页出现的数据量

    //模拟渲染
    //var render = function (data, curr) {
    //    var arr = []
    //        , thisData = data.concat().splice(curr * nums - nums, nums);
    //    layui.each(thisData, function (index, item) {
    //        arr.push('<li>' + item + '</li>');
    //    });
    //    return arr.join('');
    //};

    //调用分页
    //laypage({
    //    cont: 'tb'
    //    , pages: Math.ceil(data.length / nums) //得到总页数
    //    , jump: function (obj) {
    //        document.getElementById('biuuu_city_list').innerHTML = render(data, obj.curr);
    //    }
    //});

});