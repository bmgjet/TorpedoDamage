namespace Oxide.Plugins
{
	[Info("TorpedoDamage", "bmgjet", "0.0.1")]
	[Description("Edits Torpedo Damage")]
	class TorpedoDamage : RustPlugin
	{
		private float DamageScale = 1000f;
		private bool ShowDebugConsole = true;
		private void OnEntitySpawned(BaseEntity torpedo)
		{
			if (torpedo == null || torpedo.prefabID != 110435217) return;
			TimedExplosive rocket = torpedo.GetComponent<TimedExplosive>();
			if (rocket == null) return;
			if (ShowDebugConsole)
			{
				foreach (Rust.DamageTypeEntry damage in rocket.damageTypes)
				{
					Puts(damage.type.ToString() + " " + damage.amount.ToString());
				}
			}
			rocket.SetDamageScale(DamageScale);
			if (ShowDebugConsole)
			{
				foreach (Rust.DamageTypeEntry damage in rocket.damageTypes)
				{
					Puts("Modded " + damage.type.ToString() + " " + damage.amount.ToString());
				}
			}
		}
	}
}