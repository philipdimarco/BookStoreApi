import React from 'react';
import './BooksFilter.css';


const BooksFilter = (props) => {

    const onFilterChanged = (event) => {
        props.onBooksFilterChanged(event.target.value);
    };
    
    return (
    <div className="books-filter">
        <div className="books-filter__control">
            <label>Filter by Price</label>
            <select value={props.priceSelected}  onChange={onFilterChanged} >
                <option value='20.00'>$20.00</option>
                <option value='40.00'>$40.00</option>
                <option value='60.00'>$60.00</option>
                <option value='80.00'>$80.00</option>
                <option value='100.00'>$100.00</option>
                <option value='200.00'>$200.00</option>
            </select>
        </div>
    </div>
    );
};

export default BooksFilter;