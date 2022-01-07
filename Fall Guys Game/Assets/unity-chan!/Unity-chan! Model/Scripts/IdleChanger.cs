using UnityEngine;
using System.Collections;

namespace UnityChan
{
//
// ↑↓キーでループアニメーションを切り替えるスクリプト（ランダム切り替え付き）Ver.3
// 2014/04/03 N.Kobayashi
//

// Require these components when using this script
	[RequireComponent(typeof(Animator))]



	public class IdleChanger : MonoBehaviour
	{
	
		private Animator anim;                      //Animator에 대한 참조
		private AnimatorStateInfo currentState;     // 현재 상태 상태를 저장하는 참조
		private AnimatorStateInfo previousState;    // 이전 상태 상태를 저장하는 참조
		public bool _random = false;                // 랜덤 판정 스타트 스위치
		public float _threshold = 0.5f;             // 랜덤 판정 임계값
		public float _interval = 10f;				// 랜덤 판정의 간격
		//private float _seed = 0.0f;					// ランダム判定用シード
	


		// Use this for initialization
		void Start ()
		{
			// 各参照の初期化
			anim = GetComponent<Animator> ();
			currentState = anim.GetCurrentAnimatorStateInfo (0);
			previousState = currentState;
			// 	랜덤 판정 함수를 시작한다.
			StartCoroutine ("RandomChange");
		}
	
		// Update is called once per frame
		void  Update ()
		{
			// ↑키/스페이스를 누르면 상태를 다음으로 보내는 처리
			if (Input.GetKeyDown ("up") || Input.GetButton ("Jump")) {
				// bool Next를 true로 설정
				anim.SetBool ("Next", true);
			}

			// ↓키를 누르면 상태를 이전으로 되돌리는 처리
			if (Input.GetKeyDown ("down")) {
				// bool Back을 true로 설정
				anim.SetBool ("Back", true);
			}

			// "Next" 플래그가 true 일 때 처리
			if (anim.GetBool ("Next")) {
				// 현재 상태를 확인하고 상태 이름이 다른 경우 부울을 false로 되돌립니다.
				currentState = anim.GetCurrentAnimatorStateInfo (0);
				if (previousState.nameHash != currentState.nameHash) {
					anim.SetBool ("Next", false);
					previousState = currentState;				
				}
			}

			// "Back"플래그가 true일 때 처리
			if (anim.GetBool ("Back")) {
				// 현재 상태를 확인하고 상태 이름이 다른 경우 bool를 false로 되돌립니다.
				currentState = anim.GetCurrentAnimatorStateInfo (0);
				if (previousState.nameHash != currentState.nameHash) {
					anim.SetBool ("Back", false);
					previousState = currentState;
				}
			}
		}

		void OnGUI ()
		{
			GUI.Box (new Rect (Screen.width - 110, 10, 100, 90), "Change Motion");
			if (GUI.Button (new Rect (Screen.width - 100, 40, 80, 20), "Next"))
				anim.SetBool ("Next", true);
			if (GUI.Button (new Rect (Screen.width - 100, 70, 80, 20), "Back"))
				anim.SetBool ("Back", true);
		}


		// 랜덤 판정용 함수
		IEnumerator RandomChange ()
		{
			// 무한 루프 시작
			while (true) {
				//랜덤 판정 스위치 온의 경우
				if (_random) {
					// 	랜덤 시드를 꺼내, 그 크기에 의해 플래그 설정을 한다
					float _seed = Random.Range (0.0f, 1.0f);
					if (_seed < _threshold) {
						anim.SetBool ("Back", true);
					} else if (_seed >= _threshold) {
						anim.SetBool ("Next", true);
					}
				}
				// 다음 판정까지 인터벌을 둔다
				yield return new WaitForSeconds (_interval);
			}

		}

	}
}
