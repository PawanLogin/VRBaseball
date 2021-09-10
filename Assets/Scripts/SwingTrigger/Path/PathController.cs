using System;
using System.Collections;
using System.Collections.Generic;
using SplineMesh;
using UnityEngine;
using UnityEngine.UI;

public class PathController : MonoBehaviour
{
    public GameObject pathGameobject;
    public Spline spline;
    [NonSerialized]
    public List<SplineNode> nodesList;
    private SplineNode initialSplineNode;
    public static PathController instance;

    void Awake()
    {
        instance=this;
        nodesList=new List<SplineNode>();
    }
    void Start()
    {
        
    }
    public void InitiateSplineTwoNodes(Vector3 pos, Vector3 dir)
    {
        initialSplineNode=new SplineNode(pos,dir);
        spline.AddNode(initialSplineNode);
        spline.AddNode(initialSplineNode);
    }
    public void AddSplinePoint(Vector3 pos, Vector3 dir)
    {
        SplineNode node=new SplineNode(pos,dir);
        spline.AddNode(node);
        nodesList.Add(node);
    }
    public void RemoveOtherSplineNodes()
    {
        foreach (var node in nodesList)
            spline.RemoveNode(node);
        nodesList.Clear();
    }
    public void RemoveInitialSplineNodes()
    {
        spline.RemoveNode(initialSplineNode);
        if(spline.nodes.FindIndex((s)=>{return s==initialSplineNode;})!=-1)
            spline.RemoveNode(initialSplineNode);
        initialSplineNode=null;
    }

}
