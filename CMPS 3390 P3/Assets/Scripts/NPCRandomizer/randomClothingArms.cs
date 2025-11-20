using UnityEngine;

public class randomClothingArms : MonoBehaviour
{
    public Sprite[] sprites;
    public randomClothing clothType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int armCloth = clothType.clothNum;
        GetComponent<SpriteRenderer>().sprite = sprites[armCloth];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
