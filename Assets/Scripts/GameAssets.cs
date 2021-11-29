using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameAssets instance;

    private void Awake() 
    {
        instance = this;
    }

    public Sprite snakeHeadSprite;
    public Sprite foodSprite;
}
