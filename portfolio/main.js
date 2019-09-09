var showFlag = false;
var NUM = 3;
$(function(){
	$('.item')
	.mouseover(function(){
		$(this).css({
			'opacity':'1.0'
		});
	})
	.mouseout(function(){
		$(this).css({
			'opacity':'0.8'
		});
	})
	.click(function(){
		var index = $('.item').index(this);
		/*既にSummaryが表示されてたらしまう*/
		for(var i=0;i<NUM;i++){	
			if($('.summaryLi').eq(i).children("div").css('display')=='block' && index!=i){
				$('.summaryLi').eq(i).children("div").slideToggle('slow');
			}
		}
		/*クリックされたSummaryを開く*/
		$('.summaryLi').eq(index).children("div").slideToggle('slow');
	})
	
});