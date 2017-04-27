var loginSuccess = false;
var playSuccess = false;
var capturePath = "";

// 初始化插件

// 全局保存当前选中窗口
var g_iWndIndex = 0; //可以不用设置这个变量，有窗口参数的接口中，不用传值，开发包会默认使用当前选择窗口
$(function () {
    //// 检查插件是否已经安装过
    //if (-1 == WebVideoCtrl.I_CheckPluginInstall()) {
    //    alert("您还未安装过插件！");
    //    $("#divPlugin").html("<a href='/content/HkPlugin/WebComponents.exe' target='_blank'>您还未安装过插件,点击下载插件进行安装，并刷新页面。</a>");
    //    return;
    //}

    //// 初始化插件参数及插入插件
    //WebVideoCtrl.I_InitPlugin(550, 350, {
    //    iWndowType: 2,
    //    cbSelWnd: function (xmlDoc) {
    //        g_iWndIndex = $(xmlDoc).find("SelectWnd").eq(0).text();
    //        var szInfo = "当前选择的窗口编号：" + g_iWndIndex;
    //        showOPInfo(szInfo);
    //    }
    //});
    //WebVideoCtrl.I_InsertOBJECTPlugin("divPlugin");
    //alert("aaa");

    //// 检查插件是否最新
    //if (-1 == WebVideoCtrl.I_CheckPluginVersion()) {
    //    alert("检测到新的插件版本！");
    //    $("#divPlugin").html("<a href='/content/HkPlugin/WebComponents.exe' target='_blank'>点击下载新版本插件进行安装，并刷新页面。</a>");
    //    return;
    //}
});

function InitWebVideo(id, width, height) {
    // 检查插件是否已经安装过
    if (-1 == WebVideoCtrl.I_CheckPluginInstall()) {
        alert("您还未安装过插件，请点击下载并安装！");
        $("#" + id).html("<a href='/content/HkPlugin/WebComponents.exe' target='_blank'>您还未安装过插件,点击下载插件进行安装，并刷新页面。</a>");
        return;
    }

    // 初始化插件参数及插入插件
    WebVideoCtrl.I_InitPlugin(width, height, {
        iWndowType: 2,
        cbSelWnd: function (xmlDoc) {
            g_iWndIndex = $(xmlDoc).find("SelectWnd").eq(0).text();
            var szInfo = "当前选择的窗口编号：" + g_iWndIndex;
            showOPInfo(szInfo);
        }
    });

    try {
        WebVideoCtrl.I_InsertOBJECTPlugin(id);
        //WebVideoCtrl.I_InsertOBJECTPlugin("divPlugin");
    } catch (e) {
        console.info(e);
    };
    // 检查插件是否最新
    if (-1 == WebVideoCtrl.I_CheckPluginVersion()) {
        alert("检测到新的插件版本！");
        $("#" + id).html("<a href='/content/HkPlugin/WebComponents.exe' target='_blank'>点击下载新版本插件进行安装，并刷新页面。</a>");
        return;
    }
}

//打印信息
function showOPInfo(msg) {
    console.info(msg);
}

// 窗口分割数
function changeWndNum(iType) {
    iType = parseInt(iType, 10);
    WebVideoCtrl.I_ChangeWndNum(iType);
}

// 获取本地参数
function getLocalCfg() {
    var xmlDoc = WebVideoCtrl.I_GetLocalCfg();
    showOPInfo("本地配置获取成功！");
    capturePath = $(xmlDoc).find("CapturePath").eq(0).text();
}

// 登录
function login(szIP, szPort, szUsername, szPassword, channel) {
    if ("" == szIP || "" == szPort) {
        return;
    }

    var iRet = WebVideoCtrl.I_Login(szIP, 1, szPort, szUsername, szPassword, {
        success: function (xmlDoc) {
            showOPInfo(szIP + " 登录成功！");
            loginSuccess = true;
            getLocalCfg();
            //setTimeout(function () {
            //    getChannelInfo(szIP);
            //}, 10);
            //$("#divOp input[type=button][name!=play]").attr("disabled", true);

            //开始播放视频
            startRealPlay(szIP, channel);
        },
        error: function () {
            showOPInfo(szIP + " 登录失败！");
            loginSuccess = false;
            //$("#divOp input[type=button][name!=play]").attr("disabled", false);
            alert("登录失败");
        }
    });

    if (-1 == iRet) {
        showOPInfo(szIP + " 已登录过！");
    }
}

// 退出
function logout(szIP) {
    //var szIP = $("#ip").val(),
    var szInfo = "";

    if (szIP == "") {
        return;
    }

    var iRet = WebVideoCtrl.I_Logout(szIP);
    if (0 == iRet) {
        szInfo = "退出成功！";
        //getChannelInfo();
    } else {
        szInfo = "退出失败！";
    }
    showOPInfo(szIP + " " + szInfo);
}

