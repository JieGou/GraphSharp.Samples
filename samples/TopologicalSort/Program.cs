﻿using System.Drawing;
using GraphSharp.Visitors;

ArgumentsHandler argz = new("settings.json");

var graph = Helpers.CreateGraph(argz);
graph.Do.MakeBidirected();
var sources = new int[]{65,77,39,40};
graph.Do.MakeSources(sources);

Helpers.MeasureTime(()=>{
    System.Console.WriteLine("Doing topological sort...");
    graph.Do.TopologicalSort().ApplyTopologicalSort((n,pos)=>n.Position = pos);
});

foreach(var component in graph.Do.FindComponents().Components){
    var color = Color.FromArgb(Random.Shared.Next(256),Random.Shared.Next(256),Random.Shared.Next(256));
    foreach(var node in component){
        node.Color = color;
    }
}

Helpers.ShiftNodesToFitInTheImage(graph.Nodes,x=>x.Position,(x,pos)=>x.Position = pos);
Helpers.CreateImage(argz,graph,drawer=>{
    drawer.Clear(Color.Black);
    drawer.DrawEdgesParallel(graph.Edges,argz.thickness);
    drawer.DrawDirections(graph.Edges,argz.thickness,argz.directionLength,Color.CadetBlue);
    drawer.DrawNodesParallel(sources.Select(x=>graph.Nodes[x]),argz.nodeSize);
    drawer.DrawNodeIds(sources.Select(x=>graph.Nodes[x]),Color.Azure,argz.fontSize);
},x=>x.Position);
System.Console.WriteLine("Done");