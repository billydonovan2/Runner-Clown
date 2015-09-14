using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;

		private Touch initialTouch = new Touch();
		private float distance = 0;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");

				if(m_Jump) Debug.Log ("jump");
            }

			/*foreach(Touch t in Input.touches)
			{
				if (t.phase == TouchPhase.Began)
				{
					initialTouch = t;
				}
				else if (t.phase == TouchPhase.Moved && !m_Jump)
				{
					float distance = initialTouch.position.y - t.position.y;

					if (distance > 100f)
					{						
						m_Jump = true;
					}
					
				}
				else if (t.phase == TouchPhase.Ended)
				{
					initialTouch = new Touch();
				}
			}*/

        }


        private void FixedUpdate()
        {
            // Read the inputs.
            //bool crouch = Input.GetKey(KeyCode.LeftControl);
			bool crouch = false;

            // float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(1, crouch, m_Jump);
            m_Jump = false;
        }
    }
}