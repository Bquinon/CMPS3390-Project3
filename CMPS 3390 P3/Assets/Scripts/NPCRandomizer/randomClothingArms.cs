using UnityEngine;

public class randomClothingArms : MonoBehaviour
{
    public Sprite[] sprites;
    public randomClothing randCloth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[randCloth.clothNum];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
