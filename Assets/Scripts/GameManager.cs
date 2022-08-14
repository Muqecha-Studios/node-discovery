using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject nodePrefab;
    public Node startingNode;

    public HashSet<Node> nodesInScene = new HashSet<Node>();

    public List<Transform> spawnPoints;

    private int index = 0;

    public NodeMap nodeMap;

    public NodeToTransformDictionary nodeToTransformDictionary;
    
    private void Start()
    {
        nodeMap = gameObject.transform.GetComponent<NodeMap>();
        SpawnNodes(startingNode);
        PopulateNodeMap();
        foreach (var node in nodeMap.nodeMap.Keys)
        {
            node.gameObject.GetComponent<NodeManager>().DrawLine();
        }
    }
    
    private void SpawnNodes(Node node)
    {
        nodesInScene.Add(node);
        
        List<Node> nodes = node.GetConnectedNodes();

        GameObject obj = Instantiate(nodePrefab, spawnPoints[index].position, spawnPoints[index].rotation, spawnPoints[index]);
        obj.GetComponent<NodeManager>().AttachNodeObj(node);
        spawnPoints[index].GetComponent<SpriteRenderer>().enabled = false;

        if (!nodeToTransformDictionary.ContainsKey(node))
            nodeToTransformDictionary.Add(node, obj.transform);

        foreach (var key in nodes)
        {
            if (!nodesInScene.Contains(key))
            {
                index++;
                SpawnNodes(key);
            }
        }
    }

    private void PopulateNodeMap()
    {
        foreach (var key in nodeToTransformDictionary.Keys)
        {
            
            List<Transform> connectedNodes = new List<Transform>();
            
            foreach (var node in nodeToTransformDictionary.Keys)
            {
                if (key.IsConnected(node))
                    connectedNodes.Add(nodeToTransformDictionary[node]);
            }
            nodeMap.nodeMap.Add(nodeToTransformDictionary[key], connectedNodes);
            
        }
    }
}

[Serializable]
public class NodeToTransformDictionary : UnitySerializedDictionary<Node, Transform> { }
