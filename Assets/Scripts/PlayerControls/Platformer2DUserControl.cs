using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private WeaponController m_Weapon;
        private bool m_Jump;
        private bool m_Shoot;
        private bool m_WantsToJump;
        
        public int jumpsCounter = 0;
        public int jumpsMax = 1;
        public float distToGround;
        public bool isGrounded;

        public float minSwipeDistY;
		private Touch initialTouch = new Touch();
		private float distance = 0;
        private Vector2 startPos;
        
        private PlayerInfo pi;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            m_Weapon = GetComponentInChildren<WeaponController>();
            
            m_Jump = false;
            
            distToGround = GetComponent<BoxCollider2D>().bounds.extents.y;
            
            this.pi = PlayerInfo.Instance;
            pi.LoadPlayerInfo();
            
            
            this.jumpsMax += Convert.ToInt32(pi.storeJump[0]) +
                             Convert.ToInt32(pi.storeJump[1]) +
                             Convert.ToInt32(pi.storeJump[2]);
        }


        private void Update()
        {
#if UNITY_ANDROID
            if (Input.touchCount > 0)
            {
                Touch myTouch = Input.GetTouch(0);

                if (myTouch.phase == TouchPhase.Began)
                {
                    startPos = myTouch.position;
                }

                else if (myTouch.phase == TouchPhase.Ended)
                {
                    float swipeDistVertical = (new Vector3(0, myTouch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                    if (swipeDistVertical > minSwipeDistY)
                    {
                        float swipeValue = Mathf.Sign(myTouch.position.y - startPos.y);
                        if (swipeValue > 0)
                        {
                            //up swipe JUMP
                            m_WantsToJump = true;
                        }
                    }

                    else
                    {
                        m_Shoot = true;
                    }
                }
            }


#else
			m_WantsToJump = CrossPlatformInputManager.GetButtonDown("Jump");
			m_Shoot = CrossPlatformInputManager.GetButtonDown("Fire1");
#endif

            if (m_Shoot)
            {
                m_Weapon.Attack();
                m_Shoot = false;
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            //bool crouch = Input.GetKey(KeyCode.LeftControl);
			bool crouch = false;
            
            //if (!m_Jump && m_WantsToJump && jumpsCounter < jumpsMax)
            if (m_WantsToJump && jumpsCounter < jumpsMax)
            {
                Debug.Log("Jump");
                jumpsCounter++;
                
                m_Jump = true;
                m_WantsToJump = false;
            }
            else if (m_Character.m_Rigidbody2D.velocity.y <= 0.1f &&
                     m_Character.m_Rigidbody2D.velocity.y >= -0.1f)
            {                
                jumpsCounter = 0;
            }
            
            // Pass all parameters to the character control script.
            m_Character.Move(1, crouch, m_Jump);
                
            m_Jump = false;
        }
    }
    

}
