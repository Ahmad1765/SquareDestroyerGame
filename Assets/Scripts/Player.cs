using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer rend;
	private Animator anim;

	public Color[] colors;

	public string playerColor;


	private void Start()
	{
		anim = GetComponent<Animator>();
		rend = GetComponent<SpriteRenderer>();
	}

	void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
			ChangeToRed();
        }

		if (Input.GetKeyDown(KeyCode.O))
		{
			ChangeToGreen();
		}

		if (Input.GetKeyDown(KeyCode.P))
		{
			ChangeToBlue();
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("col");

		if (other.GetComponent<Enemy>().enemyColor == playerColor){
			other.GetComponent<Enemy>().Destruction();
		
		
		}
		else
		{
			other.GetComponent<Enemy>().Restart();
			Destroy(gameObject);
		}
	}

    public void ChangeToRed()
    {
        anim.SetTrigger("change");
        rend.color = colors[0];
        playerColor = "r";
    }

    // Function to change color to green
    public void ChangeToGreen()
    {
        anim.SetTrigger("change");
        rend.color = colors[1];
        playerColor = "g";
    }

    // Function to change color to blue
    public void ChangeToBlue()
    {
        anim.SetTrigger("change");
        rend.color = colors[2];
        playerColor = "b";
    }
}


