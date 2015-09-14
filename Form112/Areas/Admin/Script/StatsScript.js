//$(function () {
//    "use strict";
//    var width = 1000,
//        height = 600,
//        margin = { top: 80, right: 40, bottom: 80, left: 40 },
//        w = width - margin.left - margin.right,
//        h = height - margin.top - margin.bottom,

//        graph = d3.select("#graph")
//                    .append("svg")
//                    .attr("width", width)
//                    .attr("height", height).append("g")
//                    .attr("transform", "translate(" + margin.left + ", " + margin.top + ")"),

//		x = d3.scale.linear()
//                .range([0, w]),
//        y = d3.scale.ordinal()
//                .rangeRoundBands([h, 0], 0.3),

//		color = d3.scale.category20(),

////		xAxis = d3.svg.axis()
////				.scale(x)
////				.orient("top"),

////		yAxis = d3.svg.axis()
////				.scale(y)
////				.orient("left")
////				.ticks(1)
////				.tickFormat(""),

////		xGrid = d3.svg.axis()
////            .scale(x)
////            .orient("top")
////            .ticks(5)
////            .tickSize(-h, 0, 0)
////            .tickFormat(d3.format("d")),

//		title = graph.append("g")
//            .attr("class", "title"),

//        labels = graph.append("g")
//            .attr("class", "labels");

//    title.append("text")
//        .attr("x", (w / 2))
//        .attr("y", -margin.top / 2)
//        .attr("text-anchor", "middle")
//        .style("font-size", "22px")
//        .text("Suivi des visites de produits");

//    // Chargement et manipulation des données

//    d3.json("/Admin/Statistiques/NombreVuesParPays/", function (error, data) {
//        x.domain([0, d3.max(data, function (d) { return d.NbVis; })]);
//        y.domain(data.map(function (d) { return d.Nom; }));

//        graph.append("g")
//            .attr("class", "y axis")
//            .attr("transform", "translate(0, 0)")
//            .call(yAxis)
//            .selectAll("text")
//                .style("text-anchor", "end")
//                .attr("dx", "-.8em")
//                .attr("dy", ".15em")
//                .attr("transform", "rotate(-65)")

//        graph.append("g")
//            .attr("class", "grid")
//            .call(xGrid);

//        labels.append("text")
//            .attr("y", h - margin.bottom / 2)
//            .attr("x", -w / 2)
//            .style("text-anchor", "middle")
//            .text("Nombre de visites");

//        graph.attr('id', 'bars')
//			.selectAll("rect")
//            .data(data)
//            .enter().append("rect")
//			.attr("x", w)
//			.attr("width", 0)
//            .attr("y", function (d) { return y(d.Nom); })
//            .attr("height", y.rangeBand())
//			.attr("fill", function (d) { return color(d.Nom); })
//			.transition()
//				.attr("x", function (d) { return 0; })
//				.attr("width", function (d) { return x(d.NbVis); })
//				.duration(3000)
//				.delay(100);
//    });
//});

$(function () {
    barChart().drawChart("/Admin/Statistiques/NombreVuesParPays/", {
        svgContainer: "#graph",
        graphTitle: "Suivi des visites de produits"
    });
});

function readableColor(color) {
    var rgbColor = d3.rgb(color), 
        r = rgbColor.r,
        g = rgbColor.g,
        b = rgbColor.b,
        yiq = (r * 299 + g * 587 + b * 114) / 1000;
        return yiq >= 128 ? "#444444" :"#f7f7f7";
}

