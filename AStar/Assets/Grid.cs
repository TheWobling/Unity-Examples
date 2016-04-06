using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private GameObject _nodePrefab ;
    [SerializeField] private LayerMask _unwalkableMask;
    [SerializeField] private Vector2 _gridSize;
    [SerializeField] private float _nodeRadius;

    private GameObject[,] _grid;
    private float _nodeDiameter;

    private void Start()
    {
        _nodeDiameter = _nodeRadius * 2;
        CreateGrid();
    }

    private void CreateGrid()
    {
        _grid = new GameObject[(int)_gridSize.x, (int)_gridSize.y];

        for (var i = 0; i < _gridSize.x; i++)
        {
            for (var j = 0; j < _gridSize.y; j++)
            {
                Vector3 worldPoint = new Vector3(transform.position.x - _gridSize.x / 2 + i, 0.0f, transform.position.y - _gridSize.y / 2 + j);

                var node = Instantiate(_nodePrefab, new Vector3(worldPoint.x, worldPoint.y, worldPoint.z), 
                                                                       Quaternion.identity) as GameObject;
                if (node == null) return;
                node.name = "FlorNode: " + i + "," + j;

                bool walkable = !(Physics.CheckSphere(worldPoint, _nodeRadius));

                var tempNode = node.GetComponent<Node>();
                tempNode.Walkable = walkable;
                tempNode.WorldPosition = worldPoint;

                _grid[i, j] = node;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(_gridSize.x, 1, _gridSize.y));
    }
}
