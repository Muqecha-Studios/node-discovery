using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public Node node;
    public List<Transform> connectedNodes;

    public void AttachNodeObj(Node nodeObj)
    {
        node = nodeObj;
        gameObject.transform.name = "Node " + nodeObj.nodeName;
    }

    public void DrawLine()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        connectedNodes = gameManager.nodeMap.nodeMap[gameObject.transform];

        foreach (var node in connectedNodes)
        {
            if (!node.TryGetComponent(out LineRenderer le))
            {
                var lr = gameObject.AddComponent<LineRenderer>();
                lr.SetPosition(0, gameObject.transform.position);
                lr.SetPosition(1, node.position);
                
            }
        }

    }
    
}

// var go = new GameObject();
// var lr = go.AddComponent<LineRenderer>();
//  
// var gun = GameObject.Find("Gun");
// var projectile = GameObject.Find("Projectile");
//  
// lr.SetPosition(0, gun.transform.position);
// lr.SetPosition(1, projectile.transform.position);
