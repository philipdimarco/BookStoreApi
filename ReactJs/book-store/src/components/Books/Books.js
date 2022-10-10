import React, { useState, useEffect }  from 'react'

import axios from 'axios';
import  BooksFilter  from './BooksFilter';
import  BooksList  from './BooksList';

const apiUrl = "https://localhost:7069/api";
let accessToken = '';

const Books = (props) => {
    const [books, setBooks] = useState([]);
    const [filterBooksByPrice, setFilterBooksByPrice] = useState('200.00');
    const [requestError, setRequestError] = useState('');

    useEffect( () => {
        fetchBooksHandler();
        }, []);
   
      const filteredBooks = books.filter(book => {
        return book.price <= filterBooksByPrice;
      });
    
      const fetchBooksHandler = async () => {
        accessToken = JSON.parse(localStorage.getItem('jwt'));
        
        console.log("accessToken", accessToken);
        try {
          const authAxios = axios.create({
            baseURL: apiUrl,
            headers: {
              Authorization: `Bearer ${accessToken}`
            }
          });
    
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
    


    const handleBookFilterChanged = priceSelected => {
        console.log('handleBookFilterChanged', priceSelected);
        setFilterBooksByPrice(priceSelected);
      };

  return (
    <>
        <BooksFilter priceSelected={filterBooksByPrice} onBooksFilterChanged={handleBookFilterChanged}/>
        <BooksList books={books} />
    </>
  )
}



export default Books;