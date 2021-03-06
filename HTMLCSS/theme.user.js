// ==UserScript==
// @name          夜のニコニココミュニティ掲示板
// @namespace     http://userstyles.org
// @description	  ニコニコ動画コミュニティ掲示板のページを目に優しくしました。
// @author        naganaga
// @homepage      https://userstyles.org/styles/161219
// @include       http://com.nicovideo.jp/bbs/*
// @include       http://dic.nicovideo.jp/*
// @include       http://com.nicovideo.jp//bbs/*
// @run-at        document-start
// @version       0.20180611102732
// ==/UserScript==
(function() {var css = [
	"/*ページ全体*/",
	"html * {",
	"	color:#EEEEEE;",
	"	border-color:#141D26 !important;",
	"	border-width:0 !important;",
	"	}",
	"/*検索欄,少窓ヘッダー*/",
	".area-pcSiteHeader,",
	".cp-tablespSiteHeader,",
	"#searchForm_sp_area,",
	".submitButton{ ",
	"	background:#494949 !important;",
	"	}",
	"/*コミュニティナビ*/",
	".area-communityNavigation{",
	"	background:#1B2836 !important;",
	"	}",
	".area-communityNavigation a{",
	"	color:#3B94BA !important;",
	"	}",
	"/*ナビ右端グラデーション消し*/",
	".area-communityNavigation::after{",
	"	display: none !important;",
	"	}",
	".forSpHeader,/*ページ全体背景*/",
	".area-communityHeader,/*コミュニティ名欄*/",
	".md-globalNav_sp,/*少窓ハンバーガーメニュー*/",
	".area-communityBbs,.cp-communityBbs,#community-bbs,.community-bbs/*掲示板レス欄*/{",
	"	background:#141D26 !important;",
	"	color:#bbb !important;",
	"	}",
	"/*掲示板レス文字*/",
	".community-bbs a {",
	"	background:#141D26 !important;",
	"	color: #3B94BA !important;",
	"	}",
	".community-bbs dl a{",
	"	color:#CCCCCC !important;",
	"	}",
	".area-communityFooter{",
	"	background:#676767 !important;",
	"	}",
	"/*フォーム欄*/",
	"html select,",
	"html textarea,",
	".textArea,#res_from,#oekaki_width,#oekaki_height{",
	"    background:#555555 !important;",
	"	color: #DDDDDD !important;",
	"    border: 1px solid #5c5a46 !important;",
	"    border-top-color: #474531 !important;",
	"    border-bottom-color: #474531 !important;",
	"	}",
	"/*書き込む/お絵カキコボタン*/",
	"input[type=submit],",
	"input[type=button]{",
	"	background: #896720;",
	"	}",
	"/*フッター*/",
	".copyright_wrap{",
	"	background:#434343 !important;",
	"	}",
	"/*リンクホバー*/",
	"html a:hover,",
	"html a:hover * {",
	"    color:#cef !important;",
	"    background:#023 !important;",
	"	}",
	"/*アイコン画像*/",
	"html img[src],",
	"html input[type=image]{opacity:0.5}",
	"html img[src]:hover,",
	"html input[type=image]:hover {opacity:0.7}",
	"",
	"/*広告消去*/",
	"#community_pc_top,/*コミュニティ検索 右*/",
	".area-adTabletSiteHeader,/*小窓 上段 ヘッダー*/",
	"#dic_pc_community_300x250_south_left,/*投稿フォーム 下段 左*/",
	"#dic_pc_community_300x250_south_right,/*投稿フォーム 下段 右*/",
	"#dic_pc_community_728x90_north/*コミュニティナビ 上段*/",
	"{ display: none !important; }"
].join("\n");
if (typeof GM_addStyle != "undefined") {
	GM_addStyle(css);
} else if (typeof PRO_addStyle != "undefined") {
	PRO_addStyle(css);
} else if (typeof addStyle != "undefined") {
	addStyle(css);
} else {
	var node = document.createElement("style");
	node.type = "text/css";
	node.appendChild(document.createTextNode(css));
	var heads = document.getElementsByTagName("head");
	if (heads.length > 0) {
		heads[0].appendChild(node);
	} else {
		// no head yet, stick it whereever
		document.documentElement.appendChild(node);
	}
}
})();
