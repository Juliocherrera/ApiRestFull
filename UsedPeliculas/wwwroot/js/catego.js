var dataTable;

$(document).ready(function () {
    loadDataTable();
    Verjs();
});

function loadDataTable() {
    dataTable = $("#tblCategorias").DataTable({
        "ajax": {
            "url": "/Categos/GetTodasCategorias",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "20%" },
            { "data": "nombre", "width": "40%" },
            { "data": "fechaCreacion", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/Categos/Update/${data}" class="btn btn-success text-white" style="cursor-pointer;">Editar</a>
                            &nbsp;
                            <a onclick=Delete("/Categos/Delete/${data}") class="btn btn-danger text-white" style="cursor-pointer;">Cancelar</a>
                           </div>` 
                }, "width": "20%"
                
            }
        ],
    });
    
    
    
}

function Verjs() {
    $.ajax({
        "url": "/Categos/GetTodasCategorias",
        "type": "GET",
        "datatype": "json",
        "success": function (data) {

            var gfg = JSON.stringify(data);
            //gfg.data[0].data[0].id;


            //var arr = rf.length;
            //data.data[0].id
            //var nregistros = gfg.length;
            var keyCount = Object.keys(data.data).length;
            //var count = data.length


            for (var i = 0; i < keyCount; i++) {
                obj = data.data[i];
                console.log(obj.id + ' | ' + obj.nombre + ' | ' + obj.fechaCreacion);
            }
            Insertj(data);
            //alert(nregistros)
        }
    });
}
function ExitoM(titulo = "Se cargo correctamente") {
    Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: 'La carga fue exitosa',
        showConfirmButton: false,
        timer: 5500
    })
}

function Insertj(data) {
    $.ajax({
        "url": "/Categos/Insertj",
        "type": "POST",
        "datatype": "json",
        "data": { datos: data.data },
        "success": function () {
            ExitoM();
        }
    });
}

function Delete(url,folio) {
    swal({
        title: "¿Estas seguro de querer borrar el folio: "+folio+"?",
        text: "¡Esta acción no puede ser revertida!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}