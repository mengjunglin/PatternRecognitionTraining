using UnityEngine;
using System.Collections;

public class GeometryContent : Content
{
	private char[] nums = {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};

	public GeometryContent()
	{
		name = "Geometry";
		description = "Some description about Geometry!";
	}

	public string getName()
	{
		return name;
	}

	public override char getItem()
	{
		return nums[Random.Range(0, nums.Length)];
	}

	public override string getTerm()
	{
		return "Click the target shapes!";
	}

	protected override void customHook(Hook hook)
	{
		/*switch(hook.type)
		{
		case HookType.Compare:
			compareHook((CompareHook)hook);
			break;
		default:
			base.customHook(hook);
			break;
		}*/
	}

	/*private void compareHook(CompareHook hook)
	{
		bool smallest = true;
		for(int i = 0; i < hook.compares.Length; i++)
		{
			if(hook.compares[i] < hook.input)
			{
				smallest = false;
			}
		}
		if(smallest)
		{
			lastActionValid = true;
		}
		else
		{
			lastActionValid = false;
		}
	}*/
}
