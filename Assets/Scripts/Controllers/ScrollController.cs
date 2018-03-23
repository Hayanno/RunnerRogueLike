using UnityEngine;

public class ScrollController : MonoBehaviour {
    public float scrollSpeed = 5.0f;

    private float posXToDestroy = -15.0f;
    private bool isScrolling;

    void Update() {
        if (!isScrolling) return;

        ScrollObjects();
    }

    private void ScrollObjects() {
        GameObject currentChild;

        for (int i = 0; i < transform.childCount; i++) {
            currentChild = transform.GetChild(i).gameObject;
            ScrollObject(currentChild);

            if (currentChild.transform.position.x <= posXToDestroy) {
                Destroy(currentChild);
            }
        }
    }

    private void ScrollObject(GameObject go) {
        go.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
    }

    public void StartScrolling() {
        isScrolling = true;
    }

    public void StopScrolling() {
        isScrolling = false;
    }
}
