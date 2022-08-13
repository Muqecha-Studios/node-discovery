using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Node", menuName = "ScriptableObjects/Node", order = 1)]
public class Node : ScriptableObject
{
    public string nodeName;
    public string description;

    [SerializeField] Dictionary<Node, string> connectedNodes;
    [SerializeField] Node[] nodes;



    public List<ScriptableObject> fetchConnectedNodes(ScriptableObject node)
    {
        List<ScriptableObject> nodes = new List<ScriptableObject>();
        
        foreach (var key in connectedNodes.Keys)
            nodes.Add(node);

        return nodes;
    }

    
    
    //public string fetchRelationshipDiscription(ScriptableObject node)
    //{
    //    return connectedNodes[node];
    //}
}
