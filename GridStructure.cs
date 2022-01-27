using Assets.Scripts.Misc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridStructure
{
    private int cellSize = 3;
    Cell[,] gridGround;
    Cell[,] gridUnderGround;
    Dictionary<Type, List<Vertex>> structureTypeAtPositions;
    private static readonly object _lock = new object();
    WorldController worldController;

    //Keep track of multiple cells here, each cell needs to be as basic as possible, as they are kinda stupid, gridstructure may know what cells are linked

    public GridStructure(int cellSize, int width, int length, WorldController world = null)
    {
        this.cellSize = cellSize;
        gridGround = new Cell[width, length];
        for (int row = 0; row < gridGround.GetLength(0); row++)
        {
            for (int col = 0; col < gridGround.GetLength(1); col++)
            {
                gridGround[row, col] = new Cell();
            }
        }
        //5 Types => Null, Road, Facility, SingleStructure, Zone
        structureTypeAtPositions = new Dictionary<Type, List<Vertex>>(5);
        worldController = world;
    }

    public Vector3Int CalculateGridPosition(Vector3 inputPosition)
    {
        int x = Mathf.FloorToInt(inputPosition.x / cellSize);
        int z = Mathf.FloorToInt(inputPosition.z / cellSize);
        return new Vector3Int(x * cellSize, 0, z * cellSize);
    }

    public Dictionary<Type, List<Vertex>> GetStructureTypeAtPositions()
    {
        return structureTypeAtPositions;
    }

    public bool ArePositionsInRange(Vector3Int gridPosition, Vector3Int nearbyGridPosition, int range)
    {
        float distance = Vector2.Distance(CalculateGridIndex(gridPosition), CalculateGridIndex(nearbyGridPosition));
        return distance <= range;
    }

    public Vector3Int GetGridPositionFromIndex(Vector2Int tempPosition)
    {
        return new Vector3Int(tempPosition.x * cellSize, 0, tempPosition.y * cellSize);
    }

    public Vector2Int CalculateGridIndex(Vector3 gridPosition)
    {
        return new Vector2Int((int)gridPosition.x / cellSize, (int)gridPosition.z / cellSize);
    }

    public bool IsCellTaken(Vector3 gridPosition)
    {
        Vector2Int cellIndex = CalculateGridIndex(gridPosition);
        if (CheckValidCell(cellIndex))
        {
            lock (_lock)
            {
                return gridGround[cellIndex.y, cellIndex.x].IsTaken;
            }
        }

        throw new IndexOutOfRangeException("cellIndex not found in grid");
    }

    private bool IsCellIndexTaken(Vector2Int cellIndex)
    {
        if (CheckValidCell(cellIndex))
        {
            lock (_lock)
            {
                return gridGround[cellIndex.y, cellIndex.x].IsTaken;
            }
        }

        throw new IndexOutOfRangeException("cellIndex not found in grid");
    }

    public IEnumerable<StructureBaseSO> GetAllStructures()
    {
        List<StructureBaseSO> structures = new List<StructureBaseSO>();
        for (int row = 0; row < gridGround.GetLength(0); row++)
        {
            for (int col = 0; col < gridGround.GetLength(1); col++)
            {
                StructureBaseSO data = GetStructureDataFromCell(row, col);
                if (data != null)
                {
                    structures.Add(data);
                }
            }
        }
        return structures;
    }

    private enum SpiralDirection
    {
        Up, Left, Down, Right
    };

    public bool AreCellsInSpiralClockwiseTaken(Vector3 gridPosition, int cells)
    {
        Vector2Int cellIndex = CalculateGridIndex(gridPosition);
        List<Vector2Int> results = GetCellIndicesInSpiralClockwise(cellIndex, cells);
        return IsAnyCellIndexTaken(results);
    }

    public bool IsAnyCellIndexTaken(List<Vector2Int> results)
    {
        foreach (var pos in results)
        {
            if (IsCellIndexTaken(pos) && CheckValidCell(pos))
            {
                return true;
            }
        }
        return false;
    }

    public List<Vector2Int> GetCellIndicesInSpiralClockwise(Vector3Int gridPosition, int cells)
    {
        Vector2Int cellIndex = CalculateGridIndex(gridPosition);
        return GetCellIndicesInSpiralClockwise(cellIndex, cells);
    }

    public List<Vector2Int> GetCellIndicesInSpiralClockwise(Vector2Int gridIndex, int cells)
    {
        int moveAmount = 1;
        SpiralDirection dir = SpiralDirection.Up;
        int cellsChecked = 1; //Our first one is detected
        List<Vector2Int> spiralPositions = new List<Vector2Int>();

        for (int i = 1; i < cells; i++)
        {
            for (int m = 0; m < moveAmount; m++)
            {
                if (cellsChecked >= cells)
                    return spiralPositions;

                switch (dir)
                {
                    case SpiralDirection.Right:
                        gridIndex += Vector2Int.right;
                        break;
                    case SpiralDirection.Up:
                        gridIndex += Vector2Int.up;
                        break;
                    case SpiralDirection.Left:
                        gridIndex += Vector2Int.right;
                        break;
                    case SpiralDirection.Down:
                        gridIndex += Vector2Int.down;
                        break;
                }

                spiralPositions.Add(gridIndex);

                cellsChecked++;
            }

            dir = (SpiralDirection)(i % 4);
            moveAmount += (i % 2 - 1) * -1;
        }
        return spiralPositions;
    }

    private StructureBaseSO GetStructureDataFromCell(int row, int col)
    {
        lock (_lock)
        {
            var parent = gridGround[row, col].GetParent();
            if (parent.vertexHasData)
            {
                return gridGround[parent.y, parent.x].GetStructureData();
            }
            return gridGround[row, col].GetStructureData();
        }
    }

    public IEnumerable<StructureBaseSO> GetAllStructures(Type StructureBaseSOType)
    {
        if (StructureBaseSOType.BaseType != typeof(StructureBaseSO)) return null;

        List<StructureBaseSO> structures = new List<StructureBaseSO>();
        lock (_lock) //Lock since we are modifying our collection
        {
            if (structureTypeAtPositions.ContainsKey(StructureBaseSOType))
            {
                List<Vertex> gridOfType = structureTypeAtPositions[StructureBaseSOType];

                foreach (Vertex gridPosition in gridOfType)
                {
                    var data = GetStructureDataFromCell(gridPosition.y, gridPosition.x);
                    if (data != null)
                    {
                        structures.Add(data);
                    }
                }
            }
            else
            {
                structureTypeAtPositions.Add(StructureBaseSOType, new List<Vertex>());
            }
        }

        return structures;
    }

    public void PlaceStructureOnGrid(GameObject structure, Vector3 gridPosition, StructureBaseSO structureData)
    {
        var cellIndex = CalculateGridIndex(gridPosition);
        if (CheckValidCell(cellIndex))
        {
            lock (_lock) //Lock since we are modifying our collection
            {
                List<Vector2Int> childCellIndices = new List<Vector2Int>();

                if (structureData != null && structureData.GetType() == typeof(ZoneStructureSO))
                {
                    childCellIndices = GetCellIndicesInSpiralClockwise(cellIndex, structureData.cellSize);
                    structure.AddComponent<EstateObject>().PrepareEstate(structureData, worldController);
                }
                var parentCell = gridGround[cellIndex.y, cellIndex.x];
                var gridVertex = new Vertex(cellIndex.y, cellIndex.x);

                parentCell.SetConstruction(structure, structureData);

                foreach (var child in childCellIndices)
                {
                    gridGround[child.y, child.x].SetParent(gridVertex);
                    var childVertex = new Vertex(child.y, child.x);
                    parentCell.AddChild(childVertex);
                }

                if (structureData != null)
                {
                    var structureDataType = structureData.GetType();
                    if (!structureTypeAtPositions.ContainsKey(structureData.GetType()))
                    {
                        structureTypeAtPositions.Add(structureDataType, new List<Vertex>());
                    }

                    if (!structureTypeAtPositions[structureDataType].Contains(gridVertex))
                    {
                        structureTypeAtPositions[structureDataType].Add(gridVertex);
                    }
                }
            }
        }
    }

    public GameObject GetStructureFromGrid(Vector3 gridPosition)
    {
        Vector2Int cellIndex = CalculateGridIndex(gridPosition);
        lock (_lock)
        {
            var parent = gridGround[cellIndex.y, cellIndex.x].GetParent();
            if (parent.vertexHasData)
            {
                return gridGround[parent.y, parent.x].GetStructure();
            }
            return gridGround[cellIndex.y, cellIndex.x].GetStructure();
        }
    }

    public StructureBaseSO GetStructureDataFromGrid(Vector3 gridPosition)
    {
        Vector2Int cellIndex = CalculateGridIndex(gridPosition);
        return GetStructureDataFromCell(cellIndex.y, cellIndex.x);
    }

    public HashSet<Vector3Int> GetAllPositionsFromTo(Vector3Int minPoint, Vector3Int maxPoint)
    {

        HashSet<Vector3Int> positionsToReturn = new HashSet<Vector3Int>();
        for (int row = minPoint.z; row <= maxPoint.z; row++)
        {
            for (int col = minPoint.x; col <= maxPoint.x; col++)
            {
                Vector3Int gridPosition = CalculateGridPosition(new Vector3(col, 0, row));
                positionsToReturn.Add(Vector3Int.FloorToInt(gridPosition));
            }
        }
        return positionsToReturn;
    }

    public void RemoveStructureFromTheGrid(Vector3 gridPosition)
    {
        Vector2Int cellIndex = CalculateGridIndex(gridPosition);
        Type cellType = null;
        Cell cell = null;
        lock (_lock)
        {
            cell = gridGround[cellIndex.y, cellIndex.x];
            cellType = cell.GetStructureData()?.GetType();
        }
        if (cellType != null)
        {
            Vertex structureTypeAtPosition = structureTypeAtPositions[cellType].Where(x => x.Equals(new Vertex(cellIndex.y, cellIndex.x))).SingleOrDefault();
            if (structureTypeAtPosition.vertexHasData)
            {
                structureTypeAtPositions[cellType].Remove(structureTypeAtPosition);
            }
        }
        if (cell != null)
        {
            cell.RemoveStructure();
        }

    }

    private bool CheckValidCell(Vector2Int cellIndex)
    {
        return cellIndex.x >= 0 && cellIndex.x < gridGround.GetLength(1) && cellIndex.y >= 0 && cellIndex.y < gridGround.GetLength(0);
    }

    public Vector3Int? GetPositionOfTheNeighbourIfExists(Vector3 gridPosition, Direction direction)
    {
        Vector3Int? neighbourPosition = Vector3Int.FloorToInt(gridPosition);

        switch (direction)
        {
            case Direction.Up:
                neighbourPosition += new Vector3Int(0, 0, cellSize);
                break;
            case Direction.Right:
                neighbourPosition += new Vector3Int(cellSize, 0, 0);
                break;
            case Direction.Down:
                neighbourPosition += new Vector3Int(0, 0, -cellSize);
                break;
            case Direction.Left:
                neighbourPosition += new Vector3Int(-cellSize, 0, 0);
                break;
        }

        Vector2Int index = CalculateGridIndex(neighbourPosition.Value);
        if (!CheckValidCell(index))
        {
            return null;
        }

        return neighbourPosition;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="originCellGridPosition"></param>
    /// <param name="range">Range of building within a circle, if the circle only covers half a grid point, it is not included</param>
    /// <param name="structureType">Only get certain structures</param>
    /// <returns></returns>
    public IEnumerable<StructureBaseSO> GetStructuresDataInRange(Vector3 originCellGridPosition, int range, Type structureType = null)
    {
        var cellIndex = CalculateGridIndex(originCellGridPosition);
        List<StructureBaseSO> listToReturn = new List<StructureBaseSO>(range > 0 ? ((range * 2 + 1) * (range * 2 + 1)) : 1);
        if (!CheckValidCell(cellIndex))
        {
            return listToReturn;
        }

        for (int row = cellIndex.y - range; row <= cellIndex.y + range; row++)
        {
            for (int col = cellIndex.x - range; col <= cellIndex.x + range; col++)
            {
                if (cellIndex.x == col && cellIndex.y == row) continue; //Don't include self.

                var tempPosition = new Vector2Int(col, row);
                if (CheckValidCell(tempPosition) && Vector2.Distance(cellIndex, tempPosition) <= range)
                {
                    var data = GetStructureDataFromCell(row, col);
                    if (data != null)
                    {
                        if (structureType == null || data.GetType() == structureType)
                        {
                            listToReturn.Add(data);
                        }
                    }
                }
            }
        }
        return listToReturn;
    }

    public List<Vector3Int> GetStructurePositionsInRange(Vector3Int gridPosition, int range)
    {
        var cellIndex = CalculateGridIndex(gridPosition);
        List<Vector3Int> listToReturn = new List<Vector3Int>(range > 0 ? ((range * 2 + 1) * (range * 2 + 1)) : 1);
        if (!CheckValidCell(cellIndex))
        {
            return listToReturn;
        }

        for (int row = cellIndex.y - range; row <= cellIndex.y + range; row++)
        {
            for (int col = cellIndex.x - range; col <= cellIndex.x + range; col++)
            {
                var tempPosition = new Vector2Int(col, row);
                if (CheckValidCell(tempPosition) && Vector2.Distance(cellIndex, tempPosition) <= range)
                {
                    var data = GetStructureDataFromCell(row, col);
                    if (data != null)
                    {
                        listToReturn.Add(GetGridPositionFromIndex(tempPosition));
                    }
                }
            }
        }
        return listToReturn;
    }

    public void AddNatureObject(Vector3 position, GameObject element)
    {
        var gridPosition = CalculateGridPosition(position);
        var cellIndex = CalculateGridIndex(gridPosition);
        gridGround[cellIndex.y, cellIndex.x].AddNatureObject(element);
    }

    public List<GameObject> GetNatureObjectsToRemove(Vector3 position)
    {
        lock (_lock)
        {
            var gridPosition = CalculateGridPosition(position);
            var cellIndex = CalculateGridIndex(gridPosition);
            return gridGround[cellIndex.y, cellIndex.x].GetNatureObjectsOnCell();
        }
    }

    public void AddNatureObject(Vector3Int gridPosition, GameObject element)
    {
        var cellIndex = CalculateGridIndex(gridPosition);
        gridGround[cellIndex.y, cellIndex.x].AddNatureObject(element);
    }

    public List<GameObject> GetNatureObjectsToRemove(Vector3Int gridPosition)
    {
        var cellIndex = CalculateGridIndex(gridPosition);
        return gridGround[cellIndex.y, cellIndex.x].GetNatureObjectsOnCell();
    }
}

public enum Direction
{
    None = 0,
    Up = 1,
    Right = 2,
    Down = 4,
    Left = 8
}