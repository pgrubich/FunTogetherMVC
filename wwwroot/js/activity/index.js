$(document).ready(function () {
    createActivityIcons();

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

        filterActivities(filterModel);
    })
})

function changePage(pageNumber) {
    var categories = [];
    $('#categories input:checked').each(function () {
        categories.push($(this).val());
    });

    var city = $('#City').val();

    var filterModel = {
        "City": city,
        "SelectedCategories": categories,
        "PageNumber": pageNumber
    };

    filterActivities(filterModel);
}

function filterActivities(filters) {
    var data = JSON.stringify(filters);

    $.ajax({
        url: '/Activity/FilterActivities',
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        data: data,
        success: function (result) {
            $("#activities").html(result);
            createActivityIcons();
        },
        headers: {
            RequestVerificationToken: $('input:hidden[name="__RequestVerificationToken"]').val()
        }
    })
}

function createActivityIcons() {
    $('.card-header.Sport').html('<i class="fas fa-running fa-3x float-end mb-1"></i>');
    $('.card-header.CulturalEvent').html('<i class="fas fa-theater-mask fa-3x float-end mb-1"></i>');
    $('.card-header.Music').html('<i class="fas fa-music fa-3x float-end mb-1"></i>');
    $('.card-header.Art').html('<i class="fas fa-palette fa-3x float-end mb-1"></i>');
    $('.card-header.Food').html('<i class="fas fa-utensils fa-3x float-end mb-1"></i>');
    $('.card-header.Games').html('<i class="fas fa-dice fa-3x float-end mb-1"></i>');
    $('.card-header.Science').html('<i class="fas fa-vial fa-3x float-end mb-1"></i>');
    $('.card-header.OutdoorActivities').html('<i class="fas fa-hiking fa-3x float-end mb-1"></i>');
    $('.card-header.Other').html('<i class="fas fa-users fa-3x float-end mb-1"></i>');
}