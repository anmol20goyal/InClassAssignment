using TMPro;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
	[SerializeField] private LookAtRayCast _lookAtRayCast;
	[SerializeField] private TMP_Text teleportTxt;
	[SerializeField] private LightUpHallway lightUpHall;
	
	private void OnTriggerEnter(Collider other)
	{
		switch (other.gameObject.tag)
		{
			case "Door":
				var anim = other.GetComponent<Animator>();
				anim.enabled = true;
				// anim.Play("fenceGateOpen");
				anim.Play("slideDoorOpen");
				break;
			case "Teleporter":
				teleportTxt.gameObject.SetActive(true);
				_lookAtRayCast.teleporter = other.gameObject.GetComponent<TeleportTarget>();
				break;
			case "Chair":
				var anim2 = other.GetComponent<Animator>();
				anim2.enabled = true;
				anim2.Play("rockingChairAnim");
				break;
			case "Enter":
				lightUpHall.StartLighting();
				break;
		}
		
	}

	private void OnTriggerExit(Collider other)
	{
		switch (other.gameObject.tag)
		{
			case "Door":
				var anim = other.GetComponent<Animator>();
				anim.enabled = true;
				anim.Play("slideDoorClose");
				break;
			case "Teleporter":
				teleportTxt.gameObject.SetActive(false);
				_lookAtRayCast.teleporter = null;
				break;
			case "Chair":
				var anim2 = other.GetComponent<Animator>();
				anim2.enabled = false;
				break;
		}
	}
}
