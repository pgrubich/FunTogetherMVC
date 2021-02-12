$(document).ready(function () {
    $('#filterSubmit').click(function (e) {
        e.preventDefault();

        var categories = [];
        $('#categories input:checked').each(function () {
            categories.push($(this).val());
        });

        var city = $('#City').val();

        var filterModel = {
            "City": city,
            "SelectedCategories": categories
        };
        var data = JSON.stringify(filterModel);

        $.ajax({
            url: '/Activity/FilterActivities',
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: data,                
            success: function (result) {
                $("#activities").html(result);               
            },
            headers: {
                RequestVerificationToken: $('input:hidden[name="__RequestVerificationToken"]').val()
            }
        })
    })
})