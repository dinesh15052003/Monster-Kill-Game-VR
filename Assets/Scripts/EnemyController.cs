using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AudioClip getHit, dead, attack1, attack2, scream;
    AudioSource audioSource;
    public Animator enemyModel;
    Vector3 endPos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        endPos = 1f * (transform.position - Vector3.zero).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, endPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            Attack();
        if(other.CompareTag("Sword"))
            GetHit();
    }

    public void Attack()
    {
        enemyModel.SetTrigger("attack");
        PlayerManager.playerHealth -= 0.2f;
    }
    public void GetHit()
    {
        PlayerManager.currentScore += 100;
        enemyModel.Play("Get_Hit");
    }

    public void Death()
    {
        enemyModel.Play("Dead");
        
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void Attack1()
    {
        audioSource.PlayOneShot(attack1);
    }

    public void Attack2()
    {
        audioSource.PlayOneShot(attack2);
    }

    public void Gets_Hit()
    {
        audioSource.PlayOneShot(getHit);
    }

    public void Scream()
    {
        audioSource.PlayOneShot(scream);
    }

    public void Dies()
    {
        audioSource.PlayOneShot(dead);
    }

}
