<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Sem4.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Semana 4-CRUD-EntityFramework</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>
    <style>
        .liga{
            border: 1px solid blue;
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="row" style="margin-top:30px;">
            <div class="col-md-6 liga">
                <form id="form1" runat="server">
                    <div class="form-group">

                        <div class="form-group">
                            <asp:Label Text="Identifiacion:" runat="server" /> 
                            <asp:TextBox class="form-control" runat="server" id="txtIdentifiacion" />
                        </div>
                        <div class="form-group">
                            <asp:Label Text="Nombre:" runat="server" /> 
                            <asp:TextBox class="form-control" runat="server" id="txtNomPersona" />
                        </div>
                        <div class="form-group">
                            <asp:Label Text="Primer apellido:" runat="server" /> 
                            <asp:TextBox class="form-control" runat="server" id="txtApe1Persona" />
                        </div>
                        <div class="form-group">
                            <asp:Label Text="Segundo apellido:" runat="server" /> 
                            <asp:TextBox class="form-control" runat="server" id="txtApe2Persona" />
                        </div>
                        <asp:Button class="btn btn-primary" Text="Nuevo" ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" />
                        <asp:Button class="btn btn-primary" Text="Actualizar" ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" />
                        <asp:Button class="btn btn-primary" Text="Eliminar" ID="btnEliminar" runat="server" OnClick="btnEliminar_Click"  />
                        <asp:Button class="btn btn-primary" Text="Consultar" ID="btnConsultar" runat="server" OnClick="btnConsultar_Click"   />
                    </div>
                </form>
            </div>
                
            <div class="col-md-6 liga">
                <div class "row" style="border:1px solid red; text-align=center">
                    <div class="col-md-3"style="border:1px solid red;">
                        <asp:Label Text="Identificación: " runat="server" /> 
                        <asp:Label Text="-" runat="server" id="lblIdResul"/> 

                    </div>
                    <div class="col-md-3"style="border:1px solid red;">
                        <asp:Label Text="Nombre: " runat="server" />
                        <asp:Label Text="-" runat="server" id="lblNomResul"/> 

                    </div>
                    <div class="col-md-3"style="border:1px solid red;">
                        <asp:Label Text="Apellido1: " runat="server" />
                        <asp:Label Text="-" runat="server" id="lblApe1Resul"/> 

                    </div>
                    <div class="col-md-3"style="border:1px solid red;">
                        <asp:Label Text="Apellido2: " runat="server" />
                        <asp:Label Text="-" runat="server" id="lblApe2Resul"/> 

                    </div>
                    
                </div>
            </div>

        </div>
    </div>

    
</body>
</html>
