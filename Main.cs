using Godot;
using System;

public partial class Main : Node2D
{
	private BetMængde betMængde;

	private Label Balance;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		betMængde = GetNode<BetMængde>("Betmængde"); // Henter værdien fra betmængde noden
		Balance = GetNode<Label>("Node2D"); // Gør så vi kan 
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_spin_pressed()
	{
		GD.Print("!!!!!SPIIINNNN!!!!!");
		
		GD.Print("Din balance er: "+Balance.Text); // GD.Print værdien fra balance
		GD.Print("Din betmængde er: "+betMængde.Text); // GD.Print værdien fra Betmængde

		GD.Print(betMængde.checkBet()); // GD.Print værdien fra checkBet

		if (int.Parse(Balance.Text) >= int.Parse(betMængde.Text)) // Hvis balance er større eller lig med betmængde
		{
			GD.Print("Du har nok penge til at spille"); // GD.Print at du har nok penge til at spille
		}
		else if (int.Parse(Balance.Text) < int.Parse(betMængde.Text)) // Hvis balance er mindre end betmængde
		{
			GD.Print("Du har ikke nok penge til at spille"); // GD.Print at du ikke har nok penge til at spille
		}
	}

}
