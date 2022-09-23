using System;
using System.Collections.Generic;
using BookStoreApi.Entities;

namespace BookStoreApi.Repositories
{
    public interface IAuthorBookRepository
    {
        IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorIds);
        Author GetAuthor(Guid authorId);
        void AddAuthor(Author author);
        void DeleteAuthor(Author author);
        void UpdateAuthor(Author author);
        bool AuthorExists(Guid authorId);
        IEnumerable<Book> GetBooksForAuthor(Guid authorId);
        Book GetBookForAuthor(Guid authorId, Guid bookId);
        void AddBookForAuthor(Guid authorId, Book book);
        void UpdateBookForAuthor(Book book);
        void DeleteBook(Book book);
        bool Save();
    }
}
