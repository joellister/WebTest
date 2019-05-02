// Write your JavaScript code.

$(function () {
    $('.table tr[data-href]').each(function () {
        $(this).css('cursor', 'pointer').hover(
            function () {
                $(this).addClass('active');
            },
            function () {
                $(this).removeClass('active');
            }).click(function () {
                document.location = $(this).attr('data-href');
            }
        );
    });
    $('#Excluded').on('change', function () {
        $('#excludeform').submit();
    });
});
