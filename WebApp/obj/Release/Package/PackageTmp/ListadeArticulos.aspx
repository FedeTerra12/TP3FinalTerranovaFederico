<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadeArticulos.aspx.cs" Inherits="WebApp.ListadeArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Listado de Articulos en Venta</h1>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
  <div class="row">

        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox CssClass="form-control" ID="txtfiltro" OnTextChanged="txtfiltro_TextChanged" AutoPostBack ="true" runat="server"/>

            </div>
        </div>

    <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
        <div class="mb-3">
            <asp:CheckBox Text="FiltroAvanzado" ID="chkAvanzado" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" runat="server" />
        </div>
    </div>

          <%if(chkAvanzado.Checked) {%>

    <div class="row">
        <div class="mb-3">
            <asp:Label Text="Campo" ID="LabelCampo" runat="server"  />
            <asp:DropDownList runat="server" ID="ddlCampo" AutoPostBack="true"  OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged"   >
                <asp:ListItem Text="Precio" />
                <asp:ListItem Text="Marca" />
                <asp:ListItem Text="Categoria" />
            </asp:DropDownList>
        </div>
    </div> 

    <div class="col-3">
        <div class="mb-3">
            <asp:Label Text="Criterio" ID="LabelCriterio" runat="server" />
            <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
            </asp:DropDownList>
        </div>
    </div>
    <div class="col-3">
        <div class="mb-3">
            <asp:Label Text="Filtro" runat="server" />
            <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
        </div>
    </div>

    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
            </div>
        </div>
    </div>
    <%} %>

    </div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <asp:GridView ID="dgvArticulos" CssClass="table" AutoGenerateColumns="false" AllowPaging="false" PageSize="5" DataKeyNames="Id"
                OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" OnPageIndexChanging="dgvArticulos_PageIndexChanging" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✏️​" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>

    <a href="FormularioArticulos.aspx">Añadir Articulo</a>
</asp:Content>