// 开始预览
function startRealPlay(szIP, channel) {
    var oWndInfo = WebVideoCtrl.I_GetWindowStatus(g_iWndIndex),
    iStreamType = 1; //1为主码流，2为子码流//parseInt($("#streamtype").val(), 10),
    iChannelID = channel; //parseInt($("#channels").val(), 10),
    bZeroChannel = false; //$("#channels option").eq($("#channels").get(0).selectedIndex).attr("bZero") == "true" ? true : false,
    szInfo = "";

    if ("" == szIP) {
        return;
    }

    if (oWndInfo != null) { // 已经在播放了，先停止
        WebVideoCtrl.I_Stop();
    }

    var iRet = WebVideoCtrl.I_StartRealPlay(szIP, {
        iStreamType: iStreamType,
        iChannelID: iChannelID,
        bZeroChannel: bZeroChannel
    });

    if (0 == iRet) {
        szInfo = "预览成功！";
        playSuccess = true;
        enable3DZoom();
    } else {
        szInfo = "预览失败！";
        playSuccess = false;
        alert(szInfo);
    }

    showOPInfo(szIP + " " + szInfo);
}

// 停止预览
function stopRealPlay() {
    var oWndInfo = WebVideoCtrl.I_GetWindowStatus(g_iWndIndex),
		szInfo = "";

    if (oWndInfo != null) {
        var iRet = WebVideoCtrl.I_Stop();
        if (0 == iRet) {
            szInfo = "停止预览成功！";
        } else {
            szInfo = "停止预览失败！";
        }
        showOPInfo(oWndInfo.szIP + " " + szInfo);
    }
}

// 抓图
function capturePic(channel) {
    var oWndInfo = WebVideoCtrl.I_GetWindowStatus(g_iWndIndex),
		szInfo = "";

    if (oWndInfo != null) {
        var szChannelID = channel;// $("#channels").val(),
        szPicName = oWndInfo.szIP + "_" + szChannelID + "_" + new Date().getTime(),
        iRet = WebVideoCtrl.I_CapturePic(szPicName);
        if (0 == iRet) {
            szInfo = "抓图成功！";
            alert("图片存储于" + capturePath + "\\" + szPicName);
        } else {
            szInfo = "抓图失败！";
        }
        showOPInfo(oWndInfo.szIP + " " + szInfo);
    }
}

// 全屏
function fullScreen() {
    WebVideoCtrl.I_FullScreen(true);
}

// 设置预置点
function clickSetPreset(iPresetID) {
    var oWndInfo = WebVideoCtrl.I_GetWindowStatus(g_iWndIndex);
    //var iPresetID = parseInt($("#preset").val(), 10);

    if (oWndInfo != null) {
        WebVideoCtrl.I_SetPreset(iPresetID, {
            success: function (xmlDoc) {
                showOPInfo(oWndInfo.szIP + " 设置预置点成功！");
            },
            error: function () {
                showOPInfo(oWndInfo.szIP + " 设置预置点失败！");
            }
        });
    }
}

// 调用预置点
function clickGoPreset(iPresetID) {
    var oWndInfo = WebVideoCtrl.I_GetWindowStatus(g_iWndIndex);
    //var	iPresetID = parseInt($("#preset").val(), 10);

    if (oWndInfo != null) {
        WebVideoCtrl.I_GoPreset(iPresetID, {
            success: function (xmlDoc) {
                showOPInfo(oWndInfo.szIP + " 调用预置点成功！");
            },
            error: function () {
                showOPInfo(oWndInfo.szIP + " 调用预置点失败！");
            }
        });
    }
}

// PTZ控制 9为自动，1,2,3,4,5,6,7,8为方向PTZ
var g_bPTZAuto = false;
function mouseDownPTZControl(iPTZIndex, iPTZSpeed) {
    var oWndInfo = WebVideoCtrl.I_GetWindowStatus(g_iWndIndex),
        bZeroChannel = false;//$("#channels option").eq($("#channels").get(0).selectedIndex).attr("bZero") == "true" ? true : false,
    //iPTZSpeed = $("#ptzspeed").val(),
    bStop = false;

    if (bZeroChannel) {// 零通道不支持云台
        return;
    }

    if (oWndInfo != null) {
        if (9 == iPTZIndex && g_bPTZAuto) {
            iPTZSpeed = 0;// 自动开启后，速度置为0可以关闭自动
            bStop = true;
        } else {
            g_bPTZAuto = false;// 点击其他方向，自动肯定会被关闭
            bStop = false;
        }

        WebVideoCtrl.I_PTZControl(iPTZIndex, bStop, {
            iPTZSpeed: iPTZSpeed,
            success: function (xmlDoc) {
                if (9 == iPTZIndex) {
                    g_bPTZAuto = !g_bPTZAuto;
                }
                showOPInfo(oWndInfo.szIP + " 开启云台成功！");
            },
            error: function () {
                showOPInfo(oWndInfo.szIP + " 开启云台失败！");
            }
        });
    }
}

