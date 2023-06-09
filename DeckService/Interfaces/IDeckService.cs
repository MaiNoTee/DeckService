﻿using DeckService.Models;

namespace DeckService.Interfaces;

public interface IDeckService
{
	Deck GetDeck(string name);
	void CreateDeck(string name);
	void RemoveDeck(string name);
	List<string> GetDeckNames();
	void ShuffleDeck(string name, Models.DeckService.Shuffle shuffle);
}
