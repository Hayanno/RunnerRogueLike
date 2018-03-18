using UnityEngine;

// This script is executed in the editor
[ExecuteInEditMode]
public class SnapToGrid : MonoBehaviour {
#if UNITY_EDITOR
    public bool snapToGrid = true;
    public float snapValue = 0.1f;

    public bool sizeToGrid = true;
    public float sizeValue = 0.1f;

    // Adjust size and position
    void Update() {
        if (!Application.isPlaying && snapValue != 0 && sizeValue != 0) {
            if (snapToGrid)
                transform.position = RoundTransform(transform.position, snapValue);

            if (sizeToGrid)
                transform.localScale = RoundTransform(transform.localScale, sizeValue);
        }
    }

    // The snapping code
    private Vector3 RoundTransform(Vector3 v, float snapValue) {
        return new Vector3(
            snapValue * Mathf.Round(v.x / snapValue),
            snapValue * Mathf.Round(v.y / snapValue),
            v.z
        );
    }
#endif
}