$(function () {
    $("#phone").focus();
    refreshList(false);
    $("#go").click(function (e) {
        e.preventDefault();

        var json = Game.GetJSON().value;
        var users = JSON.parse(json);
        var items = ['guomao', 'guibinlou'];
        var phone = $.trim($("#phone").val());
        var flag = true;
        var admin = "13910681651";

        //验证
        if (phone.length == 0 || !(/^(13[0-9]|15[0-9]|18[0-9])\d{8}$/.test(phone))) {
            flag = false;
            alert('手机号不正确！');
            return;
        }
        else {
            //如果是管理员，则显示中奖结果
            if (phone == admin) {
                refreshList(true);
                return;
            }

            var errcode = checkuser(phone, users);
            if (errcode == 1) {
                alert('非常抱歉，您输入的手机号码已经参加过这次活动了');
                flag = false;
                return;
            }
            else if (errcode == 2) {
                alert('非常抱歉，您输入的手机号码不在此次活动的用户范围里');
                flag = false;
                return;
            }
        }


        //提交
        if (flag) {
            var i = randomXToY(0, 1);
            var result = gethotel(i, users);
            $.each(users, function (key, value) {
                if (users[key].phone == phone) {
                    users[key].hotel = result;
                }
            });
            //解决IE8 JSON中文问题
            var jsonString = JSON.stringify(users);
            var o = JSON.parse(jsonString);
            eval("var jsonString = '" + JSON.stringify(o) + "';");

            if (Game.Save(jsonString.toString())) {
                $("#choosing").fadeIn(function () {
                    var _this = $(this);
                    setTimeout(function () {
                        _this.hide()
                                .css({ "background": "url(images/game/" + items[result] + ".png) top left no-repeat", "_background": "url(images/game/" + items[result] + ".gif) top left no-repeat" })
                                .fadeIn();
                        weibo("我在大众汽车酒店抽取活动中抽到了" + ((result == 0) ? '国贸大厦' : '贵宾楼') + "!  详情见：");
                        refreshList(false);
                        setTimeout(function () {
                            window.location.reload();
                        }, 10000);
                    }, 5000);
                });
            }
            else {
                alert("抽取失败。请重试...");
            }
        }
    });

    //回车提交
    $("#phone").keydown(function (e) {
        if (e.which == 13) {
            e.preventDefault();
            $(this).blur();
            $("#go").click();
        }
    });
});



//list
function refreshList(admin) {
    var json = Game.GetJSON().value;
    var users = JSON.parse(json);
    var table = $('<table class="table"></table>');
    $.each(users, function (key, value) {
        if (users[key].hotel != "none") {
            if (!admin) {
                table.append('<tr><td style="width:110px; text-align:center;">' + (admin ? users[key].phone : encodePhone(users[key].phone)) + '</td><td>抽中' + (users[key].hotel == 0 ? '国贸大厦' : '贵宾楼') + '</td></tr>');
            } else {
                table.append('<tr><td colspan="2">' + users[key].name + '</td></tr><tr><td style="width:110px; text-align:center;">' + (admin ? users[key].phone : encodePhone(users[key].phone)) + '</td><td>抽中' + (users[key].hotel == 0 ? '国贸大厦' : '贵宾楼') + '</td></tr>');
            }
        }
    });
    $("#list").hide().empty().append(table).fadeIn();
}

//电话号码加密
function encodePhone(phone) {
    return phone.substring(0, 3) + '****' + phone.substring(7, phone.length);
}

//检查用户选择酒店情况（酒店A(0)=7 | 酒店B(1)=14）
function gethotel(i, users) {
    var num = 0;
    $.each(users, function (key, value) {
        if (users[key].hotel != "none" && parseInt(users[key].hotel) == i)
            num++;
    });
    if (i == 0 && num >= 6) {
        return 1;
    } else if (i == 1 && num >= 12) {
        return 0;
    } else {
        return i;
    }
}

function randomXToY(minVal, maxVal, floatVal) {
    var randVal = minVal + (Math.random() * (maxVal - minVal));
    return typeof floatVal == 'undefined' ? Math.round(randVal) : randVal.toFixed(floatVal);
}

function checkuser(phone, users) {
    var errcode = 2;
    $.each(users, function (key, value) {
        if (users[key].phone == phone) {
            if (users[key].hotel == 'none')
                errcode = 0;
            else
                errcode = 1;
        }
    });
    return errcode; //0:验证成功 | 1：已经提交过 | 2：不在用户列表
}

//生成微博分享按钮
function weibo(title) {
    var _w = 142, _h = 32;
    var param = {
        url: location.href,
        type: '4',
        count: '', /**是否显示分享数，1显示(可选)*/
        appkey: '', /**您申请的应用appkey,显示分享来源(可选)*/
        title: title, /**分享的文字内容(可选，默认为所在页面的title)*/
        pic: '', /**分享图片的路径(可选)*/
        ralateUid: '', /**关联用户的UID，分享微博会@该用户(可选)*/
        language: 'zh_cn', /**设置语言，zh_cn|zh_tw(可选)*/
        rnd: new Date().valueOf()
    }
    var temp = [];
    for (var p in param) {
        temp.push(p + '=' + encodeURIComponent(param[p] || ''))
    }
    $("#choosing").append($('<iframe id="weibo" allowTransparency="true" frameborder="0" scrolling="no" src="http://hits.sinajs.cn/A1/weiboshare.html?' + temp.join('&') + '" width="' + _w + '" height="' + _h + '"></iframe>'));
}