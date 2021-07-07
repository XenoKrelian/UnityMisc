using Assets.Scripts.Misc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathfindingHelper 
{
    #region AStarNode Vector3Int
    private class AStarNodeInt : IHeapItem<AStarNodeInt>, IEquatable<AStarNodeInt>
    {
        public int GCost { get; set; }
        public int HCost { get; set; }
        public int FCost => GCost + HCost;
        public Vector3Int position { get; set; }
        public AStarNodeInt parent { get; set; }
        public int HeapIndex { get; set; }

        public AStarNodeInt(Vector3Int position)
        {
            this.position = position;
        }

        public int CompareTo(AStarNodeInt other)
        {
            int compare = FCost.CompareTo(other.FCost);
            if (compare == 0)
            {
                compare = HCost.CompareTo(other.HCost);
            }
            return -compare;
        }

        public bool Equals(AStarNodeInt other)
        {
            return other.position.x == position.x && other.position.z == position.z;
        }

        public override int GetHashCode()
        {
            return (position.x.ToString() + "-" + position.z.ToString()).GetHashCode();
        }
    }

    //Based on Sebastian Lague Pathfinding: https://github.com/SebLague/Pathfinding
    private List<Vector2Int> AStarSearchInt(Vector3Int startPos, Vector3Int endPos, Dictionary<Vector3Int, List<Vector3Int>> neighbours, int totalNodes)
    {
        var startNode = new AStarNodeInt(startPos);
        startNode.parent = startNode;
        var endNode = new AStarNodeInt(endPos);
        Heap<AStarNodeInt> openSet = new Heap<AStarNodeInt>(totalNodes);
        HashSet<AStarNodeInt> closedSet = new HashSet<AStarNodeInt>();
        openSet.Add(startNode);
        bool pathSuccess = false;

        while (openSet.Count > 0) //autoAbort prevents infinites loops
        {
            var currentNode = openSet.RemoveFirst();
            closedSet.Add(currentNode);

            if (currentNode.Equals(endNode))
            {
                endNode = currentNode;
                //return closedSet.Reverse().Select(x => new Vector2Int(x.position.x, x.position.z)).ToList();
                pathSuccess = true;
                break;
            }

            foreach (var neighbourPoint in neighbours[currentNode.position])
            {
                var neighbour = new AStarNodeInt(neighbourPoint);
                if (closedSet.Contains(neighbour)) //Already done this node (road nodes can see both sides, not just one way
                {
                    continue;
                }

                int newMovementCostToNeighbour = currentNode.GCost + ManhattanDistanceInt(currentNode, neighbour);
                if (newMovementCostToNeighbour < neighbour.GCost || !openSet.Contains(neighbour))
                {
                    neighbour.GCost = newMovementCostToNeighbour;
                    neighbour.HCost = ManhattanDistanceInt(neighbour, endNode);
                    neighbour.parent = currentNode;

                    if (!openSet.Contains(neighbour))
                    {
                        openSet.Add(neighbour);
                    }
                    else
                    {
                        openSet.UpdateItem(neighbour);
                    }
                }
            }
        }

        if (pathSuccess)
        {
            var waypoints = RetracePathInt(startNode, endNode);
            pathSuccess = waypoints.Count > 0;
            return waypoints;
        }

        return new List<Vector2Int>();
    }

    List<Vector2Int> RetracePathInt(AStarNodeInt startNode, AStarNodeInt endNode)
    {
        List<AStarNodeInt> path = new List<AStarNodeInt>();
        AStarNodeInt currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Add(startNode);
        //Vector3[] waypoints = SimplifyPath(path);
        //Array.Reverse(waypoints);
        //return waypoints;
        return path.Select(x => new Vector2Int(x.position.x, x.position.z)).Reverse().ToList();
    }

    Vector3[] SimplifyPathInt(List<AStarNodeInt> path)
    {
        List<Vector3> waypoints = new List<Vector3>();
        Vector2 directionOld = Vector2.zero;

        for (int i = 1; i < path.Count; i++)
        {
            Vector2 directionNew = new Vector2(path[i - 1].position.x - path[i].position.x, path[i - 1].position.z - path[i].position.z);
            if (directionNew != directionOld)
            {
                waypoints.Add(path[i].position);
            }
            directionOld = directionNew;
        }
        return waypoints.ToArray();
    }
    int ManhattanDistanceInt(AStarNodeInt nodeA, AStarNodeInt nodeB)
    {
        int dstX = Mathf.Abs(nodeA.position.x - nodeB.position.x);
        int dstY = Mathf.Abs(nodeA.position.z - nodeB.position.z);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }
    #endregion

    #region AStarNodeFloat Vector3

    private class AStarNodeFloat : IHeapItem<AStarNodeFloat>, IEquatable<AStarNodeFloat>
    {
        public float GCost { get; set; }
        public float HCost { get; set; }
        public float FCost => GCost + HCost;
        public Vector3 position { get; set; }
        public AStarNodeFloat parent { get; set; }
        public int HeapIndex { get; set; }

        public AStarNodeFloat(Vector3 position)
        {
            this.position = position;
        }

        public int CompareTo(AStarNodeFloat other)
        {
            int compare = FCost.CompareTo(other.FCost);
            if (compare == 0)
            {
                compare = HCost.CompareTo(other.HCost);
            }
            return -compare;
        }

        public bool Equals(AStarNodeFloat other)
        {
            return other.position.x == position.x && other.position.z == position.z;
        }

        public override int GetHashCode()
        {
            return (position.x.ToString() + "-" + position.z.ToString()).GetHashCode();
        }
    }

    //Based on Sebastian Lague Pathfinding: https://github.com/SebLague/Pathfinding
    private List<Vector2> AStarSearchFloat(Vector3 startPos, Vector3 endPos, Dictionary<Vector3, List<Vector3>> neighbours, int totalNodes)
    {
        var startNode = new AStarNodeFloat(startPos);
        startNode.parent = startNode;
        var endNode = new AStarNodeFloat(endPos);
        Heap<AStarNodeFloat> openSet = new Heap<AStarNodeFloat>(totalNodes);
        HashSet<AStarNodeFloat> closedSet = new HashSet<AStarNodeFloat>();
        openSet.Add(startNode);
        bool pathSuccess = false;

        while (openSet.Count > 0) //autoAbort prevents infinites loops
        {
            var currentNode = openSet.RemoveFirst();
            closedSet.Add(currentNode);

            if (currentNode.Equals(endNode))
            {
                endNode = currentNode;
                pathSuccess = true;
                break;
            }

            foreach (var neighbourPoint in neighbours[currentNode.position])
            {
                var neighbour = new AStarNodeFloat(neighbourPoint);
                if (closedSet.Contains(neighbour)) //Already done this node (road nodes can see both sides, not just one way
                {
                    continue;
                }

                float newMovementCostToNeighbour = currentNode.GCost + ManhattanDistanceFloat(currentNode, neighbour);
                if (newMovementCostToNeighbour < neighbour.GCost || !openSet.Contains(neighbour))
                {
                    neighbour.GCost = newMovementCostToNeighbour;
                    neighbour.HCost = ManhattanDistanceFloat(neighbour, endNode);
                    neighbour.parent = currentNode;

                    if (!openSet.Contains(neighbour))
                    {
                        openSet.Add(neighbour);
                    }
                    else
                    {
                        openSet.UpdateItem(neighbour);
                    }
                }
            }
        }

        if (pathSuccess)
        {
            var waypoints = RetracePathFloat(startNode, endNode);
            pathSuccess = waypoints.Count > 0;
            return waypoints;
        }

        return new List<Vector2>();
    }

    List<Vector2> RetracePathFloat(AStarNodeFloat startNode, AStarNodeFloat endNode)
    {
        List<AStarNodeFloat> path = new List<AStarNodeFloat>();
        AStarNodeFloat currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Add(startNode);
        return path.Select(x => new Vector2(x.position.x, x.position.z)).Reverse().ToList();
    }

    Vector3[] SimplifyPathFloat(List<AStarNodeFloat> path)
    {
        List<Vector3> waypoints = new List<Vector3>();
        Vector2 directionOld = Vector2.zero;

        for (int i = 1; i < path.Count; i++)
        {
            Vector2 directionNew = new Vector2(path[i - 1].position.x - path[i].position.x, path[i - 1].position.z - path[i].position.z);
            if (directionNew != directionOld)
            {
                waypoints.Add(path[i].position);
            }
            directionOld = directionNew;
        }
        return waypoints.ToArray();
    }

    float ManhattanDistanceFloat(AStarNodeFloat nodeA, AStarNodeFloat nodeB)
    {
        float dstX = Mathf.Abs(nodeA.position.x - nodeB.position.x);
        float dstY = Mathf.Abs(nodeA.position.z - nodeB.position.z);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }

    #endregion
}
