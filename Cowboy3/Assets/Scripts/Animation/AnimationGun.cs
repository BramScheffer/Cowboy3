using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationGun : MonoBehaviour
{
    public Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
