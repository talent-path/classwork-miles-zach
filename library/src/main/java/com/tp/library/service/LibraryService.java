package com.tp.library.service;

import com.tp.library.exceptions.*;
import com.tp.library.model.Book;
import com.tp.library.persistence.LibraryDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.NoSuchElementException;

@Service
public class LibraryService {

    @Autowired
    LibraryDao libraryDao;

    public Book saveBook(Book book) throws NullFieldException, EmptyFieldException,
            InvalidPublicationYearException, MissingAuthorException{

        if(book.getTitle() == null || book.getAuthors() == null || book.getPublicationYear() == null) {
            throw new NullFieldException("Fields cannot be null");
        }

        if(book.getTitle().equals("") || book.getAuthors().size() == 0) {
            throw new EmptyFieldException("Fields cannot be empty");
        }

        for(String author : book.getAuthors()) {
            if (author == null || author.equals("")) {
                throw new MissingAuthorException("Author's name cannot be missing or blank");
            }
        }

        if(book.getPublicationYear() < 1501 || book.getPublicationYear() > 2021) {
            throw new InvalidPublicationYearException("Publication year cannot be before 1501 or after 2021");
        }

        return libraryDao.saveBook(book);
    }

    public List<Book> getAllBooks() throws EmptyCollectionException {
        List<Book> books = libraryDao.getAllBooks();
        if(books.size() == 0) {
            throw new EmptyCollectionException("There are no books in the library!");
        }
        return books;
    }

    public Book getBookById(Integer id) throws InvalidBookIdException, BookNotFoundException {
        if(id <= 0 || id > 1E9) {
            throw new InvalidBookIdException("The book id you provided was invalid");
        }
        return libraryDao.getBookById(id);

    }

    public List<Book> getBooksByTitle(String title) throws EmptyFieldException, EmptyCollectionException {
        if(title.equals("")) {
            throw new EmptyFieldException("Title must not be empty");
        }

        List<Book> books = libraryDao.getBooksByTitle(title);
        if(books.size() == 0) {
            throw new EmptyFieldException("There were no books founds with the provided title");
        }

        return books;
    }

    public List<Book> getBooksByAuthor(String author) throws EmptyFieldException, EmptyCollectionException {
        if(author.equals("")) {
            throw new EmptyFieldException("Author must not be empty");
        }

        return libraryDao.getBooksByAuthor(author);
    }

    public List<Book> getBooksByPublicationYear(Integer publicationYear) throws InvalidPublicationYearException, EmptyCollectionException {
        if(publicationYear < 1501 || publicationYear > 2021) {
            throw new InvalidPublicationYearException("Publication year cannot be before 1501 or after 2021");
        }

        return libraryDao.getBooksByPublicationYear(publicationYear);
    }

    public void updateBook(Integer id, Book book) throws NullFieldException, EmptyFieldException,
            MissingAuthorException, InvalidPublicationYearException, BookNotFoundException {

        if(book.getTitle() == null || book.getAuthors() == null || book.getPublicationYear() == null) {
            throw new NullFieldException("Fields cannot be null");
        }

        if(book.getTitle().equals("") || book.getAuthors().size() == 0) {
            throw new EmptyFieldException("Fields cannot be empty");
        }

        for(String author : book.getAuthors()) {
            if (author == null || author.equals("")) {
                throw new MissingAuthorException("Author's name cannot be missing or blank");
            }
        }

        if(book.getPublicationYear() < 1501 || book.getPublicationYear() > 2021) {
            throw new InvalidPublicationYearException("Publication year cannot be before 1501 or after 2021");
        }

        libraryDao.updateBook(id, book);
    }

    public void deleteBook(Integer id) throws BookNotFoundException {
        libraryDao.deleteBook(id);
    }
}
