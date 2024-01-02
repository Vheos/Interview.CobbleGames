# Zadanie testowe - Programista MID i JUNIOR

[Figma Design doc](https://www.figma.com/file/pUixMKYzkMDAbra5tucKCR/CobbleGames?type=design&node-id=0%3A1&mode=design&t=Xccxsu8I3Vc8I8B2-1)

Utwórz system zaznaczania i poruszania się po mapie z widokiem typu izometrycznego grupą trzech (lub więcej) postaci, w której wydajemy polecenie poruszania się klikając myszką na mapie a wybrana postać porusza się od punktu A do punktu B.

Wybrana postać staje się przewodnikiem kolejnych postaci, które podążają za nią.

Każda postać ma swoje współczynniki prędkości, zwrotności i wytrzymałości, które losowo są generowane przy każdym starcie prototypu.

Wybór postaci ma być możliwy przez naciśnięcie jednego z trzech (lub więcej) przycisków na canvas.

Wymagania dla Junior:
- system może opierać się na wbudowanym w Unity Navmesh AI
- kod jest czytelny i spójny
- Canvas wspiera różne rozdzielczości ekranu i odpowiednio się formatuje
- kod jest poprawnie commitowany na publiczne repozytorium

Wymagania dla Junior +
- zamiast wbudowanego Navmesh AI zostaje użyta jakaś forma własnej implementacji algorytmu A Star
- zaimplementowane są scriptable objects
  
Wymagania na Mid
- jest możliwy w trakcie rozgrywki zapis i odczyt ustawień mapy i współczynników do pliku
- użyte są addressable
- użyte są async i await (np w zapisie plików)
- użyte są komendy prekompilatora
- użyte są interface

## Faza 1

Projektowanie:

Osoba zaczynająca zadanie zaproponuje diagram klas i rozpisze całe rozwiązanie w postaci
schematu blokowego. Dopiero po akceptacji rozwiązania przechodzimy do Fazy 2

## Faza 2

Implementacja kodu na bazie rozwiązania zaproponowanego w Fazie 1

## Faza 3

Ustne omówienie problemów, toku myślenia i rozwiązań podczas rozmowy online

Czas trwania 2 tygodnie. Rezultaty należy dostarczyć na publicznie dostępnym repozytorium
kodu. Przy czym jakość commitów i ich opis też jest przedmiotem oceny a projekt musi być
możliwy do kompilacji. Grafiki nie są przedmiotem oceny i mogą być użyte zastępcze lub
symboliczne.

Silnik użyty - Najnowsze Unity w wersji LTS.

[_Original instructions PDF_](https://github.com/Vheos/Interview.CobbleGames/files/13811324/Zadanie.testowe.-.Programista.Mid.i.Junior.pdf)
