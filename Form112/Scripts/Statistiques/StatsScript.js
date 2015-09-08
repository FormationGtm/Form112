$(function () {
    var width = 800,
        heigth = 500,
        margin = {top: 80, bottom : 80, right : 40 , left: 40},
        w = width - margin.left - margin.rigth,
        h = heigth - margin.top - margin.bottom,

        graph = d3.select("#graph").append("svg").attr("width", width).attr("height", height)
                  .append("g").attr("transform", "translate(" + margin.left + "," + margin.top + ")"),

        
})