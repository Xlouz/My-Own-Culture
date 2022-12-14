using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    public bool hasButton;
    public float time = 16;

    public Text pertanyaan, jawabanText;
    public Text a3, b3, c3;
    public Text a4, b4, c4, d4;
    public string jawabanBenar;
    public Text timeText;
    public GameObject jawaban3, jawaban4;

    public Animator animator;

    int jawabanInt;
    private void Start()
    {
        jawabanText.text = jawabanBenar;

        AudioManager.Instance.SwitchDialogBoxSfx();
    }

    bool detikan;
    private void Update()
    {
        time -= Time.deltaTime;
        timeText.text = "Waktu " + (int)time;
        time = Mathf.Clamp(time, 0, 100);

        if ((int)time == 5 && !detikan)
        {
            detikan = true;
            AudioManager.Instance.StartTimeSfx();
        }
        if (time <= 0 && !hasButton)
        {
            hasButton = true;
            BattleManager.instance.EnemyAttack();
            BattleManager.instance.SpawnNotifikasi(jawabanBenar);

            //Exit
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                AudioManager.Instance.StopTimeSfx();
                yield return new WaitForSeconds(2);
                animator.SetTrigger("Exit");
                yield return new WaitForSeconds(1f);
                BattleManager.instance.SpawnDialogBoxLevel();
                Destroy(gameObject);
            }
        }
    }

    public void Jawaban()
    {
        jawabanInt++;
        if (jawabanInt >= 5)
        {
            jawabanText.gameObject.SetActive(true);
        }
    }

    public void IsiPertanyaan(string Pertanyaan, string A, string B, string C, string D, string JawabanBenar)
    {
        //Jawabam3
        if (D == "")
        {
            jawaban3.SetActive(true);

            pertanyaan.text = Pertanyaan;
            a3.text = "A. " + A;
            b3.text = "B. " + B;
            c3.text = "C. " + C;
            jawabanBenar = JawabanBenar;
        }
        //Jawabam4
        else
        {
            jawaban3.SetActive(false);
            jawaban4.SetActive(true);

            pertanyaan.text = Pertanyaan;
            a4.text = "A. " + A;
            b4.text = "B. " + B;
            c4.text = "C. " + C;
            d4.text = "D. " + D;
            jawabanBenar = JawabanBenar;
        }

    }

    public void Jawaban(string jawaban)
    {
        if (!hasButton) hasButton = true;
        else return;

        if (jawaban == "A")
        {
            if (jawabanBenar == "A")
            {
                BattleManager.instance.PlayerAttack();
            }
            else
            {
                BattleManager.instance.EnemyAttack();
                BattleManager.instance.SpawnNotifikasi(jawabanBenar);
            }
        }
        else if (jawaban == "B")
        {
            if (jawabanBenar == "B")
            {
                BattleManager.instance.PlayerAttack();
            }
            else
            {
                BattleManager.instance.EnemyAttack();
                BattleManager.instance.SpawnNotifikasi(jawabanBenar);
            }
        }
        else if (jawaban == "C")
        {
            if (jawabanBenar == "C")
            {
                BattleManager.instance.PlayerAttack();
            }
            else
            {
                BattleManager.instance.EnemyAttack();
                BattleManager.instance.SpawnNotifikasi(jawabanBenar);
            }
        }
        else if (jawaban == "D")
        {
            if (jawabanBenar == "D")
            {
                BattleManager.instance.PlayerAttack();
            }
            else
            {
                BattleManager.instance.EnemyAttack();
                BattleManager.instance.SpawnNotifikasi(jawabanBenar);
            }
        }

        //Exit
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            AudioManager.Instance.StopTimeSfx();
            yield return new WaitForSeconds(2);
            animator.SetTrigger("Exit");
            yield return new WaitForSeconds(1f);
            BattleManager.instance.SpawnDialogBoxLevel();
            Destroy(gameObject);
        }

        AudioManager.Instance.ClickButtonSfx();
    }
}
