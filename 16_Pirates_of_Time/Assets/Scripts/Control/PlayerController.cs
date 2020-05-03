using RPG.Combat;
using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Cannon cannonFirstRight;
        [SerializeField] Cannon cannonFirstLeft;
        [SerializeField] Cannon cannonFront;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            HandleUserInput();
            if (InteractWithMovement()) return;
        }

        private void HandleUserInput()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                cannonFirstRight.Shoot();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                cannonFront.Shoot();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                cannonFirstLeft.Shoot();
            }
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMoveAction(hit.point, 1f);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}

