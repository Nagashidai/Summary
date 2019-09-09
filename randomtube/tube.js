var API_KEY = 'AIzaSyA5JXGDNU7auSBopy0524dUVrmjMdH4iVI';
// var url = 'https://www.googleapis.com/youtube/v3/search?key=AIzaSyA5JXGDNU7auSBopy0524dUVrmjMdH4iVI&part=snippet&type=video&maxResults=50&order=date&q=動画&videoEmbeddable=true';
var url = 'https://www.googleapis.com/youtube/v3/search?key=AIzaSyA5JXGDNU7auSBopy0524dUVrmjMdH4iVI&part=id,snippet&type=video&maxResults=50&order=date&q=動画&videoEmbeddable=true';
var urlFirst = 'https://www.googleapis.com/youtube/v3/search?key=AIzaSyA5JXGDNU7auSBopy0524dUVrmjMdH4iVI&part=id,snippet&type=video&maxResults=50&order=date&videoEmbeddable=true';
var urlWordFirst = '&q=';
var urlWord = ['動画','映画','アニメ','自動車','乗り物','音楽','ペット','動物','スポーツ','ショートムービー',
'ゲーム','ブログ','コメディ','エンターテイメント','ニュース','政治','ハウツー','スタイル','教育','科学','技術','アクション',
'アドベンチャー','クラシック','ドキュメンタリ','ドラマ','家族','海外','ホラー','SF','ファンタジ','サスペンス','短編','番組',
'予告編','movie','流行り','飲み物','食べ物','大食い','やってみた','金'];
var idList = [];
var coverNum = [];
var coverFlag = false;
var firstFlag = true;
// var idNum = Math.floor( Math.random() * 50 );
var idNum=0;
coverNum[0] = idNum
var nextPageToken;
var done = false;
var rnd;
var rndWord = Math.floor( Math.random() * urlWord.length );
var setTime;

var tag = document.createElement('script');
tag.src = "https://www.youtube.com/iframe_api";
var firstScriptTag = document.getElementsByTagName('script')[0];
firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);
var player;
var stopButton=false;
var splitString = "https://www.googleapis.com/youtube/v3/search?key=AIzaSyA5JXGDNU7auSBopy0524dUVrmjMdH4iVI";
var nPTFirst = "&pageToken=";
var nPT;
var split = url.split(splitString);
var nPTURL = 'https://www.googleapis.com/youtube/v3/search?key=AIzaSyA5JXGDNU7auSBopy0524dUVrmjMdH4iVI&pageToken=CDIQAA&part=snippet&type=video&maxResults=50&order=date&q=動画';
var movieNum = 1;
idList[idNum] = 'M7lc1UVf-VE'; //初期値必要


url = urlFirst + urlWordFirst + urlWord[rndWord];
/*スクロール処理*/
$(function(){
   // #で始まるアンカーをクリックした場合に処理
   $('a[href^="#"]').click(function() {
      // スクロールの速度
      var speed = 500; // ミリ秒
      // アンカーの値取得
      var href= $(this).attr("href");
      // 移動先を取得
      var target = $(href == "#" || href == "" ? 'html' : href);
      // 移動先を数値で取得
      var position = target.offset().top;
      // スムーススクロール
      $('body,html').animate({scrollTop:position}, speed, 'swing');
      return false;
   });
});

/*ストップボタン処理*/
$(function(){
  $('.stopButton').click(function(){
    if(stopButton==false){ //ボタンをOFF→ONにしたとき
      $(this).css({
        'background-color': '#ED462F'
      });
      $('.stopMessage').css({
        'display':'block'
      });
      stopButton=true;
      clearTimeout(setTime);
      // console.log(stopButton);
    }else if(stopButton==true){ //ボタンをON→OFFにしたとき
      $(this).css({
        'background-color': 'white'
      });
      $('.stopMessage').css({
        'display':'none'
      });
      stopButton=false;
      clearTimeout(setTime);
      setTime = setTimeout((function(){
        // rnd = Math.floor( Math.random() * idList.length );
        // idNum= rnd ;  
        // idNum = stopCover();
        player.loadVideoById(idList[idNum]);
      }),10000);
      idNum++;
      movieNum++;
      // console.log(movieNum);
      // console.log(stopButton);
    } 
  });
});

