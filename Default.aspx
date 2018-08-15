<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="TablerosV2._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
i {
  border: solid black;
  border-width: 0 3px 3px 0;
  display: inline-block;
  padding: 3px;
}

.right {
    transform: rotate(-45deg);
    -webkit-transform: rotate(-45deg);
}

.left {
    transform: rotate(135deg);
    -webkit-transform: rotate(135deg);
}

.up {
    transform: rotate(-135deg);
    -webkit-transform: rotate(-135deg);
}

.down {
    transform: rotate(45deg);
    -webkit-transform: rotate(45deg);
}
</style>
    
</head>
<body>
    <form id="form1" runat="server">
           <ajaxToolkit:ToolkitScriptManager runat="Server" ID="ScriptManager1" />
        <asp:Button ID="btnModal" runat="server" Text="Modal"  Style="display: none;" OnClick="ImgDetalle_Click" /> <%--para lo que queremos este es casi casi de adorno, sirve solo para ser Trget Control del modeal--%>
        <ajaxToolkit:ModalPopupExtender ID="modalDetalle"
            runat="server" Enabled="true"  OkControlID="okbutton"  TargetControlID="btnModal" 
             PopupControlID="mdlDetalle">
        </ajaxToolkit:ModalPopupExtender>

        <p>Right arrow: <i class="right"></i></p>
<p>Left arrow: <i class="left"></i></p>
<p>Up arrow: <i class="up"></i></p>
<p>Down arrow: <i class="down"></i></p>

        <asp:Panel ID="mdlDetalle" runat="server" CssClass="modal">
            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document">  
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" id="myModalLabel">Modal title</h4>
                        </div>
                        <div class="modal-body">
                            ...
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            <asp:Button runat="server" id="okbutton"   class="btn btn-primary" Text="Save changes"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>

        </asp:Panel>
    <div>
         <table>
                                    <tr>
                                        <td class="col-lg-2">
                                            <asp:ImageButton runat="server" class="close" ID="ImgDetalle" 
                                                ImageUrl="~/IMG/imgDetalle.png" OnClick="ImgDetalle_Click" Width="15px" Height="15px" />
                                        </td>
                                       
                                    </tr>
                                </table>
     
    </div>
    </form>
</body>
</html>
