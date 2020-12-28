﻿using BlazorGames.Models.Blackjack.Enums;
using BlazorGames.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorGames.Models.Blackjack
{
    public class CardDeck
    {
        protected Stack<Card> Cards { get; set; } = new Stack<Card>();

        public CardDeck()
        {
            foreach (CardSuit suit in (CardSuit[])Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue value in (CardValue[])Enum.GetValues(typeof(CardValue)))
                {
                    Card newCard = new Card()
                    {
                        Suit = suit,
                        Value = value,
                        CssClass = "card" + suit.GetDisplayName() + value.GetDisplayName()
                    };

                    Cards.Push(newCard);
                }
            }

            Shuffle();
        }

        public void Add(Card card)
        {
            Cards.Push(card);
        }

        public Card Draw()
        {
            return Cards.Pop();
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            var array = Cards.ToArray();

            //Step 1: For each unshuffled item in the collection
            for (int n = array.Count() - 1; n > 0; --n)
            {
                //Step 2: Randomly pick an item which has not been shuffled
                int k = rnd.Next(n + 1);

                //Step 3: Swap the selected item with the last "unstruck" letter in the collection
                Card temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }

            for(int n = 0; n < array.Count(); n++)
            {
                Cards.Push(array[n]);
            }
        }
    }
}