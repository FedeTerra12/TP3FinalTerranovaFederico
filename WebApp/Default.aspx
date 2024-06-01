<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        .CorregirImagen {
            width: 200px;
            height: 200px;
            object-fit: contain;
        }

        .card {
            border: 1px solid black;
           
        }
   
    </style>


    <h1>Bienvenidos a mi Home</h1>

    <div class="row row-cols-1 row-cols-md-4 g-4 text-decoration-none">
        <%foreach (Dominios.Articulos art in ListaArticulos)
            { %>

        <div class="col">
            <a href="DetalleArticulo.Aspx?id=<%: art.Id  %>" class="card-link text-decoration-none">
                <div class="card text-center d-flex align-items-center justify-content-center">
                    <img src="<%:art.ImagenUrl %>" class="card-img-top img-fluid CorregirImagen" alt="Roto">
                    <div class="card-body">
                        <h5 class="card-title"><%:art.Nombre %></h5>
                        <p class="card-text"><b><%:string.Format("{0:C0}",art.Precio) %> </b></p>

                    </div>
                </div>
            </a>
        </div>
        <% } %>
    </div>

    
</asp:Content>
