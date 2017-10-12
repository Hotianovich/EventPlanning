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

/*======================================================DatePicer======================*/
$(function () {

    $.datepicker.setDefaults($.datepicker.regional['ru']);

    $('.text-editor-calendar').datepicker({
        dateFormat: "yy/mm/dd",
        showOn: "both",
        buttonImage: "/Content/Images/calendrier.svg",
        buttonImageOnly: true,
        changeMonth: true,
        changeYear: true
    });

    $.datepicker.regional['ru'] = {
        closeText: 'Закрыть',
        prevText: 'Пред',
        nextText: 'След',
        currentText: 'Сегодня',
        monthNames: ['Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь',
        'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь'],
        monthNamesShort: ['Янв', 'Фев', 'Мар', 'Апр', 'Май', 'Июн',
        'Июл', 'Авг', 'Сен', 'Окт', 'Ноя', 'Дек'],
        dayNames: ['воскресенье', 'понедельник', 'вторник', 'среда', 'четверг', 'пятница', 'суббота'],
        dayNamesShort: ['вск', 'пнд', 'втр', 'срд', 'чтв', 'птн', 'сбт'],
        dayNamesMin: ['Вс', 'Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб'],
        weekHeader: 'Не',
        dateFormat: "yy/mm/dd",
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    $.datepicker.setDefaults($.datepicker.regional['ru']);

});