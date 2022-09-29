import { useState } from 'react';
import './BookForm.css';

const BookForm = (props) =>  {
    const [titleInput, setTitleInput] = useState('');
    const [descriptionInput, setDescriptionInput] = useState('');
    const [authorInput, setAuthorInput] = useState('');
    const [priceInput, setPriceInput] = useState('0.01');

    const onTitleChanged = (event) => {
        setTitleInput( (previousState) => {
            // console.log('onTitleChanged previousState=', previousState);
            // console.log('onTitleChanged currentState=', event.target.value);
            return event.target.value;
        });
    };
    const onDescriptionChanged = (event) => {
        setDescriptionInput( (previousState) => {
            // console.log('onDescriptionChanged previousState=', previousState);
            // console.log('onDescriptionChanged currentState=', event.target.value);
            return event.target.value;
        });
    };
    const onAuthorChanged = (event) => {
        setAuthorInput( (previousState) => {
            // console.log('onAuthorChanged previousState=', previousState);
            // console.log('onAuthorChanged currentState=', event.target.value);
            return event.target.value;
        });
    };
    const onPriceChanged = (event) => {
        setPriceInput( (previousState) => {
            // console.log('onPriceChanged previousState=', previousState);
            // console.log('onPriceChanged currentState=', event.target.value);
            return event.target.value;
        });
    };

    const onFormSubmitted = (event) => {
        event.preventDefault();

        const newBook = {
            title: titleInput,
            description: descriptionInput,
            author: authorInput,
            price: priceInput
        };
        // console.log(newBook);
        props.onSaveNewBook(newBook);
        
        setTitleInput('');
        setDescriptionInput('');
        setAuthorInput('');
        setPriceInput('0.01');
    };

    return <form onSubmit={onFormSubmitted}>
        <div className="new-book__controls" >
            <div className="new-book__control">
                <label>Title</label>
                <input type="text" value={titleInput} onChange={onTitleChanged} />
            </div>
            <div className="new-book__control">
                <label>Description</label>
                <input type="text" value={descriptionInput} onChange={onDescriptionChanged} />
            </div>
            <div className="new-book__control">
                <label>Author</label>
                <input type="text" value={authorInput} onChange={onAuthorChanged} />
            </div>
            <div className="new-book__control">
                <label>Price</label>
                <input type="number" min="0.01"  value={priceInput} step="0.01" onChange={onPriceChanged} />
            </div>
        </div>
        <div className="new-book__actions">
            <button type="submit">Add Book</button>
        </div>
    </form>
}

export default BookForm;