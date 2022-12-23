# Szoftverfejlesztés házi feladat: lapkezelõ algoritmusok
A program célja demonstrálni a 4 fõbb lapcsere stratégiát:
- FIFO: first in, first out
- LRU: least recently used
- OPT: optimal
- SC: second chance

Jelenleg csak a FIFO algoritmus van megvalósítva a 4 közül.

## Mûködése
A program elindítása után egy konzolos felület várja a felhasználót. Elsõ lépésben a fel-le nyilak illetve a W és az S billentyûk segítségével kiválaszthatja a használni kívánt algoritmust, majd az Enter, illetve Spacebar (szóköz) billentyûkkel véglegesítheti döntését.
Ez után elindul az algoritmus mûködésének szemléltetése, melyet bármely billentyû lenyomásával lehet elõreléptetni.

## A folyamatok módosítása
A **/res** mappában áll lehetõség módosítani a folyamatok listáját a **processes.txt** fájlban. A folyamatok sorszámait külön sorokba kell beírni, mint ahogyan a példában is látható.