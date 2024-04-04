using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Enemy : MonoBehaviour
{
    public float speed;

	public GameObject effect;
	public GameObject effectTwo;

	public string enemyColor;

	private Animator camAnim;
    private ScoreManager scoreManager;

    private void Start()
	{
        camAnim = Camera.main.GetComponent<Animator>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }


	private void Update()
	{
		transform.Translate(Vector2.left * speed * Time.deltaTime);
	}

	public void Destruction(){ 
		camAnim.SetTrigger("shake");
		Instantiate(effect, transform.position, Quaternion.identity);
		Instantiate(effectTwo, transform.position, Quaternion.identity);

        if (scoreManager != null)
        {
            scoreManager.AddScore();
        }
        else
        {
            Debug.LogError("ScoreManager not found.");
        }

        Destroy(gameObject);

    }

    public void Restart(){
		camAnim.SetTrigger("shake");
		Instantiate(effectTwo, transform.position, Quaternion.identity);
		StartCoroutine(WaitBeforeRestart());
	}

	IEnumerator WaitBeforeRestart(){ 
		
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
