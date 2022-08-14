using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Node", menuName = "ScriptableObjects/Node", order = 1)]
public class Node : ScriptableObject
{
    public string nodeName;
    public string description;

    [FormerlySerializedAs("nodes")] [SerializeField] private List<Node> connectedNodes;
    [SerializeField] private List<string> relationshipDescriptions;
    

    public List<Node> GetConnectedNodes()
    {
        return connectedNodes;
    }

    public void AddNode(Node node)
    {
        connectedNodes.Add(node);
        node.AddNode(this);
    }
    
    public List<string> FetchRelationshipDescriptions()
    {
        return relationshipDescriptions;
    }

    public void IsConnectedGraph()
    {
        foreach (var node in connectedNodes)
        {
            if (!node.IsConnected(this))
            {
                CreateConnection(node, this);
            }

        }
    }

    public bool IsConnected(Node node)
    {
        foreach (var key in connectedNodes)
        {
            if (key.nodeName == node.nodeName)
                return true;
        }

        return false;

    }

    public void CreateConnection(Node node1, Node node2)
    {
        node1.AddNode(node2);
    }
}