// 方向PTZ停止
function mouseUpPTZControl() {
    var oWndInfo = WebVideoCtrl.I_GetWindowStatus(g_iWndIndex);

    if (oWndInfo != null) {
        WebVideoCtrl.I_PTZControl(1, true, {
            success: function (xmlDoc) {
                showOPInfo(oWndInfo.szIP + " 停止云台成功！");
            },
            error: function () {
                showOPInfo(oWndInfo.szIP + " 停止云台失败！");
            }
        });
    }
}

//变倍+
function PTZZoomIn() {
    var oWndInfo = WebVideoCtrl.I_GetWindowStatus(g_iWndIndex);

    if (oWndInfo != null) {
        WebVideoCtrl.I_PTZControl(10, false, {
            iWndIndex: g_iWndIndex,
            success: function (xmlDoc) {
                showOPInfo(oWndInfo.szIP + " 调焦+成功！");
            },
            error: function () {
                showOPInfo(oWndInfo.szIP + "  调焦+失败！");
            }
        });
    }
}
//变倍-
function PTZZoomout() {
    var oWndInfo = WebVideoCtrl.I_GetWindowStatus(g_iWndIndex);

    if (oWndInfo != null) {
        WebVideoCtrl.I_PTZControl(11, false, {
            iWndIndex: g_iWndIndex,
            success: function (xmlDoc) {
                showOPInfo(oWndInfo.szIP + " 调焦-成功！");
            },
            error: function () {
                showOPInfo(oWndInfo.szIP + "  调焦-失败！");
            }
        });
    }
}
//变倍停止
function PTZZoomStop() {
    var oWndInfo = WebVideoCtrl.I_GetWindowStatus(g_iWndIndex);

    if (oWndInfo != null) {
        WebVideoCtrl.I_PTZControl(11, true, {
            iWndIndex: g_iWndIndex,
            success: function (xmlDoc) {
                showOPInfo(oWndInfo.szIP + " 调焦停止成功！");
            },
            error: function () {
                showOPInfo(oWndInfo.szIP + "  调焦停止失败！");
            }
        });
    }
}



// 启用电子放大
function enableEZoom() {
    var oWndInfo = WebVideoCtrl.I_GetWindowStatus(g_iWndIndex),
		szInfo = "";

    if (oWndInfo != null) {
        var iRet = WebVideoCtrl.I_EnableEZoom();
        if (0 == iRet) {
            szInfo = "启用电子放大成功！";
        } else {
            szInfo = "启用电子放大失败！";
        }
        showOPInfo(oWndInfo.szIP + " " + szInfo);
    }
}

// 禁用电子放大
function disableEZoom() {
    var oWndInfo = WebVideoCtrl.I_GetWindowStatus(g_iWndIndex),
		szInfo = "";

    if (oWndInfo != null) {
        var iRet = WebVideoCtrl.I_DisableEZoom();
        if (0 == iRet) {
            szInfo = "禁用电子放大成功！";
        } else {
            szInfo = "禁用电子放大失败！";
        }
        showOPInfo(oWndInfo.szIP + " " + szInfo);
    }
}

// 启用3D放大
function enable3DZoom() {
    var oWndInfo = WebVideoCtrl.I_GetWindowStatus(g_iWndIndex),
		szInfo = "";

    if (oWndInfo != null) {
        var iRet = WebVideoCtrl.I_Enable3DZoom();
        if (0 == iRet) {
            szInfo = "启用3D放大成功！";
        } else {
            szInfo = "启用3D放大失败！";
        }
        showOPInfo(oWndInfo.szIP + " " + szInfo);
    }
}

// 禁用3D放大
function disable3DZoom() {
    var oWndInfo = WebVideoCtrl.I_GetWindowStatus(g_iWndIndex),
		szInfo = "";

    if (oWndInfo != null) {
        var iRet = WebVideoCtrl.I_Disable3DZoom();
        if (0 == iRet) {
            szInfo = "禁用3D放大成功！";
        } else {
            szInfo = "禁用3D放大失败！";
        }
        showOPInfo(oWndInfo.szIP + " " + szInfo);
    }
}