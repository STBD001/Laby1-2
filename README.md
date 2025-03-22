Zadanie 1

W tym zadaniu zaimplementowano algorytm zachłanny do rozwiązania problemu plecakowego (knapsack problem). Program generuje losowe przedmioty o określonej wadze i wartości, a następnie wybiera te, które maksymalizują stosunek wartości do wagi, aż do osiągnięcia pojemności plecaka.

Kluczowy fragment kodu

Ciekawym fragmentem jest sortowanie przedmiotów według stosunku wartości do wagi, co pozwala na efektywne wybieranie najkorzystniejszych elementów:

items.Sort((a, b) => b.ratio.CompareTo(a.ratio));

Dzięki temu program najpierw dodaje do plecaka najbardziej opłacalne przedmioty, co jest charakterystyczne dla algorytmów zachłannych.
