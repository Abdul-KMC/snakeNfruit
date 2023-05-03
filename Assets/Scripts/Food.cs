using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private LevelManager gameLevelManager;
    public int foodValue;

    public BoxCollider2D GridArea;
    // Start is called before the first frame update
    private void Start()
    {
        RandomizePosition();
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            RandomizePosition();
            gameLevelManager.AddScore(foodValue);
        }
    }

    private void RandomizePosition() {
        Bounds bounds = this.GridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }
}
