## Deadline
- [x] projektowanie: `2024-01-09`
- [ ] implementacja: `2024-01-16 23:59:59`

</br>

## Opis projektu
- [x] system poruszania grupą postaci po mapie
  - [x] N postaci
  - [x] jedna z postaci jest przewodnikiem
  - [x] klik -> przewodnik rusza do punktu pod kursorem
  - [x] pozostałe postacie podążają za nią
- [x] atrybuty postaci:
  - [x] prędkość (`Move Speed`)
  - [x] zwrotność (`Turn Speed`)
  - [x] wytrzymałość (`Health`)
  - [x] początkowe wartości są losowo generowane przy starcie gry
- [x] widok izometryczny
- [x] UI wyboru przewodnika
  - [x] działa na różnych aspect ratio

</br>

## Wymagania
- **Ogólne**
  - [x] schemat blokowy klas i rozwiązania
  - [x] implementacja dopiero po zatwierdzeniu
  - [x] komunikacja i sposób myślenia > programowanie
  - [x] grafika nie jest oceniana
- **Programowanie**
  - [x] czytelny i spójny kod
  - [x] poprawne commity
  - [x] interface
  - [x] async/await
  - [x] komendy prekompilatora
- **Unity**
  - [x] najnowszy LTS (`2022.3.16f1`)
  - [x] A* zamiast NavMesh
  - [x] scriptable
  - [ ] addressable
  - [x] save/load system:
    - [x] atrybutów postaci
    - [x] ułożenia mapy

</br>

## Wykorzystane schematy
- ScriptableObject events
- ScriptableObject runtime collections

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
