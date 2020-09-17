using UnityEngine;
using System.Collections;
public class ScrollingUVs_Layers : MonoBehaviour 
{
	//public int materialIndex = 0;
	public string textureName = "_MainTex";
    Vector2 uvAnimationRate = new Vector2(1.0f, 0.0f);
    public float animationSpeed = 1f;
    Vector2 uvOffset = Vector2.zero;
	
	void LateUpdate() 
	{
		uvOffset += ( uvAnimationRate * Time.deltaTime / animationSpeed );
		if( GetComponent<Renderer>().enabled )
		{
			GetComponent<Renderer>().sharedMaterial.SetTextureOffset( textureName, uvOffset );
		}
	}
}