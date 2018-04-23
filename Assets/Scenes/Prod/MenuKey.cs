 using UnityEngine;
 using System.Collections;
 
 using UnityEditor;
 using UnityEngine.UI;
 
 public class MenuKey : MonoBehaviour{
	private string[] keyNames = new string[9];

	public GameObject L_Left;
	public GameObject L_Right;
	public GameObject L_Down;
	public GameObject L_Up;

	public GameObject R_Left;
	public GameObject R_Right;
	public GameObject R_Down;
	public GameObject R_Up;

	public GameObject Attack;

	void Start() {
		ReadAxes();

		L_Left.transform.GetChild(0).GetComponent<Text>().text = keyNames[0];
		L_Right.transform.GetChild(0).GetComponent<Text>().text = keyNames[1];
		L_Down.transform.GetChild(0).GetComponent<Text>().text = keyNames[2];
		L_Up.transform.GetChild(0).GetComponent<Text>().text = keyNames[3];

		R_Left.transform.GetChild(0).GetComponent<Text>().text = keyNames[4];
		R_Right.transform.GetChild(0).GetComponent<Text>().text = keyNames[5];
		R_Down.transform.GetChild(0).GetComponent<Text>().text = keyNames[6];
		R_Up.transform.GetChild(0).GetComponent<Text>().text = keyNames[7];

		Attack.transform.GetChild(0).GetComponent<Text>().text = keyNames[8];
	}

	void Update() {
		float baseColor = 0.5f;
		L_Right.GetComponent<Image>().color = new Color(1,1,1, Mathf.Clamp01(Input.GetAxisRaw("Horizontal Left")) + baseColor);
		L_Left.GetComponent<Image>().color = new Color(1,1,1, Mathf.Clamp01(-Input.GetAxisRaw("Horizontal Left")) + baseColor);

		L_Up.GetComponent<Image>().color = new Color(1,1,1, Mathf.Clamp01(Input.GetAxisRaw("Vertical Left")) + baseColor);
		L_Down.GetComponent<Image>().color = new Color(1,1,1, Mathf.Clamp01(-Input.GetAxisRaw("Vertical Left")) + baseColor);
		
		R_Right.GetComponent<Image>().color = new Color(1,1,1, Mathf.Clamp01(Input.GetAxisRaw("Horizontal Right")) + baseColor);
		R_Left.GetComponent<Image>().color = new Color(1,1,1, Mathf.Clamp01(-Input.GetAxisRaw("Horizontal Right")) + baseColor);
		
		R_Up.GetComponent<Image>().color = new Color(1,1,1, Mathf.Clamp01(Input.GetAxisRaw("Vertical Right")) + baseColor);
		R_Down.GetComponent<Image>().color = new Color(1,1,1, Mathf.Clamp01(-Input.GetAxisRaw("Vertical Right")) + baseColor);

		Attack.GetComponent<Image>().color = new Color(1,1,1, (Input.GetButton("Fire1") ? 1 : 0) + baseColor);
	}


	public void ReadAxes() {
		var inputManager = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0];

		SerializedObject obj = new SerializedObject(inputManager);

		SerializedProperty axisArray = obj.FindProperty("m_Axes");

		for( int i = 0; i < 4; ++i ) {
			var axis = axisArray.GetArrayElementAtIndex(i);

			keyNames[i*2] = axis.FindPropertyRelative("negativeButton").stringValue;
			keyNames[i*2+1] = axis.FindPropertyRelative("positiveButton").stringValue;
		}
		
		keyNames[8] = axisArray.GetArrayElementAtIndex(4).FindPropertyRelative("positiveButton").stringValue;
	}
 
 }