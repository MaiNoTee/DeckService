﻿using DeckService.Interfaces;

namespace DeckService.Model;

public class DeckService : IDeckService
{
	Dictionary<string, Deck> Decks { get; }

	public DeckService()
	{
		Decks = new Dictionary<string, Deck>();
		
	}
	
	public Deck GetDeck(string name)
	{
		return Decks[name];
	}

	public void CreateDeck(string deckName)
	{
		Decks.Add(deckName, new Deck(deckName));
	}

	public void RemoveDeck(string deckName)
	{
		Decks.Remove(deckName);
	}

	public List<string> GetDeckNames()
	{
		return Decks.Keys.ToList();
	}
	
	public void ShuffleDeck(string name, Shuffle shuffle)
	{
		var deck = Decks[name];
		deck.Shuffle(shuffle);
	}

	public enum Shuffle
	{
		Random,
		ByHalf
	}
}
