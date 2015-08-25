using UnityEngine;
using System.Collections;

public class SpriteManager : MonoBehaviour {

    private CharacterInfo myInfo;
    private SpriteRenderer spriteRenderer;

    void Awake() {
        myInfo = GetComponent<CharacterInfo>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = myInfo.mainSprite;
    }

    public void ChangeSprite(Sprite newSprite) {
        spriteRenderer.sprite = newSprite;
    }

}
