import React from 'react';
import './BooksList.css';
import BooksDashboard from './BooksDashboard';

const BooksList = (props) => {

    if (props.books && props.books.length > 0)
    {
        return (
            props.books.map(book =>    <BooksDashboard
                                            key={book.id}
                                            title={book.title}
                                            description={book.description}
                                            author={book.author}
                                            price={book.price}
                                        />)
        )
    } else {
        return (
            <h2 className="books-list__ballback">No Books Found.</h2>
        )
    }

};

export default BooksList;