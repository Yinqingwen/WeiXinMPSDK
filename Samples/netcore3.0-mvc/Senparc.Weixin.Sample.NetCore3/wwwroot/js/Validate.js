/**
 * 前端校验类
 * 兼容jquery,zepto
 * 错误显示使用Weui+
 * */
var Validate = {
    //为空校验
    require: function (elem, errmsg) {
        var value = $(elem).val();
        if (value === "") {
            $.toptip(errmsg);
            $(elem).focus();
        }
    },
    //电话号码校验
    phone: function (elem, errmsg) {
        var value = $.trim($(elem).val());
        if (!/^((0\d{2,3}-\d{7,8})|(\d{7,8})|(1[3456789]\d{9}))$/.test(value)) { // /^(0|86|17951)?(13[0-9]|15[012356789]|18[0-9]|14[57]|17[0-9])[0-9]{8}$/
            $.toptip(errmsg);
            $(elem).focus();
        }
    },
    //Email校验
    email: function (elem, errmsg) {
        var value = $.trim($(elem).val());
        if (!/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/.test(value)) {
            $toptip(errmsg);
            $(elem).focus();
        } 
    },
    //相同校验
    compare: function (elem1, elem2, errmsg) {
        elem2 = $(elem2);
        var value1 = $.trim($(elem1).val());
        var value2 = $.trim($(elem2).val());
        if (value1 !== value2) {
            $.toptip(errmsg);
            $(elem2).focus();
        } 
    }
};