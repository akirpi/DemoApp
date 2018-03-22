var showMessage = function (id) {
    $.ajax({
        type: "GET",
        dataType: "text",
        url: "/app/message1/" + id,
        data: null,
        success: function (response) {

            $("#viewMsg").text(response);
            var x = document.getElementById(id);
            $(x).removeClass("list-group-item-info");
        }
    });

}

