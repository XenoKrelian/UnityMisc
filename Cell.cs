using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    GameObject structureModel = null;
    List<GameObject> natureList = new List<GameObject>();
    StructureBaseSO structureData;
    bool isTaken = false;

    List<Vertex> ChildVertexes = new List<Vertex>();
    Vertex ParentVertex = new Vertex();

    public bool IsTaken { get => isTaken; }

    public void SetParent(Vertex parent)
    {
        if (ParentVertex.vertexHasData)
        {
            throw new InvalidOperationException("Parent already set");
        }
        else
        {
            ParentVertex = parent;
            isTaken = true;
            this.structureData = null;
            this.structureModel = null;
        }
    }

    public void AddChild(Vertex child)
    {
        if (ChildVertexes.Contains(child))
        {
            throw new InvalidOperationException("Child already added");
        }
        else
        {
            ChildVertexes.Add(child);
        }
    }

    public void SetConstruction(GameObject structureModel, StructureBaseSO structureData)
    {
        if (structureModel == null)
            return;
        this.structureData = structureData;
        this.structureModel = structureModel;

        isTaken = true;
    }

    public bool IsChild()
    {
        return ParentVertex.vertexHasData;
    }

    public Vertex GetParent()
    {
        return ParentVertex;
    }

    public StructureBaseSO GetStructureData()
    {
        return structureData;
    }

    public GameObject GetStructure()
    {
        return structureModel;
    }

    public void RemoveStructure()
    {
        structureModel = null;
        structureData = null;
        isTaken = false;
        ParentVertex = new Vertex();
        ChildVertexes.Clear();
    }

    public void AddNatureObject(GameObject element)
    {
        natureList.Add(element);
    }

    public List<GameObject> GetNatureObjectsOnCell()
    {
        return natureList;
    }
}
