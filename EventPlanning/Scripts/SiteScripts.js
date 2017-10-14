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

/*=================Modal Window AddEmployee Insert ==================================================*/
function checkEmail(){
    var email = $('#emailLogin').val()

    if (email.length != 0) {
        var pattern = /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.([a-z]{1,6}\.)?[a-z]{2,6}$/i;
        if (email.search(pattern) == 0) {
            $('#send').removeAttr('disabled');
            $('#valid').text('');
        } else {
            $('#valid').css('color', 'red');
            $('#valid').text('Введите email');
            $('#send').attr('disabled', 'disabled');
        }

    } else {
        $('#send').attr('disabled', 'disabled');
    }
}
/*==================================Clear form ========================*/

function ResetView() {
    $('#myForm').trigger('reset');
}