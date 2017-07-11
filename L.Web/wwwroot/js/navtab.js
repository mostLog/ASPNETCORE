layui.define(['element'], function (exports) {
    var element = layui.element(),
        $ = layui.jquery,
        layer = parent.layer === undefined ? layui.layer : parent.layer,
        module_name = 'navtab',
        globalTabIdIndex = 0,
        CustomTab = function () {
            this.config = {
                elem: undefined,
                closed: true
            };
        };

    element.on('tab(sidecontent)', function () {
        console.log(this);
    });
    var ELEM = {};
    /**
     * [参数设置 options]
     */
    CustomTab.prototype.set = function (options) {
        var _this = this;
        $.extend(true, _this.config, options);
        return _this;
    };
    /**
     * [init 对象初始化]
     * @return {[type]} [返回对象初始化结果]
     */
    CustomTab.prototype.init = function () {
        var _this = this;
        var _config = _this.config;
        if (typeof (_config.elem) !== 'string' && typeof (_config.elem) !== 'object') {
            layer.alert('Tab选项卡错误提示: elem参数未定义或设置出错，具体设置格式请参考文档API.');
        }
        var $container;
        if (typeof (_config.elem) === 'string') {
            $container = $('' + _config.elem + '');
            //console.log($container);
        }
        if (typeof (_config.elem) === 'object') {
            $container = _config.elem;
        }
        if ($container.length === 0) {
            layer.alert('Tab选项卡错误提示:找不到elem参数配置的容器，请检查.');
        }
        var filter = $container.attr('lay-filter');
        if (filter === undefined || filter === '') {
            layer.alert('Tab选项卡错误提示:请为elem容器设置一个lay-filter过滤器');
        }
        _config.elem = $container;
        ELEM.titleBox = $container.children('ul.layui-tab-title');
        ELEM.contentBox = $container.children('div.layui-tab-content');
        ELEM.tabFilter = filter;
        return _this;
    };
    //
    CustomTab.prototype.exists = function (title) {
        var _this = ELEM.titleBox === undefined ? this.init() : this,
            layId = -1;
        ELEM.titleBox.find('li').each(function (i, e) {
            var $em = $(this).children('em');
            if ($em.text() === title) {
                layId =$(this).attr("lay-id");
            };
        });
        return layId;
    };
    CustomTab.prototype.tabAdd = function (data) {
        var _this = this;
        var layId = _this.exists(data.title);
        // 若不存在
        if (layId === -1) {
            globalTabIdIndex++;
            var content = '<iframe src="' + data.href + '" data-id="' + globalTabIdIndex + '" class="larry-iframe"></iframe>';
            var title = '';
            // 若icon有定义
            if (data.icon !== undefined) {
                if (data.icon.indexOf('icon-') !== -1) {
                    title += '<i class="iconfont ' + data.icon + '"></i>';
                } else {
                    title += '<i class="layui-icon ">' + data.icon + '</i>';
                }
            }
            title += '<em>' + data.title + '</em>';
            if (_this.config.closed) {
                title += '<i class="layui-icon layui-unselect layui-tab-close" data-id="' + globalTabIdIndex + '">&#x1006;</i>';
            }
            //添加tab
            element.tabAdd(ELEM.tabFilter, {
                title: title,
                content: content,
                id:globalTabIdIndex
            });
            //iframe 自适应
            ELEM.contentBox.find('iframe[data-id=' + globalTabIdIndex + ']').each(function () {
                $(this).height(ELEM.contentBox.height());
            });
            if (_this.config.closed) {
                //监听关闭事件
                ELEM.titleBox.find('li').children('i.layui-tab-close[data-id=' + globalTabIdIndex + ']').on('click', function () {
                    //获取当前点击选项卡的id值
                    var id = $(this).data('id');
                    element.tabDelete(ELEM.tabFilter, id).init();//1.0.9版本 fhua 17.2.28
                });
            };

            //切换到当前打开的选项卡
            element.tabChange(ELEM.tabFilter, ELEM.titleBox.find('li').length-1);
        } else {
            element.tabChange(ELEM.tabFilter, layId);
        }
    };
    CustomTab.prototype.tabDelete = function () {

    }
    /**
    *删除已存在选项卡
    */
    var navtab = new CustomTab();
    exports(module_name, function (options) {
        return navtab.set(options);
    });

});
