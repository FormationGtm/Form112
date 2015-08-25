$(function () {
    $('#idVmapWorld').vectorMap({
        map: 'world_en',
        backgroundColor: '#a5bfdd',
        borderColor: 'none',
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
        showTooltip: true
    });

    $('#idVmapWorld').bind('regionClick.jqvmap',
    function (event, code, region) {
        $('#idContinentChoice').val(code);
        console.log($('#idContinentChoice').val());
       $("#idFormMap").submit();
    }
);

});