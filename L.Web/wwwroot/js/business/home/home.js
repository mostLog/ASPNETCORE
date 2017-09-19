layui.use(["jquery", "element", "common"], function () {
    var $ = layui.$,
        common = layui.common,
        device = layui.device();
    //火狐
    if (navigator.userAgent.indexOf('Firefox') >= 0) {
        redict();
    }
    //google
    if (navigator.userAgent.indexOf("Chrome") < 0) {
        if (device.ie && device.ie > 8) {
            console.log(device.ie);
        } else {
            redict();
        }
    }

    function redict() {
        window.location.href = "https://www.baidu.com/";
        return false
    }

    function disabled() {
        if (window.console && (console.firebug || console.table && /firebug/.test(console.table())) || typeof opera == "object" && typeof opera.postError == "function" && console.profile.length > 0) {
            redict()
        }
        if (typeof console.profiles == "object" && console.profiles.length > 0) {
            redict()
        }
    }
    disabled();
    window.onresize = function () {
        if (top.window.outerHeight - top.window.innerHeight > 150) {
            redict()
        }
        if (top.window.outerWidth - top.window.innerWidth > 150) {
            redict()
        }
    };
    //按键监听
    $(document).keydown(function () {
        return disabledKey(arguments[0])
    });

    function disabledKey(key) {
        var value;
        if (window.event) {
            value = key.keyCode
        } else if (key.which) {
            value = key.which
        }
        if (value == 123) {
            common.cmsError("不允许F12哦！", "警告");
            return false
        }
        if (r.ctrlKey) {
            if (r.shiftKey && value == 73) {
                common.cmsError("不允许ctrl+shift+I哦！", "警告");
                return false
            }
        }
        if (r.ctrlKey && value == 83) {
            common.cmsError("不允许ctrl+s保存哦！", "警告");
            return false
        }
    }
    $(document).ready(function () {
        if (device.ie && device.ie < 9) {
            common.cmsError("本系统最低支持ie8，您当前使用的是古老的 IE" + device.ie + "！ \n 建议使用IE9及以上版本的现代浏览器", "警告")
        }
        if (device.android || device.ios) {
            if ($("#larry_admin_out").length > 0) {
                $("#larry_admin_out").addClass("larry-mobile")
            } else {
                $("body").addClass("larry-mobile")
            }
        } else {
            if ($("#larry_admin_out").length > 0) {
                if ($("#larry_admin_out").hasClass("larry-mobile")) {
                    $("#larry_admin_out").removeClass("larry-mobile")
                }
            } else {
                if ($("body").hasClass("larry-mobile")) {
                    $("body").removeClass("larry-mobile")
                }
            }
        }
    })
});