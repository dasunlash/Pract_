$(document).ready(function () {
    initValidation();
    getDepartments();
    getEmployees();
});
var selectedIndex = -1;
var employees = [];

function btnSave_Click() {
    if ($('#frmEmployee').valid()) {
        save();
    }
}
function save() {

}
function saveEmployee_Success(result) {
    if (result!=null) {
        addItemsToEmployeeList(result);
    }
}
function addItemsToEmployeeList(result) {
    if (selectedIndex == -1) {
        employees.push(result);
    }
    else {
        employees[selectedIndex] = result;
    }
    drawTable(employees);
}
function createObject() {
    var object = {};
    if (selectedIndex == -1) {
        object.Id = -1;
    }
    else {
        object.Id = employees[selectedIndex].Id;
    }
    object.FirstName = $('#txtFirstName').val();
    object.LastName = $('#txtLastName').val();
    object.NIC = $('#txtNIC').val();
    object.Email = $('#txtEmail').val();
    object.NIC = $('#txtNIC').val();
    object.DepartmentId = $('#ddlDepartment').val();
    object.IsActive = $('#chkActive').Is(':checked');
}
function getDepartments() {
    var result = [{ Id: 1, Name: "HR" }, { Id: 1, Name: "IT" }]


    //sendRequestGet(null, getDepartment_success, handleResponse, 'getAreas');
    getDepartment_success(result);
}

function getDepartment_success(result) {
    if (result != null) {
        bindToDropdown('#ddlDepartment', result)
    }
}

function getEmployees() {
    var employees = [{ Id: 1, FirstName: "Dasun", LastName: "Lakshan", Email: "d@gmail.com", NIC: "911580756V", DepartmentId: 1, IsActive: true }]
    //sendRequestGet(null, getDepartment_success, handleResponse, 'getAreas');
    getEmployees_success(employees);
}

function getEmployees_success(result) {
    if (result != null) {
        employees = result;
        drawTable(result);
    }
}
function drawTable(result) {
    $('#dataTable tbody').html('');
    var htmlRow = '';
    for (var i = 0; i < result.length; i++) {
        var row = '<tr><td>' + result[i].FirstName + '</td><td>' + result[i].LastName + '</td><td>' + result[i].Email + '</td><td>' + result[i].NIC + '</td><td>' + result[i].IsActive + '</td><td><i class="fas fa-edit" onclick="item_Click(\'' + result[i].Id + '\',\'' + i + '\')" ></i></td><td><i onclick="delteItem_Click(' + result[i].Id + ')"class="fa fa-trash  color"></i></td></tr>'
        htmlRow += row
    }
    $('#dataTable tbody').html(htmlRow);
}
function item_Click(id, i) {
    selectedIndex = i;
    if (i != undefined) {
        var employee = employees[selectedIndex];
        setValueToView(employee);
    }
}
function setValueToView(employee) {
    $('#frmEmployee').validate().resetForm();
    $('#txtFirstName').val(employee.FirstName);
    $('#txtLastName').val(employee.LastName);
    $('#txtNIC').val(employee.NIC);
    $('#txtEmail').val(employee.Email);
    $('#txtNIC').val(employee.NIC);
    $('#ddlDepartment').val(employee.DepartmentId);
    $('#chkActive').prop('checked', employee.IsActive);
}
function delteItem_Click(id) {
    $('#modelConfirm').modal('show')
    $('#btnDelete').attr("onClick", "deleteClick(" + id + ")");
}
function deleteClick(id) {
    debugger
    $('#divLoder').show();
    toastr.error("Saves Suceesfully");
}
function btnClear_Click() {
    clearAll();
}
function clearAll() {
    selectedIndex = -1;
    $('#txtFirstName').val('');
    $('#txtLastName').val('');
    $('#txtNIC').val('');
    $('#txtEmail').val('');
    $('#txtNIC').val('');
    $('#ddlDepartment').val('');
    $('#chkActive').prop('checked', false);
}
function initValidation() {
    customizedValidationRules();
    $('#frmEmployee').validate({
        rules:
        {
            firstname: { required: true },
            lastname: { required: true },
            email: { required: true, validEmail: true },
            nic: { required: true },
            department: { validateDepartment: true },
        },
        messages:
        {
            firstname:
            {
                required: "First Name is required",
            },
            lastname:
            {
                required: "Last Name is required",
            },
            email:
            {
                required: "Email Name is required",
                validEmail: "Email is not valid Email"
            },
            nic:
            {
                required: "NIC is required",
            },
            department:
            {
                validateDepartment: "Department in required",
            },
        },
    });

}
function customizedValidationRules() {
    $.validator.addMethod('validateDepartment', function (value, element) {
        debugger
        if (value == "-1") { return false } return true;
    });
    $.validator.addMethod('validEmail', function (value, element) {
        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return regex.test(value);
    });
    $.validator.addMethod('PhoneNumber',
        function (value, element) {
            return this.optional(element) || /^\d{3}-?\d{3}-?\d{4}$/.test(value);
        });

}


function sendRequestGet(json, successMethod, errorMethod, url) {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        url: url,
        data: json,
        success: successMethod,
        error: errorMethod
    });
}
function sendRequestPost(json, successMethod, errorMethod, url) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json;charset=UTF-8',
        accept: 'application/json, text/plain, */*',
        url: url,
        data: JSON.stringify(json),
        success: successMethod,
        error: errorMethod
    });
}

function bindToDropdown(control, dropDownlist) {
    $(control).html('');
    $(control).append($('<option>').text('Select').attr('value', '-1'));
    if (dropDownlist === 'null' || dropDownlist == null) return;
    $(dropDownlist).each(function (index, val) {
        $(control).append('<option value="' + val.Id + '">' + val.Name + '</option>');
    });
}
function handleResponse() {

}