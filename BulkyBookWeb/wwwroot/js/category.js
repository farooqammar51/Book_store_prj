﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#categorytbl').DataTable({
        "ajax": {
            "url": "/Admin/Category/GetCategory"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "displayOrder", "width": "15%" },
            { "data": "createdDateTime", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="/Admin/Category/Upsert?id=${data}" class="btn btn-outline-primary"><i class="bi bi-pencil-square"></i> &nbsp; Edit</a>
                            <a onClick=Delete('/Admin/Category/Delete/${data}') class="btn btn-outline-danger"><i class="bi bi-trash"></i> &nbsp; Delete</a>
                        </div>
                            `
                },
                "width": "15%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}
