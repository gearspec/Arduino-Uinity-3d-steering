using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{

    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
		public TextMesh NumValText;
		public TextMesh NumValInt;
		int steerVal;
		float h;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate ()
		{
			// pass the input to the car!
			steerVal = int.Parse (NumValText.text);
			NumValInt.text = steerVal.ToString ();

			float h = CrossPlatformInputManager.GetAxis ("Horizontal");
            
			if (steerVal > 450 && steerVal < 500) //neutral
			{
				h=0.5f;
			}

			if (steerVal > 500 && steerVal < 600) //right
			{
				h=0.55f;
			}
			if (steerVal > 600 && steerVal < 700) //right
			{
				h=0.65f;
			}
			if (steerVal > 700 && steerVal < 800) //right
			{
				h=0.75f;
			}
		    if (steerVal >= 800) //right
			{
				h=1.0f;
			}
			//---------------/.///
			
			if (steerVal < 450 && steerVal > 400) //left
			{
				h=-0.55f;
			}
			if (steerVal < 350 && steerVal > 200) //left
			{
				h=-0.65f;
			}
			if (steerVal < 200 && steerVal > 50) //left
			{
				h=-0.75f;
			}
			if (steerVal <= 50) //left
			{
				h=-1.0f;
			}
			

			//float h = steerVal*0.001f;
			float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
