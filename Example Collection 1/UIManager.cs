using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[Header("Player")]
	[SerializeField] private HealthBar playerHealthBar;
	[SerializeField] private Image weaponIcon;
	[SerializeField] private Text livesLabel;
	[SerializeField] private string livesFormat = "❤ x {0}";
	[Header("Enemies")]
	[SerializeField] private HealthBar enemyHealthBarPrefab;
	[SerializeField] private Transform enemyHealthBarContainer;
	[Header("Windows")]
	[SerializeField] private Transform pauseWindow;
	[SerializeField] private Transform gameOverWindow;

	public void RegisterPlayer(Player player)
	{
		playerHealthBar.Register (player.Health);
	}

	public void RegisterEnemy(Enemy enemy)
	{
		var healthBar = Instantiate (enemyHealthBarPrefab, enemyHealthBarContainer) as HealthBar;
		healthBar.Register (enemy.Health);
	}

	private void Update()
	{
		pauseWindow.gameObject.SetActive (Toolbox.GameManager.Paused && !Toolbox.GameManager.IsGameOver);
		gameOverWindow.gameObject.SetActive (Toolbox.GameManager.IsGameOver);

		weaponIcon.overrideSprite = null;
		if (Toolbox.Player)
		{
			if (Toolbox.Player.EquippedWeapon)
			{
				weaponIcon.overrideSprite = Toolbox.Player.EquippedWeapon.Icon;
			}
		}

		livesLabel.text = string.Format (livesFormat, Toolbox.GameManager.PlayerLives);
	}
}