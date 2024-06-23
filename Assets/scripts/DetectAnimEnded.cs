using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAnimEnded : MonoBehaviour
{
    Animator animator;
    public GameObject virus;
    public GameObject head;
    Animator selfAnimator;
    Vector3 selfPos;
    Vector3 virusPos;

    // Start is called before the first frame update
    void Start()
    {
        animator = virus.GetComponent<Animator>();
        selfAnimator = gameObject.GetComponent<Animator>();
        selfPos = gameObject.transform.position;
        virusPos = virus.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((animator.GetCurrentAnimatorStateInfo(0).IsName("move in")))
        {
            selfAnimator.SetBool("movetwoobj", true);
            animator.SetBool("movetwoobj", true);
            StartCoroutine(DisableAll());
        }
    }

    IEnumerator DisableAll()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        head.SetActive(false);
        gameObject.transform.position = selfPos;
        animator.SetBool("movetwoobj", false);
    }
}
