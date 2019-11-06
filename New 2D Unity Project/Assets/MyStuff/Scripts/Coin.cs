using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectible
{
    public override void HandleCollected()
    {
        base.HandleCollected();
        CollectibleManager.Instance.HandleCoinCollected();
        SoundManager.Instance.PlayCoinCollectSound();
    }
}
