$(function() {
	// Initialize the slider
	var runTime = 500;
	var slider = new Lectric();
	slider.init('#slider', {next: '.next', previous: '.previous', animateDuration : runTime });
	
	var numItems = $("#scrubber a.item").length;
	var percentageMargin = parseInt((850/numItems) - 13);
	$("#scrubber a.item").css("margin-right", percentageMargin+"px");
	
	var totalWidth = 0;
	jQuery.each($("#scrubber a.item"),function(idx,val){
		totalWidth += parseInt($(val).css("margin-right")) + parseInt($(val).css("width"));
	});
	$("#scrubber").css("width", totalWidth+"px");
	$("#scrubber").css("margin", "0px auto");
	
	
	var stcPointer = 9;
	var count = 0;
	$("#scrubber a.item").click(function(event){
		count = $(this).attr("title");
		var bgPos = event.target.offsetLeft - stcPointer;
		$("#scrubmover").animate({
			"left" : bgPos+"px"
		}, runTime,"linear");
		slider.to(count);
		clearIt();
	});
	
	
	var timer = setInterval(function() {
	  count = (count < slider.itemCount() - 1) ? count+1 : 0;
	  var itemsPos = $("#scrubber a.item")[count].offsetLeft;
	  var bgPos = itemsPos - stcPointer;
		$("#scrubmover").animate({
			"left" : bgPos+"px"
		}, runTime,"linear");
	  slider.to(count);
	}, 5000);
	
	// Clear the interval if we touch the slider for the first time
	// or tap one the next or previous buttons
	var clearIt = function(s, e) {
	  clearInterval(timer);
	  slider.unsubscribe(e.type, e.handler); 
	};
	slider.subscribe('start', clearIt);
	
	// Keyboard shortcuts for left and right arrows
	$(document).keydown(function(e) {
	  if (e.keyCode === 39) { 
		e.preventDefault();
		var previous = slider.page();
		slider.to(previous + 1);
	  } else if (e.keyCode === 37) { 
		e.preventDefault();
		var previous = slider.page();
		slider.to(previous - 1);
	  }
	});
  });