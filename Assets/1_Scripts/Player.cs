using StarterAssets;
using UnityEngine;

public class Player : Character
{
    private int maxCountBullets, currentCountBullet, countBullet;

    protected override void Death()
    {
        GetComponent<FirstPersonController>().enabled = false;
        GameController.Instance.PlayerDeath();
        GetComponent<Animator>().enabled = true;
        GetComponent<Animator>().SetTrigger("Death");
    }
}
