Zadanie 1

W tym zadaniu zaimplementowano algorytm zachłanny do rozwiązania problemu plecakowego (knapsack problem). Program generuje losowe przedmioty o określonej wadze i wartości, a następnie wybiera te, które maksymalizują stosunek wartości do wagi, aż do osiągnięcia pojemności plecaka.

Kluczowy fragment kodu:

Ciekawym fragmentem jest sortowanie przedmiotów według stosunku wartości do wagi, co pozwala na efektywne wybieranie najkorzystniejszych elementów:

items.Sort((a, b) => b.ratio.CompareTo(a.ratio));

Dzięki temu program najpierw dodaje do plecaka najbardziej opłacalne przedmioty, co jest charakterystyczne dla algorytmów zachłannych.

Zadanie 2

W tej sekcji sprawdzono poprawność działania algorytmu plecakowego za pomocą testów jednostkowych w frameworku NUnit. Testy sprawdzają poprawność działania algorytmu plecakowego w różnych scenariuszach.

Opis testów

Problem1 – Sprawdza, czy dla przykładowych danych wejściowych zwracany jest co najmniej jeden wybrany przedmiot. Jeśli oczywiście spełnia wymagania. 

Problem2 – Testuje przypadek, gdy pojemność plecaka wynosi 0. Oczekiwane jest, że nie zostaną wybrane żadne przedmioty.

Problem3 – Weryfikuje, czy łączna waga wybranych przedmiotów nie przekracza pojemności plecaka oraz czy wartości są poprawnie sumowane.

Problem4 – Sprawdza, czy jeśli żaden przedmiot nie spełnia ograniczeń wagowych, to rozwiązanie zwraca pustą listę oraz zerowe wartości.

Problem5 – Weryfikuje, czy jeśli plecak może pomieścić tylko najlżejszy przedmiot, to zostaje wybrany ten o najlepszym stosunku wartości do wagi.
