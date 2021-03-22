# language: fr
Fonctionnalité: Gestion du paquet de cartes

  Scénario: Initialisation d'un paquet de cartes neuves
    Et que le jeu de carte simple est neuf
    Quand je récupère le paquet de cartes
    Alors il doit être trié par couleur et ordre croissant
      | color  | value |
      | BLUE   | ZERO  |
      | BLUE   | ONE   |
      | BLUE   | ONE   |
      | BLUE   | TWO   |
      | BLUE   | TWO   |
      | BLUE   | THREE |
      | BLUE   | THREE |
      | BLUE   | FOUR  |
      | BLUE   | FOUR  |
      | BLUE   | FIVE  |
      | BLUE   | FIVE  |
      | BLUE   | SIX   |
      | BLUE   | SIX   |
      | BLUE   | SEVEN |
      | BLUE   | SEVEN |
      | BLUE   | EIGHT |
      | BLUE   | EIGHT |
      | BLUE   | NINE  |
      | BLUE   | NINE  |
      | RED    | ZERO  |
      | RED    | ONE   |
      | RED    | ONE   |
      | RED    | TWO   |
      | RED    | TWO   |
      | RED    | THREE |
      | RED    | THREE |
      | RED    | FOUR  |
      | RED    | FOUR  |
      | RED    | FIVE  |
      | RED    | FIVE  |
      | RED    | SIX   |
      | RED    | SIX   |
      | RED    | SEVEN |
      | RED    | SEVEN |
      | RED    | EIGHT |
      | RED    | EIGHT |
      | RED    | NINE  |
      | RED    | NINE  |
      | YELLOW | ZERO  |
      | YELLOW | ONE   |
      | YELLOW | ONE   |
      | YELLOW | TWO   |
      | YELLOW | TWO   |
      | YELLOW | THREE |
      | YELLOW | FOUR  |
      | YELLOW | FOUR  |
      | YELLOW | FOUR  |
      | YELLOW | FIVE  |
      | YELLOW | FIVE  |
      | YELLOW | SIX   |
      | YELLOW | SIX   |
      | YELLOW | SEVEN |
      | YELLOW | SEVEN |
      | YELLOW | EIGHT |
      | YELLOW | EIGHT |
      | YELLOW | NINE  |
      | YELLOW | NINE  |
      | GREEN  | ZERO  |
      | GREEN  | ONE   |
      | GREEN  | ONE   |
      | GREEN  | TWO   |
      | GREEN  | TWO   |
      | GREEN  | THREE |
      | GREEN  | THREE |
      | GREEN  | FOUR  |
      | GREEN  | FOUR  |
      | GREEN  | FIVE  |
      | GREEN  | FIVE  |
      | GREEN  | SIX   |
      | GREEN  | SIX   |
      | GREEN  | SEVEN |
      | GREEN  | SEVEN |
      | GREEN  | EIGHT |
      | GREEN  | EIGHT |
      | GREEN  | NINE  |
      | GREEN  | NINE  |

  Scénario: Distribution des cartes
    Etant donné que le jeu de carte simple est neuf trié
    Et une partie avec 3 joueurs
    Et le jeu de carte simple est mélangé
      | color  | value |
      | BLUE   | ONE   |
      | BLUE   | TWO   |
      | BLUE   | FIVE  |
      | BLUE   | THREE |
      | BLUE   | FOUR  |
      | BLUE   | FIVE  |
      | BLUE   | SIX   |
      | BLUE   | ONE   |
      | BLUE   | SEVEN |
      | BLUE   | EIGHT |
      | BLUE   | ZERO  |
      | RED    | TWO   |
      | RED    | ONE   |
      | RED    | ONE   |
      | RED    | TWO   |
      | BLUE   | THREE |
      | BLUE   | SEVEN |
      | RED    | FIVE  |
      | BLUE   | SIX   |
      | RED    | THREE |
      | RED    | ZERO  |
      | RED    | FOUR  |
      | RED    | SIX   |
      | BLUE   | EIGHT |
      | RED    | THREE |
      | BLUE   | FOUR  |
      | BLUE   | NINE  |
      | RED    | SIX   |
      | YELLOW | ONE   |
      | RED    | SEVEN |
      | RED    | SEVEN |
      | YELLOW | FOUR  |
      | RED    | EIGHT |
      | RED    | NINE  |
      | YELLOW | EIGHT |
      | RED    | NINE  |
      | RED    | FOUR  |
      | RED    | EIGHT |
      | BLUE   | NINE  |
      | YELLOW | ZERO  |
      | YELLOW | ONE   |
      | YELLOW | TWO   |
      | YELLOW | TWO   |
      | YELLOW | THREE |
      | YELLOW | FOUR  |
      | BLUE   | TWO   |
      | YELLOW | FOUR  |
      | YELLOW | FIVE  |
      | YELLOW | FIVE  |
      | RED    | FIVE  |
      | YELLOW | SIX   |
      | YELLOW | SIX   |
      | YELLOW | SEVEN |
      | YELLOW | SEVEN |
      | GREEN  | FOUR  |
      | YELLOW | EIGHT |
      | RED    | FIVE  |
      | YELLOW | NINE  |
      | GREEN  | EIGHT |
      | GREEN  | EIGHT |
      | YELLOW | NINE  |
      | GREEN  | ZERO  |
      | GREEN  | ONE   |
      | GREEN  | ONE   |
      | GREEN  | THREE |
      | GREEN  | TWO   |
      | GREEN  | TWO   |
      | GREEN  | SIX   |
      | GREEN  | NINE  |
      | GREEN  | THREE |
      | GREEN  | FOUR  |
      | GREEN  | FIVE  |
      | GREEN  | SEVEN |
      | GREEN  | FIVE  |
      | GREEN  | SIX   |
      | GREEN  | SEVEN |
      | GREEN  | NINE  |
    Quand je distribue 7 cartes
    Alors il ne reste plus que les cartes suivantes
      | color  | value |
      | BLUE   | ONE   |
      | BLUE   | TWO   |
      | BLUE   | FIVE  |
      | BLUE   | THREE |
      | BLUE   | FOUR  |
      | BLUE   | FIVE  |
      | BLUE   | SIX   |
      | BLUE   | ONE   |
      | BLUE   | SEVEN |
      | BLUE   | EIGHT |
      | BLUE   | ZERO  |
      | RED    | TWO   |
      | RED    | ONE   |
      | RED    | ONE   |
      | RED    | TWO   |
      | BLUE   | THREE |
      | BLUE   | SEVEN |
      | RED    | FIVE  |
      | BLUE   | SIX   |
      | RED    | THREE |
      | RED    | ZERO  |
      | RED    | FOUR  |
      | RED    | SIX   |
      | BLUE   | EIGHT |
      | RED    | THREE |
      | BLUE   | FOUR  |
      | BLUE   | NINE  |
      | RED    | SIX   |
      | YELLOW | ONE   |
      | RED    | SEVEN |
      | RED    | SEVEN |
      | YELLOW | FOUR  |
      | RED    | EIGHT |
      | RED    | NINE  |
      | YELLOW | EIGHT |
      | RED    | NINE  |
      | RED    | FOUR  |
      | RED    | EIGHT |
      | BLUE   | NINE  |
      | YELLOW | ZERO  |
      | YELLOW | ONE   |
      | YELLOW | TWO   |
      | YELLOW | TWO   |
      | YELLOW | THREE |
      | YELLOW | FOUR  |
      | BLUE   | TWO   |
      | YELLOW | FOUR  |
      | YELLOW | FIVE  |
      | YELLOW | FIVE  |
      | RED    | FIVE  |
      | YELLOW | SIX   |
      | YELLOW | SIX   |
      | YELLOW | SEVEN |
      | YELLOW | SEVEN |
      | GREEN  | FOUR  |
      | YELLOW | EIGHT |
    Et le joueur 1 a les cartes suivantes
      | color | value | id |
      | GREEN | EIGHT | 1  |
      | GREEN | ZERO  | 1  |
      | GREEN | THREE | 1  |
      | GREEN | SIX   | 1  |
      | GREEN | FOUR  | 1  |
      | GREEN | FIVE  | 1  |
      | GREEN | NINE  | 1  |
    Et le joueur 2 a les cartes suivantes
      | color  | value | id |
      | YELLOW | NINE  | 2  |
      | YELLOW | NINE  | 2  |
      | GREEN  | ONE   | 2  |
      | GREEN  | TWO   | 2  |
      | GREEN  | THREE | 2  |
      | GREEN  | SEVEN | 2  |
      | GREEN  | SEVEN | 2  |
    Et le joueur 3 a les cartes suivantes
      | color | value | id |
      | RED   | FIVE  | 3  |
      | GREEN | EIGHT | 3  |
      | GREEN | ONE   | 3  |
      | GREEN | TWO   | 3  |
      | GREEN | NINE  | 3  |
      | GREEN | FIVE  | 3  |
      | GREEN | SIX   | 3  |