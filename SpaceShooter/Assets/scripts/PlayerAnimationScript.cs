using UnityEngine;

/*
 * Script that handles animations of the Alien.
 */
public class PlayerAnimationScript : MonoBehaviour
{
    private Animator anim;
    int jiggleHash;

    void Start()
    {
        anim = GetComponent<Animator>();
        jiggleHash = Animator.StringToHash("jiggle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))// && (stateInfo.fullPathHash != jiggleHash))
        {
            anim.SetTrigger(jiggleHash);
        }
    }
}
