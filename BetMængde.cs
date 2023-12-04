using Godot;
using System;

public partial class BetMængde : Label
{
	public int checkBet()
	{
		return 1010101010;
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void _on_button_ned_pressed()
	{
		// en if sætning der sørger for at når knappen ned bliver trykket på så bliver der trukket 100 fra betmængde
		if (int.Parse(Text) != 100){
		Text = (int.Parse(Text) - 100).ToString(); // laver text om til en int og trækker 100 fra og laver det om til en string igen
		}
	}
	public void _on_button_op_pressed()
	{
		// en if sætning der sørger for at når knappen op bliver trykket på så bliver der lagt 100 til betmængde
		if (int.Parse(Text) != 1000){
		Text = (int.Parse(Text) + 100).ToString(); // laver text om til en int og lægger 100 til og laver det om til en string igen
		// pls sig at deat her hjælper
		}
	}
}
