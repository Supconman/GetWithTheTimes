using UnityEngine;

public class GetMallScreenshot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rect SpritePosition = new Rect(0, 0, GlobalManager.globalInstance.battleBackground.width, GlobalManager.globalInstance.battleBackground.height);

        Sprite newSprite = Sprite.Create(GlobalManager.globalInstance.battleBackground, SpritePosition, SpritePosition.center, 1.0f);

        GetComponent<SpriteRenderer>().sprite = newSprite;
    }
}
