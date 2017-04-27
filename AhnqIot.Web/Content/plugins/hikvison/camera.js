function playCamera() {
	var ip = "223.241.243.77";
	var port = 10002;
	var username = "admin";
	var pwd = "smt12345";
	var channel = 1;

	changeWndNum(1); //1个播放窗口
	login(ip, port, username, pwd);
}

function initCameraControlButton() {
	//预览
	$("#btnStartRealPlay").click(function() {
		play(channel);
	});
	//停止
	$("#btnStopRealPlay").click(function() {
		stopRealPlay();
	});
	//拍照
	$("#btnTakePhoto").click(function() {
		capturePic(channel);
	});

	//上
	$("#btnArrowUp").mousedown(function() {
		var ptzSpeed = parseInt($("#selPtzSpeed").val(), 10);
		mouseDownPTZControl(1, ptzSpeed);
	}).mouseup(function() {
		mouseUpPTZControl();
	});
	//下
	$("#btnArrowDown").mousedown(function() {
		var ptzSpeed = parseInt($("#selPtzSpeed").val(), 10);
		mouseDownPTZControl(2, ptzSpeed);
	}).mouseup(function() {
		mouseUpPTZControl();
	});
	//左
	$("#btnArrowLeft").mousedown(function() {
		var ptzSpeed = parseInt($("#selPtzSpeed").val(), 10);
		mouseDownPTZControl(3, ptzSpeed);
	}).mouseup(function() {
		mouseUpPTZControl();
	});
	//右
	$("#btnArrowRight").mousedown(function() {
		var ptzSpeed = parseInt($("#selPtzSpeed").val(), 10);
		mouseDownPTZControl(4, ptzSpeed);
	}).mouseup(function() {
		mouseUpPTZControl();
	});
	//自动
	$("#btnArrowAuto").mousedown(function() {
		var ptzSpeed = parseInt($("#selPtzSpeed").val(), 10);
		mouseDownPTZControl(9, ptzSpeed);
	}).mouseup(function() {
		mouseUpPTZControl();
	});

	//设置预置点
	$("#btnPresetSet").click(function() {
		var id = $("#selPresetPoint").val();
		alert(id);
		clickSetPreset(parseInt(id, 10));
	});
	//调用预置点
	$("#btnPresetGo").click(function() {
		var id = $("#selPresetPoint").val();
		clickGoPreset(parseInt(id, 10));
	});

	$("#btnNear").mousedown(function() {
		PTZZoomIn();
	}).mouseup(function() {
		PTZZoomStop();
	});
	$("#btnFar").mousedown(function() {
		PTZZoomout();
	}).mouseup(function() {
		PTZZoomStop();
	});

	$("#control").css("background-image", "url(/content/ptz/play.png)");
	$("#control").click(function() {
		if ($("#control").attr("data") == "play") {
			$("#btnStartRealPlay").click();
			$("#control").attr("data", "stop");
			$("#control").css("background-image", "url(/content/ptz/stop.png)");
		} else {
			$("#btnStopRealPlay").click();
			$("#control").attr("data", "play");
			$("#control").css("background-image", "url(/content/ptz/play.png)");
		}
	});
}
