using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMap : MonoBehaviour
{
    public WorldSpaceNodeDictionary nodeMap;
    
}

[Serializable]
public class WorldSpaceNodeDictionary : UnitySerializedDictionary<Transform, List<Transform>> { }