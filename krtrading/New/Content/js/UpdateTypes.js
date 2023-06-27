$(document).on("change", ".ddlTreatmentType", function () {

    var TreatmentType = $(this).val();
    var LeadId = $('.hdnLeadId').val();
    $.ajax({
        url: "/Lead/UpdateTreatmentType",
        data: "{'TreatmentType':'" + TreatmentType + "','LeadId':'" + LeadId + "'}",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data == 1) {
                alert("Treatment Type Change Successfully..");
            }
        },
        failure: function (response) {
            alert(response.responseText);
        }
    });
});

$(document).on("change", ".ddlCaseType", function () {

    var CaseType = $(this).val();
    var LeadId = $('.hdnLeadId').val();
    $.ajax({
        url: "/Lead/UpdateCaseType",
        data: "{'CaseType':'" + CaseType + "','LeadId':'" + LeadId + "'}",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data == 1) {
                alert("Case Type Change Successfully..");
            }
        },
        failure: function (response) {
            alert(response.responseText);
        }
    });
});

$(document).on("change", ".ddlConnectStatus", function () {
    
    var ConnectStatus = $(this).val();
    var LeadId = $('.hdnLeadId').val();
    $.ajax({
        url: "/Lead/UpdateConnectStatus",
        data: "{'ConnectStatus':'" + ConnectStatus + "','LeadId':'" + LeadId + "'}",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data == 1) {
                alert("Case Status Change Successfully..");
            }
        },
        failure: function (response) {
            alert(response.responseText);
        }
    });
});

$(document).on("change", ".ddlSource", function () {

    var Source = $(this).val();
    var LeadId = $('.hdnLeadId').val();
    $.ajax({
        url: "/Lead/UpdateSource",
        data: "{'Source':'" + Source + "','LeadId':'" + LeadId + "'}",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data == 1) {
                alert("Source Change Successfully..");
            }
        },
        failure: function (response) {
            alert(response.responseText);
        }
    });
});

