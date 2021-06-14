﻿$('#Faculty').change(function () {

    var selectedFaculty = $("#Faculty").val();
    var departmentsSelect = $('#Department');
    var groupsSelect = $('#Group');
    departmentsSelect.empty();
    groupsSelect.empty();
    if (selectedFaculty != null && selectedFaculty != '') {
        $.ajax({
            type: "POST",
            url: "/WorkManagementCycles/Create?handler=Departments",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            data: selectedFaculty,
            contentType: "json; charset=utf-8",
            success: function (departments) {
                if (departments != null && !jQuery.isEmptyObject(departments)) {
                    departmentsSelect.append($('<option/>', {
                        value: null,
                        text: "--- select department ---"
                    }));
                    $.each(departments, function (index, department) {
                        departmentsSelect.append("<option value='" + department.value + "'>" + department.text + "</option>");
                    });
                };
            },
            failure: function (response) {
                alert(response);
            }
        });
    }
});
$('#Department').change(function () {
    alert("group");
    var selectedDepartment = $("#Department").val();
    var groupsSelect = $('#Group');
    groupsSelect.empty();
    if (selectedDepartment != null && selectedDepartment != '') {
        $.ajax({
            type: "POST",
            url: "/WorkManagementCycles/Create?handler=Groups",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            data: selectedDepartment,
            contentType: "json; charset=utf-8",
            success: function (groups) {
                if (groups != null && !jQuery.isEmptyObject(groups)) {
                    groupsSelect.append($('<option/>', {
                        value: null,
                        text: "--- select group ---"
                    }));
                    $.each(groups, function (index, group) {
                        groupsSelect.append("<option value='" + group.value + "'>" + group.text + "</option>");
                    });
                };
            },
            failure: function (response) {
                alert(response);
            }
        });
    }
});