$(".getRow").click(function (e) {
    e.preventDefault();
    $(".lineaId").val(($(this).attr('getLineaId')));
    $(".reqId").val(($(this).attr('getReqId')));
    $(".linea").val(($(this).attr('getLinea')));
    $(".parteId").val(($(this).attr('getParteId')));
    $(".cantidad").val(($(this).attr('getCantidad')));
    $(".precioVenta").val(($(this).attr('getPrecioVenta')));
    $(".descripcion").val(($(this).attr('getDescripcion')));
    $(".creadoPor").val(($(this).attr('getCreadoPor')));
    $(".creado").val(($(this).attr('getCreado')));
    $(".actualizadoPor").val(($(this).attr('getActualizadoPor')));
    $(".actualizado").val(($(this).attr('getActualizado')));
});