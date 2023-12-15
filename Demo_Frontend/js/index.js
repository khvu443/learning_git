let table = new DataTable('#myTable');



$(document).ready(async function() {
    setInterval(initTable(), 2000);

    $("#delete-btn").hide();

    //get all Roles to form
    $.ajax({
        headers: {
            'Access-Control-Allow-Origin': '*'
        },
        type: "GET",
        contentType: 'application/json',
        Credential: 'include',
        url: "https://localhost:7024/api/Role",
        xhrFields: {
            withCredentials: true
        },
        error: function() {
            console.log("Error");
        },
        success: function(data) {

            for (var i = 0; i < data.length; i++) {
                $('#role').append('<option value="' + data[i].roleId + '">' + data[i].roleName + '</option>');
            }
        }
    })


})


//---------------- Init Data ------------------------
//Init Employee to table
function initTable() {
    table.clear().draw()
    $.ajax({
        headers: {
            'Access-Control-Allow-Origin': '*',
        },
        type: "GET",
        Credential: 'include',
        url: "https://localhost:7024/api/User",
        xhrFields: {
            withCredentials: true
        },
        error: function() {
            console.log("Error");
        },
        success: function(data, statusText, xhr) {

            for (var i = 0; i < data.length; i++) {
                table.row
                    .add([
                        data[i].id,
                        data[i].name,
                        data[i].address,
                        data[i].phone,
                        data[i].roleId,
                        data[i].image,
                        data[i].status,
                        "<td>"+
                        "<a id='update-employee-btn' onclick=\"updateEmployee('" + data[i].id + "')\" data-bs-toggle='modal' data-bs-target='#exampleModal'><i class='fa-solid fa-pen-to-square fa-lg'></i></a>"+
                        "<a id='detail-employee-btn' onclick=\"detailEmployee('" + data[i].id + "')\" data-bs-toggle='modal' data-bs-target='#exampleModal' ><i class='fa-solid fa-circle-info fa-lg'></i></a>"+
                        "</td>",
                    ])
                    .draw();
            }
        }

    })
}


//--------------Employee function--------------

//--- empty form ---
function emptyFormEmployee() {
    $("#employee-id").val("");
    $("#employee-name").val("");
    $("#employee-address").val("");
    $("#employee-phone").val("");
    $("#employee-password").val("");
}

//--- Add new product ---
$("#add-new-btn").click(function() {
    $('#notice-employee-change').empty()

    $('#save-btn').show();
    $("#delete-btn").hide();

    $("#lbl-employee-password").show();
    $("#employee-password").show(),

    $('#role').attr("disabled", false);
    $('#Add-Update-Label').text("Thêm mới nhân viên");
    saveChange(1);
    emptyFormEmployee();
});


// --- update Employee ---
function updateEmployee(id) {

    $('#notice-employee-change').empty()
    $('#Add-Update-Label').html("Cập nhật thông tin nhân viên");

    $('#save-btn').show();
    $("#delete-btn").hide();

    $("#lbl-employee-password").show();
    $("#employee-password").show(),

    $('#role').attr("disabled", false);
    saveChange(2);

    getEmployeeById(id);
    emptyFormEmployee();
}

//--- Detail Employee ---
function detailEmployee(id) {
    $('#notice-employee-change').empty()

    $('#save-btn').hide();
    $("#delete-btn").show();
    $('#Add-Update-Label').html("Thông tin chi tiết");

    $("#lbl-employee-password").hide();
    $("#employee-password").hide(),

    $('#role').attr("disabled", true);;
    getEmployeeById(id);

    $("#delete-btn").on("click", function()
    {
        deleteEmployee(id);
    })
}

function getEmployeeById(id) {
    //set data to form
    $.ajax({
        headers: {
            'Access-Control-Allow-Origin': '*'
        },
        type: "GET",
        contentType: 'application/json',
        url: "https://localhost:7024/api/User/" + id,
        error: function() {
            console.log("Error");
        },
        success: function(data) {

            $("#employee-id").val(data.id);
            $("#employee-name").val(data.name);
            $('#role option[value=' + data.roleId + ']').prop('selected', true);
            $("#employee-address").val(data.address);
            $("#employee-phone").val(data.phone);

        }
    })
}

//--- Delete Employee ---


