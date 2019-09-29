﻿using System;
using System.Collections.Generic;

namespace Casino
{
    public class Deck52 : Deck
    {
        public int pointer;

        public Deck52()
        {
            deckSize = 52;
            FillDeck(cards, deckSize);
            ShakeDeck(cards);
            pointer = deckSize - 1;
        }

        public Par52 GetPar(int cardNumber)
        {
            return (Par52)(cardNumber % (deckSize / 4));
        }

        public override string ToString(int cardNumber)
        {
            return GetPar(cardNumber) + " " + GetSuit(cardNumber, cards);
        }

        public int GetCard(Deck52 deck)
        {
            return deck.cards[deck.pointer--];
        }

        public int CalculatePoints(List<int> hand)
        {
            var result = 0;
            var acesNum = 0;

            foreach (var card in hand)
            {
                switch (GetPar(card))
                {
                    case Par52.two:
                        result += 2;
                        break;
                    case Par52.three:
                        result += 3;
                        break;
                    case Par52.four:
                        result += 4;
                        break;
                    case Par52.five:
                        result += 5;
                        break;
                    case Par52.six:
                        result += 6;
                        break;
                    case Par52.seven:
                        result += 7;
                        break;
                    case Par52.eight:
                        result += 8;
                        break;
                    case Par52.nine:
                        result += 9;
                        break;
                    case Par52.ten:
                    case Par52.joker:
                    case Par52.queen:
                    case Par52.king:
                        result += 10;
                        break;
                    case Par52.ace:
                        result += 1;
                        acesNum++;
                        break;
                }
            }
            for (int i = acesNum; i > 0; i--)
            {
                if (result > 11) break;
                result += 10;
            }
            return result;
        }
    }
}
