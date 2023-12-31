﻿function imgVer(Config) {
    var el = eval(Config.el);
    var w = Config.width;
    var h = Config.height;
    var imgLibrary = Config.img;
    var PL_Size = 48;
    var padding = 20;
    var MinN_X = padding + PL_Size;
    var MaxN_X = w - padding - PL_Size - PL_Size / 6;
    var MaxN_Y = padding;
    var MinN_Y = h - padding - PL_Size - PL_Size / 6;
    function RandomNum(Min, Max) {
        var Range = Max - Min;
        var Rand = Math.random();
        if (Math.round(Rand * Range) == 0) {
            return Min + 1;
        } else if (Math.round(Rand * Max) == Max) {
            return Max - 1;
        } else {
            var num = Min + Math.round(Rand * Range) - 1;
            return num;
        }
    }
    var imgRandom = RandomNum(1, imgLibrary.length);
    var imgSrc = imgLibrary[imgRandom];
    var X = RandomNum(MinN_X, MaxN_X);
    var Y = RandomNum(MinN_Y, MaxN_Y);
    var left_Num = -X + 10;
    var lineW = parseInt(w) + parseInt(22);
    var html = '<div style="position:relative;padding:10px 10px 28px;border:1px solid #ebebeb;background:#fcfdfe;border-radius:2px;">';
    html += '<div style="position:relative;overflow:hidden;width:' + w + 'px;">';
    html += '<div style="position:relative;width:' + w + 'px;height:' + h + 'px;">';
    html += '<img id="scream" src="' + imgSrc + '" style="width:' + w + 'px;height:' + h + 'px;">';
    html += '<canvas id="puzzleBox" width="' + w + '" height="' + h + '" style="position:absolute;left:0;top:0;z-index:22;"></canvas>';
    html += '</div>';
    html += '<div class="puzzle-lost-box" style="position:absolute;width:' + w + 'px;height:' + h + 'px;top:0;left:' + left_Num + 'px;z-index:111;">';
    html += '<canvas id="puzzleShadow" width="' + w + '" height="' + h + '" style="position:absolute;left:0;top:0;z-index:22;"></canvas>';
    html += '<canvas id="puzzleLost" width="' + w + '" height="' + h + '" style="position:absolute;left:0;top:0;z-index:33;"></canvas>';
    html += '</div>';
    html += '<p class="ver-tips"></p>';
    html += '</div>';
    html += '<div class="re-btn"><a></a></div>';
    html += '</div>';
    html += '<br>';
    html += '<div style="width:' + lineW + 'px;border:1px solid #ebebeb;border-radius:24px;background:#fcfdfe;padding:0px 11px;">';
    html += '<div style="position:relative;">';
    html += '<p style="font-size:12px;color: #4d5259;line-height:28px;margin:0;text-align:right;padding-right:17px;">按住左边滑块，拖动完成上方拼图</p>';
    html += '<div class="slider-btn"></div>';
    html += '</div>';
    html += '</div>';
    el.html(html);
    var d = PL_Size / 3;
    var c = document.getElementById("puzzleBox");
    var ctx = c.getContext("2d");
    ctx.globalCompositeOperation = "xor";
    ctx.shadowBlur = 10;
    ctx.shadowColor = "#fff";
    ctx.shadowOffsetX = 3;
    ctx.shadowOffsetY = 3;
    ctx.fillStyle = "rgba(0,0,0,0.7)";
    ctx.beginPath();
    ctx.lineWidth = "1";
    ctx.strokeStyle = "rgba(0,0,0,0)";
    ctx.moveTo(X, Y);
    ctx.lineTo(X + d, Y);
    ctx.bezierCurveTo(X + d, Y - d, X + 2 * d, Y - d, X + 2 * d, Y);
    ctx.lineTo(X + 3 * d, Y);
    ctx.lineTo(X + 3 * d, Y + d);
    ctx.bezierCurveTo(X + 2 * d, Y + d, X + 2 * d, Y + 2 * d, X + 3 * d, Y + 2 * d);
    ctx.lineTo(X + 3 * d, Y + 3 * d);
    ctx.lineTo(X, Y + 3 * d);
    ctx.closePath();
    ctx.stroke();
    ctx.fill();
    var c_l = document.getElementById("puzzleLost");
    var c_s = document.getElementById("puzzleShadow");
    var ctx_l = c_l.getContext("2d");
    var ctx_s = c_s.getContext("2d");
    var img = new Image();
    img.src = imgSrc;
    img.onload = function () {
        ctx_l.drawImage(img, 0, 0, w, h)
    }
    ctx_l.beginPath();
    ctx_l.strokeStyle = "rgba(0,0,0,0)";
    ctx_l.moveTo(X, Y);
    ctx_l.lineTo(X + d, Y);
    ctx_l.bezierCurveTo(X + d, Y - d, X + 2 * d, Y - d, X + 2 * d, Y);
    ctx_l.lineTo(X + 3 * d, Y);
    ctx_l.lineTo(X + 3 * d, Y + d);
    ctx_l.bezierCurveTo(X + 2 * d, Y + d, X + 2 * d, Y + 2 * d, X + 3 * d, Y + 2 * d);
    ctx_l.lineTo(X + 3 * d, Y + 3 * d);
    ctx_l.lineTo(X, Y + 3 * d);
    ctx_l.closePath();
    ctx_l.stroke();
    ctx_s.fill();
    ctx_l.clip();
    ctx_s.beginPath();
    ctx_s.lineWidth = "1";
    ctx_s.strokeStyle = "rgba(0,0,0,0)";
    ctx_s.moveTo(X, Y);
    ctx_s.lineTo(X + d, Y);
    ctx_s.bezierCurveTo(X + d, Y - d, X + 2 * d, Y - d, X + 2 * d, Y);
    ctx_s.lineTo(X + 3 * d, Y);
    ctx_s.lineTo(X + 3 * d, Y + d);
    ctx_s.bezierCurveTo(X + 2 * d, Y + d, X + 2 * d, Y + 2 * d, X + 3 * d, Y + 2 * d);
    ctx_s.lineTo(X + 3 * d, Y + 3 * d);
    ctx_s.lineTo(X, Y + 3 * d);
    ctx_s.closePath();
    ctx_s.stroke();
    ctx_s.shadowBlur = 20;
    ctx_s.shadowColor = "black";
    ctx_s.fill();
    var moveStart = '';
    $(".slider-btn").on('mousedown touchstart', function (e) {
        e = e || window.event;
        moveStart = e.pageX || e.originalEvent.targetTouches[0].pageX;
    });
    $(window).on('mousemove touchmove', function (e) {
        e = e || window.event;
        var moveX = e.pageX || e.originalEvent.targetTouches[0].pageX;
        var d = moveX - moveStart;
        if (moveStart == '') { } else {
            if (d < 0 || d > (w - padding - PL_Size)) { } else {
                $(".slider-btn").css({
                    "left": d + 'px',
                    "transition": "inherit"
                });
                $("#puzzleLost").css({
                    "left": d + 'px',
                    "transition": "inherit"
                });
                $("#puzzleShadow").css({
                    "left": d + 'px',
                    "transition": "inherit"
                });
            }
        }
    })
    $(window).on('mouseup touchend', function (e) {
        e = e || window.event;
        var e_pageX = e.originalEvent.changedTouches == undefined ? moveStart : e.originalEvent.changedTouches[0];
        var moveEnd_X = e.pageX - moveStart || e_pageX.pageX - moveStart;
        var ver_Num = X - 10;
        var deviation = 4;
        var Min_left = ver_Num - deviation;
        var Max_left = ver_Num + deviation;
        if (moveStart == '') { } else {
            if (Max_left > moveEnd_X && moveEnd_X > Min_left) {
                $(".ver-tips").html('<i class="text-success"></i><span class="text-success">验证通过</span><span></span>');
                $(".ver-tips").addClass("slider-tips");
                $(".puzzle-lost-box").addClass("hidden");
                $("#puzzleBox").addClass("hidden");
                setTimeout(function () {
                    $(".ver-tips").removeClass("slider-tips");
                    imgVer(Config);
                }, 2000);
                Config.success();
            } else {
                $(".ver-tips").html('<i class="text-danger"></i><span class="text-danger">验证失败:</span><span class="m-l-5">拖动滑块将悬浮图像正确拼合</span>');
                $(".ver-tips").addClass("slider-tips");
                setTimeout(function () {
                    $(".ver-tips").removeClass("slider-tips");
                }, 2000);
                Config.error();
            }
        }
        setTimeout(function () {
            $(".slider-btn").css({
                "left": '0',
                "transition": "left 0.5s"
            });
            $("#puzzleLost").css({
                "left": '0',
                "transition": "left 0.5s"
            });
            $("#puzzleShadow").css({
                "left": '0',
                "transition": "left 0.5s"
            });
        }, 1000);
        moveStart = '';
    })
    $(".re-btn a").on("click", function () {
        imgVer(Config);
    })
}
