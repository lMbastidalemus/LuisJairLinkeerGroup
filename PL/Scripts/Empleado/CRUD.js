
$(document).ready(function () {
    GetAll();
    EntidadFederativaGetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:58538/api/empleado/',

        success: function (result)
        {
            $('#tblEmpleados tbody').empty();
            $.each(result.Objects, function (i, Empleado) {
                var filas =
                    '<tr>'
                    + '<td class="text-center"> '+'<a href="#" onclick="GetById(' + Empleado.IdEmpleado + ')">' + '</a> ' + '</td>'

                    + "<td  id='id' class='text-center'>" + Empleado.IdEmpleado + "</td>"
                    + "<td class='text-center'>" + Empleado.NombreNomina + "</td>"
                    + "<td class='text-center'>" + Empleado.Nombre + "</ td>"
                    + "<td class='text-center'>" + Empleado.ApellidoPaterno + "</td>"
                    + "<td class='text-center'>" + Empleado.ApellidoMaterno + "</td>"
                    + "<td class='text-center'>" + Empleado.Estado.Nombre + "</td>"

                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + Empleado.IdEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#tblEmpleados tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function EntidadFederativaGetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:58538/api/empleado/Entidad',
        success: function (result) {
            $("#ddlCategorias").append('<option value="' + 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.Objects, function (i, categoria) {
                $("#ddlCategorias").append('<option value="'
                    + categoria.IdCategoria + '">'
                    + categoria.Descripcion + '</option>');
            });
        }
    });
}