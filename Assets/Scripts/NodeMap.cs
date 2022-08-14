using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMap : MonoBehaviour
{
    public NodeMapDictionary nodemap;
}

[Serializable]
public class NodeMapDictionary : UnitySerializedDictionary<Node, List<Node>> { }