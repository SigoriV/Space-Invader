using UnityEngine;
using System.Collections;

public class InvadersManager : MonoBehaviour
{
		public Transform invader1Prefab;
		public Transform invader2Prefab;
		public Transform invader3Prefab;
		private Transform[] invaders;
		private bool goingRight;

		// Use this for initialization
		void Start ()
		{
				invaders = new Transform[100];
				int index = 0;
				for (int i = 0; i < 6; i++) {
						for (int j = 0; j < 12; j++) {
								if (i <= 1) {
										invaders [index] = Instantiate (invader3Prefab) as Transform;
										invaders [index].transform.position = new Vector2 (j * 2.2f - 12, i * 2.2f);
								}
								if (i == 4 || i == 5) {
										invaders [index] = Instantiate (invader2Prefab) as Transform;
										invaders [index].transform.position = new Vector2 (j * 2.2f - 12, i * 2.2f);
								}
								if (i == 2 || i == 3) {
										invaders [index] = Instantiate (invader1Prefab) as Transform;
										invaders [index].transform.position = new Vector2 (j * 2.2f - 12, i * 2.2f);
								}
								invaders[index].transform.parent = transform;
								index = index + 1;
						}

						
				}
		}
	
		// Update is called once per frame
		void Update ()
		{

		Debug.Log (goingRight);

		for (int i = 0; i < invaders.Length; i++) {
			int x = 1;
			if(goingRight == true){
				x = -1;
			}
			if(goingRight == false){
				x = 1;
			}

			if(invaders[i] != null){
				invaders[i].transform.Translate(3*x* Time.deltaTime, 0, 0);
			}
		}
		}

		public void moveInvadersCloser (bool right)
		{
		goingRight = !right;
		for (int i = 0; i < invaders.Length; i++) {
			if(invaders[i] != null){
				invaders[i].transform.Translate(0, -1, 0);
			}

		}
		}

		public void destroyInvader (Transform invader)
		{
				for (int i = 0; i < invaders.Length; i++) {
						if (invaders [i] == invader) {
								Destroy (invader.gameObject);
								invaders [i] = null;
								
						}
				}
		}

}
