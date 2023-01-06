"# Deloitte" 
 
1.      Adatbázis
Adott 2 hasonló tábla - nem minden oszlop van felsorolva

User_A
Login (PRIMARY KEY CLUSTERED) [nvarchar](32) NOT NULL
Name [nvarchar](128) NOT NULL
Lastlogin [datetime2](7) NULL

User_B
Login_ID (PRIMARY KEY CLUSTERED) [nvarchar](64) NOT NULL
Full_name [nvarchar](96) NOT NULL
LoginDate [datetime] NULL

Tételezzük fel, hogy a két tábla azonos COLLATION-t használ.

Feladat 1: Szükségünk van minden userre egyszer a listánkban mely mindkét táblában előfordul, Login-ra,  a névre, és a valódi utolsó login dátumra
Feladat 2: Szükségünk van minden userre mely valamelyik táblából hiányzik, Login-ra,  a névre, és a valódi utolsó login dátumra

2.      Programozás
Készítsen egy konzolos c# alkalmazást, mely a következőket tudja:
Feladat 1:  Fel kell tölteni egy 7 elemszámú listát a következő szabályok szerint:
    1.      Kell egy döntési pont, hogy a következő elem szám, vagy szöveg lesz
    2.      Ha számot ad meg, abban az esetben 10 és 9999 közötti egész számot fogadjon el
    3.      Ha szöveget ad meg, abban az esetben a bekért szöveg hossza 5 és 45 között legyen
    4.      Extra: Amennyiben rossz inputot adott meg, figyelmeztesse a felhasználót, majd ismételje meg a bekérést.
            
Feladat 2:  A 7 elem bekérésének befejezése után a következő outputot kell megjeleníteni:
    1.      A bekért számok esetén a páros számokat ossza el 2-vel a páratlanokat szorozza kettővel. Extra: jelölje a prímszámokat
    2.      A bekért szövegekek esetén fűzzön hozzá annyi karakter a következő szövegből amilyen hosszú a karakterlánc – „Making an impact that matters –Deloitte”

Minta.
Szám (3)
13 – 26 !prímszám
55 - 110
66 - 33

Szöveg (2)
Deloitte - Making a
SQL - Mak
