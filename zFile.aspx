<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="zFile.aspx.vb" Inherits="TablerosV2.zFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" src="JS/jquery-1.9.1.js"></script>
   
    <script>
        

        $(function () {
            $("#image").click(function (e) {
                //var offset = $(this).offset();
                //var relativeX = (e.pageX - offset.left);
                //var relativeY = (e.pageY - offset.top);

                var hoffset = $(this).offset();
                var hoffsettop = hoffset.top
                var hoffsetleft = hoffset.left
                var hleft = e.clientX - hoffsetleft;
                var htop = e.clientY - hoffsettop;
                
                
                $('#htop').val(Math.round(htop));
                $('#hleft').val(Math.round(hleft));
                $('#hoffsettop').val(Math.round(hoffsettop));
                $('#hoffsetleft').val(Math.round(hoffsetleft));
               // alert(htop);
                //alert(relativeX + ':' + relativeY);
                //$(".position").val("afaf");

                
            });
        });
         
        popFileSelector = function () {
            var el = document.getElementById("utxtArchivo");
            if (el) {
                el.click();
            }
        };

      
          
         
        window.popRightAway = function () {
          //  document.getElementById('log').innerHTML += 'I am right away!<br />';
            popFileSelector();
        };

        function handleFiles(files) {
            for (var i = 0; i < files.length; i++) {
                var file = files[i];
                var imageType = /image.*/;

                if (!file.type.match(imageType)) {
                    continue;
                }

                var img = document.createElement("img");
                img.classList.add("obj");
                img.file = file;
                //preview.appendChild(img);

                var reader = new FileReader();
                reader.onload = (function (aImg) { return function (e) { aImg.src = e.target.result; }; })(img);
                reader.readAsDataURL(file);
            }
        }
    </script>
    <style>
        html {height:600px;
              width:1000px;
}
body {height:600px;
      width:1000px;
}

.campos { display:none;
}
        .upfile {
             border-top: #191970 thin solid;
                                font-weight: lighter; font-size: 12px; width: 412px; color: #1E2024; border-bottom: #191970 thin solid;
                                font-style: normal; font-family: Arial; height: 21px; background-color: white;
                                font-variant: normal; border-top-color: #1E2024; border-bottom-color: #1E2024; 
                                display:none;
        }
        .cmdfile {
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <img  id="image" src="img/CAMIONETAS.PNG"  onclick="popRightAway()"  />
        <input type="text" id="htop" runat="server" class="campos" />
        <input type="text" id="hleft" runat="server" class="campos"/>
        <input type="text" id="hoffsettop" runat="server" class="campos"/>
        <input type="text" id="hoffsetleft" runat="server" class="campos"/>
         <input type="hidden" id="txtNoorden" runat="server" class="campos"/>
          <input id="utxtArchivo" runat="server" name="utxtArchivo" size="40"  class="upfile" multiple accept="image/*"  type="file" onchange="handleFiles(this.files)" />
        <asp:Button id="ucmdCargar" runat="server"  
                                Text="Cargar Imagen"  OnClick="ucmdCargar_Click"  /> 

          <asp:Button id="cmdActualizar" runat="server"  
                                Text="Refrescar"     /> 

                           
                            
    </div>
    </form>
</body>
</html>
