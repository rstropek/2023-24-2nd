# Twenty-One (Deutsch: Siebzehn und Vier)

## Einführung

[Twenty-One](<https://en.wikipedia.org/wiki/Twenty-One_(banking_game)>) (auf Deutsch [17-und-4](https://de.wikipedia.org/wiki/Siebzehn_und_Vier)) ist ein traditionelles Kartenspiel. In dieser Übung müssen Sie eine einfache Version dieses Spiels implementieren.

## Regeln

Das Spiel wird mit einem Kartensatz von 52 Karten gespielt. Hier sind die Kartentypen:

- Ass
- Zahlkarten 2-10
- Bildkarten Bube, Dame, König

Das Kartendeck enthält alle diese Karten in vier verschiedenen Farben: Herz (♥️), Karo (♦️), Kreuz (♣️), Pik (♠️).

![Karten](640px-Piatnikcards.jpg)

Bildquelle: https://de.wikipedia.org/wiki/Spielkarte#/media/Datei:Piatnikcards.jpg

Vor dem Spiel werden die 52 Karten gemischt, sodass sie in zufälliger Reihenfolge sind. Dann erhält der Spieler zwei Karten. Der Computer berechnet den Wert der Hand (Einzelheiten siehe unten). Der Benutzer kann dann entscheiden, ob er eine zusätzliche Karte möchte. Dies wird wiederholt, bis der Benutzer sich entscheidet, keine zusätzliche Karte mehr zu nehmen oder der Wert der Hand größer als 21 ist. Im letzteren Fall verliert der Benutzer.

Mehrere Spieler spielen das Spiel nacheinander. Der Gewinner ist der Spieler mit dem höchsten Handwert, der nicht größer als 21 ist.

Der Wert einer Hand wird wie folgt berechnet:

- Zahlkarten zwischen 2 und 10 haben den Wert ihrer Zahl.
- Bildkarten haben den Wert 10.
- Asse haben den Wert 11 oder 1, je nachdem, welcher Wert für den Spieler besser ist.
- Die Farbe der Karten spielt für den Wert der Hand keine Rolle.

Hier sind einige Beispiele für Hände und ihre Werte:

| Hand                        | Wert |
| --------------------------- | ----: |
| Zwei, Drei, Vier            |     9 |
| Zwei, Drei, Vier, König     |    19 |
| Zwei, Drei, Vier, Ass       |    20 |
| Zwei, Drei, Vier, Ass, König|    20 |
| Ass, Ass                    |    12 |
| Ass, Ass, Ass               |    13 |

## Technische Anforderungen

Sie müssen eine _Stack_-Datenstruktur implementieren, die die Karten des Decks speichern kann. Als Nächstes müssen Sie eine _List_-Datenstruktur implementieren, die die Karten der Hand speichert. Beide Datenstrukturen haben einige Hilfsmethoden.

Ihr Startcode enthält die folgenden sofort einsatzbereiten Teile:

* Klasse [`Card`](./starter/Seventeen.Logic/Card.cs), die eine einzelne Karte darstellt, bestehend aus Kartentyp und Farbe.
* Klasse [`CardInCollection`](./starter/Seventeen.Logic/CardInCollection.cs), die eine Karte in einer Sammlung (Stapel oder Liste) darstellt.
* [Konsolenanwendung](./starter/Seventeen.App/), die verwendet werden kann, um Ihre Implementierung interaktiv zu testen.
* [Unit-Tests](./starter/Seventeen.Tests/), die verwendet werden können, um Ihre Implementierung automatisch zu testen.

## Grundanforderungen

* Klasse [`StackOfCards`](./starter/Seventeen.Logic/StackOfCards.cs):
    * Implementieren Sie die Methode `Push`
    * Implementieren Sie die Methode `Pop`
    * Implementieren Sie die Methode `Fill` **ohne Mischen der Karten**. Sie können die Karten in beliebiger Reihenfolge hinzufügen.
* Klasse [`HandOfCards`](./starter/Seventeen.Logic/HandOfCards.cs):
    * Implementieren Sie die Methode `AddCardAtEnd`
    * Implementieren Sie die Methode `GetTotalValue` **ohne Berücksichtigung des doppelten Werts der Asse**. Ein Ass hat immer den Wert 1.
    * Implementieren Sie die Methode `ToString`

## Erweiterte Anforderungen

* Klasse [`StackOfCards`](./starter/Seventeen.Logic/StackOfCards.cs):
 * Implementieren Sie die Methode `Fill` **mit** Mischen der Karten.
* Klasse [`HandOfCards`](./starter/Seventeen.Logic/HandOfCards.cs):
    * Implementieren Sie die Methode `GetTotalValue` **mit** Berücksichtigung des doppelten Werts der Asse.