function barChart() {
    "use strict";
    /*global d3,$,console*/
    var localData,
        config = Object.create({
            graphTitle: "",
            svgContainer: "",
            margin: { top: 70, right: 40, bottom: 70, left: 40 }
        }),
        svgGraph = {
            renderChart: function () {
                var width, height, aspect, w, h, svg, graph, x, y, xAxis, yAxis, xGrid, title, labels,
                    barColor, textBarColor, fontSizeScaleTitre, fontSizeScaleTitreAxe, fontSizeScaleBarLabel, marginTopBottomScale, marginLeftRightScale;

                // Les couleurs des barres du graphique
                barColor = d3.scale
                        .category20();
                textBarColor = d3.scale
                        .category20();

                fontSizeScaleTitre = d3.scale.linear()
                                        .domain([300, 1600])
                                        .range(["10px", "50px"]);

                fontSizeScaleTitreAxe = d3.scale.linear()
                                        .domain([300, 1600])
                                        .range(["5px", "25px"]);

                fontSizeScaleBarLabel = d3.scale.linear()
                                        .domain([300, 1600])
                                        .range(["5px", "15px"]);

                marginTopBottomScale = d3.scale.linear()
                                        .domain([300, 1600])
                                        .range([20, 80]);

                marginLeftRightScale = d3.scale.linear()
                                        .domain([300, 1600])
                                        .range([10, 40]);

                $(config.svgContainer).empty();

                aspect = $(document).height() / $(document).width();
                width = parseInt(d3.select(config.svgContainer).style('width'), 10);
                height = width * aspect;

                // Adaptation des marges
                config.margin.top = config.margin.bottom = marginTopBottomScale(width);
                config.margin.left = config.margin.right = marginLeftRightScale(width);

                w = width - config.margin.left - config.margin.right;
                h = height - config.margin.top - config.margin.bottom;

                // Définition de la zone du graphique
                svg = d3.select(config.svgContainer)
                            .append("svg")
                                .attr("height", height)
                                .attr("width", width);

                graph = svg.append("g")
                            .attr("transform", "translate(" + config.margin.left + ", " + config.margin.top + ")");

                // Des données d'échelle
                // En x données linéaires qui correspondent à la hauteur des barres
                x = d3.scale.linear()
                    .range([0, w])
                    .domain([0, d3.max(localData, function (d) { return d.NbVis; })]);
                // En y données discrètes par bandes ce qui convient très bien aux barres verticales
                y = d3.scale.ordinal()
                    .rangeRoundBands([h, 0], 0.3)
                    .domain(localData.map(function (d) { return d.Nom; }));

                // Les axes

                xAxis = d3.svg.axis()
                    .scale(x)
                    .orient("top");

                yAxis = d3.svg.axis()
                    .scale(y)
                    .orient("left");

                xGrid = d3.svg.axis()
                    .scale(x)
                    .orient("top")
                    .ticks(5)
                    .tickSize(h, 0, 0)
                    .tickFormat(d3.format("d"));

                title = graph.append("g")
                    .attr("class", "title")
                        .append("text")
                    .attr("x", (w / 2))
                    .attr("y", -config.margin.top / 2)
                    .attr("text-anchor", "middle")
                    .style("font-size", fontSizeScaleTitre(width))
                    .text(config.graphTitle);

                labels = graph.append("g")
                    .attr("class", "labels");

                graph.append("g")
                    .attr("class", "x axis")
                    .attr("transform", "translate(0," + h + ")")
                    .call(xAxis)
                    .selectAll("text")
                        .style("text-anchor", "middle")
                        .style("font-size", fontSizeScaleTitreAxe(width))
                        .attr("dy", "1.5em");

                graph.append("g")
                    .attr("class", "grid")
                    .call(xGrid);

                labels.append("text")
                    .attr("y", h + config.margin.bottom / 2)
                    .attr("x", width / 2)
                    .style("text-anchor", "middle")
                    .style("font-size", fontSizeScaleTitreAxe(width))
                    .text("Nombre de visites");

                graph.attr('id', 'bars')
                    .selectAll("rect")
                    .data(localData)
                    .enter()
                        .append("rect")
                    .attr("x", w)
                    .attr("width", 0)
                    .attr("y", function (d) { return y(d.Nom); })
                    .attr("height", y.rangeBand())
                    .attr("fill", function (d) { console.log(d); return barColor(d.Nom); })
                    .transition()
                        .attr("x", function (d) { return 0; })
                        .attr("width", function (d) { return x(d.NbVis); })
                        .duration(3000)
                        .delay(100);

                graph.append("g")
                    .attr("class", "y axis")
                    .call(yAxis)
                    .selectAll("text")
                        .style("text-anchor", "start")
                        .style("font-size", fontSizeScaleBarLabel(width))
                        .attr("dx", "1em")
                        .style("fill", function (d) {
                            console.log(d); return readableColor(barColor(d));
                        })
                ;
                return this;
            },
            resizeChart: function () {
                svgGraph.renderChart();
                return this;
            },
            drawChart: function (dataSource, options) {
                svgGraph.configuration(options);
                // Tout ce qui dépend des données doit être placé dans cette fonction de callback
                // Obtention du fichier de données
                d3.json(dataSource, function (error, data) {
                    if (error) {
                        return console.warn(error);
                    }
                    localData = data;
                    svgGraph.renderChart();
                });
                return this;
            },
            configuration: function (value) {
                if (!arguments.length) {
                    return config;
                }
                d3.entries(value || {}).forEach(function (option) {
                    config[option.key] = option.value;
                });
                return this;
            }
        };

    //d3.select(window).on('load', svgGraph.resizeChart);
    d3.select(window).on('resize', svgGraph.resizeChart);

    return svgGraph;
}