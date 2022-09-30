import React, { useState } from 'react';
import './App.css';
import AddBook from './components/AddBook';
import BooksFilter from './components/BooksFilter';
import BooksList from './components/BooksList';

const INITIAL_BOOKS = [];
/*
const INITIAL_BOOKS = [
  {
    id: 'b1',
    title: 'book 1',
    description: 'book 1 desc',
    author: 'author 1',
    price: 19.99
  },
  {
    id: 'b2',
    title: 'book 2',
    description: 'book 2 desc',
    author: 'author 2',
    price: 39.99
  },
  {
    id: 'b3',
    title: 'book 3',
    description: 'book 3 desc',
    author: 'author 3',
    price: 59.98
  },
  {
    id: 'b4',
    title: 'book 4',
    description: 'book 4 desc',
    author: 'author 4',
    price: 79.88 
  }
];
*/


const App = () => {

  const [books, setBooks] = useState(INITIAL_BOOKS);
  const [filterBooksByPrice, setFilterBooksByPrice] = useState('200.00');

  const fetchBooksHandler = () => {
    fetch('https://localhost:7069/api/Books/GetBooks')
      .then(response => response.json())
      .then(data => { 
        const xformdBooks = data.map( svcBook => {
          return {
            id: svcBook.id,
            title: svcBook.title,
            description: svcBook.description,
            author: svcBook.authorId,
            price: svcBook.price
          }
        });
        console.log("xformdBooks", xformdBooks);
        setBooks(xformdBooks);
        handleBookFilterChanged(filterBooksByPrice);
      })
      .catch(err => console.log("ERROR=", err));
  }
  
  
  const filteredBooks = books.filter(book => {
    //console.log(`book.price=${book.price} - filterBooksByPrice=${filterBooksByPrice}`)
    return book.price <= filterBooksByPrice;
  });

  const handleBookFilterChanged = priceSelected => {
    console.log('handleBookFilterChanged', priceSelected);
    setFilterBooksByPrice(priceSelected);
  };

  const addBookHandler = (newBook) => {
    console.log('App.js newBook=', newBook);
    setBooks( (previousBooks) => {
      return [newBook, ...previousBooks];
    });
  };
  
  return (
    <>
      <AddBook onAddBook={addBookHandler} />
      <button className='btn-getbooks' onClick={fetchBooksHandler}>Fetch Books</button>
      <BooksFilter priceSelected={filterBooksByPrice} onBooksFilterChanged={handleBookFilterChanged}/>
      <BooksList books={filteredBooks} />
    </>
  );
}

export default App;
