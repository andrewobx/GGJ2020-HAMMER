using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{

    private Animator _animator;

    private Transform _rHandTransform;
    private Transform _lHandTransform;

    private void Start()
    {
        _animator = FindObjectOfType<Animator>();

        _rHandTransform = _animator.GetBoneTransform(HumanBodyBones.RightHand);
        _lHandTransform = _animator.GetBoneTransform(HumanBodyBones.LeftHand);
    }

    private void OnAnimatorIK()
    {
        _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
        _animator.SetIKRotation(AvatarIKGoal.RightHand, Quaternion.AngleAxis(-15f, _rHandTransform.forward) * Quaternion.AngleAxis(15f, _rHandTransform.up));

        _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
        _animator.SetIKRotation(AvatarIKGoal.LeftHand, Quaternion.AngleAxis(15f, _lHandTransform.forward) * Quaternion.AngleAxis(-15f, _lHandTransform.up));
    }
}