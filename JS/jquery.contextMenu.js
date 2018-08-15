 
if(jQuery)( function() {
	$.extend($.fn, {
		
		contextMenu: function(o, callback) {
			 
		    if (o.menu == undefined)   return false;  
			if( o.inSpeed == undefined ) o.inSpeed = 150;
			if( o.outSpeed == undefined ) o.outSpeed = 75;
			 
			if( o.inSpeed == 0 ) o.inSpeed = -1;
			if( o.outSpeed == 0 ) o.outSpeed = -1;
			 
			$(this).each( function() {
				var el = $(this);
				var offset = $(el).offset();
				 
				$('#' + o.menu).addClass('contextMenu');
				
				 
				$(this).mousedown(function (e) {
				    document.getElementById("dhMenu").value = document.getElementById("dhtml").value;
				    var evt = e;
				    if (evt.button == 2){
				        evt.stopPropagation();
                    }
					$(this).mouseup( function(e) {
						if (e.button == 2){
						    e.stopPropagation();
                        }
						var srcElement = $(this);
						$(this).unbind('mouseup');
						if( evt.button == 2 ) {
						  //  $(this).parent().addClass('cc100');
						     
							$(".contextMenu").hide();
							document.getElementById("mymenu").value = false;
							var menu = $('#' + o.menu);
							
							if( $(el).hasClass('disabled') ) return false;
							
							if (document.getElementById("dhtml").value.substr(0, 2) != 'ds' && document.getElementById("dhtml").value.substr(0, 2) != 'tx') return false;
							



							var d = {}, x, y;
							
							if( self.innerHeight ) {
								d.pageYOffset = self.pageYOffset;
								d.pageXOffset = self.pageXOffset;
								d.innerHeight = self.innerHeight;
								d.innerWidth = self.innerWidth;
							} else if( document.documentElement &&
								document.documentElement.clientHeight ) {
								d.pageYOffset = document.documentElement.scrollTop;
								d.pageXOffset = document.documentElement.scrollLeft;
								d.innerHeight = document.documentElement.clientHeight;
								d.innerWidth = document.documentElement.clientWidth;
							} else if( document.body ) {
								d.pageYOffset = document.body.scrollTop;
								d.pageXOffset = document.body.scrollLeft;
								d.innerHeight = document.body.clientHeight;
								d.innerWidth = document.body.clientWidth;
							}
							(e.pageX) ? x = (e.pageX - e.offsetX) : x = e.clientX + d.scrollLeft;
							(e.pageY) ? y = (e.pageY - e.offsetY ): y = e.clientY + d.scrollTop;
							
							 
							$(document).unbind('click');
							$(menu).css({ top: y , left: x }).fadeIn(o.inSpeed);
							 
							$(menu).find('A').mouseover( function() {
								$(menu).find('LI.hover').removeClass('hover');
								$(this).parent().addClass('hover');
								 
								$(".menu").css('zIndex', 0);
								document.getElementById("mymenu").value = true;

							}).mouseout( function() {
							    $(menu).find('LI.hover').removeClass('hover');
							    $(".menu").css('zIndex', 0);
							    document.getElementById("mymenu").value = false;
							   
							});
							//$(menu).css({ zindex: e.zindex + 1000 });
							 
//							$(document).keypress( function(e) {
//								switch( e.keyCode ) {
//									case 38:  
//										if( $(menu).find('LI.hover').size() == 0 ) {
//											$(menu).find('LI:last').addClass('hover');
//										} else {
//											$(menu).find('LI.hover').removeClass('hover').prevAll('LI:not(.disabled)').eq(0).addClass('hover');
//											if( $(menu).find('LI.hover').size() == 0 ) $(menu).find('LI:last').addClass('hover');
//										}
//									break;
//									case 40:  
//										if( $(menu).find('LI.hover').size() == 0 ) {
//											$(menu).find('LI:first').addClass('hover');
//										} else {
//											$(menu).find('LI.hover').removeClass('hover').nextAll('LI:not(.disabled)').eq(0).addClass('hover');
//											if( $(menu).find('LI.hover').size() == 0 ) $(menu).find('LI:first').addClass('hover');
//										}
//									break;
//									case 13:  
//										$(menu).find('LI.hover A').trigger('click');
//									break;
//									case 27:  
//										$(document).trigger('click');
//									break
//								}
//							});
//							
							 
							$('#' + o.menu).find('A').unbind('click');
							$('#' + o.menu).find('LI:not(.disabled) A').click( function() {
								$(document).unbind('click').unbind('keypress');
								$(".contextMenu").hide();
								//document.getElementById("mymenu").value = false;
								if( callback ) callback( $(this).attr('href').substr(1), $(srcElement), {x: x - offset.left, y: y - offset.top, docX: x, docY: y} );
								return false;
							});
							
							 
							setTimeout( function() {  
								$(document).click( function() {
									$(document).unbind('click').unbind('keypress');
									$(menu).fadeOut(o.outSpeed);
									return false;
								});
							}, 0);
						}
					});
				});
				
 
				$(el).add($('UL.contextMenu')).bind('contextmenu', function() { return false; });
				
			});
			return $(this);
		},
		
	 		 
		
		 
		destroyContextMenu: function() {
		 
			$(this).each( function() {
			  
			    $(this).unbind('mousedown').unbind('mouseup');
			    
			});
			return( $(this) );
		}
		
	});
})(jQuery);