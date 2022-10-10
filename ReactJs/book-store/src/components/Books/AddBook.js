import './AddBook.css';
import BookForm from './BookForm';

const AddBook = (props) =>  {

    const addBookHandler = (newBook) => {
        console.log('App.js newBook=', newBook);
        // PhD:
        // setBooks( (previousBooks) => {
        //   return [newBook, ...previousBooks];
        // });
      };
    
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