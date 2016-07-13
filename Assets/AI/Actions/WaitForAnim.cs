using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class WaitForAnim : RAINAction
{
	Animator _animator;

    public override void Start(RAIN.Core.AI ai)
    {
		_animator = ai.Body.GetComponent<Animator>();
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		AnimatorStateInfo tInfo = _animator.GetCurrentAnimatorStateInfo(0);
		if (tInfo.normalizedTime < 1)
		{
			return ActionResult.RUNNING;
		}
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}