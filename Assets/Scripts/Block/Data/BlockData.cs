using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newBlockData", menuName = "Data/Block Data/Base Data")]
public class BlockData : ScriptableObject {

    [Header("Red")]
    public Sprite redBlockSprite;

    [Header("Yellow")]
    public Sprite yellowBlockSprite;

    [Header("Green")]
    public Sprite greenBlockSprite;

}
