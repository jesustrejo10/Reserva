<%@ Page Title="" Language="C#" MasterPageFile="~/view/RESFOM07/RESFOM7.Master" AutoEventWireup="true" CodeBehind="guardar-reserva.aspx.cs" Inherits="frontoffice.view.RESFOM07.guardar_reserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Estilos" runat="server">
    <link href="css/global.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
        <div class="col-xs-8">
            <h2 class="color-azul">Reserva : #000000000</h2>
        </div>
        <div class="col-xs-4">
            <a href="listar-reservas.aspx" class="btn btn-default pull-right">Cancelar</a>
            <button type="button" class="btn btn-success pull-right" data-toggle="modal" data-target=".bs-example-modal-sm">Guardar</button>
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
            <h3 class="color-gris-oscuro">Datos del Hotel</h3>
            <hr />
            ...
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
                    <div class="col-md-12 col-sm-12">
                        <label>Descripcion *</label>
                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec faucibus sem non nisl convallis, quis porttitor risus congue. Donec semper eget purus eget congue. Nulla feugiat, purus nec tempor luctus, mi nisl condimentum ipsum, quis finibus urna orci nec risus. Maecenas sed justo finibus, posuere nibh vel, eleifend nulla. Aenean dapibus blandit rutrum. Nunc laoreet eros justo, nec egestas erat imperdiet id. Nullam in quam porttitor urna volutpat finibus et vitae magna. Curabitur interdum nisl non suscipit faucibus. Proin vulputate, augue non scelerisque feugiat, urna tellus pharetra nisl, a pharetra nulla arcu sed magna. Vivamus molestie augue in lobortis venenatis. Sed ut nulla sit amet mi ultrices varius. Aliquam nec vehicula erat. Vivamus consectetur ante ipsum, a tincidunt magna porttitor et.
                        </p>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <div class="col-md-12 col-sm-12">
                        <label>Caracteristicas por Tipo de Habitacion *</label>
                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec faucibus sem non nisl convallis, quis porttitor risus congue. Donec semper eget purus eget congue. Nulla feugiat, purus nec tempor luctus, mi nisl condimentum ipsum, quis finibus urna orci nec risus. Maecenas sed justo finibus, posuere nibh vel, eleifend nulla. Aenean dapibus blandit rutrum. Nunc laoreet eros justo, nec egestas erat imperdiet id. Nullam in quam porttitor urna volutpat finibus et vitae magna. Curabitur interdum nisl non suscipit faucibus. Proin vulputate, augue non scelerisque feugiat, urna tellus pharetra nisl, a pharetra nulla arcu sed magna. Vivamus molestie augue in lobortis venenatis. Sed ut nulla sit amet mi ultrices varius. Aliquam nec vehicula erat. Vivamus consectetur ante ipsum, a tincidunt magna porttitor et.
                        </p>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <div class="col-md-6 col-sm-6">
                        <label>Codigo*</label>
                        <p>H5-030A</p>
                    </div>
                    <div class="col-md-6 col-sm-6">
                        <label>Piso *</label>
                        <p>5</p>
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
    <div class="row">
        <div class="col-xs-10 col-xs-offset-1">
            <h3 class="color-gris-oscuro">Datos de Reserva</h3>
            <hr />
            <form class="validate" action="#" method="post" enctype="multipart/form-data" data-success="Sent! Thank you!" data-toastr-position="top-right">
                <fieldset>
                    <!-- required [php action request] -->
                    <input type="hidden" name="action" value="contact_send" />
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-12 col-sm-12">
                                <label>Preferecia de Ubicación*</label>
                                <select name="contact[position]" class="form-control pointer required">
                                    <option value="0">Cualquiera</option>
                                    <option value="1">Piso más bajo</option>
                                    <option value="2">Piso más alto</option>
                                </select>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-6 col-sm-6">
                                <label>Fecha de Llegada *</label>
                                <input type="text" name="contact[start_date]" value="" class="form-control datepicker required" data-format="yyyy-mm-dd" data-lang="en" data-rtl="false">
                            </div>
                            <div class="col-md-6 col-sm-6">
                                <label>Fecha de Desalojo *</label>
                                <input type="text" name="contact[end_date]" value="" class="form-control datepicker required" data-format="yyyy-mm-dd" data-lang="en" data-rtl="false">
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-12 col-sm-12">
                                <label>Comentarios</label>
                                <textarea name="contact[experience]" rows="4" class="form-control required"></textarea>
                            </div>
                        </div>
                    </div>
                </fieldset>
            </form>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Codigo" runat="server">
    <!-- JS DATATABLES -->

</asp:Content>
