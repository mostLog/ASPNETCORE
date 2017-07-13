layui.use(['laypage', 'layer','services'], function () {
    var laypage = layui.laypage
        , layer = layui.layer
        ,services=layer.services;

    
    $("#btn-add").click(function () {
        services.addOrUpdateTask({
            SpiderTask: {
                Name:"小白"
            }
        }).done(function (data) {

        });
    });
    //laypage({
    //    cont: 'tb'  //元素id
    //    , pages: 100 //总页数
    //    , groups: 5 //连续显示分页数
    //});

    ////测试数据
    //var data = [
    //    '北京',
    //    '上海',
    //    '广州',
    //    '深圳',
    //    '杭州',
    //    '长沙',
    //    '合肥',
    //    '宁夏',
    //    '成都',
    //    '西安',
    //    '南昌',
    //    '上饶',
    //    '沈阳',
    //    '济南',
    //    '厦门',
    //    '福州',
    //    '九江',
    //    '宜春',
    //    '赣州',
    //    '宁波',
    //    '绍兴',
    //    '无锡',
    //    '苏州',
    //    '徐州',
    //    '东莞',
    //    '佛山',
    //    '中山',
    //    '成都',
    //    '武汉',
    //    '青岛',
    //    '天津',
    //    '重庆',
    //    '南京',
    //    '九江',
    //    '香港',
    //    '澳门',
    //    '台北'
    //];

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