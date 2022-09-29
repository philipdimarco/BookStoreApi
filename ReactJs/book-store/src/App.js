import React, { useState } from 'react';
import './App.css';
import BooksDashboard from './components/BooksDashboard';
import AddBook from './components/AddBook';

const INITIAL_BOOKS = [
  {
    id: 'b1',
    title: 'book 1',
    description: 'book 1 desc',
    author: 'author 1',
    price: 111.11
  },
  {
    id: 'b2',
    title: 'book 2',
    description: 'book 2 desc',
    author: 'author 2',
    price: 222.22
  },
  {
    id: 'b3',
    title: 'book 3',
    description: 'book 3 desc',
    author: 'author 3',
    price: 333.33
  },
  {
    id: 'b4',
    title: 'book 4',
    description: 'book 4 desc',
    author: 'author 4',
    price: 444.44 
  }
];



const App = () => {

  const [books, setBooks] = useState(INITIAL_BOOKS);

  const addBookHandler = (newBook) => {
    console.log('App.js newBook=', newBook);
    setBooks( (previousBooks) => {
      return [newBook, ...previousBooks];
    });
  };

  return (
    <>
      <AddBook onAddBook={addBookHandler} />
      {
        books.map(book => 
        <BooksDashboard
        key={book.id}
        title={book.title}
        description={book.description}
        author={book.author}
        price={book.price}
        />)
      }
    </>
  );
}

export default App;
