using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public CanvasGroup buttonsCanvasGroup;
    public CanvasGroup finalPopup;
    public Button switchButton;
    [SerializeField] private Character[] playerCharacters = default;
    [SerializeField] private Character[] enemyCharacters = default;

    Character currentTarget;
    private bool waitingForInput;

    // Start is called before the first frame update
    void Start()
    {
        switchButton.onClick.AddListener(NextTarget);
        StartCoroutine(GameLoop());
    }

    public void PlayerAttack()
    {
        waitingForInput = false;
    }

    public void NextTarget()
    {
        var characters = enemyCharacters
            .Where(x => x != null)
            .ToArray();
        
        for (int i = 0; i < characters.Length; i++) {
            // Найти текущего персонажа (i = индекс текущего)
            if (characters[i] == currentTarget) {
                int start = i;
                ++i;
                // Идем в сторону конца массива и ищем живого персонажа
                for (; i < characters.Length; i++) {
                    if (characters[i].IsDead())
                        continue;

                    // Нашли живого, меняем currentTarget
                    currentTarget.targetIndicator.gameObject.SetActive(false);
                    currentTarget = characters[i];
                    currentTarget.targetIndicator.gameObject.SetActive(true);

                    return;
                }
                // Идем от начала массива до текущего и смотрим, если там кто живой
                for (i = 0; i < start; i++) {
                    if (characters[i].IsDead())
                        continue;

                    // Нашли живого, меняем currentTarget
                    currentTarget.targetIndicator.gameObject.SetActive(false);
                    currentTarget = characters[i];
                    currentTarget.targetIndicator.gameObject.SetActive(true);

                    return;
                }
                // Живых больше не осталось, не меняем currentTarget
                return;
            }
        }
    }

    Character FirstAliveCharacter(Character[] characters)
    {
        foreach (var character in characters.Where(x => x != null)) {
            if (!character.IsDead())
                return character;
        }

        return null;
    }

    void PlayerWon()
    {
        Utility.SetCanvasGroupEnabled(finalPopup, true);
    }

    void PlayerLost()
    {
        Utility.SetCanvasGroupEnabled(finalPopup, true);
    }

    bool CheckEndGame()
    {
        if (FirstAliveCharacter(playerCharacters) == null) {
            PlayerLost();
            return true;
        }

        if (FirstAliveCharacter(enemyCharacters) == null) {
            PlayerWon();
            return true;
        }

        return false;
    }

    IEnumerator GameLoop()
    {
        Utility.SetCanvasGroupEnabled(buttonsCanvasGroup, false);

        while (!CheckEndGame()) {
            foreach (var player in playerCharacters.Where(x => x != null)) {
                if (player.IsDead())
                    continue;

                currentTarget = FirstAliveCharacter(enemyCharacters);
                if (currentTarget == null)
                    break;

                currentTarget.targetIndicator.gameObject.SetActive(true);

                Utility.SetCanvasGroupEnabled(buttonsCanvasGroup, true);
                waitingForInput = true;
                while (waitingForInput)
                    yield return null;
                Utility.SetCanvasGroupEnabled(buttonsCanvasGroup, false);

                currentTarget.targetIndicator.gameObject.SetActive(false);

                player.target = currentTarget.transform;
                player.AttackEnemy();
                while (!player.IsIdle())
                    yield return null;
            }

            foreach (var enemy in enemyCharacters.Where(x => x != null)) {
                if (enemy.IsDead())
                    continue;

                Character target = FirstAliveCharacter(playerCharacters);
                if (target == null)
                    break;

                enemy.target = target.transform;
                enemy.AttackEnemy();
                while (!enemy.IsIdle())
                    yield return null;
            }
        }
    }
}