function deleteEmployee(id) {

    $.ajax({
        headers: {
            'Access-Control-Allow-Origin': '*'
        },
        type: "DELETE",
        Credential: 'include',
        xhrFields: {
            withCredentials: true
        },
        url: "https://localhost:7024/api/User/" + id,
        data:JSON.stringify({
            name: $("#employee-name").val(),
            address: $("#employee-address").val(),
            phone:  $("#employee-phone").val(),
            password: $("#employee-password").val(),
            roleId: $('#role').find(":selected").val(),
            image : $('#image').val(),
            status : true
        }),
        error: function(xhr, status, error) {
            console.log(xhr.status);
            if (xhr.status === 403 && xhr.status === 401) {
                $('#notice-employee-change').empty().append("Bạn không có quyền để làm điều đó").removeClass().addClass("text-warning");

            } else {
                $('#notice-employee-change').empty().append("Có lỗi đã xảy ra").removeClass().addClass("text-danger");
            }
            setTimeout((() => $('#notice-employee-change').empty()), 3000)

        },
        success: function(data, statusText, xhr) {
            if (xhr.status == 200) {
                $('#notice-employee-alert').empty().append("Xóa thành công!").removeClass().addClass("text-success");
                setTimeout((() => $('#notice-employee-alert').empty()), 3000)
                initTable();
            }
            initTable();
        }
    })
}

// --- save change ---
function saveChange(type) {
    if (type !== null) {
        switch (type) {
            case 1:

                $('#save-btn').click(function() {
                    console.log("add");

                    $.ajax({
                        headers: {
                            'Access-Control-Allow-Origin': '*'
                        },
                        contentType: 'application/json',
                        type: "POST",
                        Credential: 'include',

                        url: "https://localhost:7024/api/User",
                        xhrFields: {
                            withCredentials: true
                        },
                        data: JSON.stringify({
                            name: $("#employee-name").val(),
                            address: $("#employee-address").val(),
                            phone:  $("#employee-phone").val(),
                            password: $("#employee-password").val(),
                            roleId: $('#role').find(":selected").val(),
                            image : $('#image').val()
                        }),
                        error: function(xhr, status, error) {
                            console.log("Error");

                            if (xhr.status === 403 && xhr.status === 401) {
                                $('#notice-employee-change').empty().append("Bạn không có quyền để làm điều đó").removeClass().addClass("text-warning");

                            } else {
                                $('#notice-employee-change').empty().append("Có lỗi đã xảy ra").removeClass().addClass("text-danger");
                            }
                            setTimeout((() => $('#notice-employee-change').empty()), 3000)

                        },
                        success: function(data, statusText, xhr) {
                            if (xhr.status == 200) {
                                $('#notice-employee-change').empty().append("Thêm vào thành công").removeClass().addClass("text-success");
                                setTimeout((() => $('#notice-product-change').empty()), 3000)
                                initTable();
                            }
                        }
                    })
                });
                break;
            case 2:

                $('#save-btn').click(function() {
                    console.log("update");

                    $.ajax({
                        headers: {
                            'Access-Control-Allow-Origin': '*'
                        },
                        contentType: 'application/json',
                        type: "PUT",
                        Credential: 'include',

                        url: "https://localhost:7024/api/User/" + $("#employee-id").val(),
                        xhrFields: {
                            withCredentials: true
                        },
                        data: JSON.stringify({
                            id: $("#employee-id").val(),
                            name: $("#employee-name").val(),
                            address: $("#employee-address").val(),
                            phone:  $("#employee-phone").val(),
                            password: $("#employee-password").val(),
                            roleId: $('#role').find(":selected").val(),
                            image : $('#image').val(),
                            status: $('#employee-status').val()
                        }),
                        error: function(xhr, status, error) {

                            if (xhr.status === 403 && xhr.status === 401) {
                                $('#notice-employee-change').empty().append("Bạn không có quyền để làm điều đó").removeClass().addClass("text-warning");

                            } else {
                                $('#notice-employee-change').empty().append("Có lỗi đã xảy ra").removeClass().addClass("text-danger");
                            }
                            setTimeout((() => $('#notice-employee-change').empty()), 3000)

                        },
                        success: function(data, statusText, xhr) {
                            if (xhr.status == 200) {
                                $('#notice-employee-change').empty().append("Cập nhật thành công").removeClass().addClass("text-success");
                                setTimeout((() => $('#notice-product-change').empty()), 3000)
                                initTable();
                            }
                        }
                    })
                });
                break;
        }
    }

}


//----------Authentication--------------------


// --- login ---
$('#login').click(function() {
    $.ajax({
        headers: {
            'Access-Control-Allow-Origin': '*'
        },
        contentType: 'application/json',
        Credential: 'include',
        type: "POST",
        url: "https://localhost:7024/api/auth/login",
        data: JSON.stringify({
            phone: $("#username").val(),
            password: $("#password").val(),

        }),
        xhrFields: {
            withCredentials: true
        },
        error: function() {
            console.log("Error");
            $('.alert').empty().append("Đăng nhập thất bại!").removeClass().addClass("text-danger");
        },
        success: function(data) {
            $('.alert').empty().append("Đăng nhập thành công").removeClass().addClass("text-success");
            setTimeout(() => {
                window.open("User/user.html", "_blank");
            }, 3000);
        }
    });
});
