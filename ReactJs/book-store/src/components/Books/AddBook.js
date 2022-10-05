import './AddBook.css';
import BookForm from './BookForm';

const AddBook = (props) =>  {
    
    const onHandleSaveNewBook = (newBookTarget) => {
        const newBook = {
            ...newBookTarget,
            id: "b" + Math.random().toString()
        };
        //console.log('newBook', newBook);
        props.onAddBook(newBook);
    };

    return <div className="add-book">
        <BookForm onSaveNewBook={onHandleSaveNewBook} />
        </div>
}

export default AddBook;