# Szoftverfejleszt�s h�zi feladat: lapkezel� algoritmusok
A program c�lja demonstr�lni az �r�kon tanult 4 lapcsere strat�gi�t:
- FIFO: first in, first out
- LRU: least recently used
- OPT: optimal
- SC: second chance

Az �sszes tervezett algoritmus meg van val�s�tva a 4 k�z�l.

## M�k�d�se
A program elind�t�sa ut�n egy konzolos fel�let v�rja a felhaszn�l�t. Els� l�p�sben a fel-le nyilak illetve a W �s az S billenty�k seg�ts�g�vel kiv�laszthatja a haszn�lni k�v�nt algoritmust, majd az Enter, illetve Spacebar (sz�k�z) billenty�kkel v�gleges�theti d�nt�s�t.
Ez ut�n elindul az algoritmus m�k�d�s�nek szeml�ltet�se, melyet b�rmely billenty� lenyom�s�val lehet el�rel�ptetni.
Ha �ssze k�v�nja hasonl�tani az algoritmusokat, a program csendesen lefuttatja az algoritmusokat - vagy egy el�re megadott folyamatlist�n, vagy egy random gener�lton, - �s ki�rja az eredm�nyeket t�bl�zatos form�ban
Miut�n az lefutott, lehet�s�ge van a felhaszn�l�nak �jra lefuttatni a programot, vagy kil�pni abb�l.

## A folyamatok m�dos�t�sa
A **/res** mapp�ban �ll lehet�s�g m�dos�tani a folyamatok list�j�t a **processes.txt** f�jlban. A folyamatok sorsz�mait k�l�n sorokba kell be�rni, mint ahogyan a p�ld�ban is l�that�.

## Fejleszt�si lehet�s�gek
- [X] Lehet�s�get adni a felhaszn�l�nak hogy �sszevethesse az algoritmusokat egy v�letlenszer�en gener�lt / el�re megadott folyamatlist�val.
- [X] Megk�rdezni a felhaszn�l�t a program fut�s�nak a v�g�n, hogy szeretn�-e �jra lefuttatni.
- [X] Megval�s�tani, hogy t�bb sz�mjegy� folyamatsz�mokkal is m�k�dj�n a ki�r�s.