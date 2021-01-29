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

    public List<Book> getAllBooks() {
        return libraryDao.getAllBooks();
    }

    public Book getBookById(Integer id) throws NoSuchElementException {
        if(libraryDao.getAllBooks().stream().noneMatch(b -> b.getBookId().equals(id))) {
            throw new NoSuchElementException("Id provided was invalid");
        }

        return libraryDao.getBookById(id);

    }

    public List<Book> getBooksByTitle(String title) throws EmptyFieldException {
        if(title.equals("")) {
            throw new EmptyFieldException("Title must not be empty");
        }

        return libraryDao.getBooksByTitle(title);
    }

    public List<Book> getBooksByAuthor(String author) throws EmptyFieldException {
        if(author.equals("")) {
            throw new EmptyFieldException("Author must not be empty");
        }

        return libraryDao.getBooksByAuthor(author);
    }

    public List<Book> getBooksByPublicationYear(Integer publicationYear) throws InvalidPublicationYearException {
        if(publicationYear < 1501 || publicationYear > 2021) {
            throw new InvalidPublicationYearException("Publication year cannot be before 1501 or after 2021");
        }

        return libraryDao.getBooksByPublicationYear(publicationYear);
    }

    public void updateBook(Integer id, Book book) throws NoSuchElementException, NullFieldException, EmptyFieldException,
            MissingAuthorException, InvalidPublicationYearException {

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

    public void deleteBook(Integer id) throws NoSuchElementException {
        libraryDao.deleteBook(id);
    }
}
