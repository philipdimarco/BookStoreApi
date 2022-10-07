import React, { useState, useEffect, useCallback } from 'react';
import './App.css';

import axios from 'axios';
import AddBook from './components/Books/AddBook';
import BooksFilter from './components/Books/BooksFilter';
import BooksList from './components/Books/BooksList';
import Register from './components/Register/Register';

const INITIAL_BOOKS = [];
const apiUrl = "https://localhost:7069/api";
const accessToken = 'eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3RyaW5nIiwiZXhwIjoxNjY1MTA4Njg1fQ.5Him8r0U5kRU3UNGUNu9fOwYbLp9JBGWNpcbodDFcI0gaQCGLwANyl49P2ZeuhUkoKaXOJqc1-X50AvcNxY_XA';
/*
axios.interceptors.request.use(
  config => {
    config.headers.authorization = `Bearer ${accessToken}`;
    return config;
  },
  error => {
    return Promise.reject(error);
  }
);
*/

const authAxios = axios.create({
  baseURL: apiUrl,
  headers: {
    Authorization: `Bearer ${accessToken}`
  }
});

const App = () => {


  const [books, setBooks] = useState(INITIAL_BOOKS);
  const [requestError, setRequestError] = useState();

  const [filterBooksByPrice, setFilterBooksByPrice] = useState('200.00');
/*
  useEffect( () => {
    fetchBooksHandler();
  }, []);
*/
  const fetchBooksHandler = async () => {

    try {
      /*
      const result = await axios.get(`${apiUrl}/Books/GetBooks`);
      */
      const result = await authAxios.get(`/Books/GetBooks`);
      const data = result.data;
      const xformdbooks = data.map( svcbook => 
      {
        return {
          id: svcbook.id,
          title: svcbook.title,
          description: svcbook.description,
          author: svcbook.authorid,
          price: svcbook.price
        };
      });

      console.log("xformdbooks", xformdbooks);
      setBooks(xformdbooks);
      handleBookFilterChanged(filterBooksByPrice);

    } catch (err) {
      console.log(err.message);
      setRequestError(err.message);
    }
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

     {requestError}
     {/* <Login /> */}
     <Register></Register>

      <AddBook onAddBook={addBookHandler} />
      <button className='btn-getbooks' onClick={fetchBooksHandler}>Fetch Books</button>
      <BooksFilter priceSelected={filterBooksByPrice} onBooksFilterChanged={handleBookFilterChanged}/>
      <BooksList books={filteredBooks} />
    </>
  );
}

export default App;
