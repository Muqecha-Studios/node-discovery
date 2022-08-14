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
    
    private void Start()
    {
        SpawnNodes(startingNode);
    }
    
    private void SpawnNodes(Node node)
    {
        nodesInScene.Add(node);
        
        List<Node> nodes = node.GetConnectedNodes();

        GameObject obj = Instantiate(nodePrefab, spawnPoints[index].position, spawnPoints[index].rotation, spawnPoints[index]);
        obj.GetComponent<NodeManager>().AttachNodeObj(node);
        spawnPoints[index].GetComponent<SpriteRenderer>().enabled = false;
        
        foreach (var key in nodes)
        {
            if (!nodesInScene.Contains(key))
            {
                index++;
                SpawnNodes(key);
            }
        }
    }
}
