using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCreator : MonoBehaviour
{
    private enum ArrowPositions { Up = 0, Down = 1, Left = 2, Right = 3 }

    [SerializeField]
    private GameObject[] arrowSpawnPoints;
    [SerializeField]
    private Arrow arrowPrefab;

    private void Update()
    {
        Arrow arrowCreated = null;

        if(Input.GetKeyDown(KeyCode.I))
        {
            arrowCreated = Instantiate(arrowPrefab, arrowSpawnPoints[(int)ArrowPositions.Up].transform.position, Quaternion.identity);
            arrowCreated.InitializeArrow(-Vector2.up);
        }
        else if(Input.GetKeyDown(KeyCode.K))
        {
            arrowCreated = Instantiate(arrowPrefab, arrowSpawnPoints[(int)ArrowPositions.Down].transform.position, Quaternion.identity);
            arrowCreated.InitializeArrow(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            arrowCreated = Instantiate(arrowPrefab, arrowSpawnPoints[(int)ArrowPositions.Left].transform.position, Quaternion.identity);
            arrowCreated.InitializeArrow(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            arrowCreated = Instantiate(arrowPrefab, arrowSpawnPoints[(int)ArrowPositions.Right].transform.position, Quaternion.identity);
            arrowCreated.InitializeArrow(-Vector2.right);
        }
    }
}
