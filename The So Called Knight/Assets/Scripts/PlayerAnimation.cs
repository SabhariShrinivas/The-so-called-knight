using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void PlayWalk(int walk)
    {
        anim.SetInteger(TagManager.WALK_ANIMATION_PARAM, walk);
    }
    public void PlayJumpAndFall(int jumpFall)
    {
        anim.SetInteger(TagManager.JUMP_ANIMATION_PARAM, jumpFall);
    }
    public void PlayAnimationWithName(string amimName)
    {
        anim.Play(amimName);
    }
}
