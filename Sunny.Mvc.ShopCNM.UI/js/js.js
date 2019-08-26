$(function () {

    // a点击删除的隐式开发 条件impl-dev=true  OpElementId指定操控显隐的元素
    $("[impl-dev=true][OpElementId]").click(function (ev) {
        // 获取点击的链接
        var link = $("[impl-dev=true][OpElementId]").attr("href");
        ev.preventDefault();
        //$("a[impl-dev=true]").attr("href", "#");
        // 遮罩现
        $('.zhezhao').css('display', 'block');
        // 弹窗现
        $('#' + $("[impl-dev=true][OpElementId]").attr("OpElementId")).fadeIn();
        // 修改弹窗中确定的herf属性
        $("#yes").attr("href", link);
    });

    $('#no').click(function () {
        // 遮罩隐
        $('.zhezhao').css('display', 'none');
        // 弹窗隐
        $('#' + $("[impl-dev=true][OpElementId]").attr("OpElementId")).fadeOut();
    });

    // 使用带有属性submit=true的from提交
    $("form input[submit=true]").click(function () {
        if (check_all(this)) {
            $("form").submit();
        } 
    });

    // 异步提交数据，设置城市
    //LoadDataByAjax({ aid: "100000" }, "UPro", "AjaxToGetCity");
    //LoadDataByAjax({ aid: "110100" }, "UCounty", "AjaxToGetCity");
    $("#UPro").click(function () {
        if ($("#UPro option").siblings().length == 0) {
            LoadDataByAjax({ aid: $("#UPro").val() }, "UPro", "../Util/AjaxToGetCity", $("#UPro option").attr("value"));
        }
    });
    var canClick = "yes";
    $("#UCity").click(function () {
        if (canClick == "yes") {
            if ($("#UCity option").siblings().length == 0) {
                LoadDataByAjax({ aid: $("#UCity").val() }, "UCity", "../Util/AjaxToGetCity", $("#UCity option").attr("value"));
            }
        }
        canClick = "no";

    });
    $("#UCounty").click(function () {
        if ($("#UCounty option").siblings().length == 0) {
            LoadDataByAjax({ aid: $("#UCounty").val() }, "UCounty", "../Util/AjaxToGetCity", $("#UCounty option").attr("value"));
        }
    });
    $("#UPro").change(
        function () {
            if ($("#UPro option").siblings().length > 0) {
                var key = LoadDataByAjax({ aid: $("#UPro").val() }, "UCity", "../Util/AjaxToGetCityByChange");
                LoadDataByAjax({ aid: key }, "UCounty", "../Util/AjaxToGetCityByChange");
            }
        });
    $("#UCity").change(function () {
        if ($("#UPro option").siblings().length > 0) {
            LoadDataByAjax({ aid: $("#UCity").val() }, "UCounty", "../Util/AjaxToGetCityByChange");
        }
    });

    function LoadDataByAjax(key, ToElementById, url, selectValue) {
        var out = "";
        $.ajax({
            url: url,
            async: false, //改为同步方式
            type: "GET",
            data: key,
            success: function (data) {
                var str = "";
                for (var key in data) {
                    if (selectValue == key) {
                        str = str + '<option value="' + key + '" selected=selected>' + data[key] + '</option>';
                    } else {
                        str = str + '<option value="' + key + '">' + data[key] + '</option>';
                    }
                }
                $("#" + ToElementById).html(str);
                for (var key in data) {
                    out = key;
                    return;
                }
            },
            dataType: "json"
        });
        return out;
    }

    // 隐式开发，为带有impl-dev=true  selectValue赋选择初值
    $("[impl-dev=true][selectValue]").each(function () {
        var value = $(this).attr("selectValue");
        $(this).children("option[value=" + value + "]").attr("selected", "selected");
        $(this).children("input:radio[value=" + value + "]").attr("checked", "checked");
    });
    // <input type="button" value="查询" impl-dev=true link-to="UserInfo/Index?uNamelike=" para-from="#findName"/>
    $("[impl-dev=true][link-to]").click(function () {
        $(window).attr('location', $(this).attr("link-to") + $($(this).attr("para-from")).val
            ());
    });

    // 隐式开发，设置第几个li为active
    $("[impl-dev=true][active-index] li:nth-child(" + $("[impl-dev=true][active-index]").attr("active-index") + ")").attr("id", "active");


    if ($("[impl-dev=true][data-url][load-one=true][auto-tag]").attr("data-url") != undefined) {
        var node = $("[impl-dev=true][data-url][load-one=true][auto-tag]");
        var str = node.html();
        //if (node.children().length == 0) {
            var url = node.attr("data-url");
            var tag = node.attr("auto-tag");
            var selectValue = node.attr("selectValue");
            $.get(url, {}, function (data) {
                for (var key in data) {
                    if (key == selectValue) {
                        str += "<" + tag + " value=" + key + " selected=selected>" + data[key] + "</" + tag + ">";
                    } else {
                        str += "<" + tag + " value=" + key + ">" + data[key] + "</" + tag + ">";
                    }     
                }
                node.html(str);
            }, "json");
        //}
    }

    $("[data-val=true][ajax-url]").blur(function () {
        if (check(this)) {
            var name = $(this).attr("name");
            var msg = $(this).attr("ajax-check-msg");
            $.post($(this).attr("ajax-url"), { ajaxparam: $(this).val() }, function (data) {
                if (data != "ok") {
                    $("[data-valmsg-for=" + name + "]").html(msg);

                } else {
                    $("[data-valmsg-for=" + name + "]").html("");
                }
            });
        }
    });

    $("[limited]").click(function (ev) {
        ev.preventDefault();
        $('.zhezhao').css('display', 'block');
        $("#limited").fadeIn();
    });

    $("#limited-yes").click(function () {
        $('.zhezhao').css('display', 'none');
        $("#limited").fadeOut();
    });

});

// 判断表单提交时，判断是否通过校验
function check_all(ev) {
    var form = $(ev).parents("form");
    var b = true;
    form.find("span[data-valmsg-for]").each(function () {
        if ($(this).html() != "" || $("[name=" + $(this).attr("data-valmsg-for") + "]").val() == "") {
            return b = false;
        }
    });
    return b;
}
function check(ev) {
    var name = $(ev).attr("name");
    if ($(ev).val() != "" && $("span[data-valmsg-for=" + name + "]").html() == "") {
        return true;
    } else {
        return false;
    }
}

