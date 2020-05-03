using UnityEngine;
using System.Collections;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class controllermanager : MonoBehaviour
{
	public XRController leftHand;
	public XRController rightHand;
	public movement movement;
	

	private void Update()
	{


		bool gripL = false;
		bool b1L = false;
		bool b2L = false;
		bool triggerL = false;
		bool primaryAxisTouchL = false;
		bool primaryTouchL = false;
		bool secondaryTouchL = false;
		float triggerDownL = 0;
		Vector3 positionL = Vector3.zero;
		Vector3 velocityL = Vector3.zero;
		Quaternion rotationL = new Quaternion();


		bool gripR = false;
		bool triggerR = false;
		bool primaryAxisTouchR = false;
		bool primaryTouchR = false;
		bool secondaryTouchR = false;
		float triggerDownR = 0;
		bool b1R= false;
		bool b2R = false;
		Vector3 positionR = Vector3.zero;
		Vector3 velocityR = Vector3.zero;
		Quaternion rotationR = new Quaternion();


	

		//1. Collect controller data
		InputDevice handL = InputDevices.GetDeviceAtXRNode(leftHand.controllerNode);
		InputDevice handR = InputDevices.GetDeviceAtXRNode(rightHand.controllerNode);
		handL.TryGetFeatureValue(CommonUsages.primaryButton, out b1L);
		handL.TryGetFeatureValue(CommonUsages.secondaryButton, out b2L);

		handL.TryGetFeatureValue(CommonUsages.gripButton, out gripL);
		handL.TryGetFeatureValue(CommonUsages.triggerButton, out triggerL);
		handL.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out primaryAxisTouchL);
		handL.TryGetFeatureValue(CommonUsages.primaryTouch, out primaryTouchL);
		handL.TryGetFeatureValue(CommonUsages.secondaryTouch, out secondaryTouchL);
		handL.TryGetFeatureValue(CommonUsages.trigger, out triggerDownL);
		handL.TryGetFeatureValue(CommonUsages.devicePosition, out positionL);
		handL.TryGetFeatureValue(CommonUsages.deviceVelocity, out velocityL);
		handL.TryGetFeatureValue(CommonUsages.deviceRotation, out rotationL);

		handR.TryGetFeatureValue(CommonUsages.gripButton, out gripR);
		handR.TryGetFeatureValue(CommonUsages.triggerButton, out triggerR);
		handR.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out primaryAxisTouchR);
		handR.TryGetFeatureValue(CommonUsages.primaryTouch, out primaryTouchR);
		handR.TryGetFeatureValue(CommonUsages.secondaryTouch, out secondaryTouchR);
		handR.TryGetFeatureValue(CommonUsages.trigger, out triggerDownR);
		handR.TryGetFeatureValue(CommonUsages.devicePosition, out positionR);
		handR.TryGetFeatureValue(CommonUsages.deviceVelocity, out velocityR);
		handR.TryGetFeatureValue(CommonUsages.deviceRotation, out rotationR);
		handR.TryGetFeatureValue(CommonUsages.primaryButton, out b1R);
		handR.TryGetFeatureValue(CommonUsages.secondaryButton, out b2R);


		if (b1L || b1R) {
			movement.Forward();
		
		}


	}
}