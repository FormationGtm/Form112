$(function () {
    var listPays = [];
    $.getJSON('/Home/ListPaysCroisieres', function (data) {
        $.each(data, function (idx, pays) {
            listPays.push(pays.codeIso2.toLowerCase());
        });
    });

    $('#idVmapWorld').vectorMap({
        map: 'world_en',
        backgroundColor: '#a5bfdd',
        borderColor: '#818181',
        borderOpacity: 0.25,
        borderWidth: 1,
        color: '#f4f3f0',
        enableZoom: true,
        hoverColor: '#c9dfaf',
        hoverOpacity: null,
        normalizeFunction: 'linear',
        scaleColors: ['#b6d6ff', '#005ace'],
        selectedColor: '#c9dfaf',
        selectedRegion: null,
        showTooltip: true,
        onRegionOver: function (event, code) {
            if ($.inArray(code, listPays) == -1) {
                event.preventDefault();
            }
        },
        onRegionClick: function (element, code) {
            if ($.inArray(code, listPays) != -1) {
                $("#idPaysChoice").val(code.toUpperCase());
                console.log($("#idPaysChoice").val());
                $("#idFormMap").submit();
            }
            else {
                event.preventDefault();
            }
        }
    });


});