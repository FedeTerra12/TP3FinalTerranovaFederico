<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuLogin.aspx.cs" Inherits="WebApp.MenuLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
        .validacion {
            color: red;
            font-size: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <style>
        .CorregirImagen {
            width: 300px;
            height: 300px;
            object-fit: contain;
        }
    </style>
    <div class="row">
        <div class="col-12">
            <h2>Mi Perfil</h2>
            <div class="row">
                <div class="col-md-4">
                    <div class="mb-3">
                        <label class="form-label">Email</label>
                        <asp:TextBox ReadOnly="true" runat="server" CssClass="form-control" ID="txtEmail" />
                    </div>
                    <br />
                    <div class="mb-3">
                        <label class="form-label">Nombre</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                        <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El nombre es requerido" ControlToValidate="txtNombre" runat="server" />
                        <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="Solo se admiten letras" ControlToValidate="txtNombre" ValidationExpression="^[a-zA-Z]+$" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Apellido</label>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" MaxLength="20">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator  CssClass="validacion" ErrorMessage="El apellido es requerido" ControlToValidate="txtApellido" runat="server" />
                        <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="Solo se admiten letras" ControlToValidate="txtApellido" ValidationExpression="^[a-zA-Z]+$" runat="server" />
                    </div>
                </div>
                        <%--<asp:RangeValidator ErrorMessage="Fuera de rango.." ControlToValidate="txtApellido" Type="Integer" MinimumValue="1" MaximumValue="20" runat="server" />--%>
                        <%--<asp:RegularExpressionValidator ErrorMessage="Formato email por favor" ControlToValidate="txtApellido" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />--%>

                        <%--<asp:RegularExpressionValidator ErrorMessage="Formato incorrecto..." ControlToValidate="txtApellido" ValidationExpression="^[0-9]+$" runat="server"/>--%>


                <div class="col-md-4">
                    <div class="mb-3">
                        <label class="form-label">Imagen Perfil</label>
                        <input type="file" id="txtImagen" runat="server" class="form-control" />
                    </div>
                   
                    <asp:Image ID="imgNuevoPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                        runat="server" CssClass="img-fluid mb-3 CorregirImagen" />

                </div>

            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Button Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" ID="btnGuardar" runat="server" />
                    <a href="/">Regresar</a>
                </div>
            </div>
            <hr />
        </div>


    </div>
</asp:Content>
