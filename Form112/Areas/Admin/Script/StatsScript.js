$(function () {
    "use strict";
    var width = 1000,
        height = 600,
        margin = { top: 80, right: 40, bottom: 80, left: 40 },
        w = width - margin.left - margin.right,
        h = height - margin.top - margin.bottom,

        graph = d3.select("#graph")
                    .append("svg")
                    .attr("width", width)
                    .attr("height", height).append("g")
                    .attr("transform", "translate(" + margin.left + ", " + margin.top + ")"),

		x = d3.scale.linear()
                .range([0, w]),
        y = d3.scale.ordinal()
                .rangeRoundBands([h, 0], 0.3),

		color = d3.scale.category20(),

		xAxis = d3.svg.axis()
				.scale(x)
				.orient("top"),

		yAxis = d3.svg.axis()
				.scale(y)
				.orient("left")
				.ticks(1)
				.tickFormat(""),

		xGrid = d3.svg.axis()
            .scale(x)
            .orient("top")
            .ticks(5)
            .tickSize(-h, 0, 0)
            .tickFormat(d3.format("d")),

		title = graph.append("g")
            .attr("class", "title"),

        labels = graph.append("g")
            .attr("class", "labels");

    title.append("text")
        .attr("x", (w / 2))
        .attr("y", -margin.top / 2)
        .attr("text-anchor", "middle")
        .style("font-size", "22px")
        .text("Suivi des visites de produits");

    // Chargement et manipulation des données

    d3.json("/Admin/Statistiques/NombreVuesParPays/", function (error, data) {
        x.domain([0, d3.max(data, function (d) { return d.NbVis; })]);
        y.domain(data.map(function (d) { return d.Nom; }));

        graph.append("g")
            .attr("class", "y axis")
            .attr("transform", "translate(0, 0)")
            .call(yAxis)
            .selectAll("text")
                .style("text-anchor", "end")
                .attr("dx", "-.8em")
                .attr("dy", ".15em")
                .attr("transform", "rotate(-65)")

        graph.append("g")
            .attr("class", "grid")
            .call(xGrid);

        labels.append("text")
            .attr("y", h - margin.bottom / 2)
            .attr("x", -w / 2)
            .style("text-anchor", "middle")
            .text("Nombre de visites");

        graph.attr('id', 'bars')
			.selectAll("rect")
            .data(data)
            .enter().append("rect")
			.attr("x", w)
			.attr("width", 0)
            .attr("y", function (d) { return y(d.Nom); })
            .attr("height", y.rangeBand())
			.attr("fill", function (d) { return color(d.Nom); })
			.transition()
				.attr("x", function (d) { return 0; })
				.attr("width", function (d) { return x(d.NbVis); })
				.duration(3000)
				.delay(100);
    });
});