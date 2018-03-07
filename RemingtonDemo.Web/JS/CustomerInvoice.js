$(document).ready(function () {
    $("#InvoiceTbl").hide();
    $("#Gridview1").hide();

    $("BtnRun").on("click", function () {
        $("#Gridview1").show();
    })
    $("#runService").on("click", function () {
        
        $("#GridView1").hide();
        var object = {};
        object.start = $("#TxtStart").val();
        object.end = $("#TxtEnd").val();

        var validYear = validateStartEndYear(object.start, object.end);

        if (validYear) {
            $.ajax({
                url: 'DemoService.asmx/GetCustomerInvoices',
                method: 'post',
                data: JSON.stringify(object),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (r) {
                    var data = JSON.parse(r.d);

                    var viewModel = {

                        invoices: ko.observableArray(data)

                    }
                    var element = document.getElementById("details");
                    ko.cleanNode(element);
                    try {
                        ko.applyBindings(viewModel);
                    }
                    catch(err){
                        window.location.reload(true)
                    }
                    $("#InvoiceTbl").show()
                    
                },
                error: function (r) {
                    alert("fail");
                }
            });
        }
        else {
            alert("Order Dates do not exceed 2014");
        }

        


    });

    $("#TxtStart").datepicker();

    $("#TxtEnd").datepicker();

    $("#TxtStart").on("blur", function (e) {
        var isValidDate = validateDate(e.target.value);
        if (!isValidDate) {
            alert("Please enter a valid date in MM/DD/YYYY format");
            $(this).val("");
        }
    });

    $("#TxtEnd").on("blur", function (e) {
        var isValidDate = validateDate(e.target.value);
        if (!isValidDate) {
            alert("Please enter a valid date in MM/DD/YYYY format");
            $(this).val("");
        }
    });
});

function validateDate(dateValue) {
    var selectedDate = dateValue;
    if (selectedDate == '')
        return false;

    var regExp = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
    var dateArray = selectedDate.match(regExp);

    if (dateArray == null) {
        return false;
    }

    month = dateArray[1];
    day = dateArray[3];
    year = dateArray[5];

    if (month < 1 || month > 12) {
        return false;
    } else if (day < 1 || day > 31) {
        return false;
    } else if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31) {
        return false;
    } else if (month == 2) {
        var isLeapYear = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
        if (day > 29 || (day == 29 && !isLeapYear)) {
            return false
        }
    }
    return true;
}

function validateStartEndYear(dateValue1, dateValue2){
    var d1 = new Date(dateValue1);
    var d2 = new Date(dateValue2);
    var y1 = d1.getFullYear();
    var y2 = d2.getFullYear();
    if (y1 <= 2014 && y2 <= 2014){
        return true;
    }
    else {
        return false;
    }
}
    
