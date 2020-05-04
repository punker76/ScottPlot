﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ScottPlot.Demo.PlotTypes
{
    class Bar
    {
        public class Quickstart : PlotDemo, IPlotDemo
        {
            public string name { get; } = "Bar Plot Quickstart";
            public string description { get; } = "Bar graph series can be created by supply Xs and Ys. Optionally apply errorbars as a third array using an argument.";

            public void Render(Plot plt)
            {
                // generate random data to plot
                Random rand = new Random(0);
                int pointCount = 10;
                double[] xs = DataGen.Consecutive(pointCount);
                double[] ys = DataGen.RandomNormal(rand, pointCount, 20, 5);
                double[] yError = DataGen.RandomNormal(rand, pointCount, 5, 2);

                // make the bar plot
                plt.PlotBar(xs, ys, yError);

                // customize the plot to make it look nicer
                plt.Axis(y1: 0);
                plt.Grid(enableVertical: false, lineStyle: LineStyle.Dot);

                // apply custom axis tick labels
                string[] labels = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
                plt.XTicks(xs, labels);
            }
        }

        public class NewMultipleBars : PlotDemo, IPlotDemo
        {
            public string name { get; } = "Grouped Bar Graphs";
            public string description { get; } = "This example demonstrates how to display grouped bar plots. Data group labels are displayed as labels on the horizontal axis, while series labels are displayed in the legend.";

            public void Render(Plot plt)
            {
                // generate random data to plot
                string[] groupNames = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
                string[] seriesNames = { "alpha", "bravo", "charley" };
                int groupCount = groupNames.Length;
                Random rand = new Random(0);
                double[] ys1 = DataGen.RandomNormal(rand, groupCount, 20, 5);
                double[] ys2 = DataGen.RandomNormal(rand, groupCount, 20, 5);
                double[] ys3 = DataGen.RandomNormal(rand, groupCount, 20, 5);
                double[] err1 = DataGen.RandomNormal(rand, groupCount, 5, 2);
                double[] err2 = DataGen.RandomNormal(rand, groupCount, 5, 2);
                double[] err3 = DataGen.RandomNormal(rand, groupCount, 5, 2);

                plt.PlotMultiBar(
                    groupLabels: groupNames,
                    seriesLabels: seriesNames,
                    ys: new double[][] { ys1, ys2, ys3 }, 
                    yErr: new double[][] { err1, err2, err3 });

                // customize the plot to make it look nicer
                plt.Axis(y1: 0, y2: 50);
                plt.Grid(enableVertical: false, lineStyle: LineStyle.Dot);
                plt.Legend(location: legendLocation.upperRight);
            }
        }

        public class Horizontal : PlotDemo, IPlotDemo
        {
            public string name { get; } = "Horizontal Bar Graph";
            public string description { get; } = "Bar graphs can be displayed horizontally.";

            public void Render(Plot plt)
            {
                // generate random data to plot
                Random rand = new Random(0);
                int pointCount = 5;
                double[] xs = DataGen.Consecutive(pointCount);
                double[] ys = DataGen.RandomNormal(rand, pointCount, 20, 5);
                double[] yError = DataGen.RandomNormal(rand, pointCount, 3, 2);

                // make the bar plot
                plt.PlotBar(xs, ys, yError, horizontal: true);

                // customize the plot to make it look nicer
                plt.Axis(x1: 0);
                plt.Grid(enableHorizontal: false, lineStyle: LineStyle.Dot);

                // apply custom axis tick labels
                string[] labels = { "one", "two", "three", "four", "five" };
                plt.YTicks(xs, labels);
            }
        }

        public class Stacked : PlotDemo, IPlotDemo
        {
            public string name { get; } = "Stacked Bar Graphs";
            public string description { get; } = "Stacked bar charts can be created like this.";

            public void Render(Plot plt)
            {
                // create some sample data
                double[] xs = { 1, 2, 3, 4, 5, 6, 7 };
                double[] valuesA = { 1, 2, 3, 2, 1, 2, 1 };
                double[] valuesB = { 3, 3, 2, 1, 3, 2, 1 };

                // to simulate stacking B on A, shift B up by A
                double[] valuesB2 = new double[valuesB.Length];
                for (int i = 0; i < valuesB.Length; i++)
                    valuesB2[i] = valuesA[i] + valuesB[i];

                // plot the bar charts in reverse order (highest first)
                plt.PlotBar(xs, valuesB2, label: "Series B");
                plt.PlotBar(xs, valuesA, label: "Series A");

                // improve the styling
                plt.Legend(location: legendLocation.upperRight);
                plt.Axis(y1: 0, y2: 7);
                plt.Title("Stacked Bar Charts");
            }
        }

        public class Labels : PlotDemo, IPlotDemo
        {
            public string name { get; } = "Show values above bars";
            public string description { get; } = "Values for each bar can be shown on the graph by setting the 'showValues' argument.";

            public void Render(Plot plt)
            {
                // generate random data to plot
                Random rand = new Random(0);
                int pointCount = 10;
                double[] xs = DataGen.Consecutive(pointCount);
                double[] ys = DataGen.RandomNormal(rand, pointCount, 20, 5);

                // let's round the values to simplify display
                ys = Tools.Round(ys, 1);

                // add both bar plot
                plt.PlotBar(xs, ys, showValues: true);

                // customize the plot to make it look nicer
                plt.Axis(y1: 0);
                plt.Grid(enableVertical: false, lineStyle: LineStyle.Dot);
                plt.Axis(y1: 0);
                plt.Legend();
            }
        }

    }
}