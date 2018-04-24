 using UnityEngine;
 using System.Collections;
 
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

	private float baseColor = 0.5f;

	void Update() {
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
 
 }