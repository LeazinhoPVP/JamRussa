using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlay : MonoBehaviour
{
    public PlayerAttack player;

    public void atira()
    {
        player.Shoot();
    }
    public void termine()
    {
        player.EndedAnimation();
    }
}
