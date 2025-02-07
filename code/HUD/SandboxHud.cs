﻿using Sandbox;
using Sandbox.UI;

[Library]
public partial class SandboxHud : HudEntity<RootPanel>
{
	public SandboxHud()
	{
		if ( !IsClient )
			return;

		RootPanel.StyleSheet.Load( "/HUD/SandboxHud.scss" );

		// RootPanel.AddChild<NameTags>();
		RootPanel.AddChild<Crosshair>();
		RootPanel.AddChild<ChatBox>();
		RootPanel.AddChild<VoiceList>();
		RootPanel.AddChild<KillFeed>();
		RootPanel.AddChild<Scoreboard<ScoreboardEntry>>();
		RootPanel.AddChild<Health>();
		RootPanel.AddChild<Armor>();
		RootPanel.AddChild<Ammo>();
		RootPanel.AddChild<InventoryBar>();
	}
}
