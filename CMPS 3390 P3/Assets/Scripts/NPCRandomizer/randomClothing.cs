using UnityEngine;

public class randomClothing : MonoBehaviour
{
    public Sprite[] sprites;
    public int clothNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clothNum = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[clothNum];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
