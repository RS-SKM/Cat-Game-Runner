using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public LevelPiece[] levelPieces;
    public Transform _camera;
    public int drawDistance;

    public float pieceLenght;
    public float speed;

    Queue<GameObject> activePieces = new Queue<GameObject>();
    List<int> probabilityList = new List<int>();

    int currentCamStep = 0;
    int lastCamStep = 0;

    private void Start()
    {
        BuildProbabilityList();

        for (int i = 0; i < drawDistance; i++)
        {
            SpawnNewLevelPieces();
        }

        currentCamStep = (int)(_camera.transform.position.x / pieceLenght);
        lastCamStep = currentCamStep;

    }


    private void Update()
    {
        _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, _camera.transform.position + Vector3.right, Time.deltaTime * speed);
        
        currentCamStep = (int)(_camera.transform.position.x / pieceLenght);
        if (currentCamStep != lastCamStep)
        {
            lastCamStep = currentCamStep;
            DespawnLevelPiece();
            SpawnNewLevelPieces();
        }

    }

    void SpawnNewLevelPieces()
    {
        int pieceindex = probabilityList[Random.Range(0, probabilityList.Count)];
        GameObject newLevelPiece = Instantiate(levelPieces[pieceindex].prefab, new Vector3((currentCamStep + activePieces.Count) * pieceLenght, 0f), Quaternion.identity);
        activePieces.Enqueue(newLevelPiece);
    }

    void DespawnLevelPiece()
    {
        GameObject oldLevelPiece = activePieces.Dequeue();
        Destroy(oldLevelPiece); 
    }

    void BuildProbabilityList()
    {
        int index = 0;
        foreach (LevelPiece piece in levelPieces)
        {
            for (int i = 0; i < piece.probability; i++)
            {
                probabilityList.Add(index);
            }

            index++;
        }
    }

}





[System.Serializable]
public class LevelPiece
{
    public string name;
    public GameObject prefab;
    public int probability = 1;

}
