# Szoftverfejlesztés házi feladat: lapkezelõ algoritmusok
A program célja demonstrálni az órákon tanult 4 lapcsere stratégiát:
- FIFO: first in, first out
- LRU: least recently used
- OPT: optimal
- SC: second chance

Az összes tervezett algoritmus meg van valósítva a 4 közül.

## Mûködése
A program elindítása után egy konzolos felület várja a felhasználót. Elsõ lépésben a fel-le nyilak illetve a W és az S billentyûk segítségével kiválaszthatja a használni kívánt algoritmust, majd az Enter, illetve Spacebar (szóköz) billentyûkkel véglegesítheti döntését.
Ez után elindul az algoritmus mûködésének szemléltetése, melyet bármely billentyû lenyomásával lehet elõreléptetni.
Ha össze kívánja hasonlítani az algoritmusokat, a program csendesen lefuttatja az algoritmusokat - vagy egy elõre megadott folyamatlistán, vagy egy random generálton, - és kiírja az eredményeket táblázatos formában
Miután az lefutott, lehetõsége van a felhasználónak újra lefuttatni a programot, vagy kilépni abból.

## A folyamatok módosítása
A **/res** mappában áll lehetõség módosítani a folyamatok listáját a **processes.txt** fájlban. A folyamatok sorszámait külön sorokba kell beírni, mint ahogyan a példában is látható.

## Fejlesztési lehetõségek
- [X] Lehetõséget adni a felhasználónak hogy összevethesse az algoritmusokat egy véletlenszerûen generált / elõre megadott folyamatlistával.
- [X] Megkérdezni a felhasználót a program futásának a végén, hogy szeretné-e újra lefuttatni.
- [X] Megvalósítani, hogy több számjegyû folyamatszámokkal is mûködjön a kiírás.