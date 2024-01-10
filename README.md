## Deadline
- [x] projektowanie: `2024-01-09`
- [ ] implementacja: `2024-01-16 23:59:59`

</br>

## Opis projektu
- [x] system poruszania grupą postaci po mapie
  - [x] N postaci
  - [x] jedna z postaci jest przewodnikiem
  - [x] klik -> przewodnik rusza do punktu pod kursorem
  > event kliknięcia jest prezkazywany z obiektu `Pointer` do `CharacterManager` za pośrednictwem prostego `ScriptableObject`
  - [x] pozostałe postacie podążają za nią
  > postacie nie mają informacji o innych postaciach ani o managerze postaci. Więdza jedynie gdzie lub za kim iść 
- [x] atrybuty postaci:
  - [x] prędkość (`Move Speed`)
  > używany przy poruszaniu
  - [x] zwrotność (`Turn Speed`)
  > póki co nieużyawny, trzeba by zmienić logikę poruszania na MoveForward + RotateTowardsTarget
  - [x] wytrzymałość (`Health`)
  - [x] początkowe wartości są losowo generowane przy starcie gry
- [x] widok izometryczny
- [ ] UI wyboru przewodnika
  - [ ] działa na różnych aspect ratio

</br>

## Wymagania
- **Ogólne**
  - [x] schemat blokowy klas i rozwiązania
  - [x] implementacja dopiero po zatwierdzeniu
  - [ ] komunikacja i sposób myślenia > programowanie
  - [ ] grafika nie jest oceniana
- **Programowanie**
  - [ ] czytelny i spójny kod
  - [ ] poprawne commity
  - [ ] interface
  - [ ] async/await
  - [ ] komendy prekompilatora
- **Unity**
  - [x] najnowszy LTS (`2022.3.16f1`)
  - [ ] A* zamiast NavMesh
  - [x] scriptable
  - [ ] addressable
  - [ ] save/load mapy i atrybutów

</br>

## Załączniki

- [Figma design doc](https://www.figma.com/file/pUixMKYzkMDAbra5tucKCR/CobbleGames?type=design&node-id=0%3A1&mode=design&t=Xccxsu8I3Vc8I8B2-1)
- [PDF z instrukcją](https://github.com/Vheos/Interview.CobbleGames/files/13811324/Zadanie.testowe.-.Programista.Mid.i.Junior.pdf)
- <details><summary>Treść maila</summary>
  
  >  ...
  > 
  >  Zadanie należy dostarczyć w postaci wykonywalnego i możliwego do kompilacji kodu projektu Unity dostępnego na publicznym repozytorium. Ostatni commit ma być wykonany do północy dnia 16 stycznia 2024.
  > 
  > Nim zaczniesz kodować to przeczytaj uważnie treść zadania, zadaj pytania i przejdź wszystkie fazy wymienione w PDF. Samo kodowanie nie jest dla nas tak ważne jak umiejętność komunikacji i sposób myślenia. Do 9 stycznia będę odpowiadać na twoje maile z pytaniami. Potem już działasz samodzielnie.
  >
  > ...
  </details>
