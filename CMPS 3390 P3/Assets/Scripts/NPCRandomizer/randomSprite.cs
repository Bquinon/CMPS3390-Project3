using UnityEngine;

public class randomSprite : MonoBehaviour
{
    public Sprite[] sprites;
    public int spriteIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteIndex = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

