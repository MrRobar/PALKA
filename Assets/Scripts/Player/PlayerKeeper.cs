using UnityEngine;

public class PlayerKeeper : Singleton<PlayerKeeper> {
	[SerializeField] private Player player;

	public override void Awake() {
		base.Awake();
		player = player == null ? FindObjectOfType<Player>() : player;
	}

	public Transform GetPlayerTransform() {
		return player.transform;
	}
}
