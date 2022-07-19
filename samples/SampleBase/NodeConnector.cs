using System.Drawing;
using GraphSharp.Common;
using GraphSharp.Edges;
using GraphSharp.Nodes;
using SampleBase;

/// <summary>
/// Edge class for the NodeXY class.
/// </summary>
public class NodeConnector : IEdge<NodeXY>
{
    public NodeConnector(NodeXY source,NodeXY target)
    {
        Weight = source.Distance(target);
        Source = source;
        Target = target;
    }
    public static Color DefaultColor = Color.BlueViolet;
    public float Weight{get;set;} = 1;
    public Color Color{get;set;} = Color.BlueViolet;
    public NodeXY Source {get;set;}
    public NodeXY Target {get;set;}
    public float Flow{get;set;}
    public float Capacity{get;set;}
}