/*リストのバー切り替え処理*/
var home = $('.playerBOX').offset().top;
$(window).scroll(function(){
  let scroll = $(this).scrollTop();
  if(scroll - home <260){
    $('.current').css({
      'border-bottom':'3px solid #92D050'
      /*border-bottom: 3px solid #92D050;*/
    });
    $('.current2').css({
      'border-bottom':''
    });
    $('.current3').css({
      'border-bottom':''
    });
  }else if(scroll - home >=260 && scroll - home <880){
    $('.current').css({
      'border-bottom':''
    });
    $('.current2').css({
      'border-bottom':'3px solid #92D050'
    });
    $('.current3').css({
      'border-bottom':''
    });
  }else if(scroll - home >=880){
    $('.current').css({
      'border-bottom':''
    });
    $('.current2').css({
      'border-bottom':''
    });
    $('.current3').css({
      'border-bottom':'3px solid #92D050'
    });
  }
})



function idGetMany(){
  // for(var z=0;z<2;z++){
  $.ajax({
      type: 'GET',
      url: nPTURL,
      async: false,
      dataType: 'json',
      success: function(data){
        for(var f=0;f<50;f++){
          if(f==0){
              rndWord = Math.floor( Math.random() * urlWord.length );
              nPTURL = urlFirst + nPTFirst + nextPageToken + urlWordFirst + urlWord[rndWord];
              // console.log("rndWordは",rndWord);
          }
            // idList.push(data["items"][f]["id"]["videoId"]);
            // idList[f+(f*z)] = data["items"][f+(f*z)]["id"]["videoId"];
            idList[f] = data["items"][f]["id"]["videoId"];
            // console.log(f),idList[f];  
          }
        }
    });
  // }
}


function FirstCall(){
  $.ajax({
      type: 'GET',
      url: url,
      async: false,
      dataType: 'json',
      success: function(data){
        for(var f=0;f<50;f++){
          idList[f] = data["items"][f]["id"]["videoId"];
          nextPageToken = data["nextPageToken"];  //次のページのトークンを設定
          // console.log(f,idList[f]);
        }
      }
  });
}

function stopCover(){
  while(true){
      rnd = Math.floor( Math.random() * idList.length );
      for(var c=0;c<coverNum.length;c++){
        if(coverNum[c]==rnd){
          // console.log("被っています",rnd);
          break;
        }
        if(c==coverNum.length-1){
          coverFlag=true;
        }
      }
      if(coverFlag==true){
        coverFlag=false;
        // console.log("完了",rnd);
        coverNum.push(rnd);
        return rnd;
      }
  }
}

function coverReset(){
  for(var r=0;r<coverNum.length;r++){
    coverNum[r]=0;
  }
}

/**** 　event.target == player       *****/

FirstCall();
// idGetMany();
function onYouTubeIframeAPIReady() {
  player = new YT.Player('player', {
  height: '480',
  width: '800',
  videoId: idList[idNum],
  events: {
    'onReady': onPlayerReady,
    'onStateChange': onPlayerStateChange,
    'onError': onPlayerError
  }
  });
}

function onPlayerReady(event) {
  event.target.playVideo();
}

function onPlayerStateChange(event) {
  /*if(firstFlag && Math.floor( Math.random() * 10 )<6){
    firstFlag=false;
    console.log("こっち開始");
    idGetMany();
  }*/
  /*10秒ごとに動画切り替え*/
  if(movieNum%45==0){
    // console.log("新取得開始");
    coverReset();
    idGetMany();
  }
  if (event.data == YT.PlayerState.PLAYING) {
    clearTimeout(setTime);
    setTime = setTimeout((function(){
      // rnd = Math.floor( Math.random() * idList.length );
      // idNum= rnd ;
      idNum = stopCover();  
      event.target.loadVideoById(idList[idNum]);
    }),10000);
    movieNum++;
    // console.log(movieNum);
    // console.log(rnd);
  }
  /*動画が終了したら次の動画に移動*/
  if(event.data==0){
    //idListの要素の何番目にいくかランダムで決定
    idNum = stopCover();  
    event.target.loadVideoById(idList[idNum]);
    movieNum++;
    // console.log(movieNum);
    //$("#results").append(idList.length);
    // console.log(rnd);
  }   
}

function onPlayerError(event){
    console.log("error: 次の動画を読み込みます");
    idNum = stopCover();
    event.target.loadVideoById(idList[idNum]);
    movieNum++;
    // console.log(movieNum);
}

function stopVideo() {
  player.stopVideo();
}