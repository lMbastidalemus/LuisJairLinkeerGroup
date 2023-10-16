
$(document).ready(function () {
    GetAll();
    EntidadFederativaGetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:58538/api/empleado/',

        success: function (result) {
            $('#tblEmpleados tbody').empty();
            $.each(result.Objects, function (i, subcategoria) {
                var filas =
                    '<tr>'
                    + '<td class="text-center"> '
                    + '<a href="#" onclick="GetById(' + subCategoria.IdSubCategoria + ')">'
                    + '</a> '
                    + '</td>'

                    + "<td  id='id' class='text-center'>" + subCategoria.IdSubCategoria + "</td>"
                    + "<td class='text-center'>" + subCategoria.NombreNomina + "</td>"
                    + "<td class='text-center'>" + subCategoria.Nombre + "</ td>"
                    + "<td class='text-center'>" + subCategoria.ApellidoPaterno + "</td>"
                    + "<td class='text-center'>" + subCategoria.ApellidoMaterno + "</td>"
                    + "<td class='text-center'>" + subCategoria.Estado.Nombre + "</td>"

                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + subCategoria.IdSubCategoria + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#tblEmpleados tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};