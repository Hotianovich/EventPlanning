/*=================Modal Window Login==================================================*/
$(function () {
    $.ajaxSetup({ cache: false });
    $("#loginLink").click(function (e) {

        e.preventDefault();
        $.get(this.href, function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });
});

/*==================================Clear form ========================*/

function ResetView() {
    $('#myForm').trigger('reset');
}