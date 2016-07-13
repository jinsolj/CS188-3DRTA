using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class ToggleCollider : RAINAction
{
	Collider col;
	Rigidbody rb;

    public override void Start(RAIN.Core.AI ai)
    {
		col = ai.Body.GetComponent<Collider>();
		rb = ai.Body.GetComponent<Rigidbody>();
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		rb.constraints ^= RigidbodyConstraints.FreezePositionY;
		col.enabled = !col.enabled;
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}