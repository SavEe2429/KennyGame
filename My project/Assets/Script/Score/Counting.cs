using TMPro;
using UnityEngine;

public class Counting : MonoBehaviour
{
    enum Axis { X, Y, Z }
    [SerializeField] Axis axis = Axis.Z;
     [SerializeField] int decimalScore = 3;
    [SerializeField] TextMeshProUGUI scoreLabel;
    [SerializeField] TextMeshProUGUI scoreLabelEnd;
    float startSpot;
    float destination;

    void Start()
    {
        startSpot = GetPosValue(transform.position);
    }

    void Update()
    {
        destination = GetPosValue(transform.position);
        float score = destination - startSpot;

        string format = $"F{decimalScore}";
        scoreLabel.text = $"Score : {score.ToString(format)}";
        scoreLabelEnd.text = $"Score : {score.ToString(format)}";
        // Debug.Log($"Score : {score.ToString(format)}");
    }

    float GetPosValue(Vector3 pos)
    {
        switch (axis)
        {
            case Axis.X: return pos.x;
            case Axis.Y: return pos.y;
            case Axis.Z: return pos.z;
            default : return 0;
        }
    }
}