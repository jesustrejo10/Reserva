<%@ Page Title="" Language="C#" MasterPageFile="~/view/RESFOM07/RESFOM7.Master" AutoEventWireup="true" CodeBehind="guardar-habitacion.aspx.cs" Inherits="frontoffice.view.RESFOM07.guardar_habitacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Estilos" runat="server">
    <link href="css/global.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
        <div class="col-xs-8">
            <h2 class="color-azul">Habitacion : H5-030A</h2>
        </div>
        <div class="col-xs-4">
            <a href="listar-habitaciones.aspx" class="btn btn-default pull-right">Cancelar</a>
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
            <h3 class="color-gris-oscuro">Datos de Habitación</h3>
            <hr />
            <form class="validate" action="#" method="post" enctype="multipart/form-data" data-success="Sent! Thank you!" data-toastr-position="top-right">
                <fieldset>
                    <!-- required [php action request] -->
                    <input type="hidden" name="action" value="contact_send" />
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-6 col-sm-6">
                                <label>Tipo de Habitacion *</label>
                                <select name="contact[position]" class="form-control pointer required">
                                    <option value="0">Penthouse</option>
                                    <option value="1">5 Estrellas</option>
                                    <option value="2">3 Estrellas</option>
                                </select>
                            </div>
                            <div class="col-md-6 col-sm-6">
                                <label>Descuento *</label>
                                <select name="contact[position]" class="form-control pointer required">
                                    <option value="0">Ninguno</option>
                                    <option value="1">10%</option>
                                    <option value="2">20%</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-6 col-sm-6">
                                <label>Piso *</label>
                                <input type="text" value="5" min="1" max="1000" class="form-control stepper">
                            </div>
                            <div class="col-md-6 col-sm-6">
                                <label>Codigo*</label>
                                <input type="text" name="contact[first_name]" value="" class="form-control required">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-12 col-sm-12">
                                <label>Caracteristicas Propias *</label>
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

