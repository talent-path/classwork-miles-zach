package com.tp.library.persistence;

import com.tp.library.exceptions.BookNotFoundException;
import com.tp.library.model.Book;
import java.util.List;

public interface LibraryDao {

    List<Book> getAllBooks();
    List<Book> getBooksByTitle(String title);
    List<Book> getBooksByAuthor(String author);
    List<Book> getBooksByPublicationYear(Integer year);
    Book getBookById(Integer id) throws BookNotFoundException;
    void deleteBook(Integer id) throws BookNotFoundException;
    void updateBook(Integer id, Book book) throws BookNotFoundException;
    Book saveBook(Book book);

}
