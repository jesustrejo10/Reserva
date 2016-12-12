<%@ Page Title="" Language="C#" MasterPageFile="~/view/RESFOM07/RESFOM7.Master" AutoEventWireup="true" CodeBehind="detalle-habitacion.aspx.cs" Inherits="frontoffice.view.RESFOM07.detalle_habitacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Estilos" runat="server">
    <link href="css/global.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
        <div class="col-xs-8">
            <h2 class="color-azul">Habitacion : H5-030A</h2>
        </div>
        <div class="col-xs-4">
            <button type="button" class="btn btn-danger pull-right" data-toggle="modal" data-target=".bs-example-modal-sm">Eliminar</button>
            <a href="guardar-habitacion.aspx" class="btn btn-info pull-right">Modificar</a>
            <a href="listar-habitaciones.aspx" class="btn btn-default pull-right">Regresar</a>
        </div>
    </div>
    <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">

                <!-- header modal -->
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="mySmallModalLabel">¿Esta seguro que desea guardar los cambios?</h4>
                </div>

                <!-- body modal -->
                <div class="modal-body">
                    <div class="row">
                        <div class="col-xs-12 centrado">
                            <button type="button" class="btn btn-success">Seguro</button>
                            <button type="button" class="btn btn-default" data-toggle="modal" data-target=".bs-example-modal-sm">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-10 col-xs-offset-1">
            <h3 class="color-gris-oscuro">Datos de Habitación</h3>
            <hr />

            <div class="row">
                <div class="form-group">
                    <div class="col-md-6 col-sm-6">
                        <label>Tipo de Habitacion *</label>
                        <p>Lorem ipsum dolor sit amet</p>
                    </div>
                    <div class="col-md-6 col-sm-6">
                        <label>Descuento *</label>
                        <p>No Tiene</p>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <div class="col-md-6 col-sm-6">
                        <label>Piso *</label>
                        <p>5</p>
                    </div>
                    <div class="col-md-6 col-sm-6">
                        <label>Codigo*</label>
                        <p>H5-030A</p>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <div class="col-md-12 col-sm-12">
                        <label>Caracteristicas Propias *</label>
                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec faucibus sem non nisl convallis, quis porttitor risus congue. Donec semper eget purus eget congue. Nulla feugiat, purus nec tempor luctus, mi nisl condimentum ipsum, quis finibus urna orci nec risus. Maecenas sed justo finibus, posuere nibh vel, eleifend nulla. Aenean dapibus blandit rutrum. Nunc laoreet eros justo, nec egestas erat imperdiet id. Nullam in quam porttitor urna volutpat finibus et vitae magna. Curabitur interdum nisl non suscipit faucibus. Proin vulputate, augue non scelerisque feugiat, urna tellus pharetra nisl, a pharetra nulla arcu sed magna. Vivamus molestie augue in lobortis venenatis. Sed ut nulla sit amet mi ultrices varius. Aliquam nec vehicula erat. Vivamus consectetur ante ipsum, a tincidunt magna porttitor et.
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Codigo" runat="server">
    <!-- JS DATATABLES -->

</asp:Content>

