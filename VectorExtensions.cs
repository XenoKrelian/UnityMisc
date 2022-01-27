using UnityEngine;

public static class Extensions
{
    public static Vector2Int ToInt2InGrid(this Vector2 v)
    {
        return new Vector2Int(Mathf.RoundToInt(v.x + .5f), Mathf.RoundToInt(v.y));
    }

    public static Vector2Int ToInt2(this Vector2 v)
    {
        return new Vector2Int((int)v.x, (int)v.y);
    }

    public static Vector2Int SnapToGrid(this Vector2 moveToPos, Transform transform, float gridSize = 1f)
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x + moveToPos.x / gridSize) * gridSize;
        snapPos.y = Mathf.RoundToInt(transform.position.y + moveToPos.y / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z);
        return new Vector2Int((int)snapPos.x, (int)snapPos.y);
    }
}