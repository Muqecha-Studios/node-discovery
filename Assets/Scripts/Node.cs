using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Node", menuName = "ScriptableObjects/Node", order = 1)]
public class Node : ScriptableObject
{
    public string nodeName;
    public string description;

    [SerializeField] private List<Node> nodes;
    [SerializeField] private List<string> relationshipDescriptions;


    

    public List<Node> GetConnectedNodes(ScriptableObject node)
    {
        return nodes;
    }

    public void AddNode(Node node)
    {
        nodes.Add(node);
    }
    
    public List<string> FetchRelationshipDescriptions(ScriptableObject node)
    {
        return relationshipDescriptions;
    }

    public bool CheckConnectedNodes()
    {
        foreach (var node in nodes)
        {
            if (!node.CheckConnection(this))
            {
                CreateConnection(node, this);
            }

        }
        
        return true;
    }

    public bool CheckConnection(Node node)
    {
        foreach (var key in nodes)
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
