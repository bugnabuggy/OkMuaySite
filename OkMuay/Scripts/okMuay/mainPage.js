var picsPath = "/BgPics/";
var picsUrl = "/OKMUAY/GetBgPics";
var bgPic1;
var bgPic2;
var index;

var flag = false;
var bgPictures = new Array();
var timer;

function picChange() {

	if (index >= bgPictures.length-1)
		index = 0;
	else {
		index++;
	}

	if (index % 2 > 0) {
		bgPic1.css('background-image', 'url("' + picsPath + bgPictures[index] + '")');
	}
	else{
		bgPic2.css('background-image', 'url("' + picsPath + bgPictures[index] + '")');
	}

	bgPic1.fadeToggle(3000);
	bgPic2.fadeToggle(4000);
}

function photoClick(img) {
	$('.om-cover-inner').html('');
	$('.om-cover').toggle();
	$('.om-cover-inner').css('background-image', 'url('+ $(img).attr('src') +')');
}

$().ready(function () {
	$.ajax({
		url: picsUrl,
		async:"false"
	}).success(function(data) {
		bgPictures = data;
		if (bgPictures.length > 1) {
			flag = true;
			index = 0;
			bgPic2.css('background-image', 'url("' + picsPath + bgPictures[0] + '")');
			bgPic1.css('background-image', 'url("' + picsPath + bgPictures[1] + '")');
		}	
		
	});
	
	bgPic1 = $('#bg1');
	bgPic2 = $('#bg2');

	bgPic1.toggle();

	if (screen.width > 800) {
		timer = window.setInterval(picChange, 10000);
		$('.om-fixed-regalies').tooltip({
			delay: { show: 100, hide: 1500 },
			template: '<div class="tooltip" role="tooltip"><div class="tooltip-arrow"></div><h1><a href="/okmuay/trainings" class="tooltip-inner om-big-text "></a></h1></div>'
			});
	}

	$('.om-cover').click(function() {
		$('.om-cover').toggle();
	});

	$(".img-thumbnail").click(function () {
		photoClick(this);
	});

});
