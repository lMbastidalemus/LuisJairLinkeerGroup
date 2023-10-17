
$(document).ready(function () {
    GetAll();
    EntidadFederativaGetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:58538/api/empleado',

        success: function (result)
        {
            $('#tblEmpleados tbody').empty();
            $.each(result.Objects, function (i, Empleado) {
                var filas =
                    '<tr>'
                    //+ '<td class="text-center"> '+'<a href="#" onclick="GetById(' + Empleado.IdEmpleado + ')">' + '</a> ' + '</td>'
                    + '<td class="text-center">' +'<button class="btn glyphicon glyphicon-pencil"  onclick = "GetbyId(' + Empleado.IdEmpleado + ')" >Actualizar</button ></td>'
                    //+ "<td  id='id' class='text-center'>" + Empleado.IdEmpleado + "</td>"

                    + "<td class='text-center'>" + Empleado.NombreNomina + "</td>"
                    + "<td class='text-center'>" + Empleado.Nombre + "</ td>"
                    + "<td class='text-center'>" + Empleado.ApellidoPaterno + "</td>"
                    + "<td class='text-center'>" + Empleado.ApellidoMaterno + "</td>"
                    + "<td class='text-center'>" + Empleado.Entidad.Estado + "</td>"

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
            $("#ddlEstados").append('<option value="' + 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.Objects, function (i, Entidad) {
                $("#ddlEstados").append('<option value="'
                    + Entidad.IdEstado + '">'
                    + Entidad.Estado + '</option>');
            });
        }
    });
};

function Add() {

    var Empleado = {
        IdEmpleado: 0,
        NombreNomina: $('#txtNombreNomina'),
        Nombre: $('#txtNombre').val(),
        ApellldoPaterno: $('#txtApellidoPaterno').val(),
        ApellldoMaterno: $('#txtApellidoMaterno').val(),
        Categoria: {
            IdCategoria: $('#ddlEntidad').val()
        }
    }

    $.ajax({
        type: 'POST',
        url: 'http://localhost:14982/api/SubCategoria/Add',
        dataType: 'json',
        data: subcategoria,
        success: function (result) {
            $('#myModal').modal();
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function GetById() {
    $.ajax({
        type: "GET",
        url: 'http://localhost:58538/api/empleado/' + IdEmpleado,
        success: function (result) {
            $('txtIdEmpleado').val(result.Object.IdEmpleado)
            $('txtNombreNomina').val(result.Object.NombreNomina);
            $('txtNombre').val(result.Object.Nombre);
            $('txtApellidoPaterno').val(result.Object.ApellidoPaterno);
            $('txtApellidoMaterno').val(result.Object.ApellidoMaterno);
            $('txtIdEstado').val(result.Object.IdEstado);

            $('ModalUpdate').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    })
};


function Update() {
    var Empleado = {
        IdEmpleado: 0,
        NombreNomina: $('#txtNombreNomina'),
        Nombre: $('#txtNombre').val(),
        ApellldoPaterno: $('#txtApellidoPaterno').val(),
        ApellldoMaterno: $('#txtApellidoMaterno').val(),
        Categoria: {
            IdCategoria: $('#ddlEntidad').val()
        }
    }

    $.ajax({
        type: 'POST',
        url: 'http://localhost:58538/api/empleado',
        datatype: 'json',
        data: subcategoria,
        success: function (result) {
            $('#myModal').modal();
            $('#Modal').modal('show');
            GetAll();
            Console(respond);
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function Delete() {
    if (confirm("Estas seguro de eliminar el usuario? ")) {
        $.ajax({
            type: 'DELETE',
            url: 'http://localhost:58538/api/empleado/' + IdEmpleado,
            success: function (result) {
                $('#myModal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });
    };
};
