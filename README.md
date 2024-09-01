# 📚 Progetto di Gestione Libri

## Descrizione del Progetto

Questo progetto è un'applicazione web per la gestione di libri. Gli utenti possono visualizzare, aggiungere, modificare ed eliminare libri. L'applicazione è costruita utilizzando **ASP.NET Core MVC** e include un'API per interagire con i dati in modo asincrono tramite **JavaScript** e **Axios**.

## Utilizzato

- **.NET Core 8.0** 
- **Visual Studio 2022**
- **Node.js** e **npm** 

## Struttura del Progetto

- **Model**: Rappresenta la struttura dei dati del libro.
- **Controller**: Gestisce le richieste HTTP per visualizzazione, creazione, modifica ed eliminazione dei libri.
- **Views**: Fornisce l'interfaccia utente per interagire con i dati dei libri.
- **API Controller**: Permette la gestione asincrona dei libri tramite chiamate API.
- **JavaScript**: Gestisce le interazioni asincrone con l'API.

## Funzionalità

- **Visualizzazione dei Libri**: Mostra una lista di libri con opzioni per visualizzare i dettagli, modificare e eliminare.
- **Creazione di Nuovi Libri**: Permette agli utenti di aggiungere nuovi libri al sistema.
- **Dettagli del Libro**: Visualizza i dettagli completi di un libro specifico.
- **Modifica del Libro**: Permette di aggiornare le informazioni di un libro esistente.
- **Eliminazione del Libro**: Rimuove un libro dal sistema.
- **Interazione Asincrona con l'API**: Utilizza JavaScript e Axios per interagire con l'API senza ricaricare la pagina.


## Endpoints API

- **GET** `/api/BookApi/GetBooks`  
  Ottiene la lista di tutti i libri.

- **GET** `/api/BookApi/GetBookById/{id}`  
  Ottiene i dettagli di un libro specifico.

- **POST** `/api/BookApi/Create`  
  Crea un nuovo libro.

- **DELETE** `/api/BookApi/DeleteBook/{id}`  
  Elimina un libro specifico.

## Note Aggiuntive

- **Validazione del Modulo**: Le viste di creazione e modifica includono la validazione lato client e server per garantire che i dati inseriti siano validi.
- **Gestione degli Errori**: Il progetto include una gestione degli errori per gestire situazioni come il tentativo di eliminare un libro non esistente.

