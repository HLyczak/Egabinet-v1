# EGabinet

## Projekt EGabinet przygotowany na potrzebę obsługi przychodni medycznej. 

### Założenia:
* dodawania użytkowników wg. przypisanej roli:
pacjent, pielęgniarka, lekarz.
* dodawanie / usuwanie wizyt w przychodni,
* zmiana danych użytkownika,
* wyświetlanie listy wizyt i użytkowników,
* oddzielne widoki dla poszczególnych ról.

### Technologie:
* ASP.NET CORE MVC
* ASP.NET CORE IDENTITY
* ENTITY FRAMEWORK
* MSSQL
* XUNIT
* MOQ
* SWAGGER
* AZURE 
* BOOSTRAP

### Uruchomienie:
```
git clone https://github.com/HLyczak/Egabinet.git
cd Egabinet/Egabinet 
dotnet run
wejdź na: https://localhost:7253/
```
Przykładowi użytkownicy:
* pielęgniarka: user5@op.pl hasło: Admin123!
* pacjnet: user1@op.pl hasło: Admin123!
* doktor: user10@op.pl hasło: Admin123!

