// using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private List<Transform> segments;
    public Transform segmentPrefab;
    // Start is called before the first frame update
    void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)) {
            direction = Vector2.up;
        } else if(Input.GetKeyDown(KeyCode.S)) {
            direction = Vector2.down;
        } else if(Input.GetKeyDown(KeyCode.A)) {
            direction = Vector2.left;
        } else if(Input.GetKeyDown(KeyCode.D)) {
            direction = Vector2.right;
        } else if(Input.GetKeyDown(KeyCode.UpArrow)) {
            direction = Vector2.up;
        } else if(Input.GetKeyDown(KeyCode.DownArrow)) {
            direction = Vector2.down;
        } else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            direction = Vector2.left;
        } else if(Input.GetKeyDown(KeyCode.RightArrow)) {
            direction = Vector2.right;
        }
    }

    private void FixedUpdate() {
        for(int i = segments.Count-1; i>0; i--) {
            segments[i].position = segments[i-1].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y,
            0.0f
        );
    }

    private void Grow() {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    private void ResetState() {
        for(int i=1; i<segments.Count; i++) {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(this.transform);

        this.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Food") {
            Grow();
        } else if (other.tag == "bonus") {
            Grow();
            Grow();
            Grow();
        } else if (other.tag == "Obstacle") {
            ResetState();
        }
    }
}
