var pageIndex = 1;
var pageSize = 10;
window.onload = function () {
    getDats();
    $("#wrap").on("click", "img", function () {
        var $this = $(this);
        var width = "800";
        var height = "100%";
        if (isNaN($this.attr("data-width"))) {
            width = $this.attr("data-width");
        }
        if (isNaN($this.attr("data-height"))) {
            height = $this.attr("data-height");
        }
        parent.layer.open({
            type: 1,
            area: [width, height],
            skin: 'layui-layer-nobg', //没有背景色
            closeBtn: 0,
            shadeClose: true,
            title: false,
            content: "<img width='100%' height='100%' src='"+$this.attr("src")+"' />"
        });
    });
    //设置滚动加载
    window.onscroll = function () {
        //校验数据请求
        if (getCheck()) {
            pageIndex++;
            getDats();
        }
    }
}
/**
* 瀑布流主函数
* @param  wrap	[Str] 外层元素的ID
* @param  box 	[Str] 每一个box的类名
*/
function PBL(wrap, box) {
    //	1.获得外层以及每一个box
    var wrap = document.getElementById(wrap);
    var boxs = getClass(wrap, box);
    //	2.获得屏幕可显示的列数
    var boxW = boxs[0].offsetWidth;
    var colsNum = Math.floor(document.documentElement.clientWidth / boxW);
    wrap.style.width = boxW * colsNum + 'px';//为外层赋值宽度
    //	3.循环出所有的box并按照瀑布流排列
    var everyH = [];//定义一个数组存储每一列的高度
    for (var i = 0; i < boxs.length; i++) {
        if (i < colsNum) {
            everyH[i] = boxs[i].offsetHeight;
        } else {
            var minH = Math.min.apply(null, everyH);//获得最小的列的高度
            var minIndex = getIndex(minH, everyH); //获得最小列的索引
            getStyle(boxs[i], minH, boxs[minIndex].offsetLeft, i);
            everyH[minIndex] += boxs[i].offsetHeight;//更新最小列的高度
        }
    }
}
/**
* 获取类元素
* @param  warp		[Obj] 外层
* @param  className	[Str] 类名
*/
function getClass(wrap, className) {
    var obj = wrap.getElementsByTagName('*');
    var arr = [];
    for (var i = 0; i < obj.length; i++) {
        if (obj[i].className == className) {
            arr.push(obj[i]);
        }
    }
    return arr;
}
/**
* 获取最小列的索引
* @param  minH	 [Num] 最小高度
* @param  everyH [Arr] 所有列高度的数组
*/
function getIndex(minH, everyH) {
    for (index in everyH) {
        if (everyH[index] == minH) return index;
    }
}
/**
* 数据请求检验
*/
function getCheck() {
    var documentH = document.documentElement.clientHeight;
    var scrollH = document.documentElement.scrollTop || document.body.scrollTop;
    return documentH + scrollH >= getLastH() ? true : false;
}
/**
* 获得最后一个box所在列的高度
*/
function getLastH() {
    var wrap = document.getElementById('wrap');
    var boxs = getClass(wrap, 'box');
    return boxs[boxs.length - 1].offsetTop + boxs[boxs.length - 1].offsetHeight;
}
/**
* 设置加载样式
* @param  box 	[obj] 设置的Box
* @param  top 	[Num] box的top值
* @param  left 	[Num] box的left值
* @param  index [Num] box的第几个
*/
var getStartNum = 0;//设置请求加载的条数的位置
function getStyle(box, top, left, index) {
    if (getStartNum >= index) return;
    $(box).css({
        'position': 'absolute',
        'top': top,
        "left": left,
        "opacity": "0"
    });
    $(box).stop().animate({
        "opacity": "1"
    }, 999);
    getStartNum = index;//更新请求数据的条数位置
}

function getDats() {
    var index;
    return $.ajax({
        type: 'POST',
        url: '/Images/GetPagedList',
        beforeSend: function () {
            index = layer.load(2, { shade: false, offset: 'b' });
        },
        complete: function () {
            layer.close(index);
        },
        data: {
            pageIndex: window.pageIndex,
            pageSize: window.pageSize
        }
    }).done(function (d) {
        if (d.data.length > 0) {
            var wrap = document.getElementById('wrap');
            for (i in d.data) {
                //创建box
                var box = document.createElement('div');
                box.className = 'box';
                wrap.appendChild(box);
                //创建info
                var info = document.createElement('div');
                info.className = 'info';
                box.appendChild(info);
                //创建pic
                var pic = document.createElement('div');
                pic.className = 'pic';
                info.appendChild(pic);
                //创建img
                var img = document.createElement('img');
                img.src = "/images/Sources/" + d.data[i].name;
                img.style.height = 'auto';
                pic.appendChild(img);
                //创建title
                var title = document.createElement('div');
                title.className = 'title';
                info.appendChild(title);
                //创建a标记
                var a = document.createElement('a');
                a.className ="iconfont icon-close"
                a.innerHTML = "";
                title.appendChild(a);
            }
            PBL('wrap', 'box');
        }
    }).fail(function () {

    });
    
}