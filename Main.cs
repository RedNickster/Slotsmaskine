using Godot;
using System;

public partial class Main : Node2D
{
	private Label betMængde;

	private Label Balance;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		betMængde = GetNode<Label>("Node2D");
		Balance = GetNode<Label>("Node2D2");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_spin_pressed()
	{
		GD.Print("Du har trykket på spin");
		
		// GD.Print værdien fra balance
		GD.Print(Balance.Text);
		GD.Print(betMængde.Text);
	}

}
