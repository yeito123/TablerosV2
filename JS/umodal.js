 
 

jQuery(function ($) {
    var umodal = {
        container: null,
        init: function () {
            $("input.umodal").click(function (e) {
                //				e.preventDefault();	

                $("#umodal-modal-content").modal({
                    overlayId: 'umodal-overlay',
                    containerId: 'umodal-container',
                    closeHTML: null,
                    minHeight: 80,
                    opacity: 65, 
                    position: ['0',],
                    overlayClose: true,
                    onOpen: umodal.open,
                    onClose: umodal.close,
                    zIndex:19999
                     
                
                });
            });
        },
        open: function (d) {
            var self = this;
            self.container = d.container[0];
            d.overlay.fadeIn('fast', function () {
                $("#umodal-modal-content", self.container).show();
                var title = $("#umodal-modal-title", self.container);
                title.show();
                d.container.slideDown('fast', function () {
                    setTimeout(function () {
                        var h = $("#umodal-modal-data", self.container).height()
							+ title.height()
							+ 20; 
                        d.container.animate(
							{height: h}, 
							200,
							function () {
							    $("div.close", self.container).show();
							    $("#umodal-modal-data", self.container).show();
							}
						);
                    }, 300);
                });
            })
        },
        close: function (d) {
            var self = this;  
            d.container.animate(
				{top:"-" + (d.container.height() + 20)},
				500,
				function () {
				    self.close(); 
				}
			);
        }
    };
    umodal.init();
});



jQuery(function ($) {
    var umodal2 = {
        container: null,
        init: function () {
            $("input.umodal2").click(function (e) {
               				e.preventDefault();	

                $("#umodal2-modal-content").modal({
                    overlayId: 'umodal2-overlay',
                    containerId: 'umodal2-container',
                    closeHTML: null,
                    minHeight: 80,
                    opacity: 65,
                    position: ['0', ],
                    overlayClose: true,
                    onOpen: umodal2.open,
                    onClose: umodal2.close,
                    zIndex: 19999


                });
            });
        },
        open: function (d) {
            var self = this;
            self.container = d.container[0];
            d.overlay.fadeIn('fast', function () {
                $("#umodal2-modal-content", self.container).show();
                var title = $("#umodal2-modal-title", self.container);
                title.show();
                d.container.slideDown('fast', function () {
                    setTimeout(function () {
                        var h = $("#umodal2-modal-data", self.container).height()
							+ title.height()
							+ 20;  
                        d.container.animate(
							{ height: h },
							200,
							function () {
							    $("div.close", self.container).show();
							    $("#umodal2-modal-data", self.container).show();
							    
							    //$("#umodal2-overlay").appendTo('form');
							    $("#umodal2-container").appendTo('form');
							}
						);
                    }, 300);
                });
            })
        },
        close: function (d) {
           // d.preventDefault();
            
            var self = this;  
            d.container.animate(
				{ top: "-" + (d.container.height() + 20) },
				500,
				function () {
				    self.close(); 
				}
			);
        }
    };
    umodal2.init();
   
});
 


function mostrarTooltip(elemento, mensaje) {
   
    if (document.getElementById(elemento.id + "tp")) {
        // Dimensiones del elemento al que se quiere añadir el tooltip
        anchoElemento = $('#' + elemento.id).width();
        altoElemento = $('#' + elemento.id).height();

        // Coordenadas del elemento al que se quiere añadir el tooltip
        coordenadaXElemento = $('#' + elemento.id).position().left;
        coordenadaYElemento = $('#' + elemento.id).position().top;

        // Coordenadas en las que se colocara el tooltip
        x = coordenadaXElemento + anchoElemento / 2 ;
        y = coordenadaYElemento + altoElemento / 2 + 15;

        // Crea el tooltip con sus atributos
        var tooltip = document.getElementById(elemento.id + "tp");
       
        tooltip.style.left = x + "px";
        tooltip.style.top = y + "px";
        tooltip.style.width =   "300px";

    }
    if (!document.getElementById(elemento.id + "tp")) {

        // Dimensiones del elemento al que se quiere añadir el tooltip
        anchoElemento = $('#' + elemento.id).width();
        altoElemento = $('#' + elemento.id).height();

        // Coordenadas del elemento al que se quiere añadir el tooltip
        coordenadaXElemento = $('#' + elemento.id).position().left;
        coordenadaYElemento = $('#' + elemento.id).position().top;

        // Coordenadas en las que se colocara el tooltip
        x = coordenadaXElemento + anchoElemento / 2;
        y = coordenadaYElemento + altoElemento / 2 + 15;
        // Crea el tooltip con sus atributos
        var tooltip = document.createElement('div');
        tooltip.id = elemento.id + "tp";
        tooltip.className = 'toolTipA';
        tooltip.innerHTML =  mensaje  ;
        tooltip.style.left = x + "px";
        tooltip.style.top = y + "px";
        tooltip.style.width = "300px";
        // Añade el tooltip
        document.body.appendChild(tooltip);
    }
    

    // Cambia la opacidad del tooltip y lo muestra o lo oculta (Si el raton esta encima del elemento se muestra el tooltip y sino se oculta)
    $('#' + elemento.id).hover(
        function () {
            try {

              
                                tooltip.style.display = "block";
                           
               // tooltip.style.display = "block";
                $('#' + tooltip.id).animate({ "opacity": .86 });
                $('#' + tooltip.id).animate({ "zIndex": 9999 });
            }
            catch (e) { }
        },
        function () {
            try {

                $('#' + tooltip.id).animate({ "opacity": .86 });
                $('#' + tooltip.id).animate({ "zIndex": 9999 });
                tooltip.style.display = "none";


            }
            catch (e) { }

        }
    );
}
 