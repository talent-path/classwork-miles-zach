package com.tp.library.persistence;

import com.tp.library.model.Book;
import java.util.List;

public interface LibraryDao {

    List<Book> getAllBooks();
    List<Book> getBooksByTitle(String title);
    List<Book> getBooksByAuthor(String author);
    List<Book> getBooksByPublicationYear(Integer year);
    Book getBookById(Integer id);
    void deleteBook(Integer id);
    void updateBook(Integer id, Book book);
    Book saveBook(Book book);

}